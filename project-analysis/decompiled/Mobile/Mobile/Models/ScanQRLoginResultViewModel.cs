namespace Mobile.Models;

public class ScanQRLoginResultViewModel
{
	public string Token { get; set; }

	public bool LoginWithScan { get; set; }

	public int? ShiftWorkingId { get; set; }

	public int UserId { get; set; }
}
