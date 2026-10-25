using System.Collections.Generic;
using CRM.Models;

namespace CRMIdeal.Areas.BuyOrders.Controllers;

public class IndicatorBuyOrderItem
{
	public List<mct_WSspSelectBuyOrderIndicator_Result> Items { get; set; }

	public mct_WSspSelectBuyOrderIndicatorSum_Result ItemFooter { get; set; }
}
