using System;

namespace Mobile.Models;

public class FOMobspReturnSumCompanyScores_Result
{
	public double SumScores { get; set; }

	public double SumUsableScores { get; set; }

	public DateTime? LastScoreDate { get; set; }
}
