using System;

namespace CRMIdealApi.ApiModels;

public class IssueDocItemSerialsViewModel
{
	public int? ItemId { get; set; }

	public string Serial { get; set; }

	public int? StatusId { get; set; }

	public string Description { get; set; }

	public short? IsFix { get; set; }

	public int? WHId { get; set; }

	public bool? IsAutoBarcode { get; set; }

	public int? SerialId { get; set; }

	public int? tblTmpBarcodeId { get; set; }

	public string ExpDatePersian { get; set; }

	public DateTime? ExpDate { get; set; }

	public string InfoI { get; set; }

	public string InfoII { get; set; }

	public string InfoIII { get; set; }

	public string InfoIV { get; set; }

	public string InfoV { get; set; }

	public string InfoVI { get; set; }
}
