using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace CRMIdeal.Hubs;

[HubName("progressHub")]
public class ProgressHub : Hub
{
	public string msg = "Initializing and Preparing...";

	public int count = 1;

	[HubMethodName("sendMessage")]
	public static void SendMessage(string msg, int count, int userId, bool actStatus = true)
	{
		if (!string.IsNullOrEmpty(msg))
		{
			IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ProgressHub>();
			hubContext.Clients.All.sendMessage(string.Format(msg), count, userId, actStatus);
		}
	}

	[HubMethodName("getCountAndMessage")]
	public void GetCountAndMessage()
	{
		base.Clients.Caller.sendMessage(string.Format(msg), count);
	}
}
