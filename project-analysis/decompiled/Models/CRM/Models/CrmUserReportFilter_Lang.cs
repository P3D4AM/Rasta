using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmUserReportFilter_LangMetadata))]
public class CrmUserReportFilter_Lang
{
	public int CrmUserReportFilterLangID { get; set; }

	public int LanguageID { get; set; }

	public int UserReportFilterId { get; set; }

	public string rptTitle { get; set; }

	public virtual CrmUserReportFilter CrmUserReportFilter { get; set; }
}
