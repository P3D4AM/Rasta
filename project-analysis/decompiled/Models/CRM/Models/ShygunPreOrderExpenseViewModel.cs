using System;

namespace CRM.Models;

public class ShygunPreOrderExpenseViewModel
{
	public int InvExpRowId { get; set; }

	public int? InvExpRowOrder { get; set; }

	public int? InvHeaderId { get; set; }

	public Guid? AccountGuId { get; set; }

	public Guid? JobCostingGuId { get; set; }

	public string AccountNumber { get; set; }

	public string AccountName { get; set; }

	public string JobCostingNumber { get; set; }

	public string InvExpRowDesc { get; set; }

	public decimal? InvExpRowAmount { get; set; }

	public string SecondAccountNumber { get; set; }

	public string SecondAccountName { get; set; }

	public Guid? SecondJobCostingGuId { get; set; }

	public Guid? SecondAccountGuId { get; set; }

	public string SecondJobCostingNumber { get; set; }

	public int? FixCostType { get; set; }

	public Guid? InvGuId { get; set; }

	public int RowNumber { get; set; }

	public int PreOrderId { get; set; }
}
