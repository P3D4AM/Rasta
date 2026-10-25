using System.Collections.Generic;

namespace CRMIdealApi.ApiModels;

public class FullUpdateOrderViewModel
{
	public UpdateOrderViewModel Order { get; set; }

	public List<UpdateOrderItemsViewModel> OrderItemsList { get; set; }

	public List<UpdateOrderPaymentsViewModel> OrderPaymentsList { get; set; }

	public List<UpdateOrderCommissionViewModel> OrderCommissionsList { get; set; }
}
