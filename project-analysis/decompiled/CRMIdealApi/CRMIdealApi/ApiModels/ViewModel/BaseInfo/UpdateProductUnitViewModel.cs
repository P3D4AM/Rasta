using System;

namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class UpdateProductUnitViewModel : PublicParametersWithOutCenter
{
	public int ApiProductUnitId { get; set; }

	public string ApiUnit { get; set; }

	public string ApiDescription { get; set; }

	public string ApiUnitEn { get; set; }

	public int ApiQuantityInUnit { get; set; }

	public float ApiFCR { get; set; }

	public float ApiFCRI { get; set; }

	public string ApiSHPUnit { get; set; }

	public string ApiTspUnitCode { get; set; }

	public string ApiUnitLinkAccUnitIdStr { get; set; }

	public int ApiUnitLinkAccUnitId { get; set; }

	public DateTime? ApiLinkAccFirstTransferDate { get; set; }

	public DateTime? ApiLinkAccLastTransferDate { get; set; }

	public string ApiLinkAccData { get; set; }

	public string ApiLinkAccFirstTransferDatePersian { get; set; }

	public string ApiLinkAccLastTransferDatePersian { get; set; }
}
