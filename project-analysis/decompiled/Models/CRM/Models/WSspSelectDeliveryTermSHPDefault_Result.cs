namespace CRM.Models;

public class WSspSelectDeliveryTermSHPDefault_Result
{
	public int DeliveryTermId { get; set; }

	public string DeliveryTerm { get; set; }

	public int? OrderView { get; set; }

	public bool? SHPVisible { get; set; }

	public bool? SHPDefault { get; set; }

	public bool? SHPNeedAddress { get; set; }
}
