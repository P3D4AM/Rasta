namespace CRM.Models;

public class TarazAccPerComOtherInsertViewModel
{
	public string percomTel { get; set; }

	public string percomMobile { get; set; }

	public string nationalCode { get; set; }

	public string customerCode { get; set; }

	public string salesManCode { get; set; }

	public string marketingManCode { get; set; }

	public string providerCode { get; set; }

	public long? customerClassID { get; set; }

	public long? marketingManClassID { get; set; }

	public long? customerGeoID { get; set; }

	public long? salesManGeoID { get; set; }

	public long? marketingManGeoID { get; set; }

	public long? providerGeoID { get; set; }

	public bool? iSProviderManNotActive { get; set; }

	public bool? iSStockerNotActive { get; set; }

	public string birthDateStocker { get; set; }

	public string numberMemberStocker { get; set; }

	public string identityCodeStocker { get; set; }

	public long? webUserType { get; set; }

	public bool? isSaleCustomer { get; set; }

	public bool? isSaleMan { get; set; }

	public bool? isMarketingMan { get; set; }

	public bool? providerMan { get; set; }

	public bool? isPerson { get; set; }

	public bool? isStocker { get; set; }

	public long? salesManClassID { get; set; }

	public bool? isForeignProvider { get; set; }

	public bool? isCustomerNotActive { get; set; }

	public bool? isSalesManNotActive { get; set; }

	public bool? isMarketingManNotActive { get; set; }

	public bool? isAllowDuplicate { get; set; }

	public string preCityCode { get; set; }

	public string postalCode { get; set; }

	public string economicCode { get; set; }

	public string zoneCode { get; set; }
}
