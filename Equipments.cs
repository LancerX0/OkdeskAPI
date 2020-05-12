namespace OkdeskAPI
{
    public class Equipments
    {
        public int id { get; set; }
        public string serial_number { get; set; }
        public string inventory_number { get; set; }
        public string comment { get; set; }
        public string type { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public int maintenance_entity_id { get; set; }
        public Parameter[] parameters { get; set; }
    }
}
