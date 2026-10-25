using System.Collections.Generic;

namespace CRM.Models;

public class ArianSystemInsertApiResponseViewModel
{
	public string Err { get; set; }

	public long? Id { get; set; }

	public List<List<object>> rows { get; set; }

	public ArianSystemSelectApiOtherInfoViewModel OtherInfo { get; set; }

	public object DefOrders { get; set; }
}
