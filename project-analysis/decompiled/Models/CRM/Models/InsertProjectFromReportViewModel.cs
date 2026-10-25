using System;

namespace CRM.Models;

public class InsertProjectFromReportViewModel
{
	public string PrjTitle { get; set; }

	public string PrjTitle_Lang { get; set; }

	public int PrjcnvsStatusGroupId { get; set; }

	public bool? AddCnvs { get; set; }

	public int? CnvsReferUserId { get; set; }

	public int? CnvsTopicId { get; set; }

	public int? CnvsStatusId { get; set; }

	public string CnvsRemindDate { get; set; }

	public DateTime? CnvsRemindDateTime { get; set; }

	public string CnvsDesc { get; set; }

	public string CnvsDesc_Lang { get; set; }
}
