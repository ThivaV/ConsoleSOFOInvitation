using System;
using System.Collections.Generic;
using System.Text;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;

namespace ConsoleSOFOInvitation
{
    public class CalEvent
    {
        [JsonProperty("@odata.context")]
        public Uri OdataContext { get; set; }

        [JsonProperty("@odata.id")]
        public Uri OdataId { get; set; }

        [JsonProperty("@odata.etag")]
        public string OdataEtag { get; set; }

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("CreatedDateTime")]
        public DateTimeOffset CreatedDateTime { get; set; }

        [JsonProperty("LastModifiedDateTime")]
        public DateTimeOffset LastModifiedDateTime { get; set; }

        [JsonProperty("ChangeKey")]
        public string ChangeKey { get; set; }

        [JsonProperty("Categories")]
        public object[] Categories { get; set; }

        [JsonProperty("TransactionId")]
        public object TransactionId { get; set; }

        [JsonProperty("OriginalStartTimeZone")]
        public string OriginalStartTimeZone { get; set; }

        [JsonProperty("OriginalEndTimeZone")]
        public string OriginalEndTimeZone { get; set; }

        [JsonProperty("iCalUId")]
        public string ICalUId { get; set; }

        [JsonProperty("ReminderMinutesBeforeStart")]
        public long ReminderMinutesBeforeStart { get; set; }

        [JsonProperty("IsReminderOn")]
        public bool IsReminderOn { get; set; }

        [JsonProperty("HasAttachments")]
        public bool HasAttachments { get; set; }

        [JsonProperty("Subject")]
        public string Subject { get; set; }

        [JsonProperty("BodyPreview")]
        public string BodyPreview { get; set; }

        [JsonProperty("Importance")]
        public string Importance { get; set; }

        [JsonProperty("Sensitivity")]
        public string Sensitivity { get; set; }

        [JsonProperty("IsAllDay")]
        public bool IsAllDay { get; set; }

        [JsonProperty("IsCancelled")]
        public bool IsCancelled { get; set; }

        [JsonProperty("IsOrganizer")]
        public bool IsOrganizer { get; set; }

        [JsonProperty("IsRoomRequested")]
        public bool IsRoomRequested { get; set; }

        [JsonProperty("AutoRoomBookingStatus")]
        public string AutoRoomBookingStatus { get; set; }

        [JsonProperty("ResponseRequested")]
        public bool ResponseRequested { get; set; }

        [JsonProperty("SeriesMasterId")]
        public object SeriesMasterId { get; set; }

        [JsonProperty("ShowAs")]
        public string ShowAs { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("WebLink")]
        public Uri WebLink { get; set; }

        [JsonProperty("OnlineMeetingUrl")]
        public Uri OnlineMeetingUrl { get; set; }

        [JsonProperty("IsOnlineMeeting")]
        public bool IsOnlineMeeting { get; set; }

        [JsonProperty("OnlineMeetingProvider")]
        public string OnlineMeetingProvider { get; set; }

        [JsonProperty("AllowNewTimeProposals")]
        public bool AllowNewTimeProposals { get; set; }

        [JsonProperty("OccurrenceId")]
        public object OccurrenceId { get; set; }

        [JsonProperty("IsDraft")]
        public bool IsDraft { get; set; }

        [JsonProperty("ResponseStatus")]
        public Status ResponseStatus { get; set; }

        [JsonProperty("Body")]
        public Body Body { get; set; }

        [JsonProperty("Start")]
        public End Start { get; set; }

        [JsonProperty("End")]
        public End End { get; set; }

        [JsonProperty("Location")]
        public Location Location { get; set; }

        [JsonProperty("Locations")]
        public Location[] Locations { get; set; }

        [JsonProperty("Recurrence")]
        public Recurrence Recurrence { get; set; }

        [JsonProperty("AutoRoomBookingOptions")]
        public object AutoRoomBookingOptions { get; set; }

