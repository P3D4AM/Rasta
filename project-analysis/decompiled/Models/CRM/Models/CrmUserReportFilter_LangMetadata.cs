using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmUserReportFilter_LangMetadata
{
	[Key]
	public int CrmUserReportFilterLangID { get; set; }

	public int LanguageID { get; set; }

	public int UserReportFilterId { get; set; }

	public string rptTitle { get; set; }
}
