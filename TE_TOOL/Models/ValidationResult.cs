using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE_TOOL.Models
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; } = "";

        public static ValidationResult Success()
            => new ValidationResult { IsValid = true };

        public static ValidationResult Fail(string message)
            => new ValidationResult { IsValid = false, ErrorMessage = message };
    }
}
