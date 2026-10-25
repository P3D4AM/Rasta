namespace CRM.Models;

public class PasargadVerifyPaymentResponseViewModel
{
	public string resultMsg { get; set; }

	public int? resultCode { get; set; }

	public PasargadVerifyPaymentInfoResponseViewModel data { get; set; }
}
