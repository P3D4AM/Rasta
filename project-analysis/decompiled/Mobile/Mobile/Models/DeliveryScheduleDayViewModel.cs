using System;

namespace Mobile.Models;

public class DeliveryScheduleDayViewModel
{
	public string DayDate { get; set; }

	public DateTime DayDateTime { get; set; }

	public int DayNumber { get; set; }

	public string DayName { get; set; }

	public dynamic DeliverySchedule { get; set; }
}
