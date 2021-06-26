

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagement.Models
{
    public class ExamSchedule
    {
        public int Id { get; set; }

        [Required]
        public DateTime ExamDate { get; set; }
        [Required]
        public string ExamVenue { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public virtual IEnumerable<ExamScheduleSubject> ExamScheduleSubjects { get; set; }
        public virtual IEnumerable<ExamScheduleEnrollment> ExamScheduleEnrollments { get; set; }

    }
}
