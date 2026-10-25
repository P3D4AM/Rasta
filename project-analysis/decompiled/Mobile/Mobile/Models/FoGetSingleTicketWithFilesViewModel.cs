using System.Collections.Generic;

namespace Mobile.Models;

public class FoGetSingleTicketWithFilesViewModel
{
	public FOMobspSelectTicketsWithTicketNumber_Result Ticket { get; set; }

	public List<FOMobspSelectFilesDirectory_Result> FileList { get; set; }
}
