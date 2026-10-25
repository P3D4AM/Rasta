using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CrmUserReportFilterMetadata))]
public class CrmUserReportFilter
{
	public int UserReportFilterID { get; set; }

	public int? rptFilterGroupId { get; set; }

	public string rptTitle { get; set; }

	public string rptFilterTermsTxt { get; set; }

	public bool? rptIsPublic { get; set; }

	public string rptIsPublicForUsersId { get; set; }

	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string rptResultColumnsJson { get; set; }

	public virtual ICollection<CrmUserReportFilter_Lang> CrmUserReportFilter_Lang { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public CrmUserReportFilter()
	{
		CrmUserReportFilter_Lang = (ICollection<CrmUserReportFilter_Lang>)new HashSet<CrmUserReportFilter_Lang>();
	}
}
