using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSDocLanguageViewModel
{
	[Key]
	public int DocID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocOprId")]
	public int OprId { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "DocNumberIE")]
	public int DocNumber { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "DocDateIE")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public string DocDate { get; set; }

	public int? SenderId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocSenderName")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SenderName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocFactorNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FactorNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocDescription")]
	[MaxLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(4000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Description { get; set; }

	public short? IsFix { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocWHId")]
	public int WHId { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string OrderIds { get; set; }

	public int? BuyOrderId { get; set; }

	public bool? CanEditOrd { get; set; }

	public Guid? GUId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocSendAddress")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string SendAddress { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocDriverName")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DriverName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocDriverTel")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DriverTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocFreightName")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string FreightName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocBijakNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string BijakNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocCarNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string CarNumber { get; set; }

	public DateTime? DocDateTime { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? WHIdI { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "DocCompanyId")]
	public int? CompanyId { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "DocCompanyPersonId")]
	public int? CompanyPersonId { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[Display(ResourceType = typeof(Labels), Name = "DocProjectId")]
	public int? ProjectId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocCmpTitle")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpTitle { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocNumRef")]
	[MaxLength(150, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(150, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string DocNumRef { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocOrderId")]
	public string DocOrderId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocVerifierRequestId")]
	public int? VerifierRequestId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "DocVerificationWorkFlowId")]
	public int? VerificationWorkFlowId { get; set; }

	public string SenderName_Lang { get; set; }

	public string Description_Lang { get; set; }

	public string SendAddress_Lang { get; set; }

	public string DriverName_Lang { get; set; }

	public string FreightName_Lang { get; set; }

	public string cmpTitle_Lang { get; set; }
}
