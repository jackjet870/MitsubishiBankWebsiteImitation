using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Core.MitsubishiBank.ATMCommon;
using Domain.Core.MitsubishiBank.BankCommon;
using Domain.Interfaces.MitsubishiBank.BankInterfaces;
using PresentationLayer.MitsubishiBankWebsite.Controllers.Base;

namespace PresentationLayer.MitsubishiBankWebsite.Controllers.Intranet.AdminAccess
{
    public class BankController : BaseController
    {
        private IBankRepository _repository;

        public BankController(/*IBankRepository repository*/)
        {
            //_repository = repository;
        }

    }
}