using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Planning
{
    class Pay
    {
        decimal totalHours { get; set; }
        DateTime startDate { get; set; }
        DateTime endTime { get; set; }
        decimal eveneningHours { get; set; }
        decimal weekendHours { get; set; }
        decimal nightHours { get; set; }
        decimal totalPay { get; set; }

    }
}
