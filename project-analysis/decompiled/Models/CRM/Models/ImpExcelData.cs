using System;

namespace CRM.Models;

public class ImpExcelData
{
	public DateTime StartReq { get; set; }

	public string StartReqStr { get; set; }

	public DateTime EndReq { get; set; }

	public string EndReqStr { get; set; }

	public DateTime EndTotalReq { get; set; }

	public string EndTotalReqStr { get; set; }

	public string Messages { get; set; }

	public string Data { get; set; }
}
