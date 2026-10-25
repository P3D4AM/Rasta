namespace CRM.General.Utilities;

public static class Math
{
	public static int DivRem(int a, int b, out int result)
	{
		int num = 0;
		if (b == 0)
		{
			result = 0;
		}
		else
		{
			num = a / b;
			result = a - b * num;
		}
		return num;
	}

	public static long DivRem(long a, long b, out long result)
	{
		result = 0L;
		long num = 0L;
		if (b != 0L)
		{
			num = a / b;
			result = a - b * num;
		}
		return num;
	}

	public static int Mod(int numerator, int denominator)
	{
		return GetRemainder(GetRemainder(numerator, denominator) + denominator, denominator);
	}

	public static long Mod(long numerator, long denominator)
	{
		return GetRemainder(GetRemainder(numerator, denominator) + denominator, denominator);
	}

	public static int GetRemainder(int a, int b)
	{
		DivRem(a, b, out var result);
		return result;
	}

	public static long GetRemainder(long a, long b)
	{
		DivRem(a, b, out var result);
		return result;
	}

	public static int GetQuotient(int a, int b)
	{
		int result = 0;
		return DivRem(a, b, out result);
	}

	public static long GetQuotient(long a, long b)
	{
		long result = 0L;
		return DivRem(a, b, out result);
	}
}
