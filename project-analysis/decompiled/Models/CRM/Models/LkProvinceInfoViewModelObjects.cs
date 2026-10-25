using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class LkProvinceInfoViewModelObjects
{
	public List<LkProvinceInfoViewModel> lst { get; set; }

	public List<LkProvinceInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }
}
