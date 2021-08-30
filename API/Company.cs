namespace OkdeskAPI
{
    public class Company
    {
        public int id { get; set; }
        public string name { get; set; }
        public string additional_name { get; set; }
        public string site { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string comment { get; set; }
        public Person[] observers { get; set; }
        public Person[] contacts { get; set; }
        public Person default_assignee { get; set; }
        public Category category { get; set; }
        public Parameter[] parameters { get; set; }
    }
}
