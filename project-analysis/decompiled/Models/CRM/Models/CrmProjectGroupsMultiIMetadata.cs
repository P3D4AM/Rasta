using System;

namespace CRM.Models;

public class CrmProjectGroupsMultiIMetadata
{
	public int ProjectGroupsMultiIId { get; set; }

	public string ProjectGroupsMultiIName { get; set; }

	public string ProjectGroupsMultiIDesc { get; set; }

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
