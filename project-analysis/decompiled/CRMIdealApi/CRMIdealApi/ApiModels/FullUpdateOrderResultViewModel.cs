using System.Collections.Generic;
using CRMIdealApi.DataType;

namespace CRMIdealApi.ApiModels;

public class FullUpdateOrderResultViewModel
{
	public class FullUpdateOrderItemResultViewModel
	{
		public int Index { get; set; }

		public int OrderItemId { get; set; }

		public ServiceResult<int> Result { get; set; }
	}

	public class FullUpdateOrderPaymentResultViewModel
	{
		public int Index { get; set; }

		public int OrderPaymentId { get; set; }

		public ServiceResult<int> Result { get; set; }
	}

	public class FullUpdateOrderCommissionResultViewModel
	{
		public int Index { get; set; }

		public int OrderCommissionId { get; set; }

		public ServiceResult<int> Result { get; set; }
	}

	public ServiceResult<int> OrderResult { get; set; }

	public List<FullUpdateOrderItemResultViewModel> OrderItemResult { get; set; }

	public List<FullUpdateOrderPaymentResultViewModel> OrderPaymentResult { get; set; }

	public List<FullUpdateOrderCommissionResultViewModel> OrderCommissionResult { get; set; }
}
