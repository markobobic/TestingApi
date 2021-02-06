using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingAPI_s.Enums;

namespace TestingAPI_s.Factory
{
   public abstract class FactoryCreator
    {
        public abstract IStreetLookUp FactoryMethod(APIsOptions type);
    }
}
