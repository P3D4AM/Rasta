using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectDocItemSerials_Result
{
	public int ApiDocItemSerialID { get; set; }

	public int ApiItemId { get; set; }

	public string ApiSerial { get; set; }

	public int? ApiStatusId { get; set; }

	public string ApiDescription { get; set; }

	public short? ApiIsFix { get; set; }

	public int? ApiWHId { get; set; }

	public string ApiWH { get; set; }

	public int? ApiSerialId { get; set; }

	public bool? ApiIsAutoBarcode { get; set; }

	public int? ApitblTmpBarcodeId { get; set; }

	public DateTime? ApiExpDate { get; set; }

	public string ApiAppType { get; set; }

	public string ApiInfoI { get; set; }

	public string ApiInfoII { get; set; }

	public string ApiInfoIII { get; set; }

	public string ApiInfoIV { get; set; }

	public string ApiInfoV { get; set; }

	public string ApiInfoVI { get; set; }

	public int ApiFPId { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public int? ApiDocISLinkAccItemSerialId { get; set; }

	public DateTime? ApiDocISLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiDocISLinkAccLastTransferDate { get; set; }

	public string ApiDocISLinkAccData { get; set; }
}
