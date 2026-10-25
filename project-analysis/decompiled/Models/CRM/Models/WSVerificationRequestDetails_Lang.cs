using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSVerificationRequestDetails_LangMetadata))]
public class WSVerificationRequestDetails_Lang
{
	public int WSVerificationRequestDetailLangID { get; set; }

	public int VerificationRequestDetailId { get; set; }

	public int LanguageID { get; set; }

	public string VerifyText { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSVerificationRequestDetails WSVerificationRequestDetails { get; set; }
}
