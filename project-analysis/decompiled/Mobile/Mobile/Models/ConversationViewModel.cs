using System.Collections.Generic;

namespace Mobile.Models;

public class ConversationViewModel
{
	public int CompanyID { get; set; }

	public int ProjectID { get; set; }

	public int? OprTypeId { get; set; }

	public string Opr { get; set; }

	public long OprId { get; set; }

	public int CountPage { get; set; }

	public string CoordinateLatitude { get; set; }

	public string CoordinateLongitude { get; set; }

	public Dictionary<string, object> otherFields { get; set; }

	public Dictionary<string, object> otherFieldsHeader { get; set; }

	public List<FileDirectoryViewModel> CnvsFiles { get; set; }
}
