using System.Collections.Generic;

namespace CRM.Models;

public class HamrahanWarehouseInfoViewModel
{
	public long? recNo { get; set; }

	public string nameCellar { get; set; }

	public string codeCellar { get; set; }

	public List<HamrahanLinkInfoViewModel> links { get; set; }
}
