using System.Collections.Generic;

namespace Mobile.Models;

public class ProjectViewModel
{
	public int ProjectID { get; set; }

	public int prjCompanyId { get; set; }

	public string prjFullTitle { get; set; }

	public int? ProgressPercent { get; set; }

	public string IsArchive { get; set; }

	public Dictionary<string, object> otherFields { get; set; }

	public Dictionary<string, object> otherFieldsHeader { get; set; }
}
