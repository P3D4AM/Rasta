using System;

namespace Mobile.Models;

public class MobspSelectVerificationRequestObjectInfo_Result
{
	public int oprId { get; set; }

	public long oprNumber { get; set; }

	public string oprDate { get; set; }

	public DateTime? oprDateTime { get; set; }

	public int? CompanyId { get; set; }

	public int? cmpReferUserId { get; set; }

	public string cmpReferUser { get; set; }

	public int? cmpSuppUserId { get; set; }

	public string cmpSuppUser { get; set; }
}
