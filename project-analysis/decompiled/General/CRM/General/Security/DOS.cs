using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Microsoft.CSharp.RuntimeBinder;

namespace CRM.General.Security;

public class DOS
{
	private class Users_Data
	{
		public dynamic UID { get; set; }

		public dynamic Type { get; set; }

		public DateTime LastReqDate { get; set; }

		public string LastUrl { get; set; }

		public List<Requests_Data> Requests { get; set; }

		public int DOS_Detected_Cnt { get; set; }

		public int DOS_Passed_Cnt { get; set; }
	}

	private class Requests_Data
	{
		public DateTime ReqDate { get; set; }

		public string URL { get; set; }
	}

	public class DOS_Result
	{
		public dynamic UID { get; set; }

		public dynamic Type { get; set; }

		public int TotalRequestsCnt { get; set; }

		public int PassedBanCnt { get; set; }

		public DateTime FirstRequestDate { get; set; }

		public string FirstRequestUrl { get; set; }

		public DateTime LastRequestDate { get; set; }

		public string LastRequestUrl { get; set; }

		public string Message { get; set; }
	}

	[CompilerGenerated]
	private static class _003C_003Eo__10
	{
		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__0;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__1;
	}

	[CompilerGenerated]
	private static class _003C_003Eo__4
	{
		public static CallSite<Func<CallSite, Type, object, object, object>> _003C_003Ep__0;

		public static CallSite<Func<CallSite, object, int, object>> _003C_003Ep__1;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__2;

		public static CallSite<Action<CallSite, Type, DateTime, object, object, object, string>> _003C_003Ep__3;

		public static CallSite<Func<CallSite, List<Users_Data>, object, object>> _003C_003Ep__4;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__5;

		public static CallSite<Func<CallSite, DateTime, object, object>> _003C_003Ep__6;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__7;

		public static CallSite<Func<CallSite, object, int, object>> _003C_003Ep__8;

		public static CallSite<Func<CallSite, List<Users_Data>, object, object>> _003C_003Ep__9;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__10;

		public static CallSite<Func<CallSite, object, int, object>> _003C_003Ep__11;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__12;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__13;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__14;

		public static CallSite<Action<CallSite, Type, object>> _003C_003Ep__15;

		public static CallSite<Func<CallSite, object, int, object>> _003C_003Ep__16;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__17;

		public static CallSite<Action<CallSite, Type, object>> _003C_003Ep__18;

		public static CallSite<Func<CallSite, List<Users_Data>, object, object>> _003C_003Ep__19;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__20;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__21;

		public static CallSite<Func<CallSite, object, int, object>> _003C_003Ep__22;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__23;

		public static CallSite<Func<CallSite, List<Users_Data>, object, object>> _003C_003Ep__24;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__25;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__26;

		public static CallSite<Func<CallSite, object, int, object>> _003C_003Ep__27;

		public static CallSite<Func<CallSite, object, int, object>> _003C_003Ep__28;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__29;

		public static CallSite<Action<CallSite, Type, object>> _003C_003Ep__30;

		public static CallSite<Action<CallSite, Type, DateTime, object, object, object, string>> _003C_003Ep__31;

		public static CallSite<Func<CallSite, Type, object, object, object>> _003C_003Ep__32;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__33;

		public static CallSite<Func<CallSite, object, object>> _003C_003Ep__34;

		public static CallSite<Func<CallSite, object, int, object>> _003C_003Ep__35;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__36;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__37;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__38;

		public static CallSite<Func<CallSite, object, int, object>> _003C_003Ep__39;

		public static CallSite<Func<CallSite, object, DOS_Result>> _003C_003Ep__40;
	}

	[CompilerGenerated]
	private static class _003C_003Eo__5
	{
		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__0;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__1;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__2;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__3;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__4;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__5;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__6;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__7;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__8;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__9;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__10;
	}

	[CompilerGenerated]
	private static class _003C_003Eo__8
	{
		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__0;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__1;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__2;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__3;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__4;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__5;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__6;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__7;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__8;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__9;

		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__10;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__11;

