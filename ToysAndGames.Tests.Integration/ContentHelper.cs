using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ToysAndGames.Tests.Integration
{
   public static class ContentHelper
   {
      public static StringContent GetStringContent(object obj)
          => new(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json");
   }
}
