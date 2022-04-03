using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool _Success { get; }

        public string _Message { get; }

      
        
        public Result(bool Succes, string Message):this(Succes)
        {
            _Message = Message;
        }
        public Result(bool Succes)
        {
            _Success = Succes;
        }

    }
}
