using System.Globalization;
using System.Text.RegularExpressions;

namespace Models
{
    public class PassportDataValidator : IValidator<PassportData>
    {
        public Result Validate(PassportData obj)
        {
            var result = new Result();
            
            if (string.IsNullOrEmpty(obj.Series))
                result.AddError("Поле \"Серия паспорта\" не может быть пустым");
            if (string.IsNullOrEmpty(obj.Number))
                result.AddError("Поле \"Номер паспорта\" не может быть пустым");
            if (string.IsNullOrEmpty(obj.IssuedBy))
                result.AddError("Поле \"Кем выдан\" не может быть пустым");
            if (string.IsNullOrEmpty(obj.IssuedOn.ToString(CultureInfo.InvariantCulture)))
                result.AddError("Поле \"Когда выдан\" не может быть пустым");
            if (string.IsNullOrEmpty(obj.Registration))
                result.AddError("Поле \"Прописка\" не может быть пустым");
            
            if (obj.Series != null && (obj.Series.Length != 4 || Regex.IsMatch(obj.Series, @"/^\d+$/")))
                result.AddError("Поле \"Серия паспорта\" заполнено некорректно");
            if (obj.Number != null && (obj.Number.Length != 6 || Regex.IsMatch(obj.Number, @"/^\d+$/")))
                result.AddError("Поле \"Номер паспорта\" заполнено некорректно");

            return result;
        }
    }
}