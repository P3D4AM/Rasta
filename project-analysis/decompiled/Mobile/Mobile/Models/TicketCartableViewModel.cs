using System;

namespace Mobile.Models;

public class TicketCartableViewModel
{
	public int Mode { get; set; }

	public string PrjTitleGroup { get; set; }

	public int CrmUserId { get; set; }

	public int? PrjTitleGroupId { get; set; }

	public int? CnvsStatusGroupId { get; set; }

	public int? CnvsStatusId { get; set; }

	public int? CnvsPriorityId { get; set; }

	public DateTime? FromDateTime { get; set; }

	public DateTime? ToDateTime { get; set; }

	public int? PageSize { get; set; }

	public int? LastRowNumber { get; set; }

	public int? LanguageId { get; set; }

	public int? CenterId { get; set; }
}
