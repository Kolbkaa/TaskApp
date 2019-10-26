using System;
using System.Collections.Generic;
using System.Text;

namespace TaskApp
{
    public class TaskModel
    {
        private string description;
        private DateTime startDate;
        private DateTime? endDate;
        private bool isAllDay = false;
        private bool isImportant = false;

        public string Description { get => description; private set => description = value; }
        public DateTime StartDate { get => startDate; private set => startDate = value; }
        public DateTime? EndDate
        {
            get
            {
                if (endDate == null)
                {
                    return startDate;
                }
                else
                {
                    return endDate;
                }
            }
            private set => endDate = value;
        }
        public bool IsAllDay { get => isAllDay; private set => isAllDay = value; }
        public bool IsImportant { get => isImportant; private set => isImportant = value; }
        public TaskModel(string desc, DateTime startDate, DateTime? endDate, bool isImportant)
        {
            Description = desc;
            StartDate = startDate;
            EndDate = endDate - startDate < TimeSpan.Zero ? startDate : endDate;
            IsAllDay = endDate != null ? false : true;
            IsImportant = isImportant;
        }
        public TaskModel(string desc, DateTime startDate, DateTime? endDate,bool isAllDay, bool isImportant)
        {
            Description = desc;
            StartDate = startDate;
            EndDate = endDate;
            IsAllDay = isAllDay;
            IsImportant = isImportant;
        }

    }
}
