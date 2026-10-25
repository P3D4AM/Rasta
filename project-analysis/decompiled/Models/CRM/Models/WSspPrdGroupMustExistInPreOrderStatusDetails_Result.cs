using System;

namespace CRM.Models;

public class WSspPrdGroupMustExistInPreOrderStatusDetails_Result
{
	public int recType { get; set; }

	public int PordOrResId { get; set; }

	public long pordNumber { get; set; }

	public string pordDate { get; set; }

	public DateTime? pordDateTime { get; set; }

	public string Reason { get; set; }

	public string RefUser { get; set; }

	public int GroupId { get; set; }
}
