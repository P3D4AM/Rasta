using System;

namespace CRM.Models;

public class UserPicturesViewModel
{
	public int UserPictureId { get; set; }

	public int CrmUserId { get; set; }

	public string UserPicture { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string AppType { get; set; }
}
