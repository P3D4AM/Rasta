using System.Collections.Generic;

namespace CRMIdealApi.ApiModels;

public class FullUpdatePreOrderViewModel
{
	public UpdatePreOrderViewModel PreOrder { get; set; }

	public List<UpdatePreOrderItemsViewModel> PreOrderItemsList { get; set; }

	public List<UpdatePreOrderPaymentsViewModel> PreOrderPaymentsList { get; set; }

	public List<UpdatePreOrderCommissionViewModel> PreOrderCommissionsList { get; set; }
}
