using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class ShygunCompanyInfoViewModelObjects
{
	public List<ShygunCompanyInfoViewModel> lst { get; set; }

	public List<ShygunCompanyInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }
}
