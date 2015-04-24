using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaSoft.StampClient.Stamp
{
    internal class StampFactory
    {
        private Dictionary<string, Type> validBrokers;
        public StampFactory()
        {
            LoadValidBrokersPCC();
        }

        internal IStamping CreateStampBroker(params object[] args)
        {
            var strvalidBrokers = Implement.ConfigValue.Get("brokersPAC");
            return CreateInstance(strvalidBrokers, args);
        }

        internal IStamping CreateInstance(string validBroker, params object[] args)
        {
            Type t = GetTypeToCreate(validBroker);
            if (t == null)
                throw new Exception("Servicio de Timbrado no disponible");

            return Activator.CreateInstance(t, args) as IStamping;
        }

        private void LoadValidBrokersPCC()
        {
            validBrokers = new Dictionary<string, Type>();
            validBrokers.Add("LunaSoftPCC", typeof(LunaSoftPCC));
        }

        private Type GetTypeToCreate(string brokerName)
        {

            if (!validBrokers.Keys.Contains(brokerName))
            {
                throw new Exception("Servicio de Timbrado no disponible");
            }
            else
            {
                return validBrokers[brokerName];
            }
        }

    }


}
