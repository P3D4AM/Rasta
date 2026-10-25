using System;

namespace Mobile.Models;

public class MobspSelectLogoWithID_Result
{
	public int LogoID { get; set; }

	public byte[] Logo { get; set; }

	public string LogoDescription { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public int FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string RegisterUser { get; set; }

	public string FirstRegisterUser { get; set; }
}
