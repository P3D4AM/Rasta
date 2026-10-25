using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CRM.Models;

public class GenerateAutoCmpUPViewModel
{
	public string Companies { get; set; }

	public int Mode { get; set; }

	public int Type { get; set; }

	public bool SetNewUsername { get; set; }

	public bool SetNewPassword { get; set; }

	public int? EmailUserInfo { get; set; }

	public string Subject { get; set; }

	[UIHint("RichText")]
	[AllowHtml]
	public string EmailBody { get; set; }

	public string SMSBody { get; set; }
}
