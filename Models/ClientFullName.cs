using System.Collections.Generic;

namespace Models
{
    public class ClientFullName : ValueObject
    {
        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Patronymic { get; private set; }
        
        public Result ValidationResult { get; private set; }

        public ClientFullName(string surname, string name, string patronymic)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            
            var validator = new FullNameValidator();
            ValidationResult = validator.Validate(this);
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Surname;
            yield return Name;
            yield return Patronymic;
        }
    }
}