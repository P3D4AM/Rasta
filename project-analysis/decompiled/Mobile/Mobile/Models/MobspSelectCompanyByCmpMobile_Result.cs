using System;

namespace Mobile.Models;

public class MobspSelectCompanyByCmpMobile_Result
{
	public int CompanyId { get; set; }

	public int? cmpNumber { get; set; }

	public string CompanyName { get; set; }

	public int? cmpMainPersonId { get; set; }

	public bool? cmpCRMShopIsActive { get; set; }

	public DateTime? cmpCRMShopActiveDate { get; set; }

	public int? cmpLastCId { get; set; }

	public string cmpCIds { get; set; }
}
