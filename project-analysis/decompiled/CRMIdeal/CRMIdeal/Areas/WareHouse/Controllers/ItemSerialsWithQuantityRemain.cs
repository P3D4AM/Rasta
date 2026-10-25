using System.Collections.Generic;
using CRM.Models;

namespace CRMIdeal.Areas.WareHouse.Controllers;

public class ItemSerialsWithQuantityRemain
{
	public List<WSspSelectDocItemSerials_Result> List { get; set; }

	public double QuantityRemain { get; set; }

	public double TracingRemainCount { get; set; }
}
