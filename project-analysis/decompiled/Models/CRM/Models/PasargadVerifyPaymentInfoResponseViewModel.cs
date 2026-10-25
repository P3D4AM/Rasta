using System;

namespace CRM.Models;

public class PasargadVerifyPaymentInfoResponseViewModel
{
	public string invoice { get; set; }

	public string referenceNumber { get; set; }

	public string trackId { get; set; }

	public string maskedCardNumber { get; set; }

	public string hashedCardNumber { get; set; }

	public DateTime? requestDate { get; set; }

	public decimal? amount { get; set; }
}
