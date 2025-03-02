namespace ChoreTracker.Models
{
    public class Category()
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Icon Icon { get; set; }
    }

    public class FrequencyType()
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Frequency()
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public FrequencyType FrequencyType { get; set; }
        public int FrequencyValue { get; set; }
    }

    public class Chore()
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Frequency Frequency { get; set; }
        public Category Category { get; set; }
        public DateTime LastDone { get; set; }
    }

    public class Icon()
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CSSClass { get; set; }
    }
}
