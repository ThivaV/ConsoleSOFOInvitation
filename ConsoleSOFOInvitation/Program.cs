using System;
using System.Collections.Generic;
using System.IO;
//using Microsoft.Office365.OutlookServices;
using Microsoft.Graph.Core;
using Newtonsoft.Json;

namespace ConsoleSOFOInvitation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //CalEvent calEvent = JsonConvert.DeserializeObject<CalEvent>(File.ReadAllText(@"D:\POC\ConsoleSOFOInvitation\ConsoleSOFOInvitation\SampleCalendarEvent.json"));
            //ICalSO calSO = new ICalSO();
            //calSO.CreateICS(calEvent);

            Event calEvent = JsonConvert.DeserializeObject<event>(File.ReadAllText(@"D:\POC\ConsoleSOFOInvitation\ConsoleSOFOInvitation\MSGraphEvent.json"));
            ICalSOMSGraphs calSO = new ICalSOMSGraphs();
            calSO.CreateICS(calEvent);
        }
    }
}
