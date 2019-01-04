using System;

namespace WebApp.Web.Models
{
    public class StudentModel
    {
        public decimal StudentIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public char Sex { get; set; }
        public decimal Group { get; set; }
        public decimal Sot { get; set; }
        public decimal GroupResponsable { get; set; }
        public decimal Coda { get; set; }
    }
}
