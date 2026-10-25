using System.Collections.Generic;

namespace CRM.Models;

public class ShygunDetailedAPIWarehouseResponseViewModel
{
	public List<ShygunDetailedAPIWarehouseInfoViewModel> Result { get; set; }

	public string CurrentVersion { get; set; }

	public long? TotalRecordCount { get; set; }
}
