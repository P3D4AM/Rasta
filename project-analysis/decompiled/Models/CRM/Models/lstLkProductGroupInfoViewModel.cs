using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class lstLkProductGroupInfoViewModel
{
	public bool isDone { get; set; }

	public string Message { get; set; }

	public List<LkProductGroupInfoViewModel> lst { get; set; }

	public List<SelectListItem> lstSelectListItem { get; set; }
}
