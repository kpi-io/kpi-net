using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KPI.Client
{
    public delegate void OnErrorHandler(Exception exception);

    public delegate void OnDataAddedHandler(object data);

    internal delegate void OnHttpSuccessHandler(string result);
}
