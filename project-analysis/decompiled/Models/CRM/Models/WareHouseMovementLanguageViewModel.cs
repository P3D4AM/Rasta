using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WareHouseMovementLanguageViewModel
{
	[Key]
	public int DocID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseMovementOprId")]
	public int OprId { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "WareHouseMovementNumberIE")]
	public int DocNumber { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "WareHouseMovementDateIE")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string DocDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseMovementWHIdI")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? WHIdI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseMovementWHId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int WHId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseMovementDescription")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Description { get; set; }

	public int? SenderId { get; set; }

	public string SenderName { get; set; }

	public string FactorNumber { get; set; }

	public short? IsFix { get; set; }

	public string OrderIds { get; set; }

	public int? BuyOrderId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseMovementSendAddress")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SendAddress { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseMovementDriverName")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DriverName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseMovementDriverTel")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DriverTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseMovementFreightName")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FreightName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseMovementBijakNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string BijakNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseMovementCarNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CarNumber { get; set; }

	public int? CompanyId { get; set; }

	public int? CompanyPersonId { get; set; }

	public int? ProjectId { get; set; }

	public string cmpTitle { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public DateTime? DocDateTime { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseMovementNumRef")]
	[MaxLength(150, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(150, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DocNumRef { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseMovementVerifierRequestId")]
	public int? VerifierRequestId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "WareHouseMovementVerificationWorkFlowId")]
	public int? VerificationWorkFlowId { get; set; }

	public string SenderName_Lang { get; set; }

	public string Description_Lang { get; set; }

	public string SendAddress_Lang { get; set; }

	public string DriverName_Lang { get; set; }

	public string FreightName_Lang { get; set; }

	public string cmpTitle_Lang { get; set; }
}
