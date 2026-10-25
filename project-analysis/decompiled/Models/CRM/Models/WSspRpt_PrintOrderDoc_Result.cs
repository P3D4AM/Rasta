using System;

namespace CRM.Models;

public class WSspRpt_PrintOrderDoc_Result
{
	public int DocID { get; set; }

	public int DocNumber { get; set; }

	public DateTime? DocDateTime { get; set; }

	public string DocDate { get; set; }

	public int OprId { get; set; }

	public string DocOpr { get; set; }

	public int? OprType { get; set; }

	public string Info { get; set; }

	public string SenderName { get; set; }

	public string FactorNumber { get; set; }

	public string Description { get; set; }

	public int WHId { get; set; }

	public string WrhsName { get; set; }

	public string SendAddress { get; set; }

	public string DriverName { get; set; }

	public string DriverTel { get; set; }

	public string FreightName { get; set; }

	public string BijakNumber { get; set; }

	public string CarNumber { get; set; }

	public int? WHIdI { get; set; }

	public string WrhsNameI { get; set; }

	public string cmpTitle { get; set; }

	public string DocNumRef { get; set; }
}
