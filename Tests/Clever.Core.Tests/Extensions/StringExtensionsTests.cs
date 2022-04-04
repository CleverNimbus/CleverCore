using Clever.Core.Extensions;
using System;

namespace Clever.Core.Tests.Extensions
{
	public class StringExtensionsTests
	{
		[Fact]
		public void DecimalIsParseable()
		{
			var result = "0,001".CanBeConvertedToType(typeof(decimal), out object outData);

			Assert.True(result);
			Assert.Equal(0.001m, outData);
		}

		[Fact]
		public void DateIsParseable()
		{
			var result = "2018-03-29T13:34:00.000".CanBeConvertedToType(typeof(DateTime), out object outData);

			var date = (DateTime?)outData;

			Assert.True(result);
			Assert.Equal(2018, date.Value.Year);
			Assert.Equal(3, date.Value.Month);
			Assert.Equal(29, date.Value.Day);
			Assert.Equal(13, date.Value.Hour);
			Assert.Equal(34, date.Value.Minute);
		}

		[Fact]
		public void POCOIsParseable()
		{
			var result = "{ \"Id\": 1, \"Name\": \"cosacosacosa\"}".CanBeConvertedToType(typeof(TestClass), out object outData);

			var test = (TestClass)outData;

			Assert.True(result);
			Assert.Equal("cosacosacosa", test.Name);
			Assert.Equal(1, test.Id);
		}

		[Fact]
		public void MalformedPOCOIsNotParseable()
		{
			var result = "{ \"Id\" 1 \"Name\": \"cosacosacosa\"}".CanBeConvertedToType(typeof(TestClass), out object outData);

			Assert.False(result);
			Assert.Null(outData);
		}

		[Fact]
		public void DifferentPOCOIsNotParseable()
		{
			var result = "{ \"NOId\": 1, \"NOName\": \"cosacosacosa\"}".CanBeConvertedToType(typeof(TestClass), out object outData);

			Assert.False(result);
			Assert.Null(outData);
		}

		public class TestClass
		{
			public int Id { get; set; }
			public string Name { get; set; }
		}
	}	
}