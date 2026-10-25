using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSProductFirstGroupMetadata
{
	[Key]
	public int PrdFirstGroupID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FGCode")]
	public string FGCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FGName")]
	public string FGName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FGDescription")]
	public string FGDescription { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FGNameEn")]
	public string FGNameEn { get; set; }

	public Guid? GUId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FGInactiveInSale")]
	public bool? FGInactiveInSale { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "FGInactiveInBuy")]
	public bool? FGInactiveInBuy { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public bool? PrdGroupMustExistInPreOrder { get; set; }
}
