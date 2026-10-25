using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class KyanOrderInfoViewModelObjects
{
	public List<KyanOrderInfoViewModel> lst { get; set; }

	public List<KyanOrderInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }
}
