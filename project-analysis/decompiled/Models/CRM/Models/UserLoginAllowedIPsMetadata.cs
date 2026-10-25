using System;

namespace CRM.Models;

public class UserLoginAllowedIPsMetadata
{
	public int UserLoginAllowedIPId { get; set; }

	public int crmUserId { get; set; }

	public string AllowedIPAddress { get; set; }

	public int FirstUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }
}
