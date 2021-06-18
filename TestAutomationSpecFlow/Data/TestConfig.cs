using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Utf8Json;

namespace TestAutomationSpecFlow.Data
{
    public class TestConfig
    {
        public string BaseURL { get; set; }
        public string Browser { get; set; }

        public static TestConfig GetConfigData()
        {
            byte[] json = File.ReadAllBytes("config.json");
            TestConfig config = JsonSerializer.Deserialize<TestConfig>(json);
            return config;
        }
    }
}
