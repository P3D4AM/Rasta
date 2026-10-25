using System;

namespace CRM.Models;

public class TarazGoodsGroupViewModel
{
	public long? groupID { get; set; }

	public string groupCode { get; set; }

	public string groupDesc { get; set; }

	public string groupLatinDesc { get; set; }

	public TarazGoodsGroupTafsiliViewModel tafsili { get; set; }

	public DateTime? createDate { get; set; }

	public long? creatorID { get; set; }

	public DateTime? modifyDate { get; set; }

	public long? modifierID { get; set; }

	public long? serverID { get; set; }

	public long? pricingMethod { get; set; }

	public long? fatherID { get; set; }

	public long? groupLevel { get; set; }

	public bool? notActive { get; set; }

	public bool? onlineSale { get; set; }
}
