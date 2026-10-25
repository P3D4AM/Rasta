using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CRMspRptCompanyFilterDataViewModel
{
	[Key]
	public int? CompanyID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpNumber")]
	public int? cmpNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpName")]
	public string cmpName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpActivityType")]
	public string cmpActivityType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptprjTitle")]
	public string prjTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptConversationStatus")]
	public string ConversationStatus { get; set; }

	public int? ProjectId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "rptprsName")]
	public string prsName { get; set; }
}
