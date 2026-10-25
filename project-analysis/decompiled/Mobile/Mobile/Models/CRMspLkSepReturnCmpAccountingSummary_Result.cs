namespace Mobile.Models;

public class CRMspLkSepReturnCmpAccountingSummary_Result
{
	public int? PartyID { get; set; }

	public int? PartyDLRef { get; set; }

	public string Code { get; set; }

	public string DLTitle { get; set; }

	public string CustomerGroupingTitle { get; set; }

	public string VendorGroupingTitle { get; set; }

	public decimal? CustomerRemain { get; set; }

	public decimal? VendorRemain { get; set; }

	public decimal? BrokerRemain { get; set; }

	public decimal? OtherRemain { get; set; }

	public decimal? Remain { get; set; }

	public string Phone { get; set; }

	public string Address { get; set; }

	public string ZipCode { get; set; }

	public string EconomicCode { get; set; }

	public string IdentificationCode { get; set; }
}
