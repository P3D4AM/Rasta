using System;

namespace CRM.Models;

public class CRMspSelectCompanyOrderItemsByValidityCounting_Result
{
	public int? OrderID { get; set; }

	public int? OrderOprID { get; set; }

	public long? ordNumber { get; set; }

	public DateTime? ordDate { get; set; }

	public string ordDatePersian { get; set; }

	public int? OrderOpr { get; set; }

	public int OrderItemID { get; set; }

	public int ordIPrdId { get; set; }

	public string PrdName { get; set; }

	public double? PrdScore { get; set; }

	public int? PrdKind { get; set; }

	public string PrdCode { get; set; }

	public double? ordIQuantity { get; set; }

	public double ordIPrdValidityCountingNumTotal { get; set; }

	public double ordIPrdValidityCountingMinTotal { get; set; }

	public double ordIPrjPrdHRemainCount { get; set; }

	public double ordIPrjPrdHRemainDurationMin { get; set; }

	public int? ordProjectId { get; set; }

	public string ordProject { get; set; }

	public string OrderOprName { get; set; }

	public string ordIDescriptionI_Lang { get; set; }

	public string ordIDescriptionI { get; set; }

	public string ordIDescription_Lang { get; set; }

	public string ordIDescription { get; set; }
}
