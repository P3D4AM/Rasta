using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class LkCompanyInfoViewModelObjects
{
	public List<LkCompanyAndPersonViewModel> lst { get; set; }

	public List<LkCompanyAndPersonViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }
}
