using System.Collections.Generic;

namespace Mobile.Models;

public class FoGetTicketDetailsResult
{
	public FOMobspSelectTickets_Result Ticket { get; set; }

	public List<FoGetSingleTicketWithFilesViewModel> SubTickets { get; set; }

	public bool TicketHasValidity { get; set; }
}
