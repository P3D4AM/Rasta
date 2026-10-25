namespace Mobile.Models;

public class UpdatePersonViewModel
{
	public string Person { get; set; }

	public int CompanyId { get; set; }

	public int PersonId { get; set; }

	public int CmpReferUserId { get; set; }

	public bool? DeletePrsPicture { get; set; }

	public int? LanguageId { get; set; }

	public int? CenterId { get; set; }

	public int? OldCmpReferUserId { get; set; }

	public int? CmpSuppUserId { get; set; }

	public string CIds { get; set; }

	public string OldPrsfoInfo { get; set; }
}
