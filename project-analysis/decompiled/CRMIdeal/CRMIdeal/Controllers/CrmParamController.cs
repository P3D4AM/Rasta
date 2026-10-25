using System.Web.Mvc;
using CRM.Models;
using CRMIdeal.Classes;
using Newtonsoft.Json;

namespace CRMIdeal.Controllers;

[LoginAuthorize]
public class CrmParamController : Controller
{
	private int _UserId;

	public int UserId
	{
		get
		{
			if (_UserId == 0)
			{
				_UserId = UserLogin.CurrentUser.UserId;
			}
			return _UserId;
		}
	}

	[HttpPost]
	public string Check(CrmParamViewModel data)
	{
		return JsonConvert.SerializeObject(new MainParamController().Check(data));
	}
}
