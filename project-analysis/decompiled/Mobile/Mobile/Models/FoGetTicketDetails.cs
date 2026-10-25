namespace Mobile.Models;

public class FoGetTicketDetails
{
	public int ProjectId { get; set; }

	public int PageNumber { get; set; }

	public int PageSize { get; set; }

	public int PrjValidityPrdId { get; set; }

	public int PrjValidityOrdItemId { get; set; }

	public int? LanguageId { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? CenterId { get; set; }

	public int? FoSettingId { get; set; }
}
