using System.Collections.Generic;
using System.Web.Mvc;
using CRM.Models;

namespace CRMIdeal.Areas.ImportExcel.Controllers;

public class UserPrincipalViewModel : ImportExcelUserViewModel
{
	public List<SelectListItem> Groups { get; set; }
}
