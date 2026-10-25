using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(PayRollUserCycle_LangMetadata))]
public class PayRollUserCycle_Lang
{
	public int PayRollUserCycleLangID { get; set; }

	public int PayRollUserCycleId { get; set; }

	public int LanguageID { get; set; }

	public string CycleTitle { get; set; }

	public int? CycleMonth { get; set; }

	public int? CycleYear { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual PayRollUserCycle PayRollUserCycle { get; set; }
}
