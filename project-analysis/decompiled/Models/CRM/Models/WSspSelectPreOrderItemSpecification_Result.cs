using System;

namespace CRM.Models;

public class WSspSelectPreOrderItemSpecification_Result
{
	public int PreOrderItemSpcflID { get; set; }

	public int PreOrderItemId { get; set; }

	public string Specification { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string SpecificationI { get; set; }

	public string SpecificationII { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
