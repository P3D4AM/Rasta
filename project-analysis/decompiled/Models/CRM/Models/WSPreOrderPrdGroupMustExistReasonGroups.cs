using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSPreOrderPrdGroupMustExistReasonGroupsMetadata))]
public class WSPreOrderPrdGroupMustExistReasonGroups
{
	public int PrdGroupMustExistReasonGroupId { get; set; }

	public string PrdGroupMustExistReasonGroupTitle { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int? OrderView { get; set; }

	public int LanguageID { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public bool? NeedReasonTxt { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSPreOrderPrdGroupMustExistReasonGroups_Lang> WSPreOrderPrdGroupMustExistReasonGroups_Lang { get; set; }

	public virtual ICollection<WSPreOrderPrdGroupMustExistReasons> WSPreOrderPrdGroupMustExistReasons { get; set; }

	public WSPreOrderPrdGroupMustExistReasonGroups()
	{
		WSPreOrderPrdGroupMustExistReasonGroups_Lang = (ICollection<WSPreOrderPrdGroupMustExistReasonGroups_Lang>)new HashSet<WSPreOrderPrdGroupMustExistReasonGroups_Lang>();
		WSPreOrderPrdGroupMustExistReasons = (ICollection<WSPreOrderPrdGroupMustExistReasons>)new HashSet<WSPreOrderPrdGroupMustExistReasons>();
	}
}
