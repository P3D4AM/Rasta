using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(UsersPermissionMetadata))]
public class UsersPermission
{
	public int ID { get; set; }

	public int UserId { get; set; }

	public int? RollId { get; set; }

	public int PrjId { get; set; }

	public string Description { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string AccessLevel { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? CId { get; set; }

	public virtual CrmsysRolls CrmsysRolls { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Projects Projects { get; set; }

	public virtual ICollection<UsersPermission_Lang> UsersPermission_Lang { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public UsersPermission()
	{
		UsersPermission_Lang = (ICollection<UsersPermission_Lang>)new HashSet<UsersPermission_Lang>();
	}
}
