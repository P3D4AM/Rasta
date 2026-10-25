namespace Mobile.Models;

public class MobspSelectOrderPaymentTypesInLangsById_Result
{
	public int OrderPaymentTypeId { get; set; }

	public string ordpayType { get; set; }

	public string ordpayTypeDescription { get; set; }

	public int? LanguageID { get; set; }

	public int? ordpayTypeMode { get; set; }
}
