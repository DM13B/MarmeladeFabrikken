using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;


namespace Model.Planning

{
    class Pay : IPay
    {
        public decimal totalHours { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endTime { get; set; }
        public decimal eveneningHours { get; set; }
        public decimal weekendHours { get; set; }
        public decimal nightHours { get; set; }
        public decimal totalPay { get; set; }
        public int employeeID { get; set; }
    }
}
