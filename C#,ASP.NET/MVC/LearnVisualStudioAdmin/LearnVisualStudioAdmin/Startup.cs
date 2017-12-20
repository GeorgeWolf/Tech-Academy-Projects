using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearnVisualStudioAdmin.Startup))]
namespace LearnVisualStudioAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
