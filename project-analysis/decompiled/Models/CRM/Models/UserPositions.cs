using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(UserPositionsMetadata))]
public class UserPositions
{
	public int PositionId { get; set; }

	public int ParentId { get; set; }

	public string PositionName { get; set; }

	public string PositionCode { get; set; }

	public string PositionManager { get; set; }

	public string PositionAddress { get; set; }

	public string PositionTel { get; set; }

	public string PositionEmail { get; set; }

	public int? OrderView { get; set; }

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

	public virtual ICollection<CrmLinkedUserPositions> CrmLinkedUserPositions { get; set; }

	public virtual ICollection<CrmLinkedUserPositions> CrmLinkedUserPositions1 { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<UserPositions_Lang> UserPositions_Lang { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual ICollection<Users> Users2 { get; set; }

	public UserPositions()
	{
		CrmLinkedUserPositions = (ICollection<CrmLinkedUserPositions>)new HashSet<CrmLinkedUserPositions>();
		CrmLinkedUserPositions1 = (ICollection<CrmLinkedUserPositions>)new HashSet<CrmLinkedUserPositions>();
		UserPositions_Lang = (ICollection<UserPositions_Lang>)new HashSet<UserPositions_Lang>();
		Users2 = (ICollection<Users>)new HashSet<Users>();
	}
}
