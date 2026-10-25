using System.Collections.Generic;

namespace CRM.Models;

public class CRMShpPageViewerChartViewModel
{
	public List<CRMShpChartDailyPageViewersViewModel> ChrtShpPageViewerChartDaily { get; set; }

	public List<CRMShpChartPageViewersWithOsViewModel> ChrtShpPageViewersWithOs { get; set; }

	public List<CRMShpChartPageViewersWithDeviceTypeViewModel> ChrtShpPageViewersWithDeviceType { get; set; }

	public List<CRMShpChartPageViewersWithBrowserViewModel> ChrtShpPageViewersWithBrowser { get; set; }

	public List<CRMShpChartDailyPageViewersWithHourViewModel> ChrtShpDailyPageViewersWithHour { get; set; }

	public List<CRMShpChartPageViewersWithRefererViewModel> ChrtShpPageViewersWithReferer { get; set; }

	public PageViewerChartsWidthViewModel ChrtWidth { get; set; }
}
