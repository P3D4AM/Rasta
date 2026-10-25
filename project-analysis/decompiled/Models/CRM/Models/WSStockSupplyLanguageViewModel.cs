using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSStockSupplyLanguageViewModel
{
	[Key]
	public int StockSupplyId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "StockSupplyOprId")]
	public int StockSupplyOprId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "stsupReferUserId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int stsupReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "stsupNumber")]
	[RegularExpression("^\\d+$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	public long stsupNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "stsupDate")]
	[RegularExpression("(\\d{4})[-\\/](\\d{2})[-\\/](\\d{2})$", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorNotCorrent")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public string stsupDate { get; set; }

	public DateTime stsupDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "stsupCompanyId")]
	public int? stsupCompanyId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "stsupCompanyPersonId")]
	public int? stsupCompanyPersonId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "stsupProjectId")]
	public int? stsupProjectId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "stsupVerifierRequestId")]
	public int? stsupVerifierRequestId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "stsupVerificationWorkFlowId")]
	public int? stsupVerificationWorkFlowId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "stsupPrintFormatId")]
	public int? stsupPrintFormatId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "stsupNote")]
	[MaxLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(1000, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string stsupNote { get; set; }

	public string stsupNote_Lang { get; set; }
}
