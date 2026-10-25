using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class LkListCityInfoViewModel
{
	public bool IsDone { get; set; }

	public string Message { get; set; }

	public List<LkCityInfoViewModel> Lst { get; set; }

	public List<SelectListItem> LstSelectListItem { get; set; }
}
