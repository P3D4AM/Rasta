using System;

namespace CRM.Models;

public class LkProductPriceInfoViewModel
{
	public int PrdId { get; set; }

	public string PrdLinkAccPrdCode { get; set; }

	public string PrdLinkAccPrdIdStr { get; set; }

	public decimal Price { get; set; }

	public string ProductPriceGroupName { get; set; }

	public string LinkAccPrdPriceGroupIdStr { get; set; }

	public decimal Dicount { get; set; }

	public decimal DicountPercent { get; set; }

	public string DocDate { get; set; }

	public DateTime? DocDateTime { get; set; }
}
