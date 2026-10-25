using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSOrderPaymentGroupsII_LangMetadata))]
public class WSOrderPaymentGroupsII_Lang
{
	public int WSOrderPaymentGroupsIILangID { get; set; }

	public int OrderPaymentGroupIIId { get; set; }

	public int LanguageID { get; set; }

	public string ordpayGroupIIName { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSOrderPaymentGroupsII WSOrderPaymentGroupsII { get; set; }
}
