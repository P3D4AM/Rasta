using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class PayRollUserCycle_LangMetadata
{
	[Key]
	public int PayRollUserCycleLangID { get; set; }

	public int PayRollUserCycleId { get; set; }

	public int LanguageID { get; set; }

	public string CycleTitle { get; set; }
}
