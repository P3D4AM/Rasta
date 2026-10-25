using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

public class CrmLinkedUsersViewModel
{
	[Key]
	public int ID { get; set; }

	public int LinkedTypeId { get; set; }

	public int CrmUserId { get; set; }

	public string CrmUserFLName { get; set; }

	public int LinkedUserId { get; set; }

	public string LinkedUserFLName { get; set; }
}
