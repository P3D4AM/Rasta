using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSOrderItemSerialsLanguageViewModel
{
	[Key]
	public int OrderItemSerialID { get; set; }

	public int OrderItemId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdItemSlSerialId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int SerialId { get; set; }

	public WSspSelectDocItemSerialsWithId_Result SerialDetails { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrdItemSlDescription")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Description { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public int? WHId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string Tracing { get; set; }

	public string Description_Lang { get; set; }
}
