using System;

namespace CRMIdealApi.ApiModels;

public class SelectCompanyMoneyBagViewModel : PublicParameters
{
	public int? CompanyId { get; set; }

	public DateTime? FDateTime { get; set; }

	public DateTime? TDateTime { get; set; }

	public string TextRemainderBefore { get; set; }

	public string TextManual { get; set; }

	public string TextSystemic { get; set; }
}
