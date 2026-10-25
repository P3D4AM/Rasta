using System.Collections.Generic;
using CRM.Models;

namespace CRMIdeal.Areas.Orders.Controllers;

public class IndicatorPatmentOrderItem
{
	public List<mct_WSspSelectOrderPaymentIndicator_Result> Items { get; set; }

	public mct_WSspSelectOrderPaymentIndicatorSum_Result ItemFooter { get; set; }
}
