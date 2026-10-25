namespace CRM.Models;

public class WSspSelectProductValidityByGroupId_Result
{
	public int ProductID { get; set; }

	public int PrdGroupID { get; set; }

	public string PrdGroup { get; set; }

	public string PrdCode { get; set; }

	public string PrdName { get; set; }

	public bool? PrdValidityCounting { get; set; }

	public int? PrdValidityCountingNum { get; set; }

	public int? PrdValidityCountingMin { get; set; }

	public double? PrdScore { get; set; }

	public int? PrdKind { get; set; }

	public bool? PrdValidityCountingNumIsActive { get; set; }

	public bool? PrdValidityCountingNumNeedOrder { get; set; }

	public bool? PrdValidityCountingNumNoCheckRemain { get; set; }

	public int? PrdValidityCountingNumDefaultVal { get; set; }

	public bool? PrdValidityCountingMinIsActive { get; set; }

	public int? PrdValidityCountingMinDefaultVal { get; set; }

	public bool? PrdValidityCountingMinNeedOrder { get; set; }

	public bool? PrdValidityCountingMinNoCheckRemain { get; set; }
}
