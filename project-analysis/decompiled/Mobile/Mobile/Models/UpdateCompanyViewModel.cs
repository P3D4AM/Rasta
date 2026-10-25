namespace Mobile.Models;

public class UpdateCompanyViewModel
{
	public string Company { get; set; }

	public int CompanyId { get; set; }

	public int CmpReferUserId { get; set; }

	public bool? DeleteCmpLogo { get; set; }

	public int? LanguageId { get; set; }

	public int? CenterId { get; set; }

	public int? OldCmpReferUserId { get; set; }

	public int? CmpSuppUserId { get; set; }

	public string CIds { get; set; }

	public string OldCmpfoInfo { get; set; }
}
