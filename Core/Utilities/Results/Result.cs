using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message) : this(success)//bunun anlamı bu sınıfa ait olan bu ctor'a iki parametre gelirse success'i diğer ctor'a göndermek
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }


        public string Message { get; }
    }
}
