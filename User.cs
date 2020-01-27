using System;

namespace Anket
{
    class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public override string ToString()
        {
            return Name + " " + LastName;
        }
    }
}
