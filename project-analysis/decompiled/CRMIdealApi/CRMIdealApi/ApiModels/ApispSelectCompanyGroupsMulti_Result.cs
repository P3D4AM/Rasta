using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectCompanyGroupsMulti_Result
{
	public int ApiCompanyGroupsMultiID { get; set; }

	public string ApiCompanyGroupsMultiName { get; set; }

	public string ApiCompanyGroupsMultiDesc { get; set; }

	public int ApiUserId { get; set; }

	public short ApiYear1 { get; set; }

	public short ApiMonth1 { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public string ApiRegisterDatePersian { get; set; }

	public Guid? ApiGUId { get; set; }

	public string ApiAppType { get; set; }

	public int? ApiOrderView { get; set; }

	public int? ApiLanguageID { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterDatePersian { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }
}
