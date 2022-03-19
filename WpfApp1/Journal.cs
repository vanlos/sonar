using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Journal
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Person1 { get; set; }
        public string Account1 { get; set; }
        public string Person2 { get; set; }
        public string Account2 { get; set; }

        public Journal() { }
        public Journal(int id, string type, string person1, string account1, string person2, string account2)
        {
            Id = id;
            Type = type;
            Person1 = person1;
            Account1 = account1;
            Person2 = person2;
            Account2 = account2;
        }
    }
}
