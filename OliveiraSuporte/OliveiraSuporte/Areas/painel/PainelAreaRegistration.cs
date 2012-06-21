using System.Web.Mvc;

namespace OliveiraSuporte.Areas.painel
{
    public class PainelAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "painel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "painel_default",
                "painel/{controller}/{action}/{id}",
                new {controller ="Index", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
