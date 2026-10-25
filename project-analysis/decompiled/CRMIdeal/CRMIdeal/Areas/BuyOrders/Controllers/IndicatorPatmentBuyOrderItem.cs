using System.Collections.Generic;
using CRM.Models;

namespace CRMIdeal.Areas.BuyOrders.Controllers;

public class IndicatorPatmentBuyOrderItem
{
	public List<WSspSelectBuyOrderPaymentIndicator_Result> Items { get; set; }

	public WSspSelectBuyOrderPaymentIndicatorSum_Result ItemFooter { get; set; }
}
