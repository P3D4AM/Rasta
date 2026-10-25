namespace Mobile.Models;

public class MobspSelectUser_Result
{
	public int UserId { get; set; }

	public string FName { get; set; }

	public string LName { get; set; }

	public string FullName { get; set; }

	public bool? IsActive { get; set; }

	public string IsAdmin { get; set; }

	public string IPAddress { get; set; }

	public string ComputerName { get; set; }

	public bool? CallreIdDeActive { get; set; }

	public string CallreIdDeActiveLines { get; set; }

	public bool? DisableInternalMessageAllarmVoice { get; set; }

	public bool? DisableReceiveCNVSInfoAllarm { get; set; }

	public string EmailAttachFileLocation { get; set; }

	public string UserName { get; set; }

	public string Password { get; set; }

	public bool? AllowCopyOtherLanguage { get; set; }

	public bool? CanSetFree { get; set; }

	public bool? UserIsActiveInWinApp { get; set; }

	public bool? UserIsActiveInWebApp { get; set; }

	public bool? UserIsActiveInMobApp { get; set; }

	public string Mobile { get; set; }

	public string MobileII { get; set; }

	public string Tel { get; set; }

	public int UserRollId { get; set; }

	public string RollName { get; set; }
}
