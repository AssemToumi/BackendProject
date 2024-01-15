using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrescriptionService.Business.PrescriptionService.Business.Extensions
{
    public static class StringExtensions
    {
        public static int ToInt32(this string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new InvalidCastException();
            }

            return Convert.ToInt32(source);
        }
    }
}
