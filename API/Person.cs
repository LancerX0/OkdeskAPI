namespace OkdeskAPI
{
    public class Person
    {
        public int id { get; set; }
        public string type { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
