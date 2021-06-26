using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamManagement.ViewModels
{
    public class CreateExamScheduleViewModel
    {
        public int CourseId { get; set; }
        public List<ExamScheduleSubject> Subjects { get; set; }
        public DateTime ExamDate { get; set; }
        public string ExamVenue { get; set; }
    }

    public class ExamScheduleSubject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public bool IsAdded { get; set; }
    }
}
