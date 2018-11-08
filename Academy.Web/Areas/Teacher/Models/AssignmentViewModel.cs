﻿using Academy.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Academy.Web.Areas.Teacher.Models
{
    public class AssignmentViewModel
    {
        public AssignmentViewModel(Assignment assignment)
        {
            Id = assignment.Id;
            Name = assignment.Name;
            DueDate = assignment.DateTime;
            Grades = assignment.Grades.Select(gr => new GradeViewModel(gr));
            StudentsToBeGraded = assignment.Course.EnrolledStudents
                                  .Where(en => en.Student.Grades == null || en.Student.Grades.All(gr => gr.AssignmentId != assignment.Id))
                                  .Select(st => new StudentViewModel(st.Student));
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int AverageGrade { get; set; }

        public DateTime DueDate { get; set; }

        public IEnumerable<GradeViewModel> Grades {get;set;}

        public IEnumerable<StudentViewModel> StudentsToBeGraded { get; set; }


    }
}
