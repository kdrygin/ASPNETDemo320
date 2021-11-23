namespace ASPNetDemo320
{
    public class Project
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }

        // конструктор по умолчанию (для создания объекта во View)
        public Project()
        {}

        // конструктор для создания объекта из CVS строки 
        public Project(string s)
        {
            var data = s.Split(',');
            Name = data[0];
            Link = data[1];
            Description = data[2];
        }

        // преобразование объекта в CSV строку
        public override string ToString()
        {
            return $"{Name},{Link},{Description}";
        }
    }
}
