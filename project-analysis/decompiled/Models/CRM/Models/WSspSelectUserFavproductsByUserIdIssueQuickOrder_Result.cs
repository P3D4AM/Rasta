using System;

namespace CRM.Models;

public class WSspSelectUserFavproductsByUserIdIssueQuickOrder_Result
{
	public int UserFavproductId { get; set; }

	public string FavprdTitle { get; set; }

	public string FavprdDesc { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? OrderView { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public bool? FavprdInActive { get; set; }

	public bool? FavprdUseInIssueQuick { get; set; }
}
