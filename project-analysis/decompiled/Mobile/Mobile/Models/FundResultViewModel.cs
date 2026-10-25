using System.Collections.Generic;

namespace Mobile.Models;

public class FundResultViewModel
{
	public List<MobspSelectFund_Result> FundList { get; set; }

	public MobspReturnFundSumFooter_Result FundFooter { get; set; }
}
