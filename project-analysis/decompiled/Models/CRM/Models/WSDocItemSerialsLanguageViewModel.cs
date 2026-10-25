using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSDocItemSerialsLanguageViewModel
{
	[Key]
	public int DocItemSerialID { get; set; }

	public int ItemId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocItemSerialsSerial")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Serial { get; set; }

	public int? StatusId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocItemSerialsDescription")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Description { get; set; }

	public short? IsFix { get; set; }

	public int? WHId { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocItemSerialsSId")]
	public int? SerialId { get; set; }

	public WSspSelectDocItemSerialsWithId_Result SerialDetails { get; set; }

	public bool? IsAutoBarcode { get; set; }

	public int? tblTmpBarcodeId { get; set; }

	public Guid? GUId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocItemSerialsExpDate")]
	public DateTime? ExpDate { get; set; }

	public string ExpDatePersian { get; set; }

	public string AppType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocItemSerialsInfoI")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string InfoI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocItemSerialsInfoII")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string InfoII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocItemSerialsInfoIII")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string InfoIII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocItemSerialsInfoIV")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string InfoIV { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocItemSerialsInfoV")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string InfoV { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "SerialSearchListPlacement")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string InfoVI { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? RootId { get; set; }

	public string Tracing { get; set; }

	public string Description_Lang { get; set; }

	public string InfoI_Lang { get; set; }

	public string InfoII_Lang { get; set; }

	public string InfoIII_Lang { get; set; }

	public string InfoIV_Lang { get; set; }

	public string InfoV_Lang { get; set; }

	public string InfoVI_Lang { get; set; }

	public string AppTypeHelp { get; set; }

	public int DocId { get; set; }
}
