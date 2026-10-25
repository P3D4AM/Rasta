using System.Collections.Generic;

namespace CRM.Models;

public class CmpOrdStockPayAccViewModel
{
	public bool IsFind { get; set; }

	public string Message { get; set; }

	public long TotalPage { get; set; }

	public List<WSspRpt_CmpOrdStockPayAccI_Result> ResultList { get; set; }

	public List<WSspRpt_CmpOrdStockPayAccII_Result> PayResultList { get; set; }

	public List<WSspRpt_CmpOrdStockPayAccIII_Result> SaleOrdResultList { get; set; }

	public WSspRpt_CmpOrdStockPayAccIV_Result OrdPayAcc { get; set; }
}
