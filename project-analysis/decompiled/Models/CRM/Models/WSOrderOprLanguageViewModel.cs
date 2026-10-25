using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class WSOrderOprLanguageViewModel
{
	[Key]
	public int OrderOprID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderOprName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string Name { get; set; }

	public Guid? GUId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderOprType")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int? OprType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderOprOrderView")]
	public int? OrderView { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderOprDocOprId")]
	public int? DocOprId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderOprDailyCounter")]
	public long? DailyCounter { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderOprTspInty")]
	public int? TspInty { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderOprTspInp")]
	public int? TspInp { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderOprTspIns")]
	public int? TspIns { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderOprVerifyAfterIssue")]
	public bool? VerifyAfterIssue { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderOprTspInty")]
	public int? TspIntyI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderOprTspInp")]
	public int? TspInpI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderOprTspIns")]
	public int? TspInsI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderOprTaxable")]
	public bool? Taxable { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderOprIssueOrdWithoutPordDisc")]
	public bool? IssueOrdWithoutPordDisc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderOprTspSendOrdWithoutDisc")]
	public bool? TspSendOrdWithoutDisc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderOprUserAccessAll")]
	public bool? OrderOprUserAccessAll { get; set; }

	public string Name_Lang { get; set; }
}
