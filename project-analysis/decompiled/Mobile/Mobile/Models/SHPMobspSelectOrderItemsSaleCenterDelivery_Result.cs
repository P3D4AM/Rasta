using System;

namespace Mobile.Models;

public class SHPMobspSelectOrderItemsSaleCenterDelivery_Result
{
	public int OrderId { get; set; }

	public int OrderItemId { get; set; }

	public int ordIPrdId { get; set; }

	public DateTime? ordIDeliveryDate { get; set; }

	public string ordIDeliveryTime { get; set; }

	public int? ordIDeliveryTimeMin { get; set; }

	public DateTime? ordIDeliveryEndDate { get; set; }

	public string ordIDeliveryEndTime { get; set; }

	public int? ordIDeliveryEndTimeMin { get; set; }

	public int? ordISaleCenterId { get; set; }
}
