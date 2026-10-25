namespace CRM.Models;

public class TarazPersonTafsiliTypeInsertResultViewModel
{
	public long? tafsiliTypeID { get; set; }

	public string tafsiliTypeDesc { get; set; }

	public string startNumber { get; set; }

	public string finishNumber { get; set; }

	public TarazPersonTafsiliIdentityInsertResultViewModel tafsiliIdentity { get; set; }

	public TarazPersonTafsiliKindInsertResultViewModel tafsiliKind { get; set; }

	public string showInLevels { get; set; }

	public bool? autoCode { get; set; }

	public bool? autoDelete { get; set; }
}
