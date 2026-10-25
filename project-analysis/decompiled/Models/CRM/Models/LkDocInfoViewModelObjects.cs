using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class LkDocInfoViewModelObjects
{
	public List<LkWSDocInfoViewModel> lst { get; set; }

	public List<LkWSDocInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }

	public List<LkWSDocItemsInfoViewModel> lstItems { get; set; }
}
