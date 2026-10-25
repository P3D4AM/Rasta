using System;

namespace Mobile.Models;

public class TarazGoodsGroupTafsiliViewModel
{
	public long? tafsiliID { get; set; }

	public string tafsiliCode { get; set; }

	public string tafsiliDesc { get; set; }

	public string tafsiliDesc1 { get; set; }

	public string tafsiliDesc2 { get; set; }

	public TarazGoodsGroupTafsiliTypeViewModel tafsiliType { get; set; }

	public DateTime? createDate { get; set; }

	public long? creatorID { get; set; }

	public DateTime? modifyDate { get; set; }

	public long? modifierID { get; set; }

	public long? serverID { get; set; }

	public string lastTafsiliCode { get; set; }

	public long? referID { get; set; }

	public bool? notActive { get; set; }
}
