// Copyright (c) KPI.IO
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// The latest version of this file can be found at https://github.com/kpi-io/kpi-net


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KPI.Client
{
    public class KPIDispatcher
    {
        private object lockObj = new object();
        public KPIConfiguration Config { get; private set; }
        private Dictionary<string, KPICommand> commands = new Dictionary<string, KPICommand>();

        public KPIDispatcher()
            : this(null)
        {

        }

        public KPIDispatcher(KPIConfiguration config)
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

        public void Send(string collection, object data, OnErrorHandler onError = null, OnDataAddedHandler onSuccess = null)
        {
            var command = this.Command(collection);
            command.AddData(data, onError, onSuccess);
        }
    }
}
