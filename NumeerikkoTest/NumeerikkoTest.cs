using System;
using NUnit.Framework;
using Numeerikko;

namespace NumeerikkoTest
{
	[TestFixture]
	public class BasicTest
	{
		private NumberConverter converter;
		
		[SetUp]
		public void SetUp()
		{
			converter = new NumberConverter();
		}
		
		[Test]
		public void TestSingleDigits()
		{
			Assert.That(converter.Convert(0), Is.EqualTo("nolla"));
			Assert.That(converter.Convert(1), Is.EqualTo("yksi"));
			Assert.That(converter.Convert(2), Is.EqualTo("kaksi"));
			Assert.That(converter.Convert(3), Is.EqualTo("kolme"));
			Assert.That(converter.Convert(4), Is.EqualTo("neljä"));
			Assert.That(converter.Convert(5), Is.EqualTo("viisi"));
			Assert.That(converter.Convert(6), Is.EqualTo("kuusi"));
			Assert.That(converter.Convert(7), Is.EqualTo("seitsemän"));
			Assert.That(converter.Convert(8), Is.EqualTo("kahdeksan"));
			Assert.That(converter.Convert(9), Is.EqualTo("yhdeksän"));
		}
		
		[Test]
		public void TestTeens()
		{
			Assert.That (converter.Convert(11), Is.EqualTo("yksitoista"));
			Assert.That (converter.Convert(12), Is.EqualTo("kaksitoista"));
			Assert.That(converter.Convert(13), Is.EqualTo("kolmetoista"));
			Assert.That(converter.Convert(14), Is.EqualTo("neljätoista"));
			Assert.That(converter.Convert(15), Is.EqualTo("viisitoista"));
			Assert.That(converter.Convert(16), Is.EqualTo("kuusitoista"));
			Assert.That(converter.Convert(17), Is.EqualTo("seitsemäntoista"));
			Assert.That(converter.Convert(18), Is.EqualTo("kahdeksantoista"));
			Assert.That(converter.Convert(19), Is.EqualTo("yhdeksäntoista"));
		}
	}
}

