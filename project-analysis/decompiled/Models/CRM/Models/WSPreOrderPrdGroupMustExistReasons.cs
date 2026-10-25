using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSPreOrderPrdGroupMustExistReasonsMetadata))]
public class WSPreOrderPrdGroupMustExistReasons
{
	public int PrdGroupMustExistReasonId { get; set; }

	public int PrdGroupMustExistReasonGroupId { get; set; }

	public int? CompanyId { get; set; }

	public int cmpProjectId { get; set; }

	public int? PreOrderId { get; set; }

	public int PrdFirstGroupID { get; set; }

	public string Reason { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int FirstRegisterUserId { get; set; }

	public int UserId { get; set; }

	public int FPId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public int? CId { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WSFinancialPeriod WSFinancialPeriod { get; set; }

	public virtual WSPreOrderPrdGroupMustExistReasonGroups WSPreOrderPrdGroupMustExistReasonGroups { get; set; }

	public virtual ICollection<WSPreOrderPrdGroupMustExistReasons_Lang> WSPreOrderPrdGroupMustExistReasons_Lang { get; set; }

	public virtual WSPreOrderPrdGroupMustExistReasons WSPreOrderPrdGroupMustExistReasons1 { get; set; }

	public virtual WSPreOrderPrdGroupMustExistReasons WSPreOrderPrdGroupMustExistReasons2 { get; set; }

	public virtual WSProductFirstGroup WSProductFirstGroup { get; set; }

	public virtual WSPreOrder WSPreOrder { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual CrmProjects CrmProjects { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSPreOrderPrdGroupMustExistReasons()
	{
		WSPreOrderPrdGroupMustExistReasons_Lang = (ICollection<WSPreOrderPrdGroupMustExistReasons_Lang>)new HashSet<WSPreOrderPrdGroupMustExistReasons_Lang>();
	}
}
