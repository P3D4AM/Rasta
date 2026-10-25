using System.Collections.Generic;

namespace CRM.Models;

public class TransferCompanyViewModel
{
	public class PrsInfo
	{
		public CRMspSelectCompanyPersonsByID_Result FromPrsInfo { get; set; } = new CRMspSelectCompanyPersonsByID_Result();


		public List<CRMspSelectCompanyPersonsByID_Result> ToPrsInfo { get; set; } = new List<CRMspSelectCompanyPersonsByID_Result>();

	}

	public CRMspSelectCrmProjectsById_Result FromPrjInfo { get; set; } = new CRMspSelectCrmProjectsById_Result();


	public CRMspSelectCrmProjectsById_Result ToPrjInfo { get; set; } = new CRMspSelectCrmProjectsById_Result();


	public List<PrsInfo> PrsList { get; set; } = new List<PrsInfo>();

}
