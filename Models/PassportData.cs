using System;
using System.Collections.Generic;

namespace Models
{
    public class PassportData : ValueObject
    {
        public string Series { get; private set; }
        public string Number { get; private set; }
        public string IssuedBy { get; private set; }
        public string IssuedOn { get; private set; }
        public string Registration { get; private set; }
        
        public Result ValidationResult { get; private set; }
        
        public PassportData(string series, string number, string issuedBy, string issuedOn, string registration)
        {
            Series = series;
            Number = number;
            IssuedBy = issuedBy;
            IssuedOn = issuedOn;
            Registration = registration;
            
            var validator = new PassportDataValidator();
            ValidationResult = validator.Validate(this);
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Series;
            yield return Number;
        }
    }
}