using System;

namespace CRM.Models;

public class ChamberCommerceCompanyInfoViewModel
{
	public string OfficeTel { get; set; }

	public string TradeCardIdWithCD { get; set; }

	public string FactoryTel { get; set; }

	public string HomeTel { get; set; }

	public string WorkTel { get; set; }

	public string PersianCorporationName { get; set; }

	public string PersianLastName { get; set; }

	public string PersianFirstName { get; set; }

	public string CardNo { get; set; }

	public string CardExpireDate { get; set; }

	public string CardExpireDateInCalture { get; set; }

	public DateTime? CardExpireDateTime { get; set; }

	public string StatusTitle { get; set; }

	public string ResponseTime { get; set; }

	public long RowNumber { get; set; }

	public bool Selected { get; set; }

	public bool HasConflict { get; set; }

	public string ErrorMessage { get; set; }
}
