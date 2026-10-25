namespace CRM.Models;

public class WSspSelectProductSpecificationsUsedInPrds_Result
{
	public int SpecificationFieldID { get; set; }

	public int? specGroupId { get; set; }

	public string specGroup { get; set; }

	public int? specTypeId { get; set; }

	public string specTypeWeb { get; set; }

	public string specTitle { get; set; }

	public string specSHPTitle { get; set; }

	public long? specMinValue { get; set; }

	public long? specMaxValue { get; set; }

	public long? specStrLength { get; set; }

	public string specMultiItemValues { get; set; }

	public bool? specInActive { get; set; }

	public int? OrderView { get; set; }

	public int? LanguageID { get; set; }

	public bool? specSHPInActive { get; set; }

	public bool? specSHPFilterInActive { get; set; }
}
