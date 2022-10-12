using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace newVaccineform.DB
{
    public class DateRangeAttribute:ValidationAttribute
    {
        int _minimumAge;
        public DateRangeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }
        public override bool IsValid(object value)
        {
            DateTime date;
            if (value == null)
            {
                return false;
            }
            if (value != null && DateTime.TryParse(value.ToString(), out date))
            {
                return date.AddYears(_minimumAge) < DateTime.Now;

            }
            return false;
        }
    }
}