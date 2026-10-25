using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmInternalMessageDefaultContextLanguageViewModel
{
	[Key]
	public int InternalMessageDefaultContextId { get; set; }

	public int ContextUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "InternalMessageDefineDefaultContextColOne")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col1 { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "InternalMessageDefineDefaultContextColTwo")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col2 { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "InternalMessageDefineDefaultContextColThree")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col3 { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "InternalMessageDefineDefaultContextColFour")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col4 { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "InternalMessageDefineDefaultContextColFive")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col5 { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "InternalMessageDefineDefaultContextColOne")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col6 { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "InternalMessageDefineDefaultContextColTwo")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col7 { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "InternalMessageDefineDefaultContextColThree")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col8 { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "InternalMessageDefineDefaultContextColFour")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col9 { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "InternalMessageDefineDefaultContextColFive")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col10 { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "InternalMessageDefineDefaultContextColOne")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col11 { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "InternalMessageDefineDefaultContextColTwo")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col12 { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "InternalMessageDefineDefaultContextColThree")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col13 { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "InternalMessageDefineDefaultContextColFour")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col14 { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "InternalMessageDefineDefaultContextColFive")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Col15 { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public string Col1_Lang { get; set; }

	public string Col2_Lang { get; set; }

	public string Col3_Lang { get; set; }

	public string Col4_Lang { get; set; }

	public string Col5_Lang { get; set; }

	public string Col6_Lang { get; set; }

	public string Col7_Lang { get; set; }

	public string Col8_Lang { get; set; }

	public string Col9_Lang { get; set; }

	public string Col10_Lang { get; set; }

	public string Col11_Lang { get; set; }

	public string Col12_Lang { get; set; }

	public string Col13_Lang { get; set; }

	public string Col14_Lang { get; set; }

	public string Col15_Lang { get; set; }
}
