using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSVerificationRequests_LangMetadata
{
	[Key]
	public int WSVerificationRequestLangID { get; set; }

	public int VerificationRequestId { get; set; }

	public int LanguageID { get; set; }

	public string VerificationReqText { get; set; }
}
