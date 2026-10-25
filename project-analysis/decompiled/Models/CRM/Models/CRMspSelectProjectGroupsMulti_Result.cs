using System;

namespace CRM.Models;

public class CRMspSelectProjectGroupsMulti_Result
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

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }
}
