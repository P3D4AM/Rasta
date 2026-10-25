using System;

namespace Mobile.Models;

public class MobspSelectUserPictureByUserId_Result
{
	public int UserPictureId { get; set; }

	public int CrmUserId { get; set; }

	public byte[] UserPicture { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }
}
