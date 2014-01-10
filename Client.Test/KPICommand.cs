using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using KPI.Client;
using System.Threading;
using System.Configuration;
using System.Threading.Tasks;

namespace Client.Test
{
    [TestFixture]
    public class KPICommand
    {
        internal class Data
        {
            internal class Kpi
            {
                public DateTime timestamp;
                public DateTime createDate;
                internal Kpi()
                {
                    this.timestamp = DateTime.Now.AddDays(5);
                    this.createDate = DateTime.Now.AddDays(-5);
                }
            }
            public int Id { get; set; }
            public string Name { get; set; }
            public Kpi _kpi { get; set; }

            internal Data(int id, string name)
            {
                this.Id = id;
                this.Name = name;
                this._kpi = new Kpi();
            }
        }

        [Test]
        public void add_data()
        {
            Console.WriteLine("add_data start");
            KPIFactory factory = new KPIFactory(new KPIConfiguration("519f23ee180b7b1f74dedc96", null, null, null, "w", 5));
            List<Data> list = new List<Data>();

            list.Add(new Data(1, "bir"));
            list.Add(new Data(2, "iki"));
            list.Add(new Data(3, "üç"));
            list.Add(new Data(4, "dört"));
            list.Add(new Data(5, "beş"));
            list.Add(new Data(6, "altı"));
            list.Add(new Data(7, "yedi"));
            list.Add(new Data(8, "sekiz"));
            list.Add(new Data(9, "dokuz"));
            list.Add(new Data(10, "on"));
            list.Add(new Data(11, "onbir"));
            list.Add(new Data(12, "oniki"));
            list.Add(new Data(13, "onüç"));
            list.Add(new Data(14, "ondört"));
            list.Add(new Data(15, "onbeş"));
            list.Add(new Data(16, "onaltı"));
            list.Add(new Data(17, "onyedi"));
            list.Add(new Data(18, "onsekiz"));
            list.Add(new Data(19, "ondokuz"));
            list.Add(new Data(20, "yirmi"));
            list.Add(new Data(21, "yirmibir"));
            list.Add(new Data(22, "yirmiiki"));
            list.Add(new Data(23, "yirmiüç"));
            list.Add(new Data(24, "yirmidört"));
            list.Add(new Data(25, "yirmibeş"));
            list.Add(new Data(26, "yirmialtı"));
            list.Add(new Data(27, "yirmiyedi"));
            list.Add(new Data(28, "yirmisekiz"));
            list.Add(new Data(29, "yirmidokuz"));
            list.Add(new Data(30, "otuz"));
            list.Add(new Data(31, "otuzbir"));

            Parallel.ForEach(list, new ParallelOptions
            {
                MaxDegreeOfParallelism = 8
            }, (item) =>
            {
                factory.AddData("command_test", item, (err) =>
                {
                    Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(err));
                    Assert.Fail();
                }, (obj) =>
                {
                    Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
                });
            });

            /*
            factory.AddData("command_test", new Data(1, "bir"), (err) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(err));
                Assert.Fail();
            }, (obj) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
            });
            factory.AddData("command_test", new Data(2, "iki"), (err) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(err));
                Assert.Fail();
            }, (obj) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
            });
            factory.AddData("command_test", new Data(3, "üç"), (err) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(err));
                Assert.Fail();
            }, (obj) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
            });
            factory.AddData("command_test", new Data(4, "dört"), (err) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(err));
                Assert.Fail();
            }, (obj) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
            });
            factory.AddData("command_test", new Data(5, "beş"), (err) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(err));
                Assert.Fail();
            }, (obj) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
            });
            factory.AddData("command_test", new Data(6, "altı"), (err) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(err));
                Assert.Fail();
            }, (obj) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
            });
            factory.AddData("command_test", new Data(7, "yedi"), (err) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(err));
                Assert.Fail();
            }, (obj) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
            });
            factory.AddData("command_test", new Data(8, "sekiz"), (err) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(err));
                Assert.Fail();
            }, (obj) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
            });
            factory.AddData("command_test", new Data(9, "dokuz"), (err) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(err));
                Assert.Fail();
            }, (obj) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
            });
            factory.AddData("command_test", new Data(10, "on"), (err) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(err));
                Assert.Fail();
            }, (obj) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
            });
            factory.AddData("command_test", new Data(11, "onbir"), (err) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(err));
                Assert.Fail();
            }, (obj) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
            });
            factory.AddData("command_test", new Data(12, "oniki"), (err) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(err));
                Assert.Fail();
            }, (obj) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
            });
            factory.AddData("command_test", new Data(13, "onüç"), (err) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(err));
                Assert.Fail();
            }, (obj) =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
            });
            */
            factory.Command("command_test").Flush();
            Thread.Sleep(1000);
        }
    }
}
