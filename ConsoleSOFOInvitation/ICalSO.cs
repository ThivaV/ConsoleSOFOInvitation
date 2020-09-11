using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using Microsoft.Office365.OutlookServices;

namespace ConsoleSOFOInvitation
{
    class ICalSO
    {
        public void CreateICS(CalEvent calEvent) 
        {
            Ical.Net.Calendar calendar = new Ical.Net.Calendar 
            {
                Method = "REQUEST",
                Version = "2.0",
                ProductId = "SOFO Invitation"
            };

            CalendarEvent calendarEvent = new CalendarEvent
            {
                Uid = calEvent.ICalUId,
                DtStart = new CalDateTime(calEvent.Start.DateTime.Year, calEvent.Start.DateTime.Month, calEvent.Start.DateTime.Day, calEvent.Start.DateTime.Hour, calEvent.Start.DateTime.Minute, calEvent.Start.DateTime.Second, calEvent.Start.TimeZone), //Start = new CalDateTime(now),
                DtEnd = new CalDateTime(calEvent.End.DateTime.Year, calEvent.End.DateTime.Month, calEvent.End.DateTime.Day, calEvent.End.DateTime.Hour, calEvent.End.DateTime.Minute, calEvent.End.DateTime.Second, calEvent.End.TimeZone), //End = new CalDateTime(later),
                //DtStamp = new CalDateTime(calEvent.Start.DateTime.Year, calEvent.Start.DateTime.Month, calEvent.Start.DateTime.Day, calEvent.Start.DateTime.Hour, calEvent.Start.DateTime.Minute, calEvent.Start.DateTime.Second, calEvent.Start.TimeZone),
                IsAllDay = calEvent.IsAllDay,
                //Sequence = 0,
                //Class = "PUBLIC",
                //Priority = calEvent.Importance,
                //Transparency = TransparencyType.Transparent,
                Location = calEvent.Location.DisplayName,
                Summary = calEvent.Subject,
                Description = calEvent.BodyPreview,               
            };

            Ical.Net.DataTypes.Organizer organizer = new Ical.Net.DataTypes.Organizer();
            organizer.CommonName = calEvent.Organizer.EmailAddress.Name.ToString();
            organizer.Value = new Uri($"mailto:{calEvent.Organizer.EmailAddress.Address.ToString()}");
            calendarEvent.Organizer = organizer;

            //Repeat daily for 5 days
            var rrule = new Ical.Net.DataTypes.RecurrencePattern(FrequencyType.Daily, 1) { Count = 5 };
            calendarEvent.RecurrenceRules = new List<Ical.Net.DataTypes.RecurrencePattern> { rrule };

            //Attendees
            calendarEvent.Attendees = calEvent.Attendees.Select(a => new Ical.Net.DataTypes.Attendee() 
            {
                CommonName = a.EmailAddress.Name,
                ParticipationStatus = "REQ-PARTICIPANT",
                Rsvp = true,
                Value = new Uri($"mailto:{a.EmailAddress.Address}")
            }).ToList();
            
            //Alarm
            Alarm alarm = new Alarm()
            {
                Action = AlarmAction.Display,
                Trigger = new Trigger(TimeSpan.FromDays(-1)),
                Summary = calEvent.Subject
            };
            calendarEvent.Alarms.Add(alarm);

            calendar.Events.Add(calendarEvent);
            var serializer = new CalendarSerializer();
            var serializedCalendar = serializer.SerializeToString(calendar);

            StreamWriter sw = new StreamWriter("D:\\POC\\ConsoleSOFOInvitation\\ConsoleSOFOInvitation\\invitation.ics");
            sw.Write(serializedCalendar);

            sw.Close();
        }
    }
}
