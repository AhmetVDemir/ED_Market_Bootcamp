using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Bussiness
{
    public class BussinessRules
    {

        //kural parametrelerini al
        public static IResult Run(params IResult[] logics)
        {
            //tek tek kurallara bak
            foreach(var logic in logics)
            {
                //eğer içinde başarısız olan varsa
                if (!logic._Success)
                {
                    //başarısız olan kuralı döndür
                    return logic;
                }
            }
            //eğer tümü başarılı ise hiçbir şey döndüerme
            return null;
        }

    }
}
