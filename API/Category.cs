

namespace OkdeskAPI
{
    public class Category
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public Category(int id, string code, string name, string color)
        {
            this.id = id;
            this.code = code;
            this.name = name;
            this.color = color;
        }
    }
}
