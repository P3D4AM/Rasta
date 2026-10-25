using System.Collections.Generic;

namespace CRM.Models.ViewModel.Targeting;

public class SalesTargetUserScopeViewModel
{
	public int Key { get; set; }

	public string DepartmentId { get; set; }

	public string DepartmentName { get; set; }

	public List<SalesTargetUserScopeSelectedItem> SelectedUsers { get; set; }
}
