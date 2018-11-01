﻿using System;
using System.Runtime.Serialization.Formatters;
using System.Text;
using Newtonsoft.Json;
using Sitecore.Framework.Conditions;
using Sitecore.Xdb.MarketingAutomation.SqlServer.Serialization;

namespace Sitecore.Support.Xdb.MarketingAutomation.SqlServer.Serialization
{
  public class DefaultObjectSerializer : IObjectSerializer
  {
    protected static Encoding Encoding =>
      Encoding.UTF8;

    protected static JsonSerializerSettings JsonSerializerSettings =>
      new JsonSerializerSettings
      {
        TypeNameHandling = TypeNameHandling.All,
        TypeNameAssemblyFormat = FormatterAssemblyStyle.Full
      };

    public T Deserialize<T>(byte[] data) where T : class
    {
      Condition.Requires(data, "data").IsNotNull().IsNotEmpty();
      return JsonConvert.DeserializeObject<T>(Encoding.GetString(data), JsonSerializerSettings);
    }

    public object Deserialize(byte[] data, Type type)
    {
      Condition.Requires(data, "data").IsNotNull().IsNotEmpty();
      Condition.Requires(type, "type").IsNotNull();
      return JsonConvert.DeserializeObject(Encoding.GetString(data), type, JsonSerializerSettings);
    }

    public byte[] Serialize<T>(T data)
    {
      Condition.Requires(data, "data").IsNotNull();
      var s = JsonConvert.SerializeObject(data, JsonSerializerSettings);
      return Encoding.GetBytes(s);
    }
  }
}