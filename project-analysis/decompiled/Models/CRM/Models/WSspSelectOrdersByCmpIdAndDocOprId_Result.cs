using System;

namespace CRM.Models;

public class WSspSelectOrdersByCmpIdAndDocOprId_Result
{
	public int OrdId { get; set; }

	public long OrdNumber { get; set; }

	public string OrdInfo { get; set; }

	public string OrdDate { get; set; }

	public DateTime? OrdDateTime { get; set; }

	public int OrdType { get; set; }

	public string OrdTypeAndId { get; set; }

	public string OrdOpr { get; set; }
}
