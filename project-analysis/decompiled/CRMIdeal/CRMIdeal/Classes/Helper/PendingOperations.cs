using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using CRM.General.IO.FTP;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Newtonsoft.Json;

namespace CRMIdeal.Classes.Helper;

public class PendingOperations
{
	public class TransferedCmpFilesObj
	{
		public int FileDirectoryID { get; set; }

		public int ToCmpId { get; set; }
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_1
	{
		public TransferedCmpFilesObj rec;
	}

	public const string TransferedCmpFiles_Key = "TransferedCmpFiles";

	public const string VerifyOrder_Key = "VerifyOrder";

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	public string StartPendingOperations()
	{
		string result = "";
		try
		{
			List<CRMspSelectSysPendingOperationsNoStart_Result> sp = Enumerable.ToList<CRMspSelectSysPendingOperationsNoStart_Result>((IEnumerable<CRMspSelectSysPendingOperationsNoStart_Result>)_dbII.CRMspSelectSysPendingOperationsNoStart());
			HttpServerUtility server = HttpContext.Current.Server;
			if (sp != null && sp.Count > 0)
			{
				new Thread((ThreadStart)delegate
				{
					foreach (CRMspSelectSysPendingOperationsNoStart_Result item in sp)
					{
						PendingOperations pendingOperations = this;
						int? pendingOperationID = item.PendingOperationID;
						DateTime? poStartDate = DateTime.Now;
						string poStartDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
						pendingOperations.UpdateSysPendingOperations(pendingOperationID, null, null, null, null, null, null, null, poStartDate, poStartDatePersian);
					}
					new FilesManager();
					new FacadeFTP(Configuration.FacadeFtp);
					_ = Configuration.PathFtp;
					_ = Configuration.UserNameFtp;
					_ = Configuration.PasswordFtp;
					_ = Configuration.UsePassiveFtp;
					foreach (CRMspSelectSysPendingOperationsNoStart_Result item2 in sp)
					{
						string text = "";
						if (!string.IsNullOrWhiteSpace(item2.poCommand))
						{
							if (item2.poOperate == "TransferedCmpFiles")
							{
								_003C_003Ec__DisplayClass6_1 _003C_003Ec__DisplayClass6_ = new _003C_003Ec__DisplayClass6_1();
								_003C_003Ec__DisplayClass6_.rec = Enumerable.FirstOrDefault<TransferedCmpFilesObj>((IEnumerable<TransferedCmpFilesObj>)JsonConvert.DeserializeObject<List<TransferedCmpFilesObj>>(item2.poCommand));
								if (_003C_003Ec__DisplayClass6_.rec != null)
								{
									DbSet<CrmFilesDirectory> crmFilesDirectory = _dbTbl.CrmFilesDirectory;
									ParameterExpression val = Expression.Parameter(typeof(CrmFilesDirectory), "x");
									CrmFilesDirectory crmFilesDirectory2 = Queryable.FirstOrDefault<CrmFilesDirectory>(Queryable.Where<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass6_, typeof(_003C_003Ec__DisplayClass6_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
									string text2 = crmFilesDirectory2.FileName;
									if (crmFilesDirectory2.TypeOprObjectId.GetValueOrDefault() == 0)
									{
										text2 = text2.Replace(crmFilesDirectory2.FolderName, crmFilesDirectory2.MasterId.ToString());
									}
									string text3 = crmFilesDirectory2.MasterId.ToString();
									List<object> list = FilesManager.MoveFile(crmFilesDirectory2.FolderName, crmFilesDirectory2.FileName, text3, text2, server);
									if ((bool)(dynamic)list[1])
									{
										if (crmFilesDirectory2 != null)
										{
											crmFilesDirectory2.FilePath = ((dynamic)list[0]).ToString();
											crmFilesDirectory2.FolderName = text3;
											crmFilesDirectory2.FileName = text2;
											_dbTbl.Entry(crmFilesDirectory2).State = EntityState.Modified;
											_dbTbl.SaveChanges();
										}
									}
									else
									{
										text = ((dynamic)list[2]).ToString();
										_db.CRMspDeleteCrmFilesDirectory(crmFilesDirectory2.FileDirectoryID);
									}
								}
							}
							else if (item2.poOperate == "VerifyOrder")
							{
								try
								{
									List<SelectListItem>? list2 = JsonConvert.DeserializeObject<List<SelectListItem>>(item2.poCommand);
									int result2 = 0;
									int result3 = 0;
									foreach (SelectListItem item3 in list2)
									{
										if (item3.Text == "userid")
										{
											int.TryParse(item3.Value, out result3);
										}
										else if (item3.Text == "ordid")
										{
											int.TryParse(item3.Value, out result2);
										}
									}
									CRMspLoadUserLoginInfoViewModel user = UserLogin.User(result3);
									text = Order.VerifyOrderComplete(result2, "frmOrder", UserLogin.IsUserAccess("frmOrder", "actVerifyOrder", user), actVerifyOrder_Passed: true, UserLogin.IsUserAccess("frmOrder", "actAutoReferOrderToWrhsUserAfterVerify", user), UserLogin.IsUserAccess("frmOrder", "actIssueDraftAuto", user), "actIssueDraftAuto", UserLogin.IsUserAccess("frmOrder", "actGetOrdFOLink", user), result3);
									if (!string.IsNullOrWhiteSpace(text) && text.Substring(0, 2) == "1|")
									{
										text = "";
									}
								}
								catch (Exception ex2)
								{
									text = "Error: " + ex2.Message;
								}
							}
						}
						else
						{
							text += "Empty Command.\n";
						}
						if (!string.IsNullOrWhiteSpace(text))
						{
							PendingOperations pendingOperations2 = this;
							int? pendingOperationID2 = item2.PendingOperationID;
							DateTime? poStartDate = DateTime.Now;
							string poStartDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
							string poResult = text;
							DateTime? poResultDate = DateTime.Now;
							string poResultDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
							pendingOperations2.UpdateSysPendingOperations(pendingOperationID2, null, null, null, null, poResult, poResultDate, poResultDatePersian, null, null, poStartDate, poStartDatePersian);
						}
						else
						{
							_dbII.CRMspDeleteSysPendingOperation(item2.PendingOperationID);
						}
					}
				}).Start();
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = Messages.msgErrorOperationFailed;
		}
		return result;
	}

	public void UpdateSysPendingOperations(int? pendingOperationID = null, string poOperate = null, DateTime? poOperateDate = null, string poOperateDatePersian = null, string poCommand = null, string poResult = null, DateTime? poResultDate = null, string poResultDatePersian = null, DateTime? poStartDate = null, string poStartDatePersian = null, DateTime? poFinishDate = null, string poFinishDatePersian = null)
	{
		try
		{
			_dbII.CRMspUpdateSysPendingOperations(pendingOperationID, poOperate, poOperateDate, poOperateDatePersian, poCommand, poResult, poResultDate, poResultDatePersian, poStartDate, poStartDatePersian, poFinishDate, poFinishDatePersian);
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
	}
}
