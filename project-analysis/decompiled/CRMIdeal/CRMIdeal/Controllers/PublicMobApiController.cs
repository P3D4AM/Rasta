using System.Web.Http;
using CRMIdeal.Areas.Cartables.Controllers;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Helper;

namespace CRMIdeal.Controllers;

public class PublicMobApiController : ApiController
{
	[MobileApiAuthorize]
	public string GetLinkAccSystemTitle(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		return Setting.GetLinkAccSystemTitle(result);
	}

	public string VoIPCTC(string caller, string callee)
	{
		return new VoiceRecordController().ClickToCall(caller, callee);
	}
}
