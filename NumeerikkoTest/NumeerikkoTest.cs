/* Copyright (c) 2012, Laura Leppänen <laura.leppanen@iki.fi>
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met: 
 *
 * 1. Redistributions of source code must retain the above copyright notice, this
 *    list of conditions and the following disclaimer. 
 * 2. Redistributions in binary form must reproduce the above copyright notice,
 *    this list of conditions and the following disclaimer in the documentation
 *    and/or other materials provided with the distribution. 
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
 * ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 * SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */
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
		public void TestHundreds()
		{
			Assert.That (converter.Convert(100), Is.EqualTo("sata"));
			Assert.That (converter.Convert(200), Is.EqualTo("kaksisataa"));
			Assert.That (converter.Convert(300), Is.EqualTo("kolmesataa"));
			Assert.That (converter.Convert(400), Is.EqualTo("neljäsataa"));
			Assert.That (converter.Convert(500), Is.EqualTo("viisisataa"));
			Assert.That (converter.Convert(600), Is.EqualTo("kuusisataa"));
			Assert.That (converter.Convert(700), Is.EqualTo("seitsemänsataa"));
			Assert.That (converter.Convert(800), Is.EqualTo("kahdeksansataa"));
			Assert.That (converter.Convert(900), Is.EqualTo("yhdeksänsataa"));
		}
		
		[Test]
		public void TestTens()
		{
			Assert.That (converter.Convert(10), Is.EqualTo("kymmenen"));
			Assert.That (converter.Convert(20), Is.EqualTo("kaksikymmentä"));
			Assert.That (converter.Convert(30), Is.EqualTo("kolmekymmentä"));
			Assert.That (converter.Convert(40), Is.EqualTo("neljäkymmentä"));
			Assert.That (converter.Convert(50), Is.EqualTo("viisikymmentä"));
			Assert.That (converter.Convert(60), Is.EqualTo("kuusikymmentä"));
			Assert.That (converter.Convert(70), Is.EqualTo("seitsemänkymmentä"));
			Assert.That (converter.Convert(80), Is.EqualTo("kahdeksankymmentä"));
			Assert.That (converter.Convert(90), Is.EqualTo("yhdeksänkymmentä"));
		}
		
		[Test]
		public void TestTeens()
		{
			Assert.That(converter.Convert(11), Is.EqualTo("yksitoista"));
			Assert.That(converter.Convert(12), Is.EqualTo("kaksitoista"));
			Assert.That(converter.Convert(13), Is.EqualTo("kolmetoista"));
			Assert.That(converter.Convert(14), Is.EqualTo("neljätoista"));
			Assert.That(converter.Convert(15), Is.EqualTo("viisitoista"));
			Assert.That(converter.Convert(16), Is.EqualTo("kuusitoista"));
			Assert.That(converter.Convert(17), Is.EqualTo("seitsemäntoista"));
			Assert.That(converter.Convert(18), Is.EqualTo("kahdeksantoista"));
			Assert.That(converter.Convert(19), Is.EqualTo("yhdeksäntoista"));
		}
		
		[Test]
		public void TestDoubleDigits()
		{
			Assert.That(converter.Convert(25), Is.EqualTo("kaksikymmentäviisi"));
			Assert.That(converter.Convert(99), Is.EqualTo("yhdeksänkymmentäyhdeksän"));
			Assert.That(converter.Convert(82), Is.EqualTo("kahdeksankymmentäkaksi"));
			Assert.That(converter.Convert(64), Is.EqualTo("kuusikymmentäneljä"));
			Assert.That(converter.Convert(71), Is.EqualTo("seitsemänkymmentäyksi"));
			Assert.That(converter.Convert(48), Is.EqualTo("neljäkymmentäkahdeksan"));
		}
		
		[Test]
		public void TestTripleDigits()
		{
			Assert.That(converter.Convert(125), Is.EqualTo("satakaksikymmentäviisi"));
			Assert.That(converter.Convert(999), Is.EqualTo("yhdeksänsataayhdeksänkymmentäyhdeksän"));
			Assert.That(converter.Convert(821), Is.EqualTo("kahdeksansataakaksikymmentäyksi"));
			Assert.That(converter.Convert(640), Is.EqualTo("kuusisataaneljäkymmentä"));
			Assert.That(converter.Convert(710), Is.EqualTo("seitsemänsataakymmenen"));
		}
		
		[Test]
		public void TestThousands()
		{
			Assert.That(converter.Convert(1000), Is.EqualTo("tuhat"));
			Assert.That(converter.Convert(3000), Is.EqualTo("kolmetuhatta"));
			Assert.That(converter.Convert(4002), Is.EqualTo("neljätuhatta kaksi"));
			Assert.That(converter.Convert(200789), Is.EqualTo("kaksisataatuhatta seitsemänsataakahdeksankymmentäyhdeksän"));
			Assert.That(converter.Convert(121000), Is.EqualTo("satakaksikymmentäyksituhatta"));
			Assert.That(converter.Convert(21230), Is.EqualTo("kaksikymmentäyksituhatta kaksisataakolmekymmentä"));
			Assert.That(converter.Convert(999999), Is.EqualTo("yhdeksänsataayhdeksänkymmentäyhdeksäntuhatta yhdeksänsataayhdeksänkymmentäyhdeksän"));
		}
		
		[Test]
		public void TestMillions()
		{
			Assert.That(converter.Convert(1000000), Is.EqualTo("miljoona"));
			Assert.That(converter.Convert(3000000), Is.EqualTo("kolme miljoonaa"));
			Assert.That(converter.Convert(40000002), Is.EqualTo("neljäkymmentä miljoonaa kaksi"));
			Assert.That(converter.Convert(1300071), Is.EqualTo("miljoona kolmesataatuhatta seitsemänkymmentäyksi"));
		}
		
		[Test]
		public void TestMilliards()
		{
			Assert.That(converter.Convert(1000000000), Is.EqualTo("miljardi"));
			Assert.That(converter.Convert(3000000000), Is.EqualTo("kolme miljardia"));
			Assert.That(converter.Convert(40000000002), Is.EqualTo("neljäkymmentä miljardia kaksi"));
			Assert.That(converter.Convert(1010300071), Is.EqualTo("miljardi kymmenen miljoonaa kolmesataatuhatta seitsemänkymmentäyksi"));
		}
		
		[Test]
		public void TestBillions()
		{
			Assert.That(converter.Convert(1000000000000), Is.EqualTo("biljoona"));
			Assert.That(converter.Convert(3000000000000), Is.EqualTo("kolme biljoonaa"));
			Assert.That(converter.Convert(40000000000002), Is.EqualTo("neljäkymmentä biljoonaa kaksi"));
			Assert.That(converter.Convert(1003010300071), Is.EqualTo("biljoona kolme miljardia kymmenen miljoonaa kolmesataatuhatta seitsemänkymmentäyksi"));
			
			string nineHundredNinetyNine = "yhdeksänsataayhdeksänkymmentäyhdeksän";
			Assert.That(converter.Convert(999999999999999), Is.EqualTo(
				nineHundredNinetyNine + " biljoonaa " + nineHundredNinetyNine + " miljardia " +
				nineHundredNinetyNine + " miljoonaa " + nineHundredNinetyNine + "tuhatta " +
				nineHundredNinetyNine));
			Assert.That(converter.Convert(200000000000000000), Is.EqualTo("kaksisataatuhatta biljoonaa"));
		}
		
		[Test]
		public void TestTrillions()
		{
			Assert.That(converter.Convert(1000000000000000000), Is.EqualTo("triljoona"));
			Assert.That(converter.Convert(3000000000000000000), Is.EqualTo("kolme triljoonaa"));
			Assert.That(converter.Convert(1000001000000000000), Is.EqualTo("triljoona biljoona"));
			Assert.That(converter.Convert(UInt64.MaxValue), Is.EqualTo(
				"kahdeksantoista triljoonaa neljäsataaneljäkymmentäkuusituhatta " +
				"seitsemänsataaneljäkymmentäneljä biljoonaa seitsemänkymmentäkolme miljardia " +
				"seitsemänsataayhdeksän miljoonaa viisisataaviisikymmentäyksituhatta kuusisataaviisitoista"));
		}
	}
}

