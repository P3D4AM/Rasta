using System;

namespace CRM.Models;

public class WSspSelectProductSpecificationFields_Result
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

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterUser { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int? UserId { get; set; }

	public string EditUser { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public int? FPId { get; set; }

	public short? Month1 { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? specCId { get; set; }

	public string CenterName { get; set; }

	public bool? specSHPInActive { get; set; }

	public bool? specSHPFilterInActive { get; set; }

	public string specTypeWeb { get; set; }
}
