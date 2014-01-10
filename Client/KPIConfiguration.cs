﻿// Copyright (c) KPI.IO
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
using System.Configuration;

namespace KPI.Client
{
    public class KPIConfiguration
    {
        public string ProjectId { get; set; }
        public string MasterKey { get; set; }
        public string ProjectKey { get; set; }
        public string ReadKey { get; set; }
        public string WriteKey { get; set; }
        public int BatchSize { get; set; }

        public KPIConfiguration(
            string projectId = null, 
            string masterKey = null, 
            string projectKey = null, 
            string readKey = null, 
            string writeKey = null, 
            int batchSize = KPIConstants.BatchSize)
        {
            this.ProjectId = projectId;
            this.MasterKey = masterKey;
            this.ProjectKey = projectKey;
            this.ReadKey = readKey;
            this.WriteKey = writeKey;
            this.BatchSize = batchSize;
        }
    }
}
