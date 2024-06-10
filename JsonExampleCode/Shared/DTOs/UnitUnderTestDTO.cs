using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonExampleCode.Shared.DTOs
{
    public class UnitUnderTestDTO
    {
        public int? Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public string ComputerName { get; set; }
        public TestStatus? Status { get; set; }
       
        
        
        //Here it will calculated timespan from Start date and EndDate automatically
        public TimeSpan? ExecutionTime
        {
            get
            {
                if (StartDate == null) return TimeSpan.Zero;
                if (EndDate == null) return TimeSpan.Zero;

                return EndDate - StartDate;
            }
        }
    }

    public enum TestStatus
    {
        Success,
        Failure,
        Unexpected,
    }

}
