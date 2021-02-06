using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingAPI_s.Enums;

namespace TestingAPI_s.Factory
{
    public class ConcreteFactoryCreator : FactoryCreator
    {
        public override IStreetLookUp FactoryMethod(APIsOptions option)
        {
            switch (option)
            {
                case APIsOptions.Radar: return new RadarAPIFactory();
                case APIsOptions.SmartyStreets: return new SmartyStreetsAPIFactory();    
                default: throw new ArgumentException("Invalid type", "type");
            }
        }
    }
   
}
