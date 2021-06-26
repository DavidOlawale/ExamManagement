using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagement.Models
{
    public class ExamScheduleSubject
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public int ExamScheduleId { get; set; }
        public virtual ExamSchedule ExamSchedule { get; set; }
    }
}
