using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Application.Models
{
    public  class RequestResultModel<T>
    {
        public bool IsSuccessful { get; set; }
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        public T Result { get; set; }

        public RequestResultModel<T> CreateError(string error)
        {
            IsSuccessful = false;
            IsError = true;
            ErrorMessage = error ?? string.Empty;
            return this;
        }
        public RequestResultModel<T> CreateSuccessful(T result)
        {
            IsSuccessful = true;
            IsError = false;
            Result = result;
            return this;
        }
        public RequestResultModel<T> CreateUnsuccessful(string messages)
        {
            IsSuccessful = false;
            IsError = false;
            ErrorMessage = messages ?? string.Empty;
            return this;
        }
    }
}
