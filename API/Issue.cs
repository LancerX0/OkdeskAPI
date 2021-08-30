using OkdeskAPI;
using System;

namespace OkdeskAPI
{
    public class Issue
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? completed_at { get; set; }
        public DateTime? deadline_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? delayed_to { get; set; }
        public string source { get; set; }
        public float spent_time_total { get; set; }
        public DateTime? start_execution_until { get; set; }
        public float? planned_execution_in_hours { get; set; }
        public DateTime? planned_reaction_at { get; set; }
        public DateTime? reacted_at { get; set; }
        public int? company_id { get; set; }
        public int? group_id { get; set; }
        public int? service_object_id { get; set; }
        public int[] equipment_ids { get; set; }
        public Attachment[] attachments { get; set; }
        public Parameter[] parameters { get; set; }
        public int? parent_id { get; set; }
        public int[] child_ids { get; set; }
        public StatusTimes status_times { get; set; }
        public Status status { get; set; }
        public Status old_status { get; set; }
        public Person assignee { get; set; }
        public Person author { get; set; }
        public Agreement agreement { get; set; }
        public Person contact { get; set; }
        public Priority priority { get; set; }
        public IssueType type { get; set; }
        public Person[] observers { get; set; }
        public Person[] observer_groups { get; set; }
        public Comment comments { get; set; }

        public Issue()
        {
        }
        public override string ToString()
        {
            return id.ToString() + " | " + title;
        }
    }
}
