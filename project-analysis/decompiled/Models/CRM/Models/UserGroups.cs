using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(UserGroupsMetadata))]
public class UserGroups
{
	public int UserGroupId { get; set; }

	public string GroupName { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<UserGroups_Lang> UserGroups_Lang { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual ICollection<Users> Users2 { get; set; }

	public UserGroups()
	{
		UserGroups_Lang = (ICollection<UserGroups_Lang>)new HashSet<UserGroups_Lang>();
		Users2 = (ICollection<Users>)new HashSet<Users>();
	}
}
