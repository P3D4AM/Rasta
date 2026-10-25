namespace CRM.Models;

public class CRMspSelectCompanyLogoByCmpIds_Result
{
	public int CompanyLoGoID { get; set; }

	public int? CompanyId { get; set; }

	public byte[] CompanyLogo { get; set; }

	public string LogoDesc { get; set; }

	public string CompanyLogoStr { get; set; }
}
