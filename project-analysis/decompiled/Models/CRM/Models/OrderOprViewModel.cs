using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class OrderOprViewModel
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

	public string AppType { get; set; }

	public string Name_Lang { get; set; }

	public string FirstRegisterUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderOprDailyCounter")]
	public long? DailyCounter { get; set; }

	public int? TspInty { get; set; }

	public int? TspInp { get; set; }

	public int? TspIns { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderOprVerifyAfterIssue")]
	public bool? VerifyAfterIssue { get; set; }

	public int? TspIntyI { get; set; }

	public int? TspInpI { get; set; }

	public int? TspInsI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderOprTaxable")]
	public bool? Taxable { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderOprIssueOrdWithoutPordDisc")]
	public bool? IssueOrdWithoutPordDisc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "OrderOprTspSendOrdWithoutDisc")]
	public bool? TspSendOrdWithoutDisc { get; set; }

	public string EditUser { get; set; }
}
