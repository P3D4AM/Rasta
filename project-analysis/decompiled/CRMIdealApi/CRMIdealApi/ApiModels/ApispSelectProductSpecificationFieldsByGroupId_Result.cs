using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectProductSpecificationFieldsByGroupId_Result
{
	public int SpecificationFieldID { get; set; }

	public int? specGroupId { get; set; }

	public string specGroup { get; set; }

	public int? specTypeId { get; set; }

	public string specType { get; set; }

	public string specTitle { get; set; }

	public string specSHPTitle { get; set; }

	public long? specMinValue { get; set; }

	public long? specMaxValue { get; set; }

	public long? specStrLength { get; set; }

	public string specMultiItemValues { get; set; }

	public bool? specInActive { get; set; }

	public int? OrderView { get; set; }

	public int? UserId { get; set; }

	public string EditUser { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? specCId { get; set; }

	public string CenterName { get; set; }
}
