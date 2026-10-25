using System.Collections.Generic;

namespace Mobile.Models;

public class PreOrderDetailViewModel
{
	public MobspSelectPreOrderWithID_Result PreOrder { get; set; }

	public List<MobspSelectPreOrderItems_Result> PreOrderItems { get; set; }

	public List<MobspSelectPreOrderItemSpecificationByItemId_Result> PreOrderItemsSpecification { get; set; }

	public List<MobspSelectPreOrderPayments_Result> PreOrderPayments { get; set; }

	public List<MobspSelectFilesDirectory_Result> PreOrderFiles { get; set; }

	public MobspReturnSumPreOrderPay_Result SumPreOrderPay { get; set; }

	public MobspReturnCmpAccountingSummary_Result CmpAccountingSummary { get; set; }

	public MobfnReturnPreOrderSumFooter_Result PreOrderSumFooter { get; set; }

	public MobspReturnOrderFromPreOrder_Result OrderInfo { get; set; }

	public List<MobspReturnOrderFromPreOrder_Result> OrderInfoList { get; set; }

	public decimal NotInSumTotalPrice { get; set; }

	public List<MobspIntMsgGetByTypeAndAttachRecId_Result> InternalMsg { get; set; }
}
