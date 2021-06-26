using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagement.Models
{
    public class ExamScheduleEnrollment
    {

        public int Id { get; set; }
        public DateTime EnrolledOn { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int ExamScheduleId { get; set; }
        public virtual ExamSchedule ExamSchedule { get; set; }
    }
}
