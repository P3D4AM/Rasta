using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectBuyOrderItemSerials_Result
{
	public int ApiBuyOrderItemSerialID { get; set; }

	public int ApiBuyOrderItemId { get; set; }

	public string ApiSerial { get; set; }

	public string ApiDescription { get; set; }

	public int? ApiWHId { get; set; }

	public string ApiWH { get; set; }

	public DateTime? ApiExpDate { get; set; }

	public string ApiExpDatePersian { get; set; }

	public string ApiInfoI { get; set; }

	public string ApiInfoII { get; set; }

	public string ApiInfoIII { get; set; }

	public string ApiInfoIV { get; set; }

	public string ApiInfoV { get; set; }

	public string ApiInfoVI { get; set; }

	public string ApiAppType { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterDatePersian { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public int? ApiLanguageID { get; set; }

	public short ApiMonth1 { get; set; }

	public int ApiFPId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public string ApiRegisterDatePersian { get; set; }
}
