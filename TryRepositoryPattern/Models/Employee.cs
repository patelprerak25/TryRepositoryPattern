using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TryRepositoryPattern.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Employees")]
    public partial class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Nullable<int> Salary { get; set; }
    }
}
