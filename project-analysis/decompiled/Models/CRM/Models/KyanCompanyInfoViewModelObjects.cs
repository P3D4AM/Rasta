using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class KyanCompanyInfoViewModelObjects
{
	public List<KyanCompanyInfoViewModel> lst { get; set; }

	public List<KyanCompanyInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }
}
