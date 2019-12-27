using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Converter
{
	public class Convert_To_Image : IValueConverter

	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string path;
			if (value is string)
			{
				if (value.ToString().Length != 0)
				{
					path = "https://image.tmdb.org/t/p/original" + value;
				}
				else
				{
					return null;
				}

				BitmapImage bi = new BitmapImage();
				bi.BeginInit();
				bi.UriSource = new Uri(path);
				bi.DecodePixelHeight = 200;
				bi.DecodePixelWidth = 150;
				bi.EndInit();
				return bi;
			}

			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
