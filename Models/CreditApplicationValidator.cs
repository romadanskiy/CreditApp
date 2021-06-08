using System.Globalization;

namespace Models
{
    public class CreditApplicationValidator : IValidator<CreditApplication>

    {
        public Result Validate(CreditApplication obj)
        {
            var result = new Result();
            
            if(!obj.ClientFullName.ValidationResult.IsValid)
                result.AddError(obj.ClientFullName.ValidationResult.GetErrorList);
            if(!obj.PassportData.ValidationResult.IsValid)
                result.AddError(obj.PassportData.ValidationResult.GetErrorList);
            
            
            if (string.IsNullOrEmpty(obj.OperatorName))
                result.AddError("\"Имя оператора\" не определено");
            
            if (string.IsNullOrEmpty(obj.Age.ToString()))
                result.AddError("Поле \"Возраст\" не может быть пустым");
            if (string.IsNullOrEmpty(obj.CreditAmount.ToString(CultureInfo.InvariantCulture)))
                result.AddError("Поле \"Сумма кредита\" не может быть пустым");
            if (string.IsNullOrEmpty(obj.Goal))
                result.AddError("Поле \"Цель\" не может быть пустым");
            if (string.IsNullOrEmpty(obj.Job))
                result.AddError("Поле \"Трудоустройство\" не может быть пустым");
            
            if(obj.Age < 18)
                result.AddError("Недопустимый возраст");

            return result;
        }
    }
}