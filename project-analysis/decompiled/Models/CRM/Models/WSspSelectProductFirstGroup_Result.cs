using System;

namespace CRM.Models;

public class WSspSelectProductFirstGroup_Result
{
	public int PrdFirstGroupID { get; set; }

	public string FGCode { get; set; }

	public string FGName { get; set; }

	public string FGDescription { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public int FPId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string FGNameEn { get; set; }

	public Guid? GUId { get; set; }

	public bool? FGInactiveInSale { get; set; }

	public bool? FGInactiveInBuy { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public bool? PrdGroupMustExistInPreOrder { get; set; }

	public int? FGOrderView { get; set; }

	public bool? FGSHPIsActive { get; set; }

	public string FGSHPName { get; set; }
}
