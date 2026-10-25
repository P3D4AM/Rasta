namespace CRM.Models;

public class PasargadPurchaseResponseViewModel
{
	public string resultMsg { get; set; }

	public int? resultCode { get; set; }

	public PasargadPurchaseDataResponseViewModel data { get; set; }
}
