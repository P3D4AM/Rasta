namespace Mobile.Models;

public class InsertQuickCmpPrsPrjCnvsViewModel
{
	public string Company { get; set; }

	public string Persons { get; set; }

	public string Projects { get; set; }

	public string Conversations { get; set; }

	public string CompanyAddresses { get; set; }

	public string Type { get; set; }

	public int? LanguageId { get; set; }

	public bool? IsCloseTicket { get; set; }

	public bool? IsQuickFullCompany { get; set; }

	public int? CenterId { get; set; }

	public string cmpCIds { get; set; }

	public int? cmpReferUserId { get; set; }

	public int? cmpSuppUserId { get; set; }

	public int? SysPartDyFormId { get; set; }

	public string SysPartDyFormVal { get; set; }
}
