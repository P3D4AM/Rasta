using System;

namespace Mobile.Models;

public class CICMobspLoadUserLoginInfo_Result
{
	public int UserId { get; set; }

	public string FName { get; set; }

	public string LName { get; set; }

	public string FullName { get; set; }

	public string UserName { get; set; }

	public string Password { get; set; }

	public int UserRollId { get; set; }

	public string RollName { get; set; }

	public DateTime? ExpireDate { get; set; }

	public int? MobCICUserAppUseCnt { get; set; }

	public bool? UserIsActiveInCIC { get; set; }

	public bool? CallerIdDeActiveFromMobile { get; set; }
}
