using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSOrderPaymentsMetadata
{
	[Key]
	public int OrderPaymentId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordPayImportDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string ImportDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordPayTypeId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int ordpayTypeId { get; set; }

	public int ordpayOrderId { get; set; }

	public int? ordpayDocId { get; set; }

	public int? ordpayDocTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordPayAmount")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public decimal ordpayAmount { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordPayDocNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordpayDocNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordPayDocDate")]
	public string ordpayDocDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordPayDescription")]
	[MaxLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(2000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ordpayDescription { get; set; }

	public int? ordpayFirstRegisterUserId { get; set; }

	public string ordpayFirstRegisteDatePersian { get; set; }

	public DateTime? ordpayFirstRegisteDate { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public DateTime? ordpayDocDateTime { get; set; }

	public Guid? GUId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ordPayDocAmount")]
	public decimal? ordpayDocAmount { get; set; }

	public int? PreOrderPaymentId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
