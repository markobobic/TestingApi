using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingAPI_s.Core
{
   public class ValidationResult
    {
        public bool IsValid { get; set; }
        public string Accuracy { get; set; }
        public ValidationResult(bool isValid, string accuracy)
        {
            IsValid = isValid;
            Accuracy = accuracy;
        }
    }
}
