namespace CRM.Models;

public class ArianSystemLoginResponseViewModel
{
	public string Err { get; set; }

	public string Token { get; set; }

	public bool? MustChangePass { get; set; }

	public bool? MustConfirmInstruction { get; set; }

	public long? DefaultRowCount { get; set; }

	public string WarningMess { get; set; }
}
