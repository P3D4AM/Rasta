using System;

namespace CRM.General.Utilities;

public class RandomText
{
	public string CreateRandomCode(byte CodeCount, bool WithNumber, bool? WithSmallLetter = null)
	{
		bool num = WithSmallLetter.HasValue && WithSmallLetter != false;
		string text = "";
		text = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
		if (WithNumber)
		{
			text = "1,2,3,4,5,6,7,8,9," + text;
		}
		if (num)
		{
			text = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z," + text;
		}
		string[] array = text.Split(new char[1] { ',' });
		Random random = new Random();
		byte b = 0;
		string text2 = "";
		for (b = 1; b <= CodeCount; b++)
		{
			text2 = text2 + array[Convert.ToInt32(random.Next(array.Length))] + " ";
		}
		return text2;
	}
}
