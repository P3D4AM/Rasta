namespace Mobile.Models;

public class SHPMobspSelectDeliveryTerms_Result
{
	public int DeliveryTermId { get; set; }

	public string DeliveryTerm { get; set; }

	public int? OrderView { get; set; }

	public bool? SHPVisible { get; set; }

	public bool? SHPDefault { get; set; }

	public bool? SHPNeedAddress { get; set; }
}
