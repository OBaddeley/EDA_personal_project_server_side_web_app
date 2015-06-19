using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopShopShop.Startup))]
namespace ShopShopShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
