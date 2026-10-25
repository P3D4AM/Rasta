using System.Collections.Generic;

namespace Mobile.Models;

public class NeedUpdateDetailBaseInfoViewModel
{
	public int UserId { get; set; }

	public bool? MobAppBaseInfoNeedUpdate { get; set; }

	public List<string> MobAppBaseInfoNeedUpdateDetail { get; set; }

	public List<string> Apis { get; set; }
}
