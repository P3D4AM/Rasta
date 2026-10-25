using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class ShygunProductInfoViewModelObjects
{
	public List<ShygunProductInfoViewModel> lst { get; set; }

	public List<ShygunProductInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }
}
