namespace Mobile.Models;

public class CICMobspSelectUserBaseInfoStatus_Result
{
	public int UserId { get; set; }

	public bool? MobAppBaseInfoNeedUpdate { get; set; }

	public string MobAppBaseInfoNeedUpdateDetail { get; set; }

	public string TableName { get; set; }

	public string Apis { get; set; }
}
