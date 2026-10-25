using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class ParsianPaymentCallbackViewModel
{
	public long? Token { get; set; }

	public long? OrderId { get; set; }

	public int? TerminalNo { get; set; }

	public long? RRN { get; set; }

	public short? status { get; set; }

	public string HashCardNumber { get; set; }

	public string Amount { get; set; }

	public string TspToken { get; set; }

	[DisplayFormat(NullDisplayText = "NULL")]
	public short? ConfirmResponseStatus { get; set; }

	public int? CrmOrderId { get; set; }

	public int? CrmPreOrderId { get; set; }
}
