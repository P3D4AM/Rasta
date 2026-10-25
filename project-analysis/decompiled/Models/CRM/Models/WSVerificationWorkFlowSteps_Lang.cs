using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSVerificationWorkFlowSteps_LangMetadata))]
public class WSVerificationWorkFlowSteps_Lang
{
	public int WSVerificationWorkFlowStepLangID { get; set; }

	public int VerificationWorkFlowStepId { get; set; }

	public int LanguageID { get; set; }

	public string VerificationWorkFlowStepTitle { get; set; }

	public string VerifyText { get; set; }

	public string AutoReferToAltTxt { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSVerificationWorkFlowSteps WSVerificationWorkFlowSteps { get; set; }
}
