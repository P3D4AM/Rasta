using System.Collections.Generic;

namespace Mobile.Models;

public class OrderDetailViewModel
{
	public MobspSelectOrderWithID_Result Order { get; set; }

	public List<MobspSelectOrderItems_Result> OrderItems { get; set; }

	public List<MobspSelectOrderItemSerialsByOrderItemId_Result> OrderItemSerials { get; set; }

	public List<MobspSelectOrderPayments_Result> OrderPayments { get; set; }

	public List<MobspSelectFilesDirectory_Result> OrderFiles { get; set; }

	public MobfnReturnOrderSumFooter_Result OrderSumFooter { get; set; }

	public MobspReturnSumOrderPay_Result SumOrderPay { get; set; }

	public MobspReturnDocForSaleOrder_Result DocForSaleOrder { get; set; }

	public int WareHouseCount { get; set; }

	public List<MobspIntMsgGetByTypeAndAttachRecId_Result> InternalMsg { get; set; }

	public List<MobspReturnBuyOrderFromOrder_Result> BuyOrderList { get; set; }
}
