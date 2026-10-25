using System;

namespace CRM.Models;

public class CrmProjectGroupsMultiMetadata
{
	public int ProjectGroupsMultiId { get; set; }

	public string ProjectGroupsMultiName { get; set; }

	public string ProjectGroupsMultiDesc { get; set; }

	public bool? IsDefualtField { get; set; }

	public int? SortCode { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
