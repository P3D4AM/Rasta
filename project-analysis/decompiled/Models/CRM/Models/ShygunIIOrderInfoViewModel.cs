using System;
using System.Collections.Generic;

namespace CRM.Models;

public class ShygunIIOrderInfoViewModel
{
	public int OrderBodyCount { get; set; }

	public List<ShygunIIOrderBodyInfoViewModel> OrderBody { get; set; }

	public int OrderExpenseCount { get; set; }

	public List<ShygunIIOrderExpenseViewModel> OrderExpense { get; set; }

	public int InvTyp { get; set; }

	public int? InvNo { get; set; }

	public Guid? AccountGuId { get; set; }

	public Guid? JobCostingGuId { get; set; }

	public string InvDescription { get; set; }

	public string InvDate { get; set; }

	public string InvPayDue { get; set; }

	public string AccountNumber { get; set; }

	public string AccountName { get; set; }

	public string JobCostingNumber { get; set; }

	public string JobCostingName { get; set; }

	public string CurrencyAbb1 { get; set; }

	public Guid? SAccountGuId { get; set; }

	public Guid? SJobGuId { get; set; }

	public string bijak { get; set; }

	public DateTime? CreatedDate { get; set; }

	public string GeneralRef { get; set; }

	public string SAccountNumber { get; set; }

	public string SJobNumber { get; set; }

	public decimal? DiscountPercent { get; set; }

	public decimal? DiscAmount { get; set; }

	public string DepartmentNumber { get; set; }

	public string ST1Number { get; set; }

	public Guid? ST1GuId { get; set; }

	public string ST2Number { get; set; }

	public Guid? ST2GuId { get; set; }

	public string AtfNumber { get; set; }

	public Guid? AtfGuId { get; set; }

	public Guid? GuId { get; set; }

	public string CreatedDatePersian { get; set; }

	public int RowNumber { get; set; }

	public int OrderId { get; set; }
}
