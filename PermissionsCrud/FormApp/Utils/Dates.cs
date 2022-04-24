using System;
using System.Globalization;

namespace FormApp.Utils
{
    public static class Dates
    {
        private static string format = "dd/MM/yyyy";
        public static DateTime ConvertToDate(string dateFromView)
        {
            DateTime permissionDate;
            bool temp = DateTime.TryParseExact(dateFromView, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out permissionDate);
            return permissionDate;
        }
    }
}