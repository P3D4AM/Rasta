using System;

namespace CRM.Models;

public class CRMspLkSepSelectCash_Result
{
	public int CashId { get; set; }

	public string Title { get; set; }

	public int DlRef { get; set; }

	public int CurrencyRef { get; set; }

	public bool IsActive { get; set; }

	public decimal FirstAmount { get; set; }

	public DateTime FirstDate { get; set; }

	public string CurrencyTitle { get; set; }

	public int Version { get; set; }

	public decimal Rate { get; set; }

	public int? Creator { get; set; }

	public DateTime? CreationDate { get; set; }

	public int? LastModifier { get; set; }

	public string DlTitle { get; set; }

	public string DlCode { get; set; }

	public DateTime? LastModificationDate { get; set; }

	public decimal Balance { get; set; }

	public string CurrencyTitle_En { get; set; }
}
