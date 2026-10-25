using System.Collections.Generic;

namespace CRM.Models;

public class KendoChartViewModel<T>
{
	public string Title { get; set; }

	public string subTitle { get; set; }

	public string[] XAxisCategories { get; set; }

	public string XAxisTitle { get; set; }

	public string YAxisTitle { get; set; }

	public string YAxisTooltipValueSuffix { get; set; }

	public List<T> Series { get; set; }
}
