using System.Collections.Generic;

namespace CRM.Models;

public class LkWareHouseViewModel
{
	public int? FirstId { get; set; }

	public int? LastId { get; set; }

	public int? TotalCount { get; set; }

	public int? PagingFirstId { get; set; }

	public int? PagingLastId { get; set; }

	public int? PagingTotalCount { get; set; }

	public string ErrorMessage { get; set; }

	public List<LkWareHouseInfoViewModel> List { get; set; }
}
