using System;

namespace CRM.Models.ViewModel.Reports;

public class HourlySaleViewModel
{
	public string FromDate { get; set; }

	public string ToDate { get; set; }

	public DateTime? FromDateTime { get; set; }

	public DateTime? ToDateTime { get; set; }

	public string ReferUserIds { get; set; }

	public string OrderOprIds { get; set; }
}
