using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class PayvastProductInfoViewModelObjects
{
	public List<PayvastProductInfoViewModel> lst { get; set; }

	public List<PayvastProductInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }
}
