using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.General.Web;

public class SEOParamsViewModel
{
	public SelectListItem AddBefore_SelectListItem { get; set; }

	public List<SelectListItem> AddBefore_SelectListItems { get; set; }
}
