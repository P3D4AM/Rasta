using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSProductsMetadata
{
	[Key]
	public int ProductID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdGroupID")]
	public int PrdGroupID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdCode")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdLatinName")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdLatinName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdType")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdDesign")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdDesign { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSize")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdSize { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdColorId")]
	public int? PrdColorId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdUnitId")]
	public int? PrdUnitId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdMinQty")]
	public int? PrdMinQty { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdMaxQty")]
	public int? PrdMaxQty { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdSleepDay")]
	public int? PrdSleepDay { get; set; }

	public string PrdFirstSerial { get; set; }

	public string PrdSecondSerial { get; set; }

	public string PrdThirdSerial { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdBarCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdFirstBarcode { get; set; }

	public string PrdSecondBarcode { get; set; }

	public string PrdThirdBarcode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdDescription")]
	[MaxLength(12000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(12000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdDescription { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdBarCode")]
	public string PrdBarCode { get; set; }

	public int? PrdBarCodeTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdAutoNumBarcode")]
	public string PrdAutoNumBarcode { get; set; }

	public int? PrdAutoNumBarCodeTypeId { get; set; }

	public string PrdAutoCharBarcode { get; set; }

	public int? prdAutoCharBarCodeTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdModel")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string PrdModel { get; set; }

	public Guid? GUId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdInactiveInSale")]
	public bool? PrdInactiveInSale { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrdInactiveInBuy")]
	public bool? PrdInactiveInBuy { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
