using System;

namespace Mobile.Models;

public class StatusSalesFunnelStepsChartViewModel
{
	public int? cmpReferUserId { get; set; }

	public int? cmpPresentationId { get; set; }

	public string cmpCampaignIds { get; set; }

	public int? cmpCountryId { get; set; }

	public int? cmpProvinceId { get; set; }

	public int? cmpCityId { get; set; }

	public string prjTitle { get; set; }

	public DateTime? cnvsFDateTime { get; set; }

	public DateTime? cnvsTDateTime { get; set; }

	public int? LanguageId { get; set; }

	public int? CenterId { get; set; }
}
