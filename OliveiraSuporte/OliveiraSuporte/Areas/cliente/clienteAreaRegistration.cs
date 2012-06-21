using System.Web.Mvc;

namespace OliveiraSuporte.Areas.cliente
{
    public class clienteAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "cliente";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "cliente_default",
                "cliente/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
