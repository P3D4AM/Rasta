using System.Collections.Generic;

namespace CRM.Models;

public class CommonSelectDyFormListItemViewModel
{
	public string Key { get; set; }

	public string OrderView { get; set; }

	public List<CommonMultiLanguageViewModel> Key_allData { get; set; }

	public List<CommonMultiLanguageViewModel> Val_allData { get; set; }

	public string LkDbObjVal { get; set; }
}
