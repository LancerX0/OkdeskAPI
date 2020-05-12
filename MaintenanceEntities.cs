namespace OkdeskAPI
{
    public class MaintenanceEntities
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string comment { get; set; }
        public int default_assignee_id { get; set; }
        public int default_assignee_group_id { get; set; }
        public int company_id { get; set; }
        public int[] contacts_ids { get; set; }
        public int[] equipments_ids { get; set; }
        public float[] coordinates { get; set; }
        public Parameter[] parameters { get; set; }
    }
}
