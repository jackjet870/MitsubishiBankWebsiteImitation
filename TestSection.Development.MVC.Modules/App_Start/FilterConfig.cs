using System.Web;
using System.Web.Mvc;

namespace TestSection.Development.MVC.Modules
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
