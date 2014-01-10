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
