using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class LkUserInfoViewModelObjects
{
	public List<LkUserInfoViewModel> lst { get; set; }

	public List<LkUserInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }
}
