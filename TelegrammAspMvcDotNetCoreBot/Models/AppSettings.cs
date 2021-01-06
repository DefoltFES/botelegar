using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegrammAspMvcDotNetCoreBot.Models
{
    public static class AppSettings
    {
        public static string Url { get; set; } = "https://botelegar.herokuapp.com:443/{0}";
        public static string Name { get; set; } = "BadInsultbot";
        public static string Key { get; set; } = "1553473590:AAFGSAxdg5Ig4BPExD9FQS_d-4DXvZ3BEsE";
    }
}