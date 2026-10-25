namespace CRM.Models;

public class PasargadVerifyPaymentViewModel
{
	public bool IsSuccess { get; set; }

	public string Message { get; set; }

	public string MaskedCardNumber { get; set; }

	public string HashedCardNumber { get; set; }

	public string ShaparakRefNumber { get; set; }

	public int orderId { get; set; }

	public decimal? Amount { get; set; }

	public int? CrmPreOrderId { get; set; }
}
