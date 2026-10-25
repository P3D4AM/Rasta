using System;

namespace CRM.Models;

public class CRMspLkSepSelectSaleType_Result
{
	public int SaleTypeId { get; set; }

	public int Number { get; set; }

	public string Title { get; set; }

	public int SaleTypeMarket { get; set; }

	public int? PartSalesSLRef { get; set; }

	public int? ServiceSalesSLRef { get; set; }

	public int? PartSalesReturnSLRef { get; set; }

	public int? ServiceSalesReturnSLRef { get; set; }

	public int? PartSalesDiscountSLRef { get; set; }

	public int? ServiceSalesDiscountSLRef { get; set; }

	public int? SalesAdditionSLRef { get; set; }

	public int Version { get; set; }

	public int Creator { get; set; }

	public DateTime CreationDate { get; set; }

	public int LastModifier { get; set; }

	public DateTime LastModificationDate { get; set; }

	public int? OrderOprId { get; set; }
}
