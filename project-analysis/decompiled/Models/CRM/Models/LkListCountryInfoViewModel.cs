using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class LkListCountryInfoViewModel
{
	public bool IsDone { get; set; }

	public string Message { get; set; }

	public List<LkCountryInfoViewModel> Lst { get; set; }

	public List<SelectListItem> LstSelectListItem { get; set; }
}
