using System;

namespace Mobile.Models;

public class FOMobspDySelectFormFieldMasterValuesTree_Result
{
	public int FormId { get; set; }

	public int FormFieldMasterValueId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public bool? IsChecked { get; set; }

	public DateTime? CheckedDate { get; set; }

	public long? DyFormNumber { get; set; }
}
