namespace CRM.Models;

public class CRMspSelectCompanyWithAccLinkField_Result
{
	public int CompanyID { get; set; }

	public string cmpLinkAccCode { get; set; }

	public int? cmpLinkAccCodeId { get; set; }

	public int? cmpLinkAccCustomerId { get; set; }

	public string cmpLinkAccCustomerIdStr { get; set; }

	public string CompanyName { get; set; }
}
