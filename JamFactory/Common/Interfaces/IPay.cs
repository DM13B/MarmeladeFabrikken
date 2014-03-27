using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    interface IPay
    {
        decimal totalHours;
        DateTime startDate;
        DateTime endTime;
        decimal eveneningHours;
        decimal weekendHours;
        decimal nightHours;
        decimal totalPay;

    }
}
