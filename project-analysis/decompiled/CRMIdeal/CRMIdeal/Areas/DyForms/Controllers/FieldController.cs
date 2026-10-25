using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.DyForms.Controllers;

public class FieldController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public int fieldId;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public CrmDyFormFieldsLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__13;

		public Func<Languages, bool> _003C_003E9__35;

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__13(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__35(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public CrmDyFormFields model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass4_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public int fieldId;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmDyDefineForm", ActionName = "actInsertField,actEditField")]
	public ActionResult InsertEdit(int formId, int parentFormId = 0, int fieldId = 0, int parentFieldId = 0)
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals0.fieldId = fieldId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmDyFormFieldsLanguageViewModel crmDyFormFieldsLanguageViewModel = new CrmDyFormFieldsLanguageViewModel();
		BaseInfo baseInfo = new BaseInfo();
		try
		{
			string text = "";
			if (parentFieldId > 0)
			{
				CRMspDySelectFormFields_Result cRMspDySelectFormFields_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFields_Result>((IEnumerable<CRMspDySelectFormFields_Result>)_db.CRMspDySelectFormFields(parentFieldId, 0, null, CS_0024_003C_003E8__locals0.currLangID, result));
				if (cRMspDySelectFormFields_Result != null)
				{
					text = cRMspDySelectFormFields_Result.FieldTitle ?? "";
				}
			}
			base.ViewBag.ParentFiled = text;
			if (CS_0024_003C_003E8__locals0.fieldId > 0)
			{
				if (!UserLogin.IsUserAccess("frmDyDefineForm", "actEditField"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DbSet<CrmDyFormFields_Lang> crmDyFormFields_Lang = _dbTbl.CrmDyFormFields_Lang;
				ParameterExpression val = Expression.Parameter(typeof(CrmDyFormFields_Lang), "c");
				List<CrmDyFormFields_Lang> list = Enumerable.ToList<CrmDyFormFields_Lang>((IEnumerable<CrmDyFormFields_Lang>)Queryable.Where<CrmDyFormFields_Lang>((IQueryable<CrmDyFormFields_Lang>)crmDyFormFields_Lang, Expression.Lambda<Func<CrmDyFormFields_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				DbSet<CrmDyFormFields> crmDyFormFields = _dbTbl.CrmDyFormFields;
				val = Expression.Parameter(typeof(CrmDyFormFields), "c");
				CrmDyFormFields crmDyFormFields2 = Queryable.FirstOrDefault<CrmDyFormFields>((IQueryable<CrmDyFormFields>)crmDyFormFields, Expression.Lambda<Func<CrmDyFormFields, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmDyFormFields2 == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
					return null;
				}
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmDyFormFields_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmDyFormFields_Lang>)list, (Func<CrmDyFormFields_Lang, CommonMultiLanguageViewModel>)((CrmDyFormFields_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.FieldTitle,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = crmDyFormFields2.FieldTitle,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmDyFormFields_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmDyFormFields_Lang>)list, (Func<CrmDyFormFields_Lang, CommonMultiLanguageViewModel>)((CrmDyFormFields_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.RegularExpressionErrorTxt,
					LanguageId = item.LanguageID
				})));
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = crmDyFormFields2.RegularExpressionErrorTxt,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmDyFormFields_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmDyFormFields_Lang>)list, (Func<CrmDyFormFields_Lang, CommonMultiLanguageViewModel>)((CrmDyFormFields_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.PlaceholderTxt,
					LanguageId = item.LanguageID
				})));
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = crmDyFormFields2.PlaceholderTxt,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmDyFormFields_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmDyFormFields_Lang>)list, (Func<CrmDyFormFields_Lang, CommonMultiLanguageViewModel>)((CrmDyFormFields_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.MultiItems,
					LanguageId = item.LanguageID
				})));
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = crmDyFormFields2.MultiItems,
					LanguageId = result
				});
				List<CommonSelectDyFormListItemViewModel> list6 = new List<CommonSelectDyFormListItemViewModel>();
				int num = 0;
				CommonMultiLanguageViewModel commonMultiLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID));
				if (commonMultiLanguageViewModel != null && (crmDyFormFields2.FieldTypeId.GetValueOrDefault() == 6 || crmDyFormFields2.FieldTypeId.GetValueOrDefault() == 7 || crmDyFormFields2.FieldTypeId.GetValueOrDefault() == 8))
				{
					string text2 = ((commonMultiLanguageViewModel != null) ? commonMultiLanguageViewModel.Value : "");
					if (!string.IsNullOrWhiteSpace(text2))
					{
						string[] array = text2.Split(new char[1] { '|' });
						if (array.Length != 0)
						{
							for (int i = 0; i < array.Length; i++)
							{
								string[] array2 = array[i].Split(new char[1] { ':' });
								if (array2.Length == 0 || string.IsNullOrWhiteSpace(array2[0]))
								{
									continue;
								}
								CommonSelectDyFormListItemViewModel commonSelectDyFormListItemViewModel = new CommonSelectDyFormListItemViewModel();
								commonSelectDyFormListItemViewModel.Key_allData = new List<CommonMultiLanguageViewModel>();
								commonSelectDyFormListItemViewModel.Val_allData = new List<CommonMultiLanguageViewModel>();
								commonSelectDyFormListItemViewModel.Key = array2[0];
								if (array2.Length == 2)
								{
									commonSelectDyFormListItemViewModel.OrderView = array2[1];
								}
								else if (array2.Length == 3)
								{
									commonSelectDyFormListItemViewModel.OrderView = array2[2];
								}
								if (array2.Length >= 4)
								{
									commonSelectDyFormListItemViewModel.LkDbObjVal = array2[3];
								}
								foreach (CommonMultiLanguageViewModel item in list5)
								{
									if (item.LanguageId == CS_0024_003C_003E8__locals0.currLangID)
									{
										continue;
									}
									if (!string.IsNullOrWhiteSpace(item.Value))
									{
										string[] array3 = item.Value.Split(new char[1] { '|' });
										if (array3.Length > num)
										{
											num = array3.Length;
										}
										if (i < array3.Length)
										{
											string[] array4 = array3[i].Split(new char[1] { ':' });
											if (array4.Length == 2)
											{
												commonSelectDyFormListItemViewModel.Key_allData.Add(new CommonMultiLanguageViewModel
												{
													Value = (string.IsNullOrWhiteSpace(array4[0]) ? array2[0] : array4[0]),
													LanguageId = item.LanguageId
												});
												commonSelectDyFormListItemViewModel.Val_allData.Add(new CommonMultiLanguageViewModel
												{
													Value = "",
													LanguageId = item.LanguageId
												});
											}
											else if (array4.Length == 3)
											{
												commonSelectDyFormListItemViewModel.Key_allData.Add(new CommonMultiLanguageViewModel
												{
													Value = (string.IsNullOrWhiteSpace(array4[0]) ? array2[0] : array4[0]),
													LanguageId = item.LanguageId
												});
												commonSelectDyFormListItemViewModel.Val_allData.Add(new CommonMultiLanguageViewModel
												{
													Value = (string.IsNullOrWhiteSpace(array4[1]) ? array2[0] : array4[1]),
													LanguageId = item.LanguageId
												});
											}
											else if (array4.Length == 4)
											{
												commonSelectDyFormListItemViewModel.Key_allData.Add(new CommonMultiLanguageViewModel
												{
													Value = (string.IsNullOrWhiteSpace(array4[0]) ? array2[0] : array4[0]),
													LanguageId = item.LanguageId
												});
												commonSelectDyFormListItemViewModel.Val_allData.Add(new CommonMultiLanguageViewModel
												{
													Value = (string.IsNullOrWhiteSpace(array4[1]) ? array2[0] : array4[1]),
													LanguageId = item.LanguageId
												});
											}
										}
										else
										{
											commonSelectDyFormListItemViewModel.Key_allData.Add(new CommonMultiLanguageViewModel
											{
												Value = "",
												LanguageId = item.LanguageId
											});
											commonSelectDyFormListItemViewModel.Val_allData.Add(new CommonMultiLanguageViewModel
											{
												Value = "",
												LanguageId = item.LanguageId
											});
										}
									}
									else
									{
										commonSelectDyFormListItemViewModel.Key_allData.Add(new CommonMultiLanguageViewModel
										{
											Value = "",
											LanguageId = item.LanguageId
										});
										commonSelectDyFormListItemViewModel.Val_allData.Add(new CommonMultiLanguageViewModel
										{
											Value = "",
											LanguageId = item.LanguageId
										});
									}
								}
								list6.Add(commonSelectDyFormListItemViewModel);
							}
						}
					}
				}
				if (num > 0)
				{
					string text3 = "";
					for (int j = 0; j < num; j++)
					{
						text3 += "|";
					}
					foreach (CommonMultiLanguageViewModel item2 in list5)
					{
						if (!string.IsNullOrWhiteSpace(item2.Value))
						{
							for (int k = num - item2.Value.Split(new char[1] { '|' }).Length; k < num; k++)
							{
								item2.Value += "|";
							}
						}
						else
						{
							item2.Value = text3;
						}
					}
				}
				List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmDyFormFields_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmDyFormFields_Lang>)list, (Func<CrmDyFormFields_Lang, CommonMultiLanguageViewModel>)((CrmDyFormFields_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.DefaultValue,
					LanguageId = item.LanguageID
				})));
				list7.Add(new CommonMultiLanguageViewModel
				{
					Value = crmDyFormFields2.DefaultValue,
					LanguageId = result
				});
				crmDyFormFieldsLanguageViewModel = new CrmDyFormFieldsLanguageViewModel
				{
					FormFieldId = crmDyFormFields2.FormFieldId,
					ParentFormId = crmDyFormFields2.ParentFormId,
					FormId = crmDyFormFields2.FormId,
					FieldTypeId = crmDyFormFields2.FieldTypeId.GetValueOrDefault(),
					ParentFieldId = crmDyFormFields2.ParentFieldId,
					IsRequired = crmDyFormFields2.IsRequired,
					RegularExpressionId = crmDyFormFields2.RegularExpressionId,
					MinValue = crmDyFormFields2.MinValue,
					MaxValue = crmDyFormFields2.MaxValue,
					StrLength = crmDyFormFields2.StrLength,
					IsActive = crmDyFormFields2.IsActive,
					IsRepeatable = crmDyFormFields2.IsRepeatable,
					FOIsRepeatable = crmDyFormFields2.FOIsRepeatable,
					UploadFileMaxSize = crmDyFormFields2.UploadFileMaxSize,
					UploadFileExtension = crmDyFormFields2.UploadFileExtension,
					ColumnPosition = crmDyFormFields2.ColumnPosition,
					OrderView = crmDyFormFields2.OrderView,
					FirstRegisterUserId = crmDyFormFields2.FirstRegisterUserId,
					FirstRegisterDate = crmDyFormFields2.FirstRegisterDate,
					FirstRegisterDatePersian = crmDyFormFields2.FirstRegisterDatePersian,
					UserId = crmDyFormFields2.UserId,
					RegisterDate = crmDyFormFields2.RegisterDate,
					RegisterDatePersian = crmDyFormFields2.RegisterDatePersian,
					Year1 = crmDyFormFields2.Year1,
					Month1 = crmDyFormFields2.Month1,
					GUId = crmDyFormFields2.GUId,
					AppType = crmDyFormFields2.AppType,
					LanguageID = crmDyFormFields2.LanguageID,
					FieldTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					FieldTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					RegularExpressionErrorTxt = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					RegularExpressionErrorTxt_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					PlaceholderTxt = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					PlaceholderTxt_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					MultiItems = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					MultiItems_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					DefaultValue = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					DefaultValue_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					ParentFieldColor = baseInfo.DelphiCToRgbolor(crmDyFormFields2.ParentFieldColor),
					ParentFieldBgColor = baseInfo.DelphiCToRgbolor(crmDyFormFields2.ParentFieldBgColor),
					RowPosition = crmDyFormFields2.RowPosition,
					MultiItem_Lang_Js = JsonConvert.SerializeObject(list6),
					LinkDbObjectId = crmDyFormFields2.LinkDbObjectId
				};
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmDyDefineForm", "actInsertField"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DateTime now = DateTime.Now;
				crmDyFormFieldsLanguageViewModel = new CrmDyFormFieldsLanguageViewModel
				{
					ParentFormId = parentFormId,
					ParentFieldId = parentFieldId,
					FormId = formId,
					FirstRegisterUserId = UserLogin.CurrentUser.UserId,
					FirstRegisterDate = now,
					FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
					UserId = UserLogin.CurrentUser.UserId,
					RegisterDate = now,
					RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
					Year1 = short.Parse(Financial.Get().Id.ToString()),
					Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
					AppType = Configuration.AppType,
					LanguageID = result,
					IsActive = true
				};
				if (!crmDyFormFieldsLanguageViewModel.OrderView.HasValue || crmDyFormFieldsLanguageViewModel.OrderView <= 0)
				{
					List<CRMspDySelectFormFields_Result> list8 = Enumerable.ToList<CRMspDySelectFormFields_Result>((IEnumerable<CRMspDySelectFormFields_Result>)_db.CRMspDySelectFormFields(0, formId, null, CS_0024_003C_003E8__locals0.currLangID, result));
					_ = Enumerable.FirstOrDefault<CRMspDySelectFormFields_Result>((IEnumerable<CRMspDySelectFormFields_Result>)Enumerable.OrderByDescending<CRMspDySelectFormFields_Result, int?>((IEnumerable<CRMspDySelectFormFields_Result>)list8, (Func<CRMspDySelectFormFields_Result, int?>)((CRMspDySelectFormFields_Result m) => m.OrderView)))?.OrderView;
					int num2 = (Enumerable.Any<CRMspDySelectFormFields_Result>((IEnumerable<CRMspDySelectFormFields_Result>)list8) ? Enumerable.Count<CRMspDySelectFormFields_Result>((IEnumerable<CRMspDySelectFormFields_Result>)list8) : 0);
					crmDyFormFieldsLanguageViewModel.OrderView = num2 + 10 + num2 * 9 - 5;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		SetRegisterInfo(crmDyFormFieldsLanguageViewModel);
		GetRegularExpressions(crmDyFormFieldsLanguageViewModel.FieldTypeId.GetValueOrDefault());
		GetFieldTypes(parentFieldId);
		GetSysDBObjects(crmDyFormFieldsLanguageViewModel.FormId, crmDyFormFieldsLanguageViewModel.FieldTypeId.GetValueOrDefault());
		return View(crmDyFormFieldsLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDyDefineForm", ActionName = "actInsertField,actEditField")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(CrmDyFormFieldsLanguageViewModel vm)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass4_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FieldTitle_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.FieldTitle_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.FieldTitle,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.RegularExpressionErrorTxt_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.RegularExpressionErrorTxt_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.RegularExpressionErrorTxt,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.PlaceholderTxt_Lang))
		{
			list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.PlaceholderTxt_Lang);
		}
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.PlaceholderTxt,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.MultiItems_Lang))
		{
			list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.MultiItems_Lang);
		}
		list4.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.MultiItems,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.DefaultValue_Lang))
		{
			list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.DefaultValue_Lang);
		}
		list5.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.DefaultValue,
			LanguageId = lCID
		});
		string text = "";
		if (CS_0024_003C_003E8__locals0.vm.ParentFieldId > 0)
		{
			CRMspDySelectFormFields_Result cRMspDySelectFormFields_Result = Enumerable.FirstOrDefault<CRMspDySelectFormFields_Result>((IEnumerable<CRMspDySelectFormFields_Result>)_db.CRMspDySelectFormFields(CS_0024_003C_003E8__locals0.vm.ParentFieldId, 0, null, lCID, CS_0024_003C_003E8__locals0.defLangID));
			if (cRMspDySelectFormFields_Result != null)
			{
				text = cRMspDySelectFormFields_Result.ParentField ?? "";
			}
		}
		base.ViewBag.ParentFiled = text;
		GetRegularExpressions(CS_0024_003C_003E8__locals0.vm.FieldTypeId.GetValueOrDefault());
		GetFieldTypes(CS_0024_003C_003E8__locals0.vm.ParentFieldId.GetValueOrDefault());
		GetSysDBObjects(CS_0024_003C_003E8__locals0.vm.FormId, CS_0024_003C_003E8__locals0.vm.FieldTypeId.GetValueOrDefault());
		try
		{
			BaseInfo baseInfo = new BaseInfo();
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				_003C_003Ec__DisplayClass4_1 _003C_003Ec__DisplayClass4_ = new _003C_003Ec__DisplayClass4_1();
				_ = CRMIdeal.Cache.Setting.Language.Get().Count;
				string text2 = "";
				int num = 0;
				if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FieldTitle))
				{
					text2 = text2 + string.Format(Messages.ErrorEmpty, Labels.DyFormFieldTitle) + "<br/>";
					num++;
				}
				else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.FieldTitle, list))
				{
					text2 = text2 + string.Format(Messages.CheckFieldInLang, Labels.DyFormFieldTitle) + "<br>";
					num++;
				}
				if (!CS_0024_003C_003E8__locals0.vm.FieldTypeId.HasValue)
				{
					text2 = text2 + string.Format(Messages.ErrorEmpty, Labels.DyFormFieldType) + "<br/>";
					num++;
				}
				if (num > 0)
				{
					base.ViewBag.Error = text2;
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				_003C_003Ec__DisplayClass4_.model = new CrmDyFormFields();
				if (CS_0024_003C_003E8__locals0.vm.FormFieldId > 0)
				{
					DbSet<CrmDyFormFields> crmDyFormFields = _dbTbl.CrmDyFormFields;
					ParameterExpression val = Expression.Parameter(typeof(CrmDyFormFields), "c");
					_003C_003Ec__DisplayClass4_.model = Queryable.FirstOrDefault<CrmDyFormFields>((IQueryable<CrmDyFormFields>)crmDyFormFields, Expression.Lambda<Func<CrmDyFormFields, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass4_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass4_.model.UserId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				_003C_003Ec__DisplayClass4_.model.RegisterDate = now;
				_003C_003Ec__DisplayClass4_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_003C_003Ec__DisplayClass4_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				_003C_003Ec__DisplayClass4_.model.AppType = Configuration.AppType;
				_003C_003Ec__DisplayClass4_.model.Year1 = short.Parse(Financial.Get().Id.ToString());
				_003C_003Ec__DisplayClass4_.model.ParentFormId = CS_0024_003C_003E8__locals0.vm.ParentFormId;
				_003C_003Ec__DisplayClass4_.model.FormId = CS_0024_003C_003E8__locals0.vm.FormId;
				if (CS_0024_003C_003E8__locals0.vm.FormFieldId == 0)
				{
					_003C_003Ec__DisplayClass4_.model.FieldTypeId = ((CS_0024_003C_003E8__locals0.vm.FieldTypeId == 0) ? null : CS_0024_003C_003E8__locals0.vm.FieldTypeId);
				}
				_003C_003Ec__DisplayClass4_.model.ParentFieldId = CS_0024_003C_003E8__locals0.vm.ParentFieldId;
				_003C_003Ec__DisplayClass4_.model.IsRequired = CS_0024_003C_003E8__locals0.vm.IsRequired;
				_003C_003Ec__DisplayClass4_.model.RegularExpressionId = CS_0024_003C_003E8__locals0.vm.RegularExpressionId;
				_003C_003Ec__DisplayClass4_.model.MinValue = CS_0024_003C_003E8__locals0.vm.MinValue;
				_003C_003Ec__DisplayClass4_.model.MaxValue = CS_0024_003C_003E8__locals0.vm.MaxValue;
				_003C_003Ec__DisplayClass4_.model.StrLength = CS_0024_003C_003E8__locals0.vm.StrLength;
				_003C_003Ec__DisplayClass4_.model.IsActive = CS_0024_003C_003E8__locals0.vm.IsActive;
				_003C_003Ec__DisplayClass4_.model.IsRepeatable = CS_0024_003C_003E8__locals0.vm.IsRepeatable;
				_003C_003Ec__DisplayClass4_.model.FOIsRepeatable = CS_0024_003C_003E8__locals0.vm.FOIsRepeatable;
				_003C_003Ec__DisplayClass4_.model.UploadFileMaxSize = CS_0024_003C_003E8__locals0.vm.UploadFileMaxSize;
				_003C_003Ec__DisplayClass4_.model.UploadFileExtension = CS_0024_003C_003E8__locals0.vm.UploadFileExtension;
				_003C_003Ec__DisplayClass4_.model.ColumnPosition = CS_0024_003C_003E8__locals0.vm.ColumnPosition;
				_003C_003Ec__DisplayClass4_.model.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
				_003C_003Ec__DisplayClass4_.model.ParentFieldColor = baseInfo.RgbToDelphiColor(CS_0024_003C_003E8__locals0.vm.ParentFieldColor);
				_003C_003Ec__DisplayClass4_.model.ParentFieldBgColor = baseInfo.RgbToDelphiColor(CS_0024_003C_003E8__locals0.vm.ParentFieldBgColor);
				_003C_003Ec__DisplayClass4_.model.FieldTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass4_.model.RegularExpressionErrorTxt = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass4_.model.PlaceholderTxt = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass4_.model.MultiItems = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass4_.model.DefaultValue = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass4_.model.RowPosition = CS_0024_003C_003E8__locals0.vm.RowPosition;
				_003C_003Ec__DisplayClass4_.model.LinkDbObjectId = CS_0024_003C_003E8__locals0.vm.LinkDbObjectId;
				if (_003C_003Ec__DisplayClass4_.model.FormFieldId > 0)
				{
					_dbTbl.Entry(_003C_003Ec__DisplayClass4_.model).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass4_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass4_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass4_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<CrmDyFormFields_Lang> crmDyFormFields_Lang = _dbTbl.CrmDyFormFields_Lang;
							ParameterExpression val = Expression.Parameter(typeof(CrmDyFormFields_Lang), "c");
							CrmDyFormFields_Lang crmDyFormFields_Lang2 = Queryable.FirstOrDefault<CrmDyFormFields_Lang>((IQueryable<CrmDyFormFields_Lang>)crmDyFormFields_Lang, Expression.Lambda<Func<CrmDyFormFields_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass4_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass4_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmDyFormFields_Lang2 != null)
							{
								crmDyFormFields_Lang2.FieldTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmDyFormFields_Lang2.RegularExpressionErrorTxt = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmDyFormFields_Lang2.PlaceholderTxt = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmDyFormFields_Lang2.MultiItems = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmDyFormFields_Lang2.DefaultValue = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmDyFormFields_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmDyFormFields_Lang2 = new CrmDyFormFields_Lang();
							crmDyFormFields_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							crmDyFormFields_Lang2.FieldId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.FormFieldId;
							crmDyFormFields_Lang2.FieldTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmDyFormFields_Lang2.RegularExpressionErrorTxt = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmDyFormFields_Lang2.PlaceholderTxt = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmDyFormFields_Lang2.MultiItems = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmDyFormFields_Lang2.DefaultValue = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.CrmDyFormFields_Lang.Add(crmDyFormFields_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					_003C_003Ec__DisplayClass4_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass4_.model.FirstRegisterDate = now;
					_003C_003Ec__DisplayClass4_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass4_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_003C_003Ec__DisplayClass4_.model.GUId = Guid.NewGuid();
					_dbTbl.CrmDyFormFields.Add(_003C_003Ec__DisplayClass4_.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						CrmDyFormFields_Lang crmDyFormFields_Lang3 = new CrmDyFormFields_Lang();
						crmDyFormFields_Lang3.LanguageID = lang.LanguageID;
						crmDyFormFields_Lang3.FieldId = _003C_003Ec__DisplayClass4_.model.FormFieldId;
						crmDyFormFields_Lang3.FieldTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmDyFormFields_Lang3.RegularExpressionErrorTxt = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmDyFormFields_Lang3.PlaceholderTxt = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmDyFormFields_Lang3.MultiItems = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						crmDyFormFields_Lang3.DefaultValue = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.CrmDyFormFields_Lang.Add(crmDyFormFields_Lang3);
						_dbTbl.SaveChanges();
					}
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				CS_0024_003C_003E8__locals0.vm.ParentFieldId = _003C_003Ec__DisplayClass4_.model.ParentFieldId;
				CS_0024_003C_003E8__locals0.vm.FormFieldId = _003C_003Ec__DisplayClass4_.model.FormFieldId;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = now;
				CS_0024_003C_003E8__locals0.vm.RegisterDate = now;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
				CS_0024_003C_003E8__locals0.vm.UserId = UserLogin.CurrentUser.UserId;
				CS_0024_003C_003E8__locals0.vm.AppType = _003C_003Ec__DisplayClass4_.model.AppType;
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		SetRegisterInfo(CS_0024_003C_003E8__locals0.vm);
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	[AjaxOnly]
	public JsonResult GetRegularExpressions(int fieldTypeId)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspDySelectFormRegularExpressions_Result> list2 = Enumerable.ToList<CRMspDySelectFormRegularExpressions_Result>((IEnumerable<CRMspDySelectFormRegularExpressions_Result>)_db.CRMspDySelectFormRegularExpressions(fieldTypeId, lCID, result));
			list.AddRange(Enumerable.Select<CRMspDySelectFormRegularExpressions_Result, SelectListItem>((IEnumerable<CRMspDySelectFormRegularExpressions_Result>)list2, (Func<CRMspDySelectFormRegularExpressions_Result, SelectListItem>)((CRMspDySelectFormRegularExpressions_Result item) => new SelectListItem
			{
				Text = item.Title,
				Value = item.FormRegularExpressionId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.RegularExpressionList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetFieldTypes(int parentFieldId)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (parentFieldId == 0)
			{
				SelectListItem item2 = new SelectListItem
				{
					Selected = false,
					Text = Labels.lblMainTitle + " " + Labels.DyFrmGroupOfField,
					Value = "0"
				};
				list.Add(item2);
			}
			List<CRMspDySelectFormFieldTypes_Result> list2 = Enumerable.ToList<CRMspDySelectFormFieldTypes_Result>((IEnumerable<CRMspDySelectFormFieldTypes_Result>)_db.CRMspDySelectFormFieldTypes(lCID, result));
			list.AddRange(Enumerable.Select<CRMspDySelectFormFieldTypes_Result, SelectListItem>((IEnumerable<CRMspDySelectFormFieldTypes_Result>)list2, (Func<CRMspDySelectFormFieldTypes_Result, SelectListItem>)((CRMspDySelectFormFieldTypes_Result item) => new SelectListItem
			{
				Text = item.TypeName,
				Value = item.FormFieldTypeId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FieldTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSysDBObjects(int formId, int fieldTypeId)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspDySelectSysDBObjects_Result> list2 = Enumerable.ToList<CRMspDySelectSysDBObjects_Result>((IEnumerable<CRMspDySelectSysDBObjects_Result>)_dbII.CRMspDySelectSysDBObjects(formId, fieldTypeId, lCID, result));
			if (list2 != null && Enumerable.Any<CRMspDySelectSysDBObjects_Result>((IEnumerable<CRMspDySelectSysDBObjects_Result>)list2))
			{
				foreach (CRMspDySelectSysDBObjects_Result item2 in list2)
				{
					string text = "";
					if (!string.IsNullOrWhiteSpace(item2.DBObjectName))
					{
						if (item2.DBObjectName.ToLower() == "crmcompany")
						{
							text = Labels.lblCmp;
						}
						else if (item2.DBObjectName.ToLower() == "crmcompanypersons")
						{
							text = Labels.lblPrs;
						}
					}
					string text2 = item2.FieldTitle ?? "";
					if (!string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text))
					{
						text2 = text2 + " - " + text;
					}
					SelectListItem item = new SelectListItem
					{
						Text = text2,
						Value = item2.DBObjectId.ToString(),
						Selected = false
					};
					list.Add(item);
				}
			}
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SysDBObjectList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public bool checkMultiLanguage(string defaultValue, List<CommonMultiLanguageViewModel> list)
	{
		bool result = true;
		List<CRMspSelectUserLanguages_Result> list2 = CRMIdeal.Cache.User.Language.Get();
		bool isCurrentUserAllowCopyOtherLanguage = UserLogin.IsCurrentUserAllowCopyOtherLanguage;
		foreach (Languages itemLang in CRMIdeal.Cache.Setting.Language.Get())
		{
			CommonMultiLanguageViewModel commonMultiLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == itemLang.LanguageID));
			if (commonMultiLanguageViewModel == null)
			{
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						list.Add(new CommonMultiLanguageViewModel
						{
							LanguageId = itemLang.LanguageID,
							Value = defaultValue
						});
					}
					else
					{
						result = false;
					}
				}
				else
				{
					list.Add(new CommonMultiLanguageViewModel
					{
						LanguageId = itemLang.LanguageID,
						Value = defaultValue
					});
				}
			}
			else
			{
				if (!string.IsNullOrEmpty(commonMultiLanguageViewModel.Value))
				{
					continue;
				}
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						commonMultiLanguageViewModel.Value = defaultValue;
					}
					else
					{
						result = false;
					}
				}
				else
				{
					commonMultiLanguageViewModel.Value = defaultValue;
				}
			}
		}
		return result;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDyDefineForm", ActionName = "actDeleteField")]
	public string DeleteField(int fieldId)
	{
		_003C_003Ec__DisplayClass9_0 _003C_003Ec__DisplayClass9_ = new _003C_003Ec__DisplayClass9_0();
		_003C_003Ec__DisplayClass9_.fieldId = fieldId;
		string result = "";
		try
		{
			DbSet<CrmDyFormFields> crmDyFormFields = _dbTbl.CrmDyFormFields;
			ParameterExpression val = Expression.Parameter(typeof(CrmDyFormFields), "c");
			if (Queryable.FirstOrDefault<CrmDyFormFields>((IQueryable<CrmDyFormFields>)crmDyFormFields, Expression.Lambda<Func<CrmDyFormFields, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass9_, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				try
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
					if (result2 <= 0)
					{
						result2 = 1065;
					}
					_ = Thread.CurrentThread.CurrentCulture.LCID;
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDyDeleteFormField(_003C_003Ec__DisplayClass9_.fieldId)));
					if (mct_Result != null && mct_Result.Result > 0)
					{
						result = "";
					}
					else if (mct_Result != null && mct_Result.Result == 0)
					{
						result = Messages.RedundancyMessage;
					}
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					result = Messages.RedundancyMessage;
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					result = Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
				}
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	public void SetRegisterInfo(CrmDyFormFieldsLanguageViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		try
		{
			string text3 = "";
			string text4 = "";
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(model.FirstRegisterUserId + "," + model.UserId);
			if (Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
				text3 = ((cRMspSelectUsersByIds_Result != null) ? (cRMspSelectUsersByIds_Result.LName + ((cRMspSelectUsersByIds_Result.FName != null) ? (" " + cRMspSelectUsersByIds_Result.FName) : "")) : "");
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
				text4 = ((cRMspSelectUsersByIds_Result2 != null) ? (cRMspSelectUsersByIds_Result2.LName + ((cRMspSelectUsersByIds_Result2.FName != null) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "")) : "");
			}
			_ = model.FirstRegisterDate;
			string text5 = model.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			_ = model.RegisterDate;
			string text6 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			if (string.IsNullOrEmpty(model.AppType))
			{
				model.AppType = Configuration.AppType;
			}
			string text7 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
			text = Labels.frmFirstRegisterUser + ": " + text3 + " (" + text5 + ")";
			text2 = Labels.frmRegisterUser + ": " + text4 + " (" + text7 + ") (" + text6 + ")";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FirstRegisterInfo = text;
		base.ViewBag.EditInfo = text2;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetDbObjectValList(int dbObjId, string selectedId = "")
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspSelectSysDBObjectsByIds_Result cRMspSelectSysDBObjectsByIds_Result = Enumerable.FirstOrDefault<CRMspSelectSysDBObjectsByIds_Result>((IEnumerable<CRMspSelectSysDBObjectsByIds_Result>)_dbII.CRMspSelectSysDBObjectsByIds(dbObjId.ToString(), ",", lCID, result2));
			if (cRMspSelectSysDBObjectsByIds_Result != null)
			{
				string text = (cRMspSelectSysDBObjectsByIds_Result.DBObjectName ?? "").ToLower();
				string text2 = (cRMspSelectSysDBObjectsByIds_Result.FieldName ?? "").ToLower();
				List<SelectListItem> list = new List<SelectListItem>();
				if (text == "crmcompany")
				{
					switch (text2)
					{
					case "cmpsubgroupid":
						list = GetCmpSubGroupList();
						break;
					case "cmpgroupid":
						list = GetCmpGroupList();
						break;
					case "cmpgroupidii":
						list = GetCmpGroupIIList();
						break;
					case "cmpgroupidiii":
						list = GetCmpGroupIIIList();
						break;
					case "cmpgroupidiv":
						list = GetCmpGroupIVList();
						break;
					case "cmptitleid":
						list = GetCmpTitleList();
						break;
					case "cmppresentationid":
						list = GetCmpPresentationList();
						break;
					case "cmptypeid":
						list = GetCmpTypeList();
						break;
					}
				}
				else if (text == "crmcompanypersons")
				{
					switch (text2)
					{
					case "prstitleid":
						list = GetPrsTitleList();
						break;
					case "prsjobid":
						list = GetPrsJobList();
						break;
					case "prseducationid":
						list = GetPrsEducationList();
						break;
					}
				}
				if (list != null)
				{
					result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<SelectListItem, nComboBoxListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, nComboBoxListItem>)((SelectListItem item) => new nComboBoxListItem
					{
						Text = item.Text,
						Value = item.Value,
						Selected = (item.Value == selectedId)
					}))));
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public List<SelectListItem> GetCmpGroupList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> result2 = new List<SelectListItem>();
		try
		{
			int result3 = 0;
			int value = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
				value = UserLogin.CurrentUser.UserId;
			}
			result2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroup_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroup_Result>)Enumerable.ToList<CRMspSelectCompanyGroup_Result>((IEnumerable<CRMspSelectCompanyGroup_Result>)_db.CRMspSelectCompanyGroup(value, lCID, result, result3)), (Func<CRMspSelectCompanyGroup_Result, SelectListItem>)((CRMspSelectCompanyGroup_Result item) => new SelectListItem
			{
				Text = item.GroupName,
				Value = item.CompanyGroupID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public List<SelectListItem> GetCmpSubGroupList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> result2 = new List<SelectListItem>();
		try
		{
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			result2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspDySelectCompanySubGroup_Result, SelectListItem>((IEnumerable<CRMspDySelectCompanySubGroup_Result>)Enumerable.ToList<CRMspDySelectCompanySubGroup_Result>((IEnumerable<CRMspDySelectCompanySubGroup_Result>)_dbII.CRMspDySelectCompanySubGroup(UserLogin.CurrentUser.UserId, 0, result3, lCID, result)), (Func<CRMspDySelectCompanySubGroup_Result, SelectListItem>)((CRMspDySelectCompanySubGroup_Result item) => new SelectListItem
			{
				Text = ((!string.IsNullOrWhiteSpace(item.GroupName)) ? item.GroupName : "") + ((!string.IsNullOrWhiteSpace(item.GroupName) && !string.IsNullOrWhiteSpace(item.SubGroupName)) ? " - " : "") + ((!string.IsNullOrWhiteSpace(item.SubGroupName)) ? item.SubGroupName : ""),
				Value = item.CompanySubGroupID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public List<SelectListItem> GetCmpGroupIIList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> result2 = new List<SelectListItem>();
		try
		{
			result2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroupsII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)Enumerable.ToList<CRMspSelectCompanyGroupsII_Result>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)_db.CRMspSelectCompanyGroupsII(lCID, result)), (Func<CRMspSelectCompanyGroupsII_Result, SelectListItem>)((CRMspSelectCompanyGroupsII_Result item) => new SelectListItem
			{
				Text = item.GroupIIName,
				Value = item.CompanyGroupIIID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public List<SelectListItem> GetCmpGroupIIIList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> result2 = new List<SelectListItem>();
		try
		{
			result2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroupsIII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)Enumerable.ToList<CRMspSelectCompanyGroupsIII_Result>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)_db.CRMspSelectCompanyGroupsIII(lCID, result)), (Func<CRMspSelectCompanyGroupsIII_Result, SelectListItem>)((CRMspSelectCompanyGroupsIII_Result item) => new SelectListItem
			{
				Text = item.GroupIIIName,
				Value = item.CompanyGroupIIIID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public List<SelectListItem> GetCmpGroupIVList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> result2 = new List<SelectListItem>();
		try
		{
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			result2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroupsIV_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIV_Result>)Enumerable.ToList<CRMspSelectCompanyGroupsIV_Result>((IEnumerable<CRMspSelectCompanyGroupsIV_Result>)_db.CRMspSelectCompanyGroupsIV(UserLogin.CurrentUser.UserId, lCID, result, result3)), (Func<CRMspSelectCompanyGroupsIV_Result, SelectListItem>)((CRMspSelectCompanyGroupsIV_Result item) => new SelectListItem
			{
				Text = item.GroupIVName,
				Value = item.CompanyGroupIVID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public List<SelectListItem> GetCmpTitleList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> result2 = new List<SelectListItem>();
		try
		{
			result2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyTitle_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyTitle_Result>)Enumerable.ToList<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)_db.CRMspSelectCompanyTitle(lCID, result)), (Func<CRMspSelectCompanyTitle_Result, SelectListItem>)((CRMspSelectCompanyTitle_Result item) => new SelectListItem
			{
				Text = item.CompanyTitle,
				Value = item.CompanyTitleID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public List<SelectListItem> GetCmpPresentationList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> result2 = new List<SelectListItem>();
		try
		{
			result2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyPresentation_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyPresentation_Result>)Enumerable.ToList<CRMspSelectCompanyPresentation_Result>((IEnumerable<CRMspSelectCompanyPresentation_Result>)_db.CRMspSelectCompanyPresentation(lCID, result)), (Func<CRMspSelectCompanyPresentation_Result, SelectListItem>)((CRMspSelectCompanyPresentation_Result item) => new SelectListItem
			{
				Text = item.Presentation,
				Value = item.CompanyPresentationID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public List<SelectListItem> GetCmpTypeList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> result2 = new List<SelectListItem>();
		try
		{
			result2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyType_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyType_Result>)Enumerable.ToList<CRMspSelectCompanyType_Result>((IEnumerable<CRMspSelectCompanyType_Result>)_db.CRMspSelectCompanyType(lCID, result)), (Func<CRMspSelectCompanyType_Result, SelectListItem>)((CRMspSelectCompanyType_Result item) => new SelectListItem
			{
				Text = item.CompanyTypeName,
				Value = item.CompanyTypeID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public List<SelectListItem> GetPrsTitleList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> result2 = new List<SelectListItem>();
		try
		{
			result2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectPersonTitle_Result, SelectListItem>((IEnumerable<CRMspSelectPersonTitle_Result>)Enumerable.ToList<CRMspSelectPersonTitle_Result>((IEnumerable<CRMspSelectPersonTitle_Result>)_db.CRMspSelectPersonTitle(lCID, result)), (Func<CRMspSelectPersonTitle_Result, SelectListItem>)((CRMspSelectPersonTitle_Result item) => new SelectListItem
			{
				Text = item.PersonTitle,
				Value = item.PersonTitleID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public List<SelectListItem> GetPrsJobList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> result2 = new List<SelectListItem>();
		try
		{
			result2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectPersonJobs_Result, SelectListItem>((IEnumerable<CRMspSelectPersonJobs_Result>)Enumerable.ToList<CRMspSelectPersonJobs_Result>((IEnumerable<CRMspSelectPersonJobs_Result>)Enumerable.OrderBy<CRMspSelectPersonJobs_Result, string>((IEnumerable<CRMspSelectPersonJobs_Result>)Enumerable.ToList<CRMspSelectPersonJobs_Result>((IEnumerable<CRMspSelectPersonJobs_Result>)_db.CRMspSelectPersonJobs(lCID, result)), (Func<CRMspSelectPersonJobs_Result, string>)((CRMspSelectPersonJobs_Result c) => c.Jobs))), (Func<CRMspSelectPersonJobs_Result, SelectListItem>)((CRMspSelectPersonJobs_Result item) => new SelectListItem
			{
				Text = item.Jobs,
				Value = item.PersonJobID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public List<SelectListItem> GetPrsEducationList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> result2 = new List<SelectListItem>();
		try
		{
			result2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectEducation_Result, SelectListItem>((IEnumerable<CRMspSelectEducation_Result>)Enumerable.ToList<CRMspSelectEducation_Result>((IEnumerable<CRMspSelectEducation_Result>)_db.CRMspSelectEducation(lCID, result)), (Func<CRMspSelectEducation_Result, SelectListItem>)((CRMspSelectEducation_Result item) => new SelectListItem
			{
				Text = item.Education,
				Value = item.EducationID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
