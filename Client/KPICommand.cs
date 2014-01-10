using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KPI.Client
{
    public delegate void testDelegate(int a);
    public class KPICommand
    {
        private object lockObj = new object();
        public KPIConfiguration Config { get; private set; }
        public string Collection { get; private set; }
        private Queue<DataItem> queue;
        private KPISecureClient client;

        public KPICommand(KPIConfiguration config, string collection)
        {
            this.Config = config;
            this.client = new KPISecureClient(this.Config.WriteKey);
            this.Collection = collection;
            this.queue = new Queue<DataItem>();
        }

        public void AddData(object data, OnErrorHandler onError = null, OnDataAddedHandler onSuccess = null)
        {
            if (onError == null)
            {
                onError = this.OnError;
            }
            if (onSuccess == null)
            {
                onSuccess = this.OnSuccess;
            }
            DataItem item = null;
            try
            {
                item = new DataItem(data, onError, onSuccess);
            }
            catch (Exception exc)
            {
                onError(exc);
                return;
            }
            this.queue.Enqueue(item);
            this.Send(this.Config.BatchSize);
        }

        public void Flush()
        {
            this.Send(0);
        }

        private void Send(int bufferSize)
        {
            while (this.queue.Count>0 && this.queue.Count >= bufferSize)
            {
                List<DataItem> items = new List<DataItem>();
                lock (this.lockObj)
                {
                    if (this.queue.Count > 0 && this.queue.Count >= bufferSize)
                    {
                        while (this.queue.Count > 0 && items.Count < this.Config.BatchSize)
                        {
                            items.Add(this.queue.Dequeue());
                        }
                    }
                }
                if (items.Count > 0)
                {
                    var list = items.Select(t => t.Data).ToArray();
                    this.client.Send("POST", "/projects/" + this.Config.ProjectId + "/collections/" + this.Collection + "/data", null, list, (err) =>
                    {
                        foreach (var item in items)
                        {
                            item.OnError(err);
                        }
                    }, (result) => {
                        foreach (var item in items)
                        {
                            item.OnSuccess(item.Data);
                        }
                    });
                }
            }
        }

        private void OnError(Exception exception)
        {
            Console.Write(exception);
        }

        private void OnSuccess(object obj)
        {
            Console.Write(obj);
        }

        internal class DataItem
        {
            internal object Data { get; set; }
            internal OnErrorHandler OnError { get; set; }
            internal OnDataAddedHandler OnSuccess { get; set; }
            internal DataItem(object data, OnErrorHandler onError, OnDataAddedHandler onSuccess)
            {
                if (data == null)
                {
                    throw new ArgumentNullException("data");
                }
                var type = data.GetType();
                if (!(type.IsClass && !type.IsPrimitive))
                {
                    throw new Exception("Invalid parameter");
                }
                this.Data = data;
                this.OnError = onError;
                this.OnSuccess = onSuccess;
            }
        }
    }
}
