using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELibrary.models
{
    public class bookInventoryModels
    {
        public string bookID { get; set; }
        public string bookName { get; set; }
        public string language { get; set; }
        public string authorName { get; set; }
        public string publisherName { get; set; }
        public string publishDate { get; set; }
        public string genre { get; set; }
        public string edition { get; set; }
        public string bookCost { get; set; }
        public string pages { get; set; }
        public string actualStock { get; set; }
        public string currentStock { get; set; }
        public string bookDescription { get; set; }
        public string bookLink { get; set; }
    }

    public class bookIssueModels
    {
        public string memberID { get; set; }
        public string bookID { get; set; }
        public string memberName { get; set; }
        public string bookName { get; set; }
        public string issueDate { get; set; }
        public string dueDate { get; set; }
    }
}