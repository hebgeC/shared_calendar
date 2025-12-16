using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace shared_calendar.Models
{
    public class CalendarEvent
    {
        public CalendarEvent() 
        {
            this.date = DateTime.Now;
            this.endTime = TimeOnly.FromDateTime(DateTime.Now);
            this.startTime = TimeOnly.FromDateTime(DateTime.Now);
            this.Title = string.Empty;
            this.Description = string.Empty;
        }

        private TimeOnly startTime;
        private TimeOnly endTime;
        private DateTime date;

        public int id { get; set; }

        public DateTime? Date 
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = (DateTime)value;
            }
        }

        public string StartTime 
        {
            get
            {
                return this.startTime.ToString();
            }

            set
            {
                try
                {
                    startTime = TimeOnly.Parse(value);
                } 
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    this.startTime = new TimeOnly();
                }
            }
        } 
        public string EndTime
        {
            get
            {
                return this.endTime.ToString();
            }
            set
            {
                try
                {
                    endTime = TimeOnly.Parse(value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    this.endTime = new TimeOnly();
                }
            }
        }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

