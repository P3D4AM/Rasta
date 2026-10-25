using System.Collections.Generic;
using System.Web.Mvc;

namespace CRM.Models;

public class ConversationQuickViewModel
{
	public List<SelectListItem> CmpPerson { get; set; }

	public List<SelectListItem> CnvsStatus { get; set; }

	public CrmConversationLanguageViewModel CnvsTicket { get; set; }

	public List<SelectListItem> CnvsStatusProgress { get; set; }
}
