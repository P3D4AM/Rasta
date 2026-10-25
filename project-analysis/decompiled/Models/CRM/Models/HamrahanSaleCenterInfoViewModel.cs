using System.Collections.Generic;

namespace CRM.Models;

public class HamrahanSaleCenterInfoViewModel
{
	public long? recNo { get; set; }

	public string codeFormal { get; set; }

	public long? stateFormal { get; set; }

	public long? groupFormal { get; set; }

	public string groupName { get; set; }

	public string nameFormal { get; set; }

	public long? recNoSaleCenter { get; set; }

	public string nameRouter { get; set; }

	public List<HamrahanLinkInfoViewModel> links { get; set; }
}
