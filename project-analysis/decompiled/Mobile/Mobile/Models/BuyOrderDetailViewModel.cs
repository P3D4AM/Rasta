using System.Collections.Generic;

namespace Mobile.Models;

public class BuyOrderDetailViewModel
{
	public MobspSelectBuyOrderWithID_Result BuyOrder { get; set; }

	public List<MobspSelectBuyOrderItems_Result> BuyOrderItems { get; set; }

	public List<MobspSelectBuyOrderItemSerials_Result> BuyOrderItemSerials { get; set; }

	public List<MobspSelectBuyOrderPayments_Result> BuyOrderPayments { get; set; }

	public List<FileDirectoryViewModel> BuyOrderFiles { get; set; }

	public MobfnReturnBuyOrderSumFooter_Result BuyOrderSumFooter { get; set; }

	public MobspReturnSumBuyOrderPay_Result SumBuyOrderPay { get; set; }

	public MobspReturnDocForBuyOrder_Result DocForBuyOrder { get; set; }
}
