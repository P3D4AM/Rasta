using System;

namespace CRM.Models;

public class TarazGoodsTypeViewModel
{
	public long? typeID { get; set; }

	public string typeCode { get; set; }

	public string typeDesc { get; set; }

	public long? serverID { get; set; }

	public DateTime? createDate { get; set; }

	public long? creatorID { get; set; }

	public DateTime? modifyDate { get; set; }

	public long? modifierID { get; set; }

	public string taxCode { get; set; }

	public long? goodsType { get; set; }
}