		public static CallSite<Func<CallSite, object, bool, object>> _003C_003Ep__12;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__13;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__14;
	}

	[CompilerGenerated]
	private static class _003C_003Eo__9
	{
		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__0;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__1;
	}

	public const string TypeUser = "1";

	public const string TypeCmp = "2";

	private const int MaxReqCount = 15;

	private static List<Users_Data> lstRequests = new List<Users_Data>();

	public static DOS_Result Check(dynamic uId = null, dynamic type = null, string url = null)
	{
		DOS_Result dOS_Result = new DOS_Result();
		string message = "";
		DateTime now = DateTime.Now;
		try
		{
			dynamic index = DOS.GetIndex(uId, type);
			if (_003C_003Eo__4._003C_003Ep__2 == null)
			{
				_003C_003Eo__4._003C_003Ep__2 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(DOS), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Func<CallSite, object, bool> target = _003C_003Eo__4._003C_003Ep__2.Target;
			CallSite<Func<CallSite, object, bool>> _003C_003Ep__ = _003C_003Eo__4._003C_003Ep__2;
			if (_003C_003Eo__4._003C_003Ep__1 == null)
			{
				_003C_003Eo__4._003C_003Ep__1 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)13, typeof(DOS), new CSharpArgumentInfo[2]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
				}));
			}
			dynamic val;
			if (target((CallSite)(object)_003C_003Ep__, _003C_003Eo__4._003C_003Ep__1.Target((CallSite)(object)_003C_003Eo__4._003C_003Ep__1, (object)index, -1)))
			{
				DOS.Add(now, index, uId, type, url);
			}
			else
			{
				object arg = lstRequests[index].LastReqDate;
				if (_003C_003Eo__4._003C_003Ep__6 == null)
				{
					_003C_003Eo__4._003C_003Ep__6 = CallSite<Func<CallSite, DateTime, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)42, typeof(DOS), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				object arg2 = ((dynamic)_003C_003Eo__4._003C_003Ep__6.Target((CallSite)(object)_003C_003Eo__4._003C_003Ep__6, now, arg)).Seconds;
				if (_003C_003Eo__4._003C_003Ep__14 == null)
				{
					_003C_003Eo__4._003C_003Ep__14 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(DOS), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				Func<CallSite, object, bool> target2 = _003C_003Eo__4._003C_003Ep__14.Target;
				CallSite<Func<CallSite, object, bool>> _003C_003Ep__2 = _003C_003Eo__4._003C_003Ep__14;
				if (_003C_003Eo__4._003C_003Ep__8 == null)
				{
					_003C_003Eo__4._003C_003Ep__8 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)15, typeof(DOS), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				val = _003C_003Eo__4._003C_003Ep__8.Target((CallSite)(object)_003C_003Eo__4._003C_003Ep__8, arg2, 43200);
				if (_003C_003Eo__4._003C_003Ep__13 == null)
				{
					_003C_003Eo__4._003C_003Ep__13 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)84, typeof(DOS), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				dynamic arg4;
				if (!_003C_003Eo__4._003C_003Ep__13.Target((CallSite)(object)_003C_003Eo__4._003C_003Ep__13, (object)val))
				{
					if (_003C_003Eo__4._003C_003Ep__12 == null)
					{
						_003C_003Eo__4._003C_003Ep__12 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(DOS), new CSharpArgumentInfo[2]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, object, object> target3 = _003C_003Eo__4._003C_003Ep__12.Target;
					CallSite<Func<CallSite, object, object, object>> _003C_003Ep__3 = _003C_003Eo__4._003C_003Ep__12;
					dynamic arg3 = val;
					if (_003C_003Eo__4._003C_003Ep__11 == null)
					{
						_003C_003Eo__4._003C_003Ep__11 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)21, typeof(DOS), new CSharpArgumentInfo[2]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					arg4 = target3((CallSite)(object)_003C_003Ep__3, (object)arg3, _003C_003Eo__4._003C_003Ep__11.Target((CallSite)(object)_003C_003Eo__4._003C_003Ep__11, (object)lstRequests[index].DOS_Detected_Cnt, 3));
				}
				else
				{
					arg4 = val;
				}
				if (target2((CallSite)(object)_003C_003Ep__2, (object)arg4))
				{
					DOS.RemoveRequestsWithIndex(index);
				}
				else
				{
					if (_003C_003Eo__4._003C_003Ep__17 == null)
					{
						_003C_003Eo__4._003C_003Ep__17 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(DOS), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					Func<CallSite, object, bool> target4 = _003C_003Eo__4._003C_003Ep__17.Target;
					CallSite<Func<CallSite, object, bool>> _003C_003Ep__4 = _003C_003Eo__4._003C_003Ep__17;
					if (_003C_003Eo__4._003C_003Ep__16 == null)
					{
						_003C_003Eo__4._003C_003Ep__16 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)16, typeof(DOS), new CSharpArgumentInfo[2]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					if (target4((CallSite)(object)_003C_003Ep__4, _003C_003Eo__4._003C_003Ep__16.Target((CallSite)(object)_003C_003Eo__4._003C_003Ep__16, arg2, 3)))
					{
						DOS.RemoveRequestsWithIndex(index);
					}
					else
					{
						if (_003C_003Eo__4._003C_003Ep__23 == null)
						{
							_003C_003Eo__4._003C_003Ep__23 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(DOS), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, bool> target5 = _003C_003Eo__4._003C_003Ep__23.Target;
						CallSite<Func<CallSite, object, bool>> _003C_003Ep__5 = _003C_003Eo__4._003C_003Ep__23;
						if (_003C_003Eo__4._003C_003Ep__22 == null)
						{
							_003C_003Eo__4._003C_003Ep__22 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)13, typeof(DOS), new CSharpArgumentInfo[2]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						if (target5((CallSite)(object)_003C_003Ep__5, _003C_003Eo__4._003C_003Ep__22.Target((CallSite)(object)_003C_003Eo__4._003C_003Ep__22, (object)lstRequests[index].Requests.Count, 15)))
						{
							val = lstRequests[index];
							bool flag = (byte)/*OpCode not supported: DynamicIsEventInstruction*/ != 0;
							object arg5 = default(object);
							if (!flag)
							{
								arg5 = val.DOS_Detected_Cnt;
							}
							if (flag)
							{
								val.add_DOS_Detected_Cnt(1);
							}
							else
							{
								dynamic val2 = val;
								if (_003C_003Eo__4._003C_003Ep__28 == null)
								{
									_003C_003Eo__4._003C_003Ep__28 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)63, typeof(DOS), new CSharpArgumentInfo[2]
									{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
									}));
								}
								val2.DOS_Detected_Cnt = _003C_003Eo__4._003C_003Ep__28.Target((CallSite)(object)_003C_003Eo__4._003C_003Ep__28, arg5, 1);
							}
							DOS.RemoveRequestsWithIndex(index);
						}
					}
				}
				DOS.Add(now, index, uId, type, url);
			}
			dynamic summary = DOS.GetSummary(uId, type);
			if (_003C_003Eo__4._003C_003Ep__38 == null)
			{
				_003C_003Eo__4._003C_003Ep__38 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(DOS), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Func<CallSite, object, bool> target6 = _003C_003Eo__4._003C_003Ep__38.Target;
			CallSite<Func<CallSite, object, bool>> _003C_003Ep__6 = _003C_003Eo__4._003C_003Ep__38;
			if (_003C_003Eo__4._003C_003Ep__33 == null)
			{
				_003C_003Eo__4._003C_003Ep__33 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(DOS), new CSharpArgumentInfo[2]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
				}));
			}
			val = _003C_003Eo__4._003C_003Ep__33.Target((CallSite)(object)_003C_003Eo__4._003C_003Ep__33, (object)summary, null);
			if (_003C_003Eo__4._003C_003Ep__37 == null)
			{
				_003C_003Eo__4._003C_003Ep__37 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)84, typeof(DOS), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			dynamic arg7;
			if (!_003C_003Eo__4._003C_003Ep__37.Target((CallSite)(object)_003C_003Eo__4._003C_003Ep__37, (object)val))
			{
				if (_003C_003Eo__4._003C_003Ep__36 == null)
				{
					_003C_003Eo__4._003C_003Ep__36 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(DOS), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, object, object, object> target7 = _003C_003Eo__4._003C_003Ep__36.Target;
				CallSite<Func<CallSite, object, object, object>> _003C_003Ep__7 = _003C_003Eo__4._003C_003Ep__36;
				dynamic arg6 = val;
				if (_003C_003Eo__4._003C_003Ep__35 == null)
				{
					_003C_003Eo__4._003C_003Ep__35 = CallSite<Func<CallSite, object, int, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(DOS), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				arg7 = target7((CallSite)(object)_003C_003Ep__7, (object)arg6, _003C_003Eo__4._003C_003Ep__35.Target((CallSite)(object)_003C_003Eo__4._003C_003Ep__35, (object)summary.Count, 0));
			}
			else
			{
				arg7 = val;
			}
			if (target6((CallSite)(object)_003C_003Ep__6, (object)arg7))
			{
				dOS_Result = summary[0];
			}
			dOS_Result.Message = message;
		}
		catch (Exception ex)
		{
			message = ex.Message;
		}
		return dOS_Result;
	}

	private static int GetIndex(dynamic uId = null, dynamic type = null)
	{
		return lstRequests.FindIndex(delegate(Users_Data x)
		{
			if (_003C_003Eo__5._003C_003Ep__0 == null)
			{
				_003C_003Eo__5._003C_003Ep__0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)13, typeof(DOS), new CSharpArgumentInfo[2]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			object obj = _003C_003Eo__5._003C_003Ep__0.Target((CallSite)(object)_003C_003Eo__5._003C_003Ep__0, (object)x.UID, (object)uId);
			if (_003C_003Eo__5._003C_003Ep__9 == null)
			{
				_003C_003Eo__5._003C_003Ep__9 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)84, typeof(DOS), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			object val;
			if (!_003C_003Eo__5._003C_003Ep__9.Target((CallSite)(object)_003C_003Eo__5._003C_003Ep__9, obj))
			{
				if (_003C_003Eo__5._003C_003Ep__8 == null)
				{
					_003C_003Eo__5._003C_003Ep__8 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(DOS), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, object, object, object> target = _003C_003Eo__5._003C_003Ep__8.Target;
				CallSite<Func<CallSite, object, object, object>> _003C_003Ep__ = _003C_003Eo__5._003C_003Ep__8;
				if (_003C_003Eo__5._003C_003Ep__1 == null)
				{
					_003C_003Eo__5._003C_003Ep__1 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)13, typeof(DOS), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				object obj2 = _003C_003Eo__5._003C_003Ep__1.Target((CallSite)(object)_003C_003Eo__5._003C_003Ep__1, (object)type, null);
				if (_003C_003Eo__5._003C_003Ep__7 == null)
				{
					_003C_003Eo__5._003C_003Ep__7 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(DOS), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				object arg2;
				if (!_003C_003Eo__5._003C_003Ep__7.Target((CallSite)(object)_003C_003Eo__5._003C_003Ep__7, obj2))
				{
					if (_003C_003Eo__5._003C_003Ep__6 == null)
					{
						_003C_003Eo__5._003C_003Ep__6 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)36, typeof(DOS), new CSharpArgumentInfo[2]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, object, object> target2 = _003C_003Eo__5._003C_003Ep__6.Target;
					CallSite<Func<CallSite, object, object, object>> _003C_003Ep__2 = _003C_003Eo__5._003C_003Ep__6;
					if (_003C_003Eo__5._003C_003Ep__2 == null)
					{
						_003C_003Eo__5._003C_003Ep__2 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(DOS), new CSharpArgumentInfo[2]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					object obj3 = _003C_003Eo__5._003C_003Ep__2.Target((CallSite)(object)_003C_003Eo__5._003C_003Ep__2, (object)type, null);
					if (_003C_003Eo__5._003C_003Ep__5 == null)
					{
						_003C_003Eo__5._003C_003Ep__5 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)84, typeof(DOS), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					object arg;
					if (!_003C_003Eo__5._003C_003Ep__5.Target((CallSite)(object)_003C_003Eo__5._003C_003Ep__5, obj3))
					{
						if (_003C_003Eo__5._003C_003Ep__4 == null)
						{
							_003C_003Eo__5._003C_003Ep__4 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(DOS), new CSharpArgumentInfo[2]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, object, object> target3 = _003C_003Eo__5._003C_003Ep__4.Target;
						CallSite<Func<CallSite, object, object, object>> _003C_003Ep__3 = _003C_003Eo__5._003C_003Ep__4;
						if (_003C_003Eo__5._003C_003Ep__3 == null)
						{
							_003C_003Eo__5._003C_003Ep__3 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)13, typeof(DOS), new CSharpArgumentInfo[2]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						arg = target3((CallSite)(object)_003C_003Ep__3, obj3, _003C_003Eo__5._003C_003Ep__3.Target((CallSite)(object)_003C_003Eo__5._003C_003Ep__3, (object)x.Type, (object)type));
					}
					else
					{
						arg = obj3;
					}
					arg2 = target2((CallSite)(object)_003C_003Ep__2, obj2, arg);
				}
				else
				{
					arg2 = obj2;
				}
				val = target((CallSite)(object)_003C_003Ep__, obj, arg2);
			}
			else
			{
				val = obj;
			}
			return (dynamic)val;
		});
	}

	private static void Add(DateTime reqDate, int foundedIndx = -1, dynamic uId = null, dynamic type = null, string url = null)
	{
		Users_Data users_Data = new Users_Data();
		if (foundedIndx == -1)
		{
			foundedIndx = DOS.GetIndex(uId, type);
		}
		if (foundedIndx == -1)
		{
			users_Data.UID = (object)uId;
			users_Data.Type = (object)type;
			users_Data.LastReqDate = reqDate;
			users_Data.LastUrl = url;
			users_Data.Requests = new List<Requests_Data>();
			users_Data.Requests.Add(new Requests_Data
			{
				URL = url,
				ReqDate = reqDate
			});
			lstRequests.Add(users_Data);
		}
		else
		{
			lstRequests[foundedIndx].Requests.Add(new Requests_Data
			{
				ReqDate = reqDate,
				URL = url
			});
			lstRequests[foundedIndx].LastReqDate = reqDate;
			lstRequests[foundedIndx].LastUrl = url;
		}
	}

	private static void RemoveRequestsWithIndex(int indx = -1)
	{
		if (indx != -1)
		{
			lstRequests[indx].Requests.Clear();
		}
	}

	public static List<DOS_Result> GetSummary(dynamic uId = null, dynamic type = null, int cnt = 0)
	{
		List<DOS_Result> list = new List<DOS_Result>();
		if (_003C_003Eo__8._003C_003Ep__1 == null)
		{
			_003C_003Eo__8._003C_003Ep__1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(DOS), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
		}
		Func<CallSite, object, bool> target = _003C_003Eo__8._003C_003Ep__1.Target;
		CallSite<Func<CallSite, object, bool>> _003C_003Ep__ = _003C_003Eo__8._003C_003Ep__1;
		if (_003C_003Eo__8._003C_003Ep__0 == null)
		{
			_003C_003Eo__8._003C_003Ep__0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(DOS), new CSharpArgumentInfo[2]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
			}));
		}
		if (target((CallSite)(object)_003C_003Ep__, _003C_003Eo__8._003C_003Ep__0.Target((CallSite)(object)_003C_003Eo__8._003C_003Ep__0, (object)uId, null)))
		{
			List<Users_Data> list2 = Enumerable.ToList<Users_Data>(Enumerable.Where<Users_Data>((IEnumerable<Users_Data>)lstRequests, (Func<Users_Data, bool>)delegate(Users_Data x)
			{
				if (_003C_003Eo__8._003C_003Ep__2 == null)
				{
					_003C_003Eo__8._003C_003Ep__2 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)13, typeof(DOS), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				object obj = _003C_003Eo__8._003C_003Ep__2.Target((CallSite)(object)_003C_003Eo__8._003C_003Ep__2, (object)x.UID, (object)uId);
				if (_003C_003Eo__8._003C_003Ep__11 == null)
				{
					_003C_003Eo__8._003C_003Ep__11 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)84, typeof(DOS), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				object obj4;
				if (!_003C_003Eo__8._003C_003Ep__11.Target((CallSite)(object)_003C_003Eo__8._003C_003Ep__11, obj))
				{
					if (_003C_003Eo__8._003C_003Ep__10 == null)
					{
						_003C_003Eo__8._003C_003Ep__10 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(DOS), new CSharpArgumentInfo[2]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, object, object, object> target2 = _003C_003Eo__8._003C_003Ep__10.Target;
					CallSite<Func<CallSite, object, object, object>> _003C_003Ep__2 = _003C_003Eo__8._003C_003Ep__10;
					if (_003C_003Eo__8._003C_003Ep__3 == null)
					{
						_003C_003Eo__8._003C_003Ep__3 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)13, typeof(DOS), new CSharpArgumentInfo[2]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					object obj2 = _003C_003Eo__8._003C_003Ep__3.Target((CallSite)(object)_003C_003Eo__8._003C_003Ep__3, (object)type, null);
					if (_003C_003Eo__8._003C_003Ep__9 == null)
					{
						_003C_003Eo__8._003C_003Ep__9 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(DOS), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					object arg2;
					if (!_003C_003Eo__8._003C_003Ep__9.Target((CallSite)(object)_003C_003Eo__8._003C_003Ep__9, obj2))
					{
						if (_003C_003Eo__8._003C_003Ep__8 == null)
						{
							_003C_003Eo__8._003C_003Ep__8 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)36, typeof(DOS), new CSharpArgumentInfo[2]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, object, object> target3 = _003C_003Eo__8._003C_003Ep__8.Target;
						CallSite<Func<CallSite, object, object, object>> _003C_003Ep__3 = _003C_003Eo__8._003C_003Ep__8;
						if (_003C_003Eo__8._003C_003Ep__4 == null)
						{
							_003C_003Eo__8._003C_003Ep__4 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)35, typeof(DOS), new CSharpArgumentInfo[2]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						object obj3 = _003C_003Eo__8._003C_003Ep__4.Target((CallSite)(object)_003C_003Eo__8._003C_003Ep__4, (object)type, null);
						if (_003C_003Eo__8._003C_003Ep__7 == null)
						{
							_003C_003Eo__8._003C_003Ep__7 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)84, typeof(DOS), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						object arg;
						if (!_003C_003Eo__8._003C_003Ep__7.Target((CallSite)(object)_003C_003Eo__8._003C_003Ep__7, obj3))
						{
							if (_003C_003Eo__8._003C_003Ep__6 == null)
							{
								_003C_003Eo__8._003C_003Ep__6 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(DOS), new CSharpArgumentInfo[2]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Func<CallSite, object, object, object> target4 = _003C_003Eo__8._003C_003Ep__6.Target;
							CallSite<Func<CallSite, object, object, object>> _003C_003Ep__4 = _003C_003Eo__8._003C_003Ep__6;
							if (_003C_003Eo__8._003C_003Ep__5 == null)
							{
								_003C_003Eo__8._003C_003Ep__5 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)13, typeof(DOS), new CSharpArgumentInfo[2]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							arg = target4((CallSite)(object)_003C_003Ep__4, obj3, _003C_003Eo__8._003C_003Ep__5.Target((CallSite)(object)_003C_003Eo__8._003C_003Ep__5, (object)x.Type, (object)type));
						}
						else
						{
							arg = obj3;
						}
						arg2 = target3((CallSite)(object)_003C_003Ep__3, obj2, arg);
					}
					else
					{
						arg2 = obj2;
					}
					obj4 = target2((CallSite)(object)_003C_003Ep__2, obj, arg2);
				}
				else
				{
					obj4 = obj;
				}
				object obj5 = obj4;
				if (_003C_003Eo__8._003C_003Ep__13 == null)
				{
					_003C_003Eo__8._003C_003Ep__13 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)84, typeof(DOS), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				object val;
				if (!_003C_003Eo__8._003C_003Ep__13.Target((CallSite)(object)_003C_003Eo__8._003C_003Ep__13, obj5))
				{
					if (_003C_003Eo__8._003C_003Ep__12 == null)
					{
						_003C_003Eo__8._003C_003Ep__12 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(DOS), new CSharpArgumentInfo[2]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
						}));
					}
					val = _003C_003Eo__8._003C_003Ep__12.Target((CallSite)(object)_003C_003Eo__8._003C_003Ep__12, obj5, x.DOS_Detected_Cnt > cnt);
				}
				else
				{
					val = obj5;
				}
				return (dynamic)val;
			}));
			if (list2 != null)
			{
				foreach (Users_Data item in list2)
				{
					list.Add(new DOS_Result
					{
						UID = item.UID,
						Type = item.Type,
						TotalRequestsCnt = item.DOS_Detected_Cnt,
						FirstRequestDate = Enumerable.FirstOrDefault<Requests_Data>((IEnumerable<Requests_Data>)item.Requests).ReqDate,
						FirstRequestUrl = Enumerable.FirstOrDefault<Requests_Data>((IEnumerable<Requests_Data>)item.Requests).URL,
						LastRequestDate = Enumerable.FirstOrDefault<Requests_Data>((IEnumerable<Requests_Data>)item.Requests).ReqDate,
						LastRequestUrl = Enumerable.FirstOrDefault<Requests_Data>((IEnumerable<Requests_Data>)item.Requests).URL,
						PassedBanCnt = item.DOS_Passed_Cnt
					});
				}
			}
		}
		return list;
	}

	public static void UpdatePassedTime(dynamic uId = null)
	{
		for (int i = 0; i < lstRequests.Count; i++)
		{
			if (_003C_003Eo__9._003C_003Ep__1 == null)
			{
				_003C_003Eo__9._003C_003Ep__1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(DOS), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Func<CallSite, object, bool> target = _003C_003Eo__9._003C_003Ep__1.Target;
			CallSite<Func<CallSite, object, bool>> _003C_003Ep__ = _003C_003Eo__9._003C_003Ep__1;
			if (_003C_003Eo__9._003C_003Ep__0 == null)
			{
				_003C_003Eo__9._003C_003Ep__0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)13, typeof(DOS), new CSharpArgumentInfo[2]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			if (target((CallSite)(object)_003C_003Ep__, _003C_003Eo__9._003C_003Ep__0.Target((CallSite)(object)_003C_003Eo__9._003C_003Ep__0, (object)lstRequests[i].UID, (object)uId)))
			{
				lstRequests[i].DOS_Passed_Cnt++;
			}
		}
	}

	public static bool Reset(dynamic uId = null)
	{
		lstRequests.RemoveAll(delegate(Users_Data x)
		{
			if (_003C_003Eo__10._003C_003Ep__0 == null)
			{
				_003C_003Eo__10._003C_003Ep__0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)13, typeof(DOS), new CSharpArgumentInfo[2]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			return (dynamic)_003C_003Eo__10._003C_003Ep__0.Target((CallSite)(object)_003C_003Eo__10._003C_003Ep__0, (object)x.UID, (object)uId);
		});
		return true;
	}
}
