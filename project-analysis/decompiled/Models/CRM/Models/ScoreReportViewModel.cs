using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class ScoreReportViewModel
{
	[Display(ResourceType = typeof(Labels), Name = "ScoreReportFDate")]
	public string ScoreReportFDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ScoreReportTDate")]
	public string ScoreReportTDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ScoreReportRuleId")]
	public string ScoreReportRuleId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "ScoreReportCompanyId")]
	public string ScoreReportCompanyId { get; set; }

	public string ScoreReportCompanyName { get; set; }
}
