using System.Collections.Generic;

namespace CRM.Models;

public class CurrentEmailSendedViewModel
{
	public EmailspSelectSendedDetailById_Result EmailInfo { get; set; }

	public List<EmailspSelectSendedAttachment_Result> Attachments { get; set; }
}
