using System;

namespace Mobile.Models;

public class TarazGoodsGroupTafsiliTypeViewModel
{
	public long? tafsiliTypeID { get; set; }

	public string tafsiliTypeDesc { get; set; }

	public string startNumber { get; set; }

	public string finishNumber { get; set; }

	public long? serverID { get; set; }

	public DateTime? createDate { get; set; }

	public long? creatorID { get; set; }

	public DateTime? modifyDate { get; set; }

	public long? modifierID { get; set; }

	public TarazGoodsGroupTafsiliTypeIdentityViewModel tafsiliIdentity { get; set; }

	public TarazGoodsGroupTafsiliKindViewModel tafsiliKind { get; set; }

	public string showInLevels { get; set; }

	public bool? autoCode { get; set; }

	public bool? autoDelete { get; set; }
}
