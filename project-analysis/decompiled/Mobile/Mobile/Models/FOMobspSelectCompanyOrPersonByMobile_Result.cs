using System;

namespace Mobile.Models;

public class FOMobspSelectCompanyOrPersonByMobile_Result
{
	public int CompanyID { get; set; }

	public int? cmpNumber { get; set; }

	public string cmpName { get; set; }

	public string CompanyName { get; set; }

	public string cmpEmail { get; set; }

	public string cmpUserName { get; set; }

	public string cmpPassword { get; set; }

	public string cmpMobile { get; set; }

	public bool? cmpFOIsActive { get; set; }

	public DateTime? cmpFOLoginExpireDate { get; set; }

	public int? CompanyPersonID { get; set; }

	public string prsLName { get; set; }

	public string prsFName { get; set; }

	public string PersonName { get; set; }

	public bool? prsFOIsActive { get; set; }

	public DateTime? prsFOLoginExpireDate { get; set; }

	public string PersonMobile { get; set; }

	public string PersonEmail { get; set; }

	public string PersonNationalCode { get; set; }

	public int? LoginType { get; set; }

	public int? LastCId { get; set; }

	public string CIds { get; set; }
}
