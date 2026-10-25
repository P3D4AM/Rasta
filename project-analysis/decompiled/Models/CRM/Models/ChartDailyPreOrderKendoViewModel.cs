namespace CRM.Models;

public class ChartDailyPreOrderKendoViewModel
{
	public string Day { get; set; }

	public int Cnt { get; set; }

	public decimal Amnt { get; set; }

	public int Ord { get; set; }

	public bool VisibleInLegend { get; set; }

	public string Color { get; set; }

	public string CategoryField { get; set; }
}
