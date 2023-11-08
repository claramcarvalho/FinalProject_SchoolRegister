using FinalProject_SchoolRegister;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Business
{
    internal class Students
    {
        internal static int UpdateStudents()
        {
            Regex regexStu = new Regex(@"S[0-9]{9}$");

            DataTable dt = Data.Students.GetStudents()
                .GetChanges(DataRowState.Added | DataRowState.Modified);

            if ( (dt != null) && (!regexStu.IsMatch(dt.Rows[0][0].ToString())) )
            {
                Form1.msgIdStudentNotCompatible();
                Data.Students.GetStudents().RejectChanges();
                return -1;
            }
            else
            {
                return Data.Students.UpdateStudents();
            }
        }
    }

    internal class Courses
    {
        internal static int UpdateCourses()
        {
            Regex regexCourse = new Regex(@"C[0-9]{6}$");

            DataTable dt = Data.Courses.GetCourses()
                .GetChanges(DataRowState.Added | DataRowState.Modified);

            if ((dt != null) && (!regexCourse.IsMatch(dt.Rows[0][0].ToString())))
            {
                Form1.msgIdCourseNotCompatible();
                Data.Courses.GetCourses().RejectChanges();
                return -1;
            }
            else
            {
                return Data.Courses.UpdateCourses();
            }
        }
    }

    internal class Programs
    {
        internal static int UpdatePrograms()
        {
            Regex regexProg = new Regex(@"P[0-9]{4}$");

            DataTable dt = Data.Programs.GetPrograms()
                .GetChanges(DataRowState.Added | DataRowState.Modified);

            if ((dt != null) && (!regexProg.IsMatch(dt.Rows[0][0].ToString())))
            {
                Form1.msgIdProgramNotCompatible();
                Data.Programs.GetPrograms().RejectChanges();
                return -1;
            }
            else
            {
                return Data.Programs.UpdateProgram();
            }
        }
    }

    internal class Enrollments
    {
        internal static int UpdateEnrollments()
        {
            DataTable dt = Data.Enrollments.GetEnrollments()
                .GetChanges(DataRowState.Added | DataRowState.Modified);

            return Data.Enrollments.UpdateEnrollments();
        }

        internal static int ValidGrade(string grade)
        {
            Int32 nbGrade;

            if ( grade == "" )
            {
                return -2;
            }
            else
            {
                try
                {
                    nbGrade = Convert.ToInt32(grade);

                    if (nbGrade < 0)
                    {
                        ManageGradeForm.msgGradeBelowZero();
                        return -1;
                    }
                    else if (nbGrade > 100)
                    {
                        ManageGradeForm.msgGradeAbove100();
                        return -1;
                    }
                    else
                    {
                        return nbGrade;
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("Grade must be an integer number!\n" + error.Message);
                    return -1;
                }
            }
        }

        internal static bool GradeAssigned(DataGridViewRow rowSelected)
        {
            if (rowSelected.Cells[4].Value.ToString() == "")
            {
                return false;
            }
            return true;
        }
    }
}
