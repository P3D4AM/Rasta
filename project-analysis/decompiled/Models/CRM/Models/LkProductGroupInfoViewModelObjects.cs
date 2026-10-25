using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class LkProductGroupInfoViewModelObjects
{
	public List<LkProductGroupInfoViewModel> lst { get; set; }

	public List<LkProductGroupInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }
}
