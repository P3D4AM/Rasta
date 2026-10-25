using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Microsoft.CSharp.RuntimeBinder;

namespace CRMIdeal.Classes.Helper;

public class ReservedNumber
{
	public class ReservedNumberObj
	{
		public bool? IsTaken { get; set; }

		public int? SysPartId { get; set; }

		public dynamic SysPartNumber { get; set; }

		public string SysPartNumberRef { get; set; }

		public DateTime RegDate { get; set; }
	}

	[CompilerGenerated]
	private static class _003C_003Eo__2
	{
		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__0;

		public static CallSite<Func<CallSite, bool, object, object>> _003C_003Ep__1;

		public static CallSite<Func<CallSite, object, bool, object>> _003C_003Ep__2;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__3;

		public static CallSite<Func<CallSite, object, bool, object>> _003C_003Ep__4;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__5;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__6;
	}

	[CompilerGenerated]
	private static class _003C_003Eo__3
	{
		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__0;

		public static CallSite<Func<CallSite, bool, object, object>> _003C_003Ep__1;

		public static CallSite<Func<CallSite, object, bool, object>> _003C_003Ep__2;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__3;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__4;
	}

	[CompilerGenerated]
	private static class _003C_003Eo__4
	{
		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__0;

		public static CallSite<Func<CallSite, bool, object, object>> _003C_003Ep__1;

		public static CallSite<Func<CallSite, object, bool, object>> _003C_003Ep__2;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__3;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__4;
	}

	private static List<ReservedNumberObj> ListResevedNumber = new List<ReservedNumberObj>();

