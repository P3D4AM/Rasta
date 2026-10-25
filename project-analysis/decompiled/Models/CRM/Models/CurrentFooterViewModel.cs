namespace CRM.Models;

public class CurrentFooterViewModel
{
	public CRMspCmsSelectFooter_Result Footer { get; set; }

	public int FooterCurrentId { get; set; }

	public int FooterNextId { get; set; }

	public int FooterPreviousId { get; set; }

	public bool IsFind { get; set; }

	public string Message { get; set; }

	public int FooterFirstId { get; set; }

	public int FooterLastId { get; set; }
}
