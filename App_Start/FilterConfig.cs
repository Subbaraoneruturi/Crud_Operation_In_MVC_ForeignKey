using System.Web;
using System.Web.Mvc;

namespace Crud_Operation_In_MVC_ForeignKey
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
