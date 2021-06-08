using System.Collections.Generic;
using System.Linq;

namespace Models
{
    public class Result
    {
        private readonly List<string> _errorList = new List<string>();

        public bool IsValid = true;

        public void AddError(string error)
        {
            IsValid = false;
            _errorList.Add(error);
        }

        public void AddError(IEnumerable<string> errors)
        {
            IsValid = false;
            _errorList.AddRange(errors);
        }

        public List<string> GetErrorList => _errorList;
    }
}