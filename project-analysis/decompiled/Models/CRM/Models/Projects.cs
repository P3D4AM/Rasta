using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(ProjectsMetadata))]
public class Projects
{
	public int Id { get; set; }

	public short Code { get; set; }

	public string Name { get; set; }

	public string Title { get; set; }

	public string Value { get; set; }

	public string Version { get; set; }

	public string OldVersion { get; set; }

	public string Company { get; set; }

	public string AboutCompany { get; set; }

	public string Type { get; set; }

	public string Description { get; set; }

	public string LogoPath { get; set; }

	public byte[] LogoPic { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<Projects_Lang> Projects_Lang { get; set; }

	public virtual ICollection<UsersPermission> UsersPermission { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public Projects()
	{
		Projects_Lang = (ICollection<Projects_Lang>)new HashSet<Projects_Lang>();
		UsersPermission = (ICollection<UsersPermission>)new HashSet<UsersPermission>();
	}
}
