using System;

namespace CRM.Models;

public class ShygunPreOrderBodyInfoViewModel
{
	public int? InvNo { get; set; }

	public int LineItemId { get; set; }

	public int? InvHeaderId { get; set; }

	public int? LineItemOrder { get; set; }

	public string ItemNumber { get; set; }

	public string STNumber { get; set; }

	public string STDesc { get; set; }

	public Guid? STGuId { get; set; }

	public Guid? ItemGuId { get; set; }

	public decimal? Quan { get; set; }

	public decimal? Quan2 { get; set; }

	public decimal? Price { get; set; }

	public decimal? Price2 { get; set; }

	public decimal? Amount { get; set; }

	public decimal? AmortizePercent { get; set; }

	public decimal? LineDiscAmount { get; set; }

	public decimal? LineDiscPer { get; set; }

	public string LineItemDesc { get; set; }

	public decimal? ReturnRial { get; set; }

	public decimal? OrderRemain1 { get; set; }

	public decimal? OrderRemain2 { get; set; }

	public decimal? FinalOrderQuan { get; set; }

	public decimal? FinalOrderQuan2 { get; set; }

	public Guid? InvGuId { get; set; }

	public int RowNumber { get; set; }

	public int PreOrderId { get; set; }
}
