using System.Text.RegularExpressions;

namespace Models
{
    public class FullNameValidator : IValidator<ClientFullName>
    {
        public Result Validate(ClientFullName obj)
        {
            var result = new Result();

            if (string.IsNullOrEmpty(obj.Surname))
                result.AddError("Поле \"Фамилия\" не может быть пустым");
            if(string.IsNullOrEmpty(obj.Name))
                result.AddError("Поле \"Имя\" не может быть пустым");
            if(string.IsNullOrEmpty(obj.Patronymic))
                result.AddError("Поле \"Отчество\" не может быть пустым");
            
            if(!string.IsNullOrEmpty(obj.Surname) && !Regex.IsMatch(obj.Surname, @"^[а-яА-ЯёЁ]+$"))
                result.AddError("Поле \"Фамилия\" должно содержать только буквы");
            if(!string.IsNullOrEmpty(obj.Name)&& !Regex.IsMatch(obj.Name, @"^[а-яА-ЯёЁ]+$"))
                result.AddError("Поле \"Имя\" должно содержать только буквы");
            if(!string.IsNullOrEmpty(obj.Patronymic) && !Regex.IsMatch(obj.Patronymic, @"^[а-яА-ЯёЁ]+$"))
                result.AddError("Поле \"Отчество\" должно содержать только буквы");

            return result;
        }
    }
}