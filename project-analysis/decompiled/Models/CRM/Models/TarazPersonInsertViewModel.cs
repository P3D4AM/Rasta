namespace CRM.Models;

public class TarazPersonInsertViewModel
{
	public long? PerComID { get; set; }

	public TarazAccPerComInsertViewModel accPerCom { get; set; }

	public TarazAccPerComOtherInsertViewModel accPerComOther { get; set; }
}
