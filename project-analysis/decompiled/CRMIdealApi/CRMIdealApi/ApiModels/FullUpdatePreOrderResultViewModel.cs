using System.Collections.Generic;
using CRMIdealApi.DataType;

namespace CRMIdealApi.ApiModels;

public class FullUpdatePreOrderResultViewModel
{
	public class FullUpdatePreOrderItemResultViewModel
	{
		public int Index { get; set; }

		public int PreOrderItemId { get; set; }

		public ServiceResult<int> Result { get; set; }
	}

	public class FullUpdatePreOrderPaymentResultViewModel
	{
		public int Index { get; set; }

		public int PreOrderPaymentId { get; set; }

		public ServiceResult<int> Result { get; set; }
	}

	public class FullUpdatePreOrderCommisionResultViewModel
	{
		public int Index { get; set; }

		public int PreOrderCommissionId { get; set; }

		public ServiceResult<int> Result { get; set; }
	}

	public ServiceResult<int> PreOrderResult { get; set; }

	public List<FullUpdatePreOrderItemResultViewModel> PreOrderItemResult { get; set; }

	public List<FullUpdatePreOrderPaymentResultViewModel> PreOrderPaymentResult { get; set; }

	public List<FullUpdatePreOrderCommisionResultViewModel> PreOrderCommissionResult { get; set; }
}
