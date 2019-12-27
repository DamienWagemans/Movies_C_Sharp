using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace Converter
{
	public class Convert_To_Stars : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			int rate = (int)value;
			string path = "C:\\Users\\damien\\Desktop\\Etoiles\\";
			switch (rate)
			{
				case (1):
					{
						path += "1.png";
						break;
					}
				case (2):
					{
						path += "2.png";
						break;
					}
				case (3):
					{
						path += "3.png";
						break;
					}
				case (4):
					{
						path += "4.png";
						break;
					}
				case (5):
					{
						path += "5.png";
						break;
					}
			}
			return path;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
