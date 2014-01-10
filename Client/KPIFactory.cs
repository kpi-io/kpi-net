using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KPI.Client
{
    public class KPIFactory
    {
        private object lockObj = new object();
        public KPIConfiguration Config { get; private set; }
        private Dictionary<string, KPICommand> commands = new Dictionary<string, KPICommand>();

        public KPIFactory()
            : this(null)
        {

        }

        public KPIFactory(KPIConfiguration config)
        {
            this.Configure(config);
        }

        public void Configure(KPIConfiguration config)
        {
            this.Config = config;
        }

        public KPICommand Command(string collection)
        {
            if (!this.commands.ContainsKey(collection))
            {
                lock (this.lockObj)
                {
                    if (!this.commands.ContainsKey(collection))
                    {
                        this.commands[collection] = new KPICommand(this.Config, collection);
                    }
                }
            }
            return this.commands[collection];
        }

        public void AddData(string collection, object data, OnErrorHandler onError = null, OnDataAddedHandler onSuccess = null)
        {
            var command = this.Command(collection);
            command.AddData(data, onError, onSuccess);
        }
    }
}
