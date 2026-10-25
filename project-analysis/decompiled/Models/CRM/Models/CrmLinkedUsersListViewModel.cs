using System.Collections.Generic;

namespace CRM.Models;

public class CrmLinkedUsersListViewModel
{
	public bool IsFind { get; set; }

	public string Message { get; set; }

	public List<CRMspSelectLinkedUsersForLinkedTypeWithPaging_Result> LinkedUsersList { get; set; }

	public int AllPage { get; set; }

	public int UsersCount { get; set; }

	public List<CRMspSelectCentersTreeFullInfo_Result> CentersTree { get; set; }

	public List<CRMspSelectUserPositionTreeFullInfo_Result> UserPositionsTree { get; set; }

	public List<CRMspSelectsysRolls_Result> RollsList { get; set; }
}
