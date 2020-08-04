using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OkdeskAPI
{
    public class Okdesk
    {
        private readonly string API_Key;
        private readonly string API_URL;
        private static readonly HttpClient client = new HttpClient();
        
        public Okdesk()
        {
        }

        public Okdesk(string aPI_Key, string aPI_URL)
        {
            API_Key = aPI_Key;
            API_URL = aPI_URL;
        }

        public bool testConnection()
        {
            try
            {
                string url = API_URL + "/api/v1/issues/count?api_token=" + API_Key;
                string res = sendGETRequest(url);

                return true;
            }
            catch(Exception exception)
            {
                Console.WriteLine("Exception: "+exception.Message);
                return false;
            }
        }

        public int[] getIssuesIds(IssuesFilter filter)
        {
            string url = API_URL + "/api/v1/issues/count?api_token=" + API_Key + filter.getFilterString();
            string res = sendGETRequest(url);
            if (res == "[]")
                return new int[0];
            res = res.Replace("[", "");
            res = res.Replace("]", "");
            string[] arr = res.Split(',');

            int[] result = arr.Select(s => int.Parse(s)).ToArray();
            return result;
        }

        public Issue[] getIssuesList(IssuesFilter filter)
        {
            int[] ids = getIssuesIds(filter);
            Issue[] result = new Issue[ids.Length];
            for (int i = 0; i < ids.Length; i++)
            {
                result[i] = getIssue(ids[i]);
            }
            return result;
        }

        public Issue getIssue(int id)
        {
            string url = API_URL + "/api/v1/issues/" + id.ToString() + "?api_token=" + API_Key;
            string response = (sendGETRequest(url));
            Issue result = JObject.Parse(response).ToObject<Issue>();
            return result;
        }

        public Company getCompanyByID(int id)
        {

            string url = API_URL + "/api/v1/companies/?api_token=" + API_Key + "&id=" + id.ToString();
            string response = (sendGETRequest(url));
            Company result = JObject.Parse(response).ToObject<Company>();
            return result;
        }

        //11
        public string addComment(int issueID, string content = "", int author_id = 0, Attachment[] attachments = null)
        {
            string url = API_URL + "/api/v1/issues/" + issueID.ToString() + "/comments?api_token=" + API_Key;
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            Dictionary<string, string> files = new Dictionary<string, string>();
            keyValues.Add("comment[content]", content);
            keyValues.Add("comment[author_id]", author_id.ToString());
            keyValues.Add("comment[public]", "true");
            if (attachments != null)
                for (int i = 0; i < attachments.Length; i++)
                {
                    files.Add("comment[attachments][" + i.ToString() + "][attachment]", attachments[i].attachmentFileName);
                    if (attachments[i].description != null && attachments[i].description != null)
                        keyValues.Add("comment[attachments][" + i.ToString() + "][description]", attachments[i].description);
                }

            string result = sendPOSTRequest(url, keyValues, files);
            return result;
        }

        private string sendGETRequest(string url)
        {

            Task<string> response = client.GetStringAsync(url);
            Console.WriteLine("GET request: " + url);
            string responseString = response.Result;

            return responseString;
        }

        private string sendPOSTRequest(string url, Dictionary<string, string> keyValues, Dictionary<string, string> files)
        {
            MultipartFormDataContent form = new MultipartFormDataContent();
            form.Headers.ContentType.MediaType = "multipart/form-data";
            foreach (KeyValuePair<string, string> entry in keyValues)
                form.Add(new StringContent(entry.Value), entry.Key);
            foreach (KeyValuePair<string, string> entry in files)
                if (File.Exists(entry.Value))
                {
                    byte[] file_bytes = File.ReadAllBytes(entry.Value);
                    form.Add(new ByteArrayContent(file_bytes, 0, file_bytes.Length), entry.Key, entry.Value);
                }

            Task<HttpResponseMessage> response = client.PostAsync(url, form);
            response.Wait();
            Task<string> respStr = response.Result.Content.ReadAsStringAsync();
            string responseString = respStr.Result;
            return responseString;
        }
    }

}

