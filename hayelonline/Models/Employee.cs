using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hayelonline.Models
{
    public class Employee
    {
        public int Id { set; get; }
        public int Code { set; get; }
        public string EnglishName { set; get; }
        public string ArabicName { set; get; }
        public string JobTitle { set; get; }
        public string Department { set; get; }
        public string Email { set; get; }

    }
}
