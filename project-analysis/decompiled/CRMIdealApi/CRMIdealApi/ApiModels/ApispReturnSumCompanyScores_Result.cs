using System;

namespace CRMIdealApi.ApiModels;

public class ApispReturnSumCompanyScores_Result
{
	public double ApiSumScores { get; set; }

	public double ApiSumUsableScores { get; set; }

	public DateTime? ApiLastScoreDate { get; set; }
}
