using System.Collections.Generic;

namespace CRM.Models;

public class CmpExcelFieldsList
{
	public List<CmpImportFromExcelFieldsViewModel> ImportFromExcelFieldsList { get; set; }

	public List<CmpImportUserSelectedFieldsViewModel> UserSelectedFieldsList { get; set; }
}
