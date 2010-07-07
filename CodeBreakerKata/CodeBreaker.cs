using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
namespace CodeBreakerKata
{
		public static class MarkingGuess
		{
				public static string Mark(this string guess, string secret)
				{
						string nonpositionalmatch =  guess.NonPositionalMatch(secret);
						string positionalmatch =  guess.PositionalMatch(secret);
						string toReturn = positionalmatch+nonpositionalmatch;
						toReturn = toReturn.Substring(0,toReturn.Length-positionalmatch.Length);
						return toReturn;
				}

				private static string NonPositionalMatch(this string guess, string secret)
				{
						List<char> lSecret= secret.ToList();
						return guess.Aggregate("",(c,n)=>c+=lSecret.CustomContains(n)?"m":"");
				}
				public static string PositionalMatch(this string guess, string secret)
				{
						int index = 0;
						return guess.Aggregate("",(c,n)=>c+=secret[index++]==n?"p":"");
				}


				private static bool CustomContains(this List<char> list, char c)
				{

						if (list.Contains(c))
						{
								list.Remove(c);
								return true;
						}
						return false;
				}
		}




































		[TestFixture]
		public class TestMakingGuess
		{
				[TestCase("","xxxx","rgby")]
				[TestCase("m","yxxx","rgby")]
				[TestCase("m","xyxx","rgby")]
				[TestCase("m","xxyx","rgby")]
				[TestCase("m","xxxb","rgby")]
				[TestCase("mm","yxxb","rgby")]
				[TestCase("mm","yyxb","rgby")]
				[TestCase("p","rxxx","rgby")]
				[TestCase("pm","ryxx","rgby")]
				[TestCase("pm","ryyx","rgby")]
				[TestCase("pp","ryyy","rgby")]
				public void TestMark(string answer, string guess, string secret)
				{
						Assert.AreEqual(answer,guess.Mark(secret));
				}
				[TestCase("p","rxxx","rgby")]
				public void TestPositionalmatch(string answer, string guess, string secret)
				{
						Assert.AreEqual(answer,guess.PositionalMatch(secret));
				}
			
			


		}






}










/*
[TestCase("rgyb","xxxx","")]
[TestCase("rgyb","xxxr","m")]
[TestCase("rgyb","xxgy","mm")]
[TestCase("rgyb","xrgy","mmm")]
[TestCase("rgyb","brgy","mmmm")]
[TestCase("rgyb","rxxx","p")]
[TestCase("rgyb","rgxx","pp")]
[TestCase("rgyb","rgyx","ppp")]
[TestCase("rgyb","rgyb","pppp")]
[TestCase("rgyb","rgby","ppmm")]
[TestCase("rggg","rgyy","pp")]
[TestCase("rgxx","rggg","pp")]


*/