	public static bool AddNumber(int sysPartId = 0, dynamic sysPartNumber = null, string sysPartNumberRef = "")
	{
		bool flag = true;
		ClearListResevedNumber();
		if (ListResevedNumber != null && Enumerable.Any<ReservedNumberObj>((IEnumerable<ReservedNumberObj>)ListResevedNumber) && Enumerable.FirstOrDefault<ReservedNumberObj>((IEnumerable<ReservedNumberObj>)ListResevedNumber, (Func<ReservedNumberObj, bool>)delegate(ReservedNumberObj m)
		{
			bool flag2 = m.SysPartId == sysPartId;
			object obj;
			if (flag2)
			{
				if (_003C_003Eo__2._003C_003Ep__1 == null)
				{
					_003C_003Eo__2._003C_003Ep__1 = CallSite<Func<CallSite, bool, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(ReservedNumber), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, bool, object, object> target = _003C_003Eo__2._003C_003Ep__1.Target;
				CallSite<Func<CallSite, bool, object, object>> _003C_003Ep__ = _003C_003Eo__2._003C_003Ep__1;
				if (_003C_003Eo__2._003C_003Ep__0 == null)
				{
					_003C_003Eo__2._003C_003Ep__0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)13, typeof(ReservedNumber), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				obj = target((CallSite)(object)_003C_003Ep__, flag2, _003C_003Eo__2._003C_003Ep__0.Target((CallSite)(object)_003C_003Eo__2._003C_003Ep__0, (object)m.SysPartNumber, (object)sysPartNumber));
			}
			else
			{
				obj = flag2;
			}
			object obj2 = obj;
			if (_003C_003Eo__2._003C_003Ep__3 == null)
			{
				_003C_003Eo__2._003C_003Ep__3 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)84, typeof(ReservedNumber), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			object obj3;
			if (!_003C_003Eo__2._003C_003Ep__3.Target((CallSite)(object)_003C_003Eo__2._003C_003Ep__3, obj2))
			{
				if (_003C_003Eo__2._003C_003Ep__2 == null)
				{
					_003C_003Eo__2._003C_003Ep__2 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(ReservedNumber), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
					}));
				}
				obj3 = _003C_003Eo__2._003C_003Ep__2.Target((CallSite)(object)_003C_003Eo__2._003C_003Ep__2, obj2, m.SysPartNumberRef == sysPartNumberRef);
			}
			else
			{
				obj3 = obj2;
			}
			object obj4 = obj3;
			if (_003C_003Eo__2._003C_003Ep__5 == null)
			{
				_003C_003Eo__2._003C_003Ep__5 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)84, typeof(ReservedNumber), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			object val;
			if (!_003C_003Eo__2._003C_003Ep__5.Target((CallSite)(object)_003C_003Eo__2._003C_003Ep__5, obj4))
			{
				if (_003C_003Eo__2._003C_003Ep__4 == null)
				{
					_003C_003Eo__2._003C_003Ep__4 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(ReservedNumber), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
					}));
				}
				val = _003C_003Eo__2._003C_003Ep__4.Target((CallSite)(object)_003C_003Eo__2._003C_003Ep__4, obj4, m.IsTaken.GetValueOrDefault());
			}
			else
			{
				val = obj4;
			}
			return (dynamic)val;
		}) != null)
		{
			flag = false;
		}
		if (flag)
		{
			ListResevedNumber.Add(new ReservedNumberObj
			{
				IsTaken = true,
				SysPartId = sysPartId,
				SysPartNumber = sysPartNumber,
				SysPartNumberRef = sysPartNumberRef,
				RegDate = DateTime.Now
			});
		}
		return flag;
	}

	public static bool RemoveNumber(int sysPartId = 0, dynamic sysPartNumber = null, string sysPartNumberRef = "")
	{
		bool result = false;
		if (ListResevedNumber != null && Enumerable.Any<ReservedNumberObj>((IEnumerable<ReservedNumberObj>)ListResevedNumber))
		{
			ReservedNumberObj reservedNumberObj = Enumerable.FirstOrDefault<ReservedNumberObj>((IEnumerable<ReservedNumberObj>)ListResevedNumber, (Func<ReservedNumberObj, bool>)delegate(ReservedNumberObj m)
			{
				bool flag = m.SysPartId == sysPartId;
				object obj;
				if (flag)
				{
					if (_003C_003Eo__3._003C_003Ep__1 == null)
					{
						_003C_003Eo__3._003C_003Ep__1 = CallSite<Func<CallSite, bool, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(ReservedNumber), new CSharpArgumentInfo[2]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					Func<CallSite, bool, object, object> target = _003C_003Eo__3._003C_003Ep__1.Target;
					CallSite<Func<CallSite, bool, object, object>> _003C_003Ep__ = _003C_003Eo__3._003C_003Ep__1;
					if (_003C_003Eo__3._003C_003Ep__0 == null)
					{
						_003C_003Eo__3._003C_003Ep__0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)13, typeof(ReservedNumber), new CSharpArgumentInfo[2]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
						}));
					}
					obj = target((CallSite)(object)_003C_003Ep__, flag, _003C_003Eo__3._003C_003Ep__0.Target((CallSite)(object)_003C_003Eo__3._003C_003Ep__0, (object)m.SysPartNumber, (object)sysPartNumber));
				}
				else
				{
					obj = flag;
				}
				object obj2 = obj;
				if (_003C_003Eo__3._003C_003Ep__3 == null)
				{
					_003C_003Eo__3._003C_003Ep__3 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)84, typeof(ReservedNumber), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
				}
				object val;
				if (!_003C_003Eo__3._003C_003Ep__3.Target((CallSite)(object)_003C_003Eo__3._003C_003Ep__3, obj2))
				{
					if (_003C_003Eo__3._003C_003Ep__2 == null)
					{
						_003C_003Eo__3._003C_003Ep__2 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(ReservedNumber), new CSharpArgumentInfo[2]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
						}));
					}
					val = _003C_003Eo__3._003C_003Ep__2.Target((CallSite)(object)_003C_003Eo__3._003C_003Ep__2, obj2, m.SysPartNumberRef == sysPartNumberRef);
				}
				else
				{
					val = obj2;
				}
				return (dynamic)val;
			});
			if (reservedNumberObj != null)
			{
				ListResevedNumber.Remove(reservedNumberObj);
				result = true;
			}
		}
		return result;
	}

	public static void UpdateNumber(int sysPartId = 0, dynamic sysPartNumber = null, string sysPartNumberRef = "", bool isTaken = false)
	{
		if (ListResevedNumber == null || !Enumerable.Any<ReservedNumberObj>((IEnumerable<ReservedNumberObj>)ListResevedNumber))
		{
			return;
		}
		foreach (ReservedNumberObj item in ListResevedNumber)
		{
			if (_003C_003Eo__4._003C_003Ep__4 == null)
			{
				_003C_003Eo__4._003C_003Ep__4 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(ReservedNumber), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			Func<CallSite, object, bool> target = _003C_003Eo__4._003C_003Ep__4.Target;
			CallSite<Func<CallSite, object, bool>> _003C_003Ep__ = _003C_003Eo__4._003C_003Ep__4;
			bool flag = item.SysPartId == sysPartId;
			object obj;
			if (flag)
			{
				if (_003C_003Eo__4._003C_003Ep__1 == null)
				{
					_003C_003Eo__4._003C_003Ep__1 = CallSite<Func<CallSite, bool, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(ReservedNumber), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Func<CallSite, bool, object, object> target2 = _003C_003Eo__4._003C_003Ep__1.Target;
				CallSite<Func<CallSite, bool, object, object>> _003C_003Ep__2 = _003C_003Eo__4._003C_003Ep__1;
				if (_003C_003Eo__4._003C_003Ep__0 == null)
				{
					_003C_003Eo__4._003C_003Ep__0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)13, typeof(ReservedNumber), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				obj = target2((CallSite)(object)_003C_003Ep__2, flag, _003C_003Eo__4._003C_003Ep__0.Target((CallSite)(object)_003C_003Eo__4._003C_003Ep__0, (object)item.SysPartNumber, (object)sysPartNumber));
			}
			else
			{
				obj = flag;
			}
			object obj2 = obj;
			if (_003C_003Eo__4._003C_003Ep__3 == null)
			{
				_003C_003Eo__4._003C_003Ep__3 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)84, typeof(ReservedNumber), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
			}
			object arg;
			if (!_003C_003Eo__4._003C_003Ep__3.Target((CallSite)(object)_003C_003Eo__4._003C_003Ep__3, obj2))
			{
				if (_003C_003Eo__4._003C_003Ep__2 == null)
				{
					_003C_003Eo__4._003C_003Ep__2 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, (ExpressionType)2, typeof(ReservedNumber), new CSharpArgumentInfo[2]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
					}));
				}
				arg = _003C_003Eo__4._003C_003Ep__2.Target((CallSite)(object)_003C_003Eo__4._003C_003Ep__2, obj2, item.SysPartNumberRef == sysPartNumberRef);
			}
			else
			{
				arg = obj2;
			}
			if (target((CallSite)(object)_003C_003Ep__, arg))
			{
				item.IsTaken = isTaken;
			}
		}
	}

	public static void ClearListResevedNumber()
	{
		if (ListResevedNumber == null || !Enumerable.Any<ReservedNumberObj>((IEnumerable<ReservedNumberObj>)ListResevedNumber))
		{
			return;
		}
		DateTime perDate = DateTime.Now.AddHours(-1.0);
		List<ReservedNumberObj> list = Enumerable.ToList<ReservedNumberObj>(Enumerable.Where<ReservedNumberObj>((IEnumerable<ReservedNumberObj>)ListResevedNumber, (Func<ReservedNumberObj, bool>)((ReservedNumberObj m) => m.RegDate <= perDate)));
		if (list == null || !Enumerable.Any<ReservedNumberObj>((IEnumerable<ReservedNumberObj>)list))
		{
			return;
		}
		foreach (ReservedNumberObj item in list)
		{
			ListResevedNumber.Remove(item);
		}
	}
}
