using System;

namespace CRM.Models;

public class WSspSelectBuyOrderOpr_Result
{
	public int BuyOrderOprID { get; set; }

	public string Name { get; set; }

	public int? OprType { get; set; }

	public int? OrderView { get; set; }

	public int? DocOprId { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string DocOpr { get; set; }

	public string FirstRegisterUser { get; set; }

	public string LinkAccBuyOrderOprIdStr { get; set; }

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public string LinkAccData { get; set; }

	public int? UserId { get; set; }

	public string EditUser { get; set; }

	public int? FPId { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }
}
