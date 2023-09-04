using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Responses
{
    public class BaseResponse
    {
        public List<string> ErrorMessages { get; set; }
        public bool HasError { get; set; } = false;

        public void AddException(Exception ex)
        {
            HasError = true;
            ErrorMessages.Add(ex.Message);
        }
        public void AddError(string error)
        {
            HasError = true;
            ErrorMessages.Add(error);
        }
    }
}
