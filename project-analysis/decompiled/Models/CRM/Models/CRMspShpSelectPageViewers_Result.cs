using System;

namespace CRM.Models;

public class CRMspShpSelectPageViewers_Result
{
	public int PageViewerId { get; set; }

	public string PageViewerIpAddress { get; set; }

	public string PageViewerBrowser { get; set; }

	public string PageViewerOs { get; set; }

	public string PageViewerReferer { get; set; }

	public string PageViewerPageViewed { get; set; }

	public string PageViewerDeviceType { get; set; }

	public string PageViewerCountryName { get; set; }

	public int? PageViewerCompanyId { get; set; }

	public string PageViewerCompany { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }
}
