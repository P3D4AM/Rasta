using Owin;

namespace Mobile;

public class Startup
{
	public void Configuration(IAppBuilder app)
	{
		app.MapSignalR();
	}
}
