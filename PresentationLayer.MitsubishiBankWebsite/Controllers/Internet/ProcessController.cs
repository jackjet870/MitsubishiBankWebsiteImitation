using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Core.MitsubishiBank.CustomerCommon;
using Infrastructure.Data.MitsubishiBank.BankContexts;
using MigraDoc.DocumentObjectModel;
using PresentationLayer.MitsubishiBankWebsite.StaticHelpers;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using MigraDoc.DocumentObjectModel.IO;
using MigraDoc.Rendering;

namespace PresentationLayer.MitsubishiBankWebsite.Controllers.Internet
{
    public class ProcessController : Controller
    {
        // GET: Process
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TransactionBetweenCustomers(string Password, double Amount, string Email)
        {
            
            BankContext db = new BankContext();
            if (db.Customers.FirstOrDefault(p => p.Profile.Password == Password).CustomerId == Globals.CurrentCustomerGuid)
            {
                if (db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).Account.Cash >= Amount)
                {
                    if (db.Customers.FirstOrDefault(p => p.Profile.Email == Email)!=null)
                    {
                        db.Customers.FirstOrDefault(p => p.Profile.Email == Email).Account.Cash += Amount;
                        db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).Account.Cash -=
                            Amount;
                        db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).AccountHistory.Add(new CustomerHistory
                        {
                            RecieverGuid = db.Customers.FirstOrDefault(p => p.Profile.Email == Email).CustomerId.ToString(),
                            RecieverMail = db.Customers.FirstOrDefault(p => p.Profile.Email == Email).Profile.Email,
                            SenderGuid = db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).CustomerId.ToString(),
                            SenderMail = db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).Profile.Email,
                            Status = "Transaction",
                            Summ = Amount,
                            Time = DateTime.Now.ToShortDateString(),
                            

                        });
                        db.SaveChanges();
                    }
                }
                
            }
            return RedirectToAction("MyProfile", "Site");
        }

        public ActionResult MakePayment(string Password, double Amount, string ServiceName)
        {

            BankContext db = new BankContext();
            if (db.Customers.FirstOrDefault(p => p.Profile.Password == Password).CustomerId == Globals.CurrentCustomerGuid)
            {
                if (db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).Account.Cash >= Amount)
                {
                    {
                        db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).Account.Cash -=
                            Amount;
                        db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).AccountHistory.Add(new CustomerHistory
                        {
                            RecieverGuid = db.Banks.First().BankId.ToString(),
                            RecieverMail = db.Banks.First().Profile.Name,
                            SenderGuid = db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).CustomerId.ToString(),
                            SenderMail = db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).Profile.Email,
                            Status = ServiceName,
                            Summ = Amount,
                            Time = DateTime.Now.ToShortDateString(),


                        });
                        db.SaveChanges();
                    }
                }

            }
            return RedirectToAction("MyProfile", "Site");
        }

        public FileContentResult PrintHistory()
        {
            int x = 80;
            BankContext db = new BankContext();

            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = "My First PDF";
            string pdfFilename = "Action Report "+ db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).Profile.FirstName+" "+ db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).Profile.LastName;
            string filepath = HttpContext.Server.MapPath("~/Content/")+ pdfFilename;
            
            PdfPage pdfPage = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            XFont font = new XFont("Verdana", 10, XFontStyle.Bold);
            graph.DrawString("Mitsubishi Bank Co. Ltd. Corporation", font, XBrushes.Black, new XRect(0,0, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            graph.DrawString("Action History Report for"+DateTime.Now.Month , font, XBrushes.Black, new XRect(0, 20, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            graph.DrawString(
                String.Format("Client Information : Credentials : {0}", db.Customers.FirstOrDefault(p=>p.CustomerId==Globals.CurrentCustomerGuid).Profile.FirstName+" "
                + db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).Profile.LastName), font, XBrushes.Black, new XRect(0,40, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            graph.DrawString(
                String.Format("Client Information : UUID : {0}", db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).CustomerId.ToString()), font, XBrushes.Black, new XRect(0, 60, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            XFont fontSmall = new XFont("Verdana", 5, XFontStyle.Bold);
            foreach (var e in db.Customers.FirstOrDefault(p => p.CustomerId == Globals.CurrentCustomerGuid).AccountHistory)
            {
                graph.DrawString(
                String.Format("History Item: SENDER: {0} TIME : {1} STATUS : {2} RECIEVER: {3} SUMM : {4}", e.SenderMail, e.Time, e.Status, e.RecieverMail,e.Summ), fontSmall, XBrushes.Black, new XRect(0, x, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                x += 20;
            }
            pdf.Save(filepath);
            Process.Start(filepath);

            byte[] filedata = System.IO.File.ReadAllBytes(filepath);
            string contentType = MimeMapping.GetMimeMapping(filepath);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = pdfFilename,
                Inline = true,
            };

            Response.AppendHeader("Content-Disposition", cd.ToString());

            return File(filedata, contentType);
        }
    }
}