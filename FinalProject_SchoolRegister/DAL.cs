using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data
{
    //Data Access Layer
    internal class Connect
    {
        //Connecting to Database

        private static String SchoolRegisterConnectionString = GetConnectString();

        internal static String ConnectionString { get => SchoolRegisterConnectionString; }

        private static String GetConnectString()
        {
            SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
            cs.DataSource = "(local)";
            cs.InitialCatalog = "College1en";
            cs.UserID = "sa";
            cs.Password = "sysadm";
            return cs.ConnectionString;
        }
    }

    internal class DataTables
    {
        //Loading Tables into memory

        private static SqlDataAdapter adapterPrograms = InitAdapterPrograms();
        private static SqlDataAdapter adapterStudents = InitAdapterStudents();
        private static SqlDataAdapter adapterCourses = InitAdapterCourses();
        private static SqlDataAdapter adapterEnrollments = InitAdapterEnrollments();


        private static DataSet ds = InitDataSet();

        private static SqlDataAdapter InitAdapterPrograms()
        {
            SqlDataAdapter r = new SqlDataAdapter(
                            "SELECT * FROM Programs ORDER BY ProgId",
                            Connect.ConnectionString);

            SqlCommandBuilder builder = new SqlCommandBuilder(r);

            return r;
        }

        private static SqlDataAdapter InitAdapterStudents()
        {
            SqlDataAdapter r = new SqlDataAdapter(
                            "SELECT * FROM Students ORDER BY StId",
                            Connect.ConnectionString);

            SqlCommandBuilder builder = new SqlCommandBuilder(r);
            r.UpdateCommand = builder.GetUpdateCommand();

            //*************************************************************************************//
            //////////MUST BE IMPLEMENTED ON THE TABLE THAT HAS FOREIGN KEYS!!!//////////////////////
            //*************************************************************************************//

            builder.ConflictOption = ConflictOption.OverwriteChanges;
            r.UpdateCommand = builder.GetUpdateCommand();

            return r;
        }

        private static SqlDataAdapter InitAdapterCourses()
        {
            SqlDataAdapter r = new SqlDataAdapter(
                            "SELECT * FROM Courses ORDER BY CId",
                            Connect.ConnectionString);

            SqlCommandBuilder builder = new SqlCommandBuilder(r);
            r.UpdateCommand = builder.GetUpdateCommand();

            //*************************************************************************************//
            //////////MUST BE IMPLEMENTED ON THE TABLE THAT HAS FOREIGN KEYS!!!//////////////////////
            //*************************************************************************************//

            builder.ConflictOption = ConflictOption.OverwriteChanges;
            r.UpdateCommand = builder.GetUpdateCommand();

            return r;
        }
        
        private static SqlDataAdapter InitAdapterEnrollments()
        {
            SqlDataAdapter r = new SqlDataAdapter(
                        "SELECT * FROM Enrollments",
                        Connect.ConnectionString);

            SqlCommandBuilder builder = new SqlCommandBuilder(r);
            r.UpdateCommand = builder.GetUpdateCommand();

            //*************************************************************************************//
            //////////MUST BE IMPLEMENTED ON THE TABLE THAT HAS FOREIGN KEYS!!!//////////////////////
            //*************************************************************************************//

            builder.ConflictOption = ConflictOption.OverwriteChanges;
            r.UpdateCommand = builder.GetUpdateCommand();

            return r;
        }

        private static DataSet InitDataSet()
        {
            DataSet ds = new DataSet();
            loadPrograms(ds);
            loadStudents(ds);
            loadCourses(ds);
            loadEnrollments(ds);

            return ds;
        }

        private static void loadPrograms(DataSet ds)
        {
            //this tells the adapter that, WHEN filling the adapter,
            //the adapter must copy all the information beyond data
            adapterPrograms.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            //filling the adapter, using dataset ds => table Departments
            adapterPrograms.Fill(ds, "Programs");
        }

        private static void loadStudents(DataSet ds)
        {
            //this tells the adapter that, WHEN filling the adapter,
            //the adapter must copy all the information beyond data
            adapterStudents.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            //filling the adapter, using dataset ds => table Departments
            adapterStudents.Fill(ds, "Students");
        }

        private static void loadCourses(DataSet ds)
        {
            //this tells the adapter that, WHEN filling the adapter,
            //the adapter must copy all the information beyond data
            adapterCourses.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            //filling the adapter, using dataset ds => table Departments
            adapterCourses.Fill(ds, "Courses");
        }

        private static void loadEnrollments(DataSet ds)
        {
            //this tells the adapter that, WHEN filling the adapter,
            //the adapter must copy all the information beyond data
            adapterEnrollments.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            //filling the adapter, using dataset ds => table Enrollments
            adapterEnrollments.Fill(ds, "Enrollments");

            //once you have all tables in memory, we can add foreign keys

            ForeignKeyConstraint myFKStudentProgram = new ForeignKeyConstraint
                (
                    "fkOnStudentsFromPrograms", //name of foreign key
                    new DataColumn[]
                        { //parent table
                            ds.Tables["Programs"].Columns["ProgId"]
                        },
                    new DataColumn[]
                        { //child table
                            ds.Tables["Students"].Columns["ProgId"]
                        }
                );

            //setting rules from database
            myFKStudentProgram.DeleteRule = Rule.None;
            myFKStudentProgram.UpdateRule = Rule.Cascade;

            //attaching fk to table
            ds.Tables["Students"].Constraints.Add(myFKStudentProgram);

            ForeignKeyConstraint myFKCourseProgram = new ForeignKeyConstraint
                (
                    "fkOnCoursesFromPrograms", //name of foreign key
                    new DataColumn[]
                        { //parent table
                            ds.Tables["Programs"].Columns["ProgId"]
                        },
                    new DataColumn[]
                        { //child table
                            ds.Tables["Courses"].Columns["ProgId"]
                        }
                );

            //setting rules from database
            myFKCourseProgram.DeleteRule = Rule.Cascade;
            myFKCourseProgram.UpdateRule = Rule.Cascade;

            //attaching fk to table
            ds.Tables["Courses"].Constraints.Add(myFKCourseProgram);

            ForeignKeyConstraint myFKEnrollMentStudent = new ForeignKeyConstraint
                (
                    "fkOnEnrollmentsFromStudents", //name of foreign key
                    new DataColumn[]
                        { //parent table
                            ds.Tables["Students"].Columns["StId"]
                        },
                    new DataColumn[]
                        { //child table
                            ds.Tables["Enrollments"].Columns["StId"]
                        }
                );

            //setting rules from database
            myFKEnrollMentStudent.DeleteRule = Rule.Cascade;
            myFKEnrollMentStudent.UpdateRule = Rule.Cascade;

            //attaching fk to table
            ds.Tables["Enrollments"].Constraints.Add(myFKEnrollMentStudent);

            ForeignKeyConstraint myFKEnrollMentCourse = new ForeignKeyConstraint
                (
                    "fkOnEnrollmentsFromCourses", //name of foreign key
                    new DataColumn[]
                        { //parent table
                            ds.Tables["Courses"].Columns["CId"]
                        },
                    new DataColumn[]
                        { //child table
                            ds.Tables["Enrollments"].Columns["CId"]
                        }
                );

            //setting rules from database
            myFKEnrollMentCourse.DeleteRule = Rule.None;
            myFKEnrollMentCourse.UpdateRule = Rule.None;

            //attaching fk to table
            ds.Tables["Enrollments"].Constraints.Add(myFKEnrollMentCourse);
        }

        internal static SqlDataAdapter getAdapterPrograms()
        {
            return adapterPrograms;
        }

        internal static SqlDataAdapter getAdapterStudents()
        {
            return adapterStudents;
        }

        internal static SqlDataAdapter getAdapterCourses()
        {
            return adapterCourses;
        }

        internal static SqlDataAdapter getAdapterEnrollments()
        {
            return adapterEnrollments;
        }

        internal static DataSet getDataset()
        {
            return ds;
        }
    }

    internal class Programs
    {
        private static SqlDataAdapter adapter = DataTables.getAdapterPrograms();
        private static DataSet ds = DataTables.getDataset();

        internal static DataTable GetPrograms()
        {
            return ds.Tables["Programs"];
        }

        internal static int UpdateProgram()
        {
            if (!ds.Tables["Programs"].HasErrors)
            {
                return adapter.Update(ds.Tables["Programs"]);
            }
            else
            {
                return -1;
            }
        }
    }

    internal class Students
    {
        private static SqlDataAdapter adapter = DataTables.getAdapterStudents();
        private static DataSet ds = DataTables.getDataset();

        internal static DataTable GetStudents()
        {
            return ds.Tables["Students"];
        }

        internal static int UpdateStudents()
        {
            if (!ds.Tables["Students"].HasErrors)
            {
                return adapter.Update(ds.Tables["Students"]);
            }
            else
            {
                return -1;
            }
        }

        internal static String GetStudentProgram(String StudentId)
        {
            var table = from tableStudent in ds.Tables["Students"].AsEnumerable()
                        where (string)tableStudent["StId"] == StudentId
                        select new
                        {
                            progId = tableStudent.Field<String>("ProgId")
                        };

            //creating a DataTable to return
            DataTable tableToReturn = new DataTable();

            //Adding Columns
            tableToReturn.Columns.Add("ProgId");

            //completing the values
            foreach (var obj in table)
            {
                object[] entireRow = { obj.progId };
                tableToReturn.Rows.Add(entireRow);
            }

            String progId = tableToReturn.Rows[0][0].ToString();

            return progId;
        }
    }

    internal class Courses
    {
        private static SqlDataAdapter adapter = DataTables.getAdapterCourses();
        private static DataSet ds = DataTables.getDataset();

        internal static DataTable GetCourses()
        {
            return ds.Tables["Courses"];
        }

        internal static int UpdateCourses()
        {
            if (!ds.Tables["Courses"].HasErrors)
            {
                return adapter.Update(ds.Tables["Courses"]);
            }
            else
            {
                return -1;
            }
        }

        internal static DataTable GetCoursesFromProgram(String progId)
        {
            var table = from tableCourses in ds.Tables["Courses"].AsEnumerable()
                        join tablePrograms in ds.Tables["Programs"].AsEnumerable() on (string)tableCourses["ProgId"] equals (string)tablePrograms["ProgId"]
                        where (string)tablePrograms["ProgId"] == progId
                        select new
                        {
                            CId = tableCourses.Field<String>("CId"),
                            CName = tableCourses.Field<String>("CName")
                        };

            //creating a DataTable to return
            DataTable tableToReturn = new DataTable();

            //Adding Columns
            tableToReturn.Columns.Add("CId");
            tableToReturn.Columns.Add("CName");

            //completing the values
            foreach (var obj in table)
            {
                object[] entireRow = { obj.CId, obj.CName };
                tableToReturn.Rows.Add(entireRow);
            }

            return tableToReturn;
        }
    }

    internal static class Enrollments
    {
        private static SqlDataAdapter adapter = DataTables.getAdapterEnrollments();
        private static DataSet ds = DataTables.getDataset();

        //adapterEnrollments.Fill(ds, "Enrollments");
        
        internal static DataTable GetEnrollments()
        {
            return ds.Tables["Enrollments"];
        }

        internal static DataTable GetEnrollmentsView()
        {
            ds.Tables["Enrollments"].Clear();
            adapter.Fill(ds,"Enrollments");
            
            var table = from tableEnroll in ds.Tables["Enrollments"].AsEnumerable()
                        join tableStu in ds.Tables["Students"].AsEnumerable() on (string)tableEnroll["StId"] equals (string)tableStu["StId"]
                        join tableCourse in ds.Tables["Courses"].AsEnumerable() on (string)tableEnroll["CId"] equals (string)tableCourse["CId"]
                        select new
                        {
                            StId = tableEnroll.Field<String>("StId"),
                            StName = tableStu.Field<String>("StName"),
                            CId = tableEnroll.Field<String>("CId"),
                            CName = tableCourse.Field<String>("CName"),
                            FinalGrade = tableEnroll.Field<Nullable<int>>("FinalGrade")
                        };

            //creating a DataTable to return
            DataTable tableToReturn = new DataTable();

            //Adding Columns
            tableToReturn.Columns.Add("StId");
            tableToReturn.Columns.Add("StName");
            tableToReturn.Columns.Add("CId");
            tableToReturn.Columns.Add("CName");
            tableToReturn.Columns.Add("FinalGrade");

            //completing the values
            foreach (var obj in table)
            {
                object[] entireRow = { obj.StId, obj.StName, obj.CId, obj.CName, obj.FinalGrade };
                tableToReturn.Rows.Add(entireRow);
            }

            return tableToReturn;
        }

        internal static int UpdateEnrollments()
        {
            if (!ds.Tables["Enrollments"].HasErrors)
            {
                    return adapter.Update(ds.Tables["Enrollments"]);
            }
            else
            {
                return -1;
            }
        }

        internal static int AddNewRow (String stId, String cId)
        {
            if(!RowAlreadyExist(stId,cId))
            {
                DataRow newRow = ds.Tables["Enrollments"].NewRow();
                newRow["StId"] = stId;
                newRow["CId"] = cId;

                ds.Tables["Enrollments"].Rows.Add(newRow);
                return adapter.Update(ds.Tables["Enrollments"]);
            }
            else
            {
                return -1;
            } 
        }

        private static bool RowAlreadyExist (String stId, String cId)
        {
            foreach (DataRow row in ds.Tables["Enrollments"].Rows)
            {
                if (row["StId"].ToString() == stId && row["CId"].ToString() == cId)
                {
                    return true;
                }
            }
            return false;
        }

        internal static int UpdateRow(String stId, String oldCId, String newCId)
        {
            if (!RowAlreadyExist(stId, newCId))
            {
                foreach (DataRow row in ds.Tables["Enrollments"].Rows)
                {
                    if (row["StId"].ToString() == stId && row["CId"].ToString() == oldCId)
                    {
                        row["CId"] = newCId;
                    }
                }
                return adapter.Update(ds.Tables["Enrollments"]);
            }
            else
            {
                return -1;
            }
        }

        internal static void UpdateGrade(String stId, String cId, string grade)
        {
            foreach (DataRow row in ds.Tables["Enrollments"].Rows)
            {
                if (row["StId"].ToString() == stId && row["CId"].ToString() == cId)
                {
                    if (grade == null)
                    {
                        row["FinalGrade"] = DBNull.Value;
                    }
                    else
                    {
                        row["FinalGrade"] = grade;
                    }
                }
            }

            UpdateEnrollments();
        }

        internal static int DeleteRows(DataGridViewSelectedRowCollection rowsSelected)
        {
            int countNotDeletedRows = 0;
            foreach (DataGridViewRow rowSelected in rowsSelected)
            {
                if (!Business.Enrollments.GradeAssigned(rowSelected))
                {
                    foreach (DataRow rowInDataset in ds.Tables["Enrollments"].Rows)
                    {
                        if (rowInDataset["StId"].ToString() == rowSelected.Cells[0].Value.ToString() && rowInDataset["CId"].ToString() == rowSelected.Cells[2].Value.ToString())
                        {
                            rowInDataset.Delete();
                            break;
                        }
                    }
                }
                else
                {
                    countNotDeletedRows++;
                }
            }
            UpdateEnrollments();
            return countNotDeletedRows;
        }
    }
}
