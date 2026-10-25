using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class LkProductInfoViewModelObjects
{
	public List<LkProductInfoViewModel> lst { get; set; }

	public List<LkProductInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }
}
