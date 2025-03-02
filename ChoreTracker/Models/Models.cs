using System.ComponentModel.DataAnnotations.Schema;

namespace ChoreTracker.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Icon Icon { get; set; }
    }

    public class FrequencyType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Frequency
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public FrequencyType FrequencyType { get; set; }
        public int FrequencyValue { get; set; }
    }

    public class Chore
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Frequency Frequency { get; set; }
        public Category Category { get; set; }
        public DateTime LastDone { get; set; }
        public DateTime? DoByDatetime { get; set; }
        public TimeSpan? TimeRemaining { get; set; }

        public Chore(int iD, string name, string description, Frequency frequency, Category category, DateTime lastDone)
        {
            ID = iD;
            Name = name;
            Description = description;
            Frequency = frequency;
            Category = category;
            LastDone = lastDone;
            DoByDatetime = ComputeDoByDate();
            TimeRemaining = ComputeTimeRemaining();
        }

        public Chore()
        {
        }

        public void SetComputedProperties()
        {
            DoByDatetime = ComputeDoByDate();
            TimeRemaining = ComputeTimeRemaining();
        }

        private DateTime? ComputeDoByDate()
        {
            switch (Frequency.FrequencyType.Name.ToUpper())
            {
                case "DAILY":
                    return DateTime.Now.AddDays(Frequency.FrequencyValue);
                case "COUNTER":
                    return null;
                case "MONTHLY":
                    var todayDate = DateTime.Now;
                    var today = todayDate.Day;
                    if (Frequency.FrequencyValue >= today)
                    {
                        return new DateTime(todayDate.Year, todayDate.Month, today);
                    }
                    else
                    {
                        return new DateTime(todayDate.Year, todayDate.Month, today).AddMonths(1);
                    }
                default:
                    return null;
            }

        }

        private TimeSpan? ComputeTimeRemaining()
        {
            switch (Frequency.FrequencyType.Name.ToUpper())
            {
                case "DAILY":
                    if (DoByDatetime != null)
                    {
                        return DoByDatetime.Value.Subtract(DateTime.Now);
                    }
                    else
                    {
                        return null;
                    }
                case "COUNTER":
                    return null;
                case "MONTHLY":
                    if (DoByDatetime != null)
                    {
                        return DoByDatetime.Value.Subtract(DateTime.Now);
                    }
                    else
                    {
                        return null; 
                    }
                default:
                    return null;

            }      
        }
    }

    public class Icon
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [Column("CSS_CLASS")]
        public string CSSClass { get; set; }
    }
}
