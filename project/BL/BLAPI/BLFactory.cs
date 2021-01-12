using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLAPI
{
    public static class BLFactory
    {
        /// <summary>
        /// return instance of BLImp
        /// </summary>
        /// <returns></returns>
        public static IBL GetBL()
        {
            return new BLImp();
        }
    }
}
