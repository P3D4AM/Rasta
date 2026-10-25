namespace CRM.Models;

public class TelegramAuthorizeViewModel
{
	public string Hash { get; set; }

	public string Code { get; set; }

	public string Password { get; set; }

	public bool IsUserAuthorized { get; set; }

	public string Message { get; set; }

	public bool IsSuccess { get; set; }

	public int UserId { get; set; }
}
