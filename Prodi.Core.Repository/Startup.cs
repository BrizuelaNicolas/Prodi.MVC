using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Prodi.Core.Repository.StartupOwin))]

namespace Prodi.Core.Repository
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
