using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingBasketAppTests
{
	[TestClass]
	public class InfoLoggerTests
	{
		[TestMethod]
		public void LoggerLogsString()
		{
			InfoLogger logger(Stream stream);
			string test = "Please log me";
			logger.log(test);
		}
	}
}
