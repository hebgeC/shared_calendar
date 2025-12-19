using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace shared_calendar.Models
{
    public class CalendarEvent
    {
        public CalendarEvent() 
        {
            this.StartDateTime = DateTime.Now;
            this.EndDateTime = DateTime.Now;
            this.Title = string.Empty;
            this.Description = string.Empty;
        }

        public int id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}