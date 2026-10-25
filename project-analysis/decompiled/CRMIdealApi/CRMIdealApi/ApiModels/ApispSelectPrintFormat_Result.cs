using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectPrintFormat_Result
{
	public int ApiPrintFormatID { get; set; }

	public int ApiPrintFormatTypeId { get; set; }

	public string ApiTitle { get; set; }

	public string ApiFileName { get; set; }

	public int ApiUserId { get; set; }

	public DateTime ApiRegisterDate { get; set; }

	public string ApiFileNameWeb { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }

	public string ApiEditUser { get; set; }
}
