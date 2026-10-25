using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class CommonSelectListItemAndExtraFieldViewModel
{
	public List<SelectListItem> List { get; set; }

	public string ExtraValuse { get; set; }

	public string ExtraValuseI { get; set; }
}
