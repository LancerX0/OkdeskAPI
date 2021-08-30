using System;

namespace OkdeskAPI
{

    public class Contacts
    {
        public int id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string mobile_phone { get; set; }
        public string comment { get; set; }
        public string cc_email { get; set; }
        public string login { get; set; }
        public int crm_1c_id { get; set; }
        public DateTime? updated_at { get; set; }
        public int company_id { get; set; }
        public string additional_emails { get; set; }
        public string[] access_level { get; set; }
        public int[] maintenance_entity_ids { get; set; }
        public string authentication_code { get; set; }
        public Person[] observers { get; set; }
        public Person default_assignee { get; set; }
        public Parameter[] parameters { get; set; }
        public Person[] observable_companies { get; set; }
    }
}
