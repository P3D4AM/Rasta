using CRMIdeal.Classes;
using Microsoft.AspNet.SignalR;

namespace CRMIdeal.Hubs;

public class MyConnectionFactory
{
	public string GenerateConnectionId(IRequest request)
	{
		return UserLogin.CurrentUser.UserId.ToString();
	}
}