        [JsonProperty("Attendees")]
        public Attendee[] Attendees { get; set; }

        [JsonProperty("Organizer")]
        public Organizer Organizer { get; set; }

        [JsonProperty("OnlineMeeting")]
        public OnlineMeeting OnlineMeeting { get; set; }

        [JsonProperty("Calendar@odata.associationLink")]
        public Uri CalendarOdataAssociationLink { get; set; }

        [JsonProperty("Calendar@odata.navigationLink")]
        public Uri CalendarOdataNavigationLink { get; set; }
    }

    public class Attendee
    {
        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Status")]
        public Status Status { get; set; }

        [JsonProperty("EmailAddress")]
        public EmailAddress EmailAddress { get; set; }
    }

    public class EmailAddress
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }
    }

    public class Status
    {
        [JsonProperty("Response")]
        public string Response { get; set; }

        [JsonProperty("Time")]
        public DateTimeOffset Time { get; set; }
    }

    public class Body
    {
        [JsonProperty("ContentType")]
        public string ContentType { get; set; }

        [JsonProperty("Content")]
        public string Content { get; set; }
    }

    public class End
    {
        [JsonProperty("DateTime")]
        public DateTimeOffset DateTime { get; set; }

        [JsonProperty("TimeZone")]
        public string TimeZone { get; set; }
    }

    public class Location
    {
        [JsonProperty("DisplayName")]
        public string DisplayName { get; set; }

        [JsonProperty("LocationUri")]
        public Uri LocationUri { get; set; }

        [JsonProperty("LocationType")]
        public string LocationType { get; set; }

        [JsonProperty("UniqueId")]
        public Uri UniqueId { get; set; }

        [JsonProperty("UniqueIdType")]
        public string UniqueIdType { get; set; }

        [JsonProperty("Address")]
        public Address Address { get; set; }

        [JsonProperty("Coordinates")]
        public Coordinates Coordinates { get; set; }
    }

    public class Address
    {
        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Street")]
        public string Street { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("State")]
        public string State { get; set; }

        [JsonProperty("CountryOrRegion")]
        public string CountryOrRegion { get; set; }

        [JsonProperty("PostalCode")]
        public string PostalCode { get; set; }
    }

    public class Coordinates
    {
        [JsonProperty("Latitude")]
        public double Latitude { get; set; }

        [JsonProperty("Longitude")]
        public double Longitude { get; set; }
    }

    public class OnlineMeeting
    {
        [JsonProperty("JoinUrl")]
        public Uri JoinUrl { get; set; }

        [JsonProperty("QuickDial")]
        public string QuickDial { get; set; }
    }

    public class Organizer
    {
        [JsonProperty("EmailAddress")]
        public EmailAddress EmailAddress { get; set; }
    }

    public class Recurrence
    {
        [JsonProperty("Pattern")]
        public Pattern Pattern { get; set; }

        [JsonProperty("Range")]
        public Range Range { get; set; }
    }

    public class Pattern
    {
        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Interval")]
        public long Interval { get; set; }

        [JsonProperty("Month")]
        public long Month { get; set; }

        [JsonProperty("DayOfMonth")]
        public long DayOfMonth { get; set; }

        [JsonProperty("DaysOfWeek")]
        public string[] DaysOfWeek { get; set; }

        [JsonProperty("FirstDayOfWeek")]
        public string FirstDayOfWeek { get; set; }

        [JsonProperty("Index")]
        public string Index { get; set; }
    }

    public class Range
    {
        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("StartDate")]
        public DateTimeOffset StartDate { get; set; }

        [JsonProperty("EndDate")]
        public DateTimeOffset EndDate { get; set; }

        [JsonProperty("RecurrenceTimeZone")]
        public string RecurrenceTimeZone { get; set; }

        [JsonProperty("NumberOfOccurrences")]
        public long NumberOfOccurrences { get; set; }
    }
}
