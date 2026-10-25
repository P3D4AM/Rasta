using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class ShygunIICompanyInfoViewModelObjects
{
	public List<ShygunIICompanyInfoViewModel> lst { get; set; }

	public List<ShygunIICompanyInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }
}
