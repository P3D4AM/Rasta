using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectWareHouse_Result
{
	public int ApiWareHouseID { get; set; }

	public string ApiWrhsName { get; set; }

	public string ApiWrhsCode { get; set; }

	public string ApiWrhsAddress { get; set; }

	public string ApiWrhsPreTel { get; set; }

	public string ApiWrhsTel { get; set; }

	public string ApiWrhsTelSecond { get; set; }

	public string ApiWrhsTelThird { get; set; }

	public string ApiWrhsFax { get; set; }

	public string ApiWrhsFaxSecond { get; set; }

	public string ApiWrhsArea { get; set; }

	public string ApiWrhsPerson { get; set; }

	public string ApiWrhsDescription { get; set; }

	public short? ApiIsFix { get; set; }

	public int ApiFPId { get; set; }

	public int ApiUserId { get; set; }

	public string ApiEditUser { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public bool? ApiWrhsDeActive { get; set; }

	public int? ApiOrderView { get; set; }
}
