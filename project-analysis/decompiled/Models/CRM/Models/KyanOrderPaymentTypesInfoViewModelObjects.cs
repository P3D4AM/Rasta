using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class KyanOrderPaymentTypesInfoViewModelObjects
{
	public List<KyanOrderPaymentTypesInfoViewModel> lst { get; set; }

	public List<KyanOrderPaymentTypesInfoViewModel> FilteredLst { get; set; }

	public JsonResult Json { get; set; }

	public string SerializedJson { get; set; }

	public string Message { get; set; }
}
