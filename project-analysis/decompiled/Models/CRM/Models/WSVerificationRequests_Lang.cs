using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSVerificationRequests_LangMetadata))]
public class WSVerificationRequests_Lang
{
	public int WSVerificationRequestLangID { get; set; }

	public int VerificationRequestId { get; set; }

	public int LanguageID { get; set; }

	public string VerificationReqText { get; set; }

	public string VerificationReqExpiredText { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSVerificationRequests WSVerificationRequests { get; set; }
}
