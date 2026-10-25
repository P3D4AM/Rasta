using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSVerificationWorkFlows_LangMetadata))]
public class WSVerificationWorkFlows_Lang
{
	public int WSVerificationWorkFlowLangID { get; set; }

	public int VerificationWorkFlowId { get; set; }

	public int LanguageID { get; set; }

	public string VerificationWorkFlowTitle { get; set; }

	public string VerifyRequestText { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSVerificationWorkFlows WSVerificationWorkFlows { get; set; }
}
