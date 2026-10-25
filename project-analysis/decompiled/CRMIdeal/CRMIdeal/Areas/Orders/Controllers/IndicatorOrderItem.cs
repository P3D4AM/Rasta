using System.Collections.Generic;
using CRM.Models;

namespace CRMIdeal.Areas.Orders.Controllers;

public class IndicatorOrderItem
{
	public List<mct_WSspSelectOrderIndicator_Result> Items { get; set; }

	public mct_WSspSelectOrderIndicatorSum_Result ItemFooter { get; set; }
}
