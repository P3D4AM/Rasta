using System.Collections.Generic;

namespace CRM.Models;

public class ChartViewModel<T, T1>
{
	public string Title { get; set; }

	public string subTitle { get; set; }

	public string[] XAxisCategories { get; set; }

	public string XAxisTitle { get; set; }

	public string YAxisTitle { get; set; }

	public string YAxisTooltipValueSuffix { get; set; }

	public ICollection<SeriesViewModel<T>> Series { get; set; }

	public ICollection<SeriesColorViewModel<T>> SeriesColor { get; set; }

	public ICollection<SeriesDataViewModel<T>> SeriesData { get; set; }

	public ICollection<SeriesDataColorViewModel<T>> SeriesDataColumnColor { get; set; }

	public ICollection<SeriesDataColorViewModel<T1>> SeriesDataLineColor { get; set; }
}
