using System;

namespace CRM.Models;

public class WSProductSecondGroupMetadata
{
	public int PrdSecondGroupID { get; set; }

	public int FirstGroupId { get; set; }

	public string SGCode { get; set; }

	public string SGName { get; set; }

	public string SGDescription { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string SGNameEn { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }
}
