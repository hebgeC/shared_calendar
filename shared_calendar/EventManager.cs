using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using MudBlazor.Interop;
using shared_calendar.Data;
using shared_calendar.Models;

namespace shared_calendar
{
    public class EventManager
    {
        private IDbContextFactory<shared_calendar.Data.ApplicationDbContext> _dbFactory;

        public EventManager(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            this._dbFactory = dbFactory;
        }

        public List<CalendarEvent> GetEvents()
        {
            using var context = _dbFactory.CreateDbContext();
            return context.CalendarEvent.ToList();
        }
        
        public List<CalendarEvent> GetEvents(string title)
        {
            using var context = _dbFactory.CreateDbContext();
            IQueryable<CalendarEvent> query = from eventItem in context.CalendarEvent 
                                              where eventItem.Title == title
                                              select eventItem;
            return query.ToList();
        }

        public List<CalendarEvent> GetEvents(TimeSpan span)
        {
            throw new NotImplementedException(); 
        }

        public List<CalendarEvent>? GetEvents(DateTime? start, DateTime? end)
        {
            // handle if either param is null. if endtime is null, then search only by starttime

            using var context = _dbFactory.CreateDbContext();
            IQueryable<CalendarEvent> query;

            if (start == null && end == null)
            {
                return null;
            }
            else if (start != null && end == null) // search via start time only
            {
                query = from eventItem in context.CalendarEvent
                        where eventItem.StartDateTime == start
                        select eventItem;
            }
            else if (start == null && end != null) // search via end time only
            {
                query = from eventItem in context.CalendarEvent
                        where eventItem.EndDateTime == end
                        select eventItem;
            }
            else // search via both start and end time
            {
                query = from eventItem in context.CalendarEvent
                        where eventItem.StartDateTime == start && eventItem.EndDateTime == end
                        select eventItem;
            }

            return query.ToList();
        }

        public List<CalendarEvent> GetEvents(DateTime? start, DateTime? end, string title)
        {
            using var context = _dbFactory.CreateDbContext();
            IQueryable<CalendarEvent> query;

            if (start == null && end == null)
            {
                return this.GetEvents(title);
            }
            else if (start != null && end == null) // search via start and title
            {
                query = from eventItem in context.CalendarEvent
                        where eventItem.StartDateTime == start
                        where eventItem.Title == title
                        select eventItem;
            }
            else if (start == null && end != null) // searh via end and title
            {
                query = from eventItem in context.CalendarEvent
                        where eventItem.EndDateTime == end
                        where eventItem.Title == title
                        select eventItem;
            }
            else // search via start, end, title
            {
                query = from eventItem in context.CalendarEvent
                        where eventItem.StartDateTime == start
                        where eventItem.EndDateTime == end
                        where eventItem.Title == title
                        select eventItem;
            }

            return query.ToList();
        }
    }
}