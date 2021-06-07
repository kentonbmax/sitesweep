using System;
using System.ComponentModel.DataAnnotations;

namespace sitesweep.Validators
{
    public class ValidateUrl : ValidationAttribute  
    {  
        public override bool IsValid(object value)  
        {  
            
            if(value == null || string.IsNullOrWhiteSpace((string)value))
            {
                return false;
            }

            var testValue = (string)value;
            return Uri.IsWellFormedUriString(testValue, UriKind.Absolute);
        }  
    } 
}
