using System;

namespace Mobile.Models;

public class TarazGoodsUnitViewModel
{
	public long? unitID { get; set; }

	public string unitCode { get; set; }

	public string unitDesc { get; set; }

	public DateTime? createDate { get; set; }

	public long? creatorID { get; set; }

	public DateTime? modifyDate { get; set; }

	public long? modifierID { get; set; }

	public long? serverID { get; set; }

	public bool? quantitative { get; set; }
}
