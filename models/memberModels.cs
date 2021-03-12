using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELibrary.models
{
    public class memberModels
    {
        public string fullName { get; set; }
        public string birthdate { get; set; }
        public string contactNo { get; set; }
        public string email { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string zipCode { get; set; }
        public string fullAddress { get; set; }
        public string memberID { get; set; }
        public string password { get; set; }
        public string accountStatus { get; set; }
    }
}