using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrGunnChartData.DataLayer
{
    public class JsonConnectionFactory : IJsonConnectionFactory
    {
        public JsonConnectionFactory()
        {
        }

        public string GetJsonPath
        { 
            get 
            {
                return "";
            }
        }
    }
}
