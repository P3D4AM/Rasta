namespace Mobile.Models;

public class PrsAuthenticationByMobileNumberModel
{
	public MobspCheckDuplicatePrsMobileByCmpId_Result Person { get; set; }

	public string MobileNumber { get; set; }

	public int CompanyId { get; set; }

	public int? LangId { get; set; }
}
