using System;

namespace CRM.Models;

public class CrmCompanyUserForbiddenMetadata
{
	public int ID { get; set; }

	public int CrmUserId { get; set; }

	public int ForbiddenCompanyId { get; set; }

	public bool? CanSee { get; set; }

	public bool? CanEdit { get; set; }

	public bool? CanDel { get; set; }

	public string Reason { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
