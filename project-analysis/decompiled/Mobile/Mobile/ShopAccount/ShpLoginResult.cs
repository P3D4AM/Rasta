using System;

namespace Mobile.ShopAccount;

public class ShpLoginResult
{
	public string Token { get; set; }

	public int CompanyID { get; set; }

	public int? cmpNumber { get; set; }

	public string CompanyName { get; set; }

	public int cmpMainPersonId { get; set; }

	public string cmpMobile { get; set; }

	public string cmpPrsMobile { get; set; }

	public bool cmpFOIsActive { get; set; }

	public int LoginType { get; set; }

	public string cmpPersonName { get; set; }

	public string FoActiveCIds { get; set; }

	public int? LastCId { get; set; }

	public bool? VBCenter { get; set; }

	public string cmpCIds { get; set; }

	public string prsCIds { get; set; }

	public string prsFoInfo { get; set; }

	public string foShpInfo { get; set; }

	public bool? prsShpIsActive { get; set; }

	public bool? cmpShpIsActive { get; set; }

	public DateTime? cmpShpLoginExpireDate { get; set; }

	public DateTime? prsShpLoginExpireDate { get; set; }
}
