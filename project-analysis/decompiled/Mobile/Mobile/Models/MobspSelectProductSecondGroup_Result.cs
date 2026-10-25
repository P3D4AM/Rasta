using System;

namespace Mobile.Models;

public class MobspSelectProductSecondGroup_Result
{
	public int PrdSecondGroupID { get; set; }

	public int FirstGroupId { get; set; }

	public string SGCode { get; set; }

	public string SGName { get; set; }

	public string SGDescription { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string SGNameEn { get; set; }

	public bool? SGInactiveInSale { get; set; }

	public bool? SGInactiveInBuy { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? SGOrderView { get; set; }

	public string FGName { get; set; }

	public long? ManualOrderView { get; set; }

	public string SGCompanyGroupIIRateJson { get; set; }
}
