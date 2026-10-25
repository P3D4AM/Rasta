namespace Mobile.Models;

public class CmpAuthenticationByMobileModel
{
	public MobspCheckDuplicateCmpMobile_Result Company { get; set; }

	public string MobileNumber { get; set; }

	public int UserId { get; set; }

	public int UserRollId { get; set; }

	public string Token { get; set; }

	public int? LangId { get; set; }

	public bool? VBCenter { get; set; }
}
