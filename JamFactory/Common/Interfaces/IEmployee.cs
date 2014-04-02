using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IEmployee
    {
        int id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        decimal HoursPrWeek { get; set; }
        decimal HourlyRate { get; set; }
    }
}
