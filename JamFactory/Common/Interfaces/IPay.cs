﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IPay
    {
        decimal totalHours { get; set; }
        DateTime startDate { get; set; }
        DateTime endTime { get; set; }
        decimal eveneningHours { get; set; }
        decimal weekendHours { get; set; }
        decimal nightHours { get; set; }
        decimal totalPay { get; set; }
        int employeeID { get; set; }

    }
}
