using System.ComponentModel.DataAnnotations;

namespace AutoSzerelo.Shared
{
    public class DatumTartomanyAttribute : ValidationAttribute
    {
        private readonly DateTime _kezdoDatum;

        public DatumTartomanyAttribute()
        {
            _kezdoDatum = DateTime.Parse("1900-01-01");
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime datum && (datum < _kezdoDatum || datum > DateTime.Today))
                return new ValidationResult($"A dátumnak {_kezdoDatum.ToShortDateString()} és a mai nap között kell lennie.");

            return ValidationResult.Success;
        }
    }
}
