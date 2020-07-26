using System;
using System.IO;
using System.Text;

namespace ShoppingBasketApp
{
	class InfoLogger
	{
		private Stream stream; 
		internal InfoLogger(Stream stream)
		{
			this.stream = stream;
		}

		internal void Log(string content)
		{
			try
			{
					byte[] byteData = Encoding.UTF8.GetBytes(content);
					stream.Write(byteData, 0, byteData.Length);
			}
			catch (SystemException ex)
			{
				Console.WriteLine(ex.StackTrace);
			}
		}
	}
}
