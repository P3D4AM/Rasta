using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class LkCityInfoViewModelObjects
{
	public List<LkCityInfoViewModel> lst { get; set; }

	public List<LkCityInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }
}
