using System.Collections.Generic;
using Kendo.Mvc.UI;

namespace CRM.Models;

public class CurrentCompanyProjectsInSummaryViewModel
{
	public List<TreeViewItemModel> Project { get; set; }

	public int ActiveCount { get; set; }

	public int ArchiveCount { get; set; }

	public List<CRMspSelectCompanyProjects_Result> ProjectsInSummary { get; set; }

	public int ProjectTicketTotal { get; set; }

	public int ProjectTicketActive { get; set; }

	public int ProjectTicketArchive { get; set; }
}
