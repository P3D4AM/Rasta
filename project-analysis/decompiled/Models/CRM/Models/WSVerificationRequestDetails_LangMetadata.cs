using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class WSVerificationRequestDetails_LangMetadata
{
	[Key]
	public int WSVerificationRequestDetailLangID { get; set; }

	public int VerificationRequestDetailId { get; set; }

	public int LanguageID { get; set; }

	public string VerifyText { get; set; }
}
