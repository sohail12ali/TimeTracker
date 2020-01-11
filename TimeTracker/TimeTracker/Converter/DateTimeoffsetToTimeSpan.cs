using System;
using System.Diagnostics;
using System.Globalization;
using Xamarin.Forms;

namespace TimeTracker.Converter
{
    public class DateTimeoffsetToTimeSpan : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                DateTimeOffset convertedDate;

                if (value != null && ((DateTimeOffset)value) == default(DateTimeOffset))
                {
                    convertedDate = DateTimeOffset.Now;
                }
                else
                {
                    convertedDate = ((DateTimeOffset)value).ToLocalTime();
                }
                return convertedDate.TimeOfDay;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new TimeSpan();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return new DateTimeOffset(DateTime.Now.Date + (TimeSpan)value);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return DateTimeOffset.Now;
            }
        }
    }
}