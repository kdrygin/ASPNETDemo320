namespace ASPNetDemo320
{
    public class Project
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }

        public Project()
        {}

        public Project(string s)
        {
            var data = s.Split(',');
            Name = data[0];
            Link = data[1];
            Description = data[2];
        }

        public override string ToString()
        {
            return $"{Name},{Link},{Description}";
        }
    }
}
