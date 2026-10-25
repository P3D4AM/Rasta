using System;

namespace CRM.Models;

public class WSspReturnDocFromPreOrder_Result
{
	public int DocID { get; set; }

	public int DocNumber { get; set; }

	public string DocDate { get; set; }

	public DateTime? DocDateTime { get; set; }

	public string UserName { get; set; }

	public string RegisterDatePersian { get; set; }

	public DateTime RegisterDate { get; set; }

	public int OprId { get; set; }

	public string Opr { get; set; }

	public int? OprType { get; set; }

	public string Info { get; set; }
}
