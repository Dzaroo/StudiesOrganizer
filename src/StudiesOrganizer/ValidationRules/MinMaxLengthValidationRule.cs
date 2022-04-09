using System.Globalization;
using System.Windows.Controls;

namespace StudiesOrganizer.ValidationRules
{
    public class MinMaxLengthValidationRule : ValidationRule
    {
        public int MinLength
        {
            get;
            set;
        }

        public int MaxLength
        {
            get;
            set;
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value.ToString().Length <= MaxLength && value.ToString().Length >= MinLength)
            {
                return new ValidationResult(true, null);
            }
            else if(value.ToString().Length < MinLength)
            {
                return new ValidationResult(false, $"Wartość tekstowa za krótka (min.: {MinLength})");
            }
            else
            {
                return new ValidationResult(false, $"Wartość tekstowa za długa (maks.: {MaxLength})");
            }
        }
    }
}
