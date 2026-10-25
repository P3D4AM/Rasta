namespace CRM.Models;

public class CRMspSelectFODefaultUserDepartmentTicket_Result
{
	public int DepartmentID { get; set; }

	public string Department { get; set; }

	public int? DefaultTicketUserId { get; set; }

	public string DefaultTicketUser { get; set; }

	public string TicketReferUserIds { get; set; }

	public string TicketReferUsers { get; set; }

	public string TicketFooterText { get; set; }

	public string TicketFooterText_Lang { get; set; }
}
