namespace Mobile.Models;

public class MobspSelectOrderOpr_Result
{
	public int Id { get; set; }

	public string Title { get; set; }

	public int OprType { get; set; }

	public long? OrderView { get; set; }

	public int DocOprId { get; set; }

	public string DocOpr { get; set; }

	public bool? IssueOrdWithoutPordDisc { get; set; }
}
