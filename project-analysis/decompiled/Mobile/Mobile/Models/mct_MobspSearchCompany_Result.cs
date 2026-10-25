using System;

namespace Mobile.Models;

public class mct_MobspSearchCompany_Result
{
	public int AllPage { get; set; }

	public long RowNum { get; set; }

	public int CompanyID { get; set; }

	public int cmpNumber { get; set; }

	public string cmpName { get; set; }

	public int? cmpTitleId { get; set; }

	public string cmpPreTel { get; set; }

	public string cmpTel { get; set; }

	public string cmpTelUpTo { get; set; }

	public string cmpTelDesc { get; set; }

	public string cmpPreTelII { get; set; }

	public string cmpTelII { get; set; }

	public string cmpTelUpToII { get; set; }

	public string cmpTelIIDesc { get; set; }

	public int? cmpProvinceId { get; set; }

	public int? cmpCityId { get; set; }

	public int FirstRegisterUserId { get; set; }

	public int cmpReferUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string CompanyName { get; set; }

	public string cmpTitle { get; set; }

	public string cmpProvince { get; set; }

	public string cmpCity { get; set; }

	public string cmpReferUser { get; set; }

	public string FirstRegisterUser { get; set; }

	public long? TotalCount { get; set; }

	public int? cmpLogoId { get; set; }

	public string cmpCoordinateLatitude { get; set; }

	public string cmpCoordinateLongitude { get; set; }

	public string cmpCIds { get; set; }

	public string cmpFOInfo { get; set; }
}
