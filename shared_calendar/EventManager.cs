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

        public List<CalendarEvent>? GetEvents(TimeOnly? startTime, TimeOnly? endTime)
        {
            // handle if either param is null. if endtime is null, then search only by starttime

            using var context = _dbFactory.CreateDbContext();
            IQueryable<CalendarEvent> query;
         
            if (startTime == null && endTime == null)
            {
                return null;
            }
            else if (startTime != null && endTime == null) // search via startTime
            {
                query = from eventItem in context.CalendarEvent
                                           where eventItem.StartTime == startTime.ToString()
                                           select eventItem;
            }
            else if (startTime == null && endTime != null) // search via endTime
            {
                query = from eventItem in context.CalendarEvent
                                                  where eventItem.EndTime == endTime.ToString()
                                                  select eventItem;
            }
            else // search via both
            {
                query = from eventItem in context.CalendarEvent
                                                  where eventItem.StartTime == startTime.ToString()
                                                  where eventItem.EndTime == endTime.ToString()
                                                  select eventItem;
            }

            return query.ToList();
        }

        public List<CalendarEvent> GetEvents(DateOnly date)
        {
            using var context = _dbFactory.CreateDbContext();
            IQueryable<CalendarEvent> query = from eventItem in context.CalendarEvent
                                              where eventItem.Date.ToString().Contains(date.ToString())
                                              select eventItem;
            return query.ToList();
        }

        public List<CalendarEvent> GetEvents(DateOnly date, TimeOnly? startTime, TimeOnly? endTime)
        {
            using var context = _dbFactory.CreateDbContext();
            IQueryable<CalendarEvent> query;

            if (startTime == null && endTime == null)
            {
                return GetEvents(date);
            }
            else if (startTime == null && endTime != null) // seach via date and endTime
            {
                query = from eventItem in context.CalendarEvent
                                                  where eventItem.Date.ToString().Contains(date.ToString())
                                                  where eventItem.EndTime == endTime.ToString()
                                                  select eventItem;
            }
            else if (startTime != null && endTime == null) // search via date ad startTime
            {
                query = from eventItem in context.CalendarEvent
                                                  where eventItem.Date.ToString().Contains(date.ToString())
                                                  where eventItem.StartTime == startTime.ToString()
                                                  select eventItem;
            }
            else // search via date, startTime, and endTime
            {
                query = from eventItem in context.CalendarEvent
                                                  where eventItem.Date.ToString().Contains(date.ToString())
                                                  where eventItem.EndTime == endTime.ToString()
                                                  where eventItem.StartTime == startTime.ToString()
                                                  select eventItem;
            }

            return query.ToList();
        }

        public List<CalendarEvent> GetEvents(DateOnly date, TimeOnly? startTime, TimeOnly? endTime, string title)
        {
            using var context = _dbFactory.CreateDbContext();
            IQueryable<CalendarEvent> query;

            if (startTime == null && endTime == null) // search via date, title
            {
                query = from eventItem in context.CalendarEvent
                                                  where eventItem.Date.ToString().Contains(date.ToString())
                                                  where eventItem.Title == title
                                                  select eventItem;
            }
            else if (startTime != null && endTime == null) // search via date, title, startTime
            {
                query = from eventItem in context.CalendarEvent
                        where eventItem.Date.ToString().Contains(date.ToString())
                        where eventItem.Title == title
                        where eventItem.StartTime == startTime.ToString()
                        select eventItem;
            }
            else if (startTime == null && endTime != null) // search via date, title, endTime
            {
                query = from eventItem in context.CalendarEvent
                        where eventItem.Date.ToString().Contains(date.ToString())
                        where eventItem.Title == title
                        where eventItem.EndTime == endTime.ToString()
                        select eventItem;
            }
            else // search via date, title, startTime, endTime
            {
                query = from eventItem in context.CalendarEvent
                        where eventItem.Date.ToString().Contains(date.ToString())
                        where eventItem.Title == title
                        where eventItem.StartTime != startTime.ToString()
                        where eventItem.EndTime == endTime.ToString()
                        select eventItem;
            }

            return query.ToList();
        }
    }
}