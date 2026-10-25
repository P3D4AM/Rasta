using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class SendCmpNotifToMobViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "SendCmpNotifToMobMsgSubject")]
	public string msgSubject { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SendCmpNotifToMobMsgBody")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string msgBody { get; set; }

	public string msgSubject_Lang { get; set; }

	public string msgBody_Lang { get; set; }
}
