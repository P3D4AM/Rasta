using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmNumRefSettingViewModel
{
	[Key]
	public int NumRefSettingId { get; set; }

	public string prjNumRefFormula { get; set; }

	public string pordNumRefFormula { get; set; }

	public string ordNumRefFormula { get; set; }

	public string bordNumRefFormula { get; set; }

	public string DocNumRefFormula { get; set; }

	public string ctshNumRefFormula { get; set; }

	public string FileDirectoryNumRefFormula { get; set; }

	public int Mode { get; set; }

	public bool? IsActivePrjNumRByAllPrj { get; set; }

	public bool? IsActivePrjNumRByCmpPrj { get; set; }

	public bool? IsActivePordNumberByType { get; set; }
}
