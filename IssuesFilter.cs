using System;
using System.Collections.Generic;
using System.Text;

namespace OkdeskAPI
{
    class IssuesFilter
    {
        public int[] assignee_ids;
        public int[] company_ids;
        public int[] contact_ids;
        public int[] author_employee_ids;
        public int[] author_contact_ids;
        public int[] maintenance_entity_ids;
        public string[] status;
        public string[] status_not;
        public string[] priority;
        public string[] type;
        public string created_since;
        public string created_until;
        public string completed_since;
        public string completed_until;
        public string updated_since;
        public string updated_until;
        public string reacted_since;
        public string reacted_until;
        public string deadline_since;
        public string deadline_until;
        public int overdue;
        public int overdue_reaction;

        public IssuesFilter()
        {
            assignee_ids = null;
            company_ids = null;
            contact_ids = null;
            author_employee_ids = null;
            author_contact_ids = null;
            maintenance_entity_ids = null;
            status = null;
            status_not = null;
            priority = null;
            type = null;
            created_since = "";
            created_until = "";
            completed_since = "";
            completed_until = "";
            updated_since = "";
            updated_until = "";
            reacted_since = "";
            reacted_until = "";
            deadline_since = "";
            deadline_until = "";
            overdue = 0;
            overdue_reaction = 0;
        }

        public string getFilterString()
        {
            string result = "";
            result += getFilterIntegerArray(assignee_ids, "assignee_ids");
            result += getFilterIntegerArray(company_ids, "company_ids");
            result += getFilterIntegerArray(contact_ids, "contact_ids");
            result += getFilterIntegerArray(author_employee_ids, "author_employee_ids");
            result += getFilterIntegerArray(author_contact_ids, "author_contact_ids");
            result += getFilterIntegerArray(maintenance_entity_ids, "maenance_entity_ids");
            result += getFilterStringArray(status, "status");
            result += getFilterStringArray(status_not, "status_not");
            result += getFilterStringArray(priority, "priority");
            result += getFilterStringArray(type, "type");
            result += getFilterString(created_since, "created_since");
            result += getFilterString(created_until, "created_until");
            result += getFilterString(completed_since, "completed_since");
            result += getFilterString(completed_until, "completed_until");
            result += getFilterString(updated_since, "updated_since");
            result += getFilterString(updated_until, "updated_until");
            result += getFilterString(reacted_since, "reacted_since");
            result += getFilterString(reacted_until, "reacted_until");
            result += getFilterString(deadline_since, "deadline_since");
            result += getFilterString(deadline_until, "deadline_until");
            result += getFilterInteger(overdue, "overdue");
            result += getFilterInteger(overdue_reaction, "overdue_reaction");
            return result;
        }

        private string getFilterIntegerArray(int[] array, string paramName)
        {
            string result = "";
            if (array != null && array.Length > 0)
                foreach (int element in array)
                    result += "&" + paramName + "[]=" + element.ToString();
            return result;
        }

        private string getFilterStringArray(string[] array, string paramName)
        {
            string result = "";
            if (array != null && array.Length > 0)
                foreach (string element in array)
                    result += "&" + paramName + "[]=" + element;
            return result;
        }

        private string getFilterInteger(int value, string paramName)
        {
            if (value != 0)
                return "&" + paramName + "=" + value.ToString();
            else
                return "";
        }

        private string getFilterString(string value, string paramName)
        {
            if (value != "")
                return "&" + paramName + "=" + value;
            else
                return "";
        }
    }
}
