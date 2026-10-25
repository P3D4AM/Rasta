using System;

namespace CRM.Models;

public class WSPreOrderOprMetadata
{
	public int PreOrderOprID { get; set; }

	public string PreOrderOpr { get; set; }

	public string Description { get; set; }

	public int? OrderView { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }
}
