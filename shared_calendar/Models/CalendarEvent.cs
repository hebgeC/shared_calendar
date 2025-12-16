using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace shared_calendar.Models
{
    public class CalendarEvent
    {
        public CalendarEvent() 
        {
            this.StartTime = DateTime.Now;
            this.EndTime = DateTime.Now;
            this.Title = string.Empty;
            this.Description = string.Empty;
        }

        public int id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}