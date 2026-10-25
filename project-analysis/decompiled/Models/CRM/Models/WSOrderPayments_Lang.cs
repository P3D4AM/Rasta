using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSOrderPayments_LangMetadata))]
public class WSOrderPayments_Lang
{
	public int WSOrderPaymentsLangID { get; set; }

	public int OrderPaymentId { get; set; }

	public string ordpayDescription { get; set; }

	public int LanguageID { get; set; }

	public string ordpayBankDocDesc { get; set; }

	public string ordpayBankDocDescI { get; set; }

	public string ordpayBankName { get; set; }

	public string ordpayBranchName { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSOrderPayments WSOrderPayments { get; set; }
}
