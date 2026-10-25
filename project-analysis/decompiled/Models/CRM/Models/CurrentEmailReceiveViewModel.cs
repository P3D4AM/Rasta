using System.Collections.Generic;

namespace CRM.Models;

public class CurrentEmailReceiveViewModel
{
	public EmailspSelectEmailReceiveAndSendById_Result EmailInfo { get; set; }

	public List<EmailspSelectEmailReceiveAttachments_Result> Attachments { get; set; }
}
