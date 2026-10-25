using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSOrderPaymentGroupsI_LangMetadata))]
public class WSOrderPaymentGroupsI_Lang
{
	public int WSOrderPaymentGroupsILangID { get; set; }

	public int OrderPaymentGroupIId { get; set; }

	public int LanguageID { get; set; }

	public string ordpayGroupIName { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSOrderPaymentGroupsI WSOrderPaymentGroupsI { get; set; }
}
