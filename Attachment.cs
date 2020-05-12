using System;

namespace OkdeskAPI
{
    public class Attachment
    {
        public Attachment(string attachmentFileName, string description)
        {
            this.attachmentFileName = attachmentFileName;
            this.description = description;
        }

        public int id { get; set; }
        public string attachmentFileName { get; set; }
        public string description { get; set; }
        public int attachmentFileSize { get; set; }
        public bool isPublic { get; set; }
        public DateTime? createdAt { get; set; }
    }
}
