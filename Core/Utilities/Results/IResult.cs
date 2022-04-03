using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{

    //for base voids
    public interface IResult
    {
        public bool _Success { get; }

        public string _Message { get; }

       
    }
}
