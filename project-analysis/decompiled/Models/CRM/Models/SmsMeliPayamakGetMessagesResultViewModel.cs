using System.Collections.Generic;

namespace CRM.Models;

public class SmsMeliPayamakGetMessagesResultViewModel
{
	public SmsMeliPayamakResultViewModel MyBase { get; set; }

	public List<SmsMeliPayamakGetMessagesDataResultViewModel> Data { get; set; }
}
