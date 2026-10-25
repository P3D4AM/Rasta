using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class LkCountryInfoViewModelObjects
{
	public List<LkCountryInfoViewModel> lst { get; set; }

	public List<LkCountryInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }
}
