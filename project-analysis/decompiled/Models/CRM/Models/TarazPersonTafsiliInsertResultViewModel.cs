namespace CRM.Models;

public class TarazPersonTafsiliInsertResultViewModel
{
	public long? tafsiliID { get; set; }

	public string tafsiliCode { get; set; }

	public string tafsiliDesc { get; set; }

	public string tafsiliDesc1 { get; set; }

	public string tafsiliDesc2 { get; set; }

	public TarazPersonTafsiliTypeInsertResultViewModel tafsiliType { get; set; }

	public string lastTafsiliCode { get; set; }

	public bool? notActive { get; set; }
}
