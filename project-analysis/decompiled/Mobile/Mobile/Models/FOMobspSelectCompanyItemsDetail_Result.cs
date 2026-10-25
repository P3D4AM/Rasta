namespace Mobile.Models;

public class FOMobspSelectCompanyItemsDetail_Result
{
	public int? PersonCount { get; set; }

	public int? ActiveProjectCount { get; set; }

	public int? ArchiveProjectCount { get; set; }

	public decimal? SumPayment { get; set; }

	public decimal? AllPayRemain { get; set; }

	public int? PreOrderCount { get; set; }

	public decimal? AllPreOrderPayment { get; set; }

	public int? OrderCount { get; set; }

	public decimal? AllOrderPayment { get; set; }

	public int? BuyOrderCount { get; set; }

	public decimal? AllBuyOrderPayment { get; set; }

	public int? DocCount { get; set; }

	public int? DraftCount { get; set; }

	public int? SendLetterCount { get; set; }

	public int? ReceiveLetterCount { get; set; }

	public int UnverifiedProductCount { get; set; }

	public decimal? AllShoppingBagPayment { get; set; }

	public int? TicketAnsweredCount { get; set; }

	public int? TicketWaitingAnsweredCount { get; set; }

	public int? TicketAllowInCurrntCount { get; set; }

	public int? TicketAllowAddBeforeAnswerCount { get; set; }

	public int? NewTicketCount { get; set; }

	public int? TotalTicket { get; set; }

	public int? TotalTicketToDay { get; set; }

	public int? TotalTicketCurrent { get; set; }

	public int? TotalTicketCurrentToDay { get; set; }

	public int? TotalCallINToDay { get; set; }

	public int? TotalCallIN { get; set; }

	public long? TotalCallINDuration { get; set; }

	public long? TotalCallINDurationToDay { get; set; }
}
