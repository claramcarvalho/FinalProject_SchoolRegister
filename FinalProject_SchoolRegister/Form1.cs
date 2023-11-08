using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace FinalProject_SchoolRegister
{
    public partial class Form1 : Form
    {
        private bool OKToChange = true;
        private bool currentBindingEnroll = false;

        //variables to update datagridview when adding / modifying / managing
        //public static String stId, cId;
        //public static Int32 grade;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Dock = DockStyle.Fill;
            ChangeVisibilitySubMenu(false);
        }

        private void ChangeVisibilitySubMenu(bool visible)
        {
            if (visible == true)
            {
                addToolStripMenuItem.Visible = true;
                modifyToolStripMenuItem.Visible = true;
                deleteToolStripMenuItem.Visible = true;
                toolStripSeparator1.Visible = true;
                manageFinalGradeToolStripMenuItem.Visible = true;
            }
            else
            {
                addToolStripMenuItem.Visible = false;
                modifyToolStripMenuItem.Visible = false;
                deleteToolStripMenuItem.Visible = false;
                toolStripSeparator1.Visible = false;
                manageFinalGradeToolStripMenuItem.Visible = false;
            }
        }

        private void programsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OKToChange)
            {
                ChangeVisibilitySubMenu(false);
                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AllowUserToDeleteRows = true;
                dataGridView1.RowHeadersVisible = true;
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                bindingSourcePrograms.DataSource = Data.Programs.GetPrograms();
                bindingSourcePrograms.Sort = "ProgId";
                dataGridView1.DataSource = bindingSourcePrograms;
                currentBindingEnroll = false;

                //changing the header of the column to be displayed differently
                dataGridView1.Columns["ProgId"].HeaderText = "Program ID";
                dataGridView1.Columns["ProgName"].HeaderText = "Program Name";

                // determining the order of display of the columns
                dataGridView1.Columns["ProgId"].DisplayIndex = 0;
                dataGridView1.Columns["ProgName"].DisplayIndex = 1;
            }
        }

        private void studentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OKToChange)
            {
                ChangeVisibilitySubMenu(false);
                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AllowUserToDeleteRows = true;
                dataGridView1.RowHeadersVisible = true;
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                bindingSourceStudents.DataSource = Data.Students.GetStudents();
                bindingSourceStudents.Sort = "StId";
                dataGridView1.DataSource = bindingSourceStudents;
                currentBindingEnroll = false;

                //changing the header of the column to be displayed differently
                dataGridView1.Columns["StId"].HeaderText = "Student ID";
                dataGridView1.Columns["StName"].HeaderText = "Student Name";
                dataGridView1.Columns["ProgId"].HeaderText = "Program ID";


                // determining the order of display of the columns
                dataGridView1.Columns["StId"].DisplayIndex = 0;
                dataGridView1.Columns["StName"].DisplayIndex = 1;
                dataGridView1.Columns["ProgId"].DisplayIndex = 2;
            }
        }

        private void coursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OKToChange)
            {
                ChangeVisibilitySubMenu(false);
                dataGridView1.ReadOnly = false;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AllowUserToDeleteRows = true;
                dataGridView1.RowHeadersVisible = true;
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                bindingSourceCourses.DataSource = Data.Courses.GetCourses();
                bindingSourceCourses.Sort = "CId";
                dataGridView1.DataSource = bindingSourceCourses;
                currentBindingEnroll = false;

                //changing the header of the column to be displayed differently
                dataGridView1.Columns["CId"].HeaderText = "Course ID";
                dataGridView1.Columns["CName"].HeaderText = "Course Name";
                dataGridView1.Columns["ProgId"].HeaderText = "Program ID";


                // determining the order of display of the columns
                dataGridView1.Columns["CId"].DisplayIndex = 0;
                dataGridView1.Columns["CName"].DisplayIndex = 1;
                dataGridView1.Columns["ProgId"].DisplayIndex = 2;
            }
        }

        private void enrolmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OKToChange)
            {
                if (!currentBindingEnroll)
                {
                    dataGridView1.ReadOnly = true;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.RowHeadersVisible = true;
                    dataGridView1.Dock = DockStyle.Fill;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.MultiSelect = true;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    bindingSourceEnrollments.DataSource = Data.Enrollments.GetEnrollmentsView();
                    bindingSourceEnrollments.Sort = "StId";
                    dataGridView1.DataSource = bindingSourceEnrollments;
                    currentBindingEnroll = true;
                    ChangeVisibilitySubMenu(true);

                    //changing the header of the column to be displayed differently
                    dataGridView1.Columns["StId"].HeaderText = "Student ID";
                    dataGridView1.Columns["StName"].HeaderText = "Student Name";

                    // determining the order of display of the columns
                    dataGridView1.Columns["StId"].DisplayIndex = 0;
                    dataGridView1.Columns["StName"].DisplayIndex = 1;
                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddForm obj = new AddForm();

            obj.ShowDialog();

            bindingSourceEnrollments.DataSource = Data.Enrollments.GetEnrollmentsView();
            dataGridView1.DataSource = bindingSourceEnrollments;
        }

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int nbCells = dataGridView1.SelectedRows.Count;
            if (nbCells > 1)
            {
                MessageBox.Show("You must select ONLY ONE row to Modify!!");
            }
            else if (nbCells == 0 )
            {
                MessageBox.Show("You must select ONE row to Modify!!");
            }
            else
            {
                DataGridViewRow rowSelected = dataGridView1.SelectedRows[0];

                if (!Business.Enrollments.GradeAssigned(rowSelected))
                {
                    ModifyForm obj = new ModifyForm(rowSelected);

                    obj.ShowDialog();

                    bindingSourceEnrollments.DataSource = Data.Enrollments.GetEnrollmentsView();
                    dataGridView1.DataSource = bindingSourceEnrollments;
                }
                else
                {
                    MessageBox.Show("To modify an enrollment that has a Final Grade assigned,\nyou must first remove the Final Grade.");
                }
            }
        }

        private void manageFinalGradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int nbCells = dataGridView1.SelectedRows.Count;
            if (nbCells > 1)
            {
                MessageBox.Show("You must select ONLY ONE row to manage the grade!!");
            }
            else if (nbCells == 0)
            {
                MessageBox.Show("You must select ONE row to manage the grade!!");
            }
            else
            {
                DataGridViewRow rowSelected = dataGridView1.SelectedRows[0];

                ManageGradeForm obj = new ManageGradeForm(rowSelected);

                obj.ShowDialog();

                bindingSourceEnrollments.DataSource = Data.Enrollments.GetEnrollmentsView();
                dataGridView1.DataSource = bindingSourceEnrollments;
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Impossible to insert/update/delete ");
            e.Cancel = false;

            OKToChange = false;
        }

        private void bindingSourceStudents_CurrentChanged(object sender, EventArgs e)
        {
            if (Business.Students.UpdateStudents() == -1)
            {
                Validate();
                bindingSourceStudents.ResetBindings(false);
                OKToChange = false;
            }
        }

        private void bindingSourceCourses_CurrentChanged(object sender, EventArgs e)
        {
            if (Business.Courses.UpdateCourses() == -1)
            {
                Validate();
                bindingSourceCourses.ResetBindings(false);
                OKToChange = false;
            }
        }

        private void bindingSourcePrograms_CurrentChanged(object sender, EventArgs e)
        {
            if (Business.Programs.UpdatePrograms() == -1)
            {
                Validate();
                bindingSourcePrograms.ResetBindings(false);
                OKToChange = false;
            }
        }

        private void menuStrip1_Click(object sender, EventArgs e)
        {
            OKToChange = true;
            BindingSource temp = (BindingSource)dataGridView1.DataSource;
            Validate();

            if (temp == bindingSourceStudents)
            {
                if (Business.Students.UpdateStudents() == -1)
                {
                    Validate(); //to avoid looping if you make an error
                    OKToChange = false;
                }
            }
            else if (temp == bindingSourceCourses)
            {
                if (Business.Courses.UpdateCourses() == -1)
                {
                    Validate(); //to avoid looping if you make an error
                    OKToChange = false;
                }
            }
            else if (temp == bindingSourcePrograms)
            {
                if (Business.Programs.UpdatePrograms() == -1)
                {
                    Validate(); //to avoid looping if you make an error
                    OKToChange = false;
                }
            }
        }

        private void bindingSourceEnrollments_CurrentChanged(object sender, EventArgs e)
        {
            if (Business.Enrollments.UpdateEnrollments() == -1)
            {
                Validate();
                bindingSourceEnrollments.ResetBindings(false);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int nbCells = dataGridView1.SelectedRows.Count;

            if (nbCells == 0)
            {
                MessageBox.Show("You must select at least ONE row to Delete!!");
            }
            else
            {
                DataGridViewSelectedRowCollection rowsSelected = dataGridView1.SelectedRows;

                //deleting from dataset
                if (Data.Enrollments.DeleteRows(rowsSelected) > 0)
                {
                    MessageBox.Show("Some of the selected enrollments could not be deleted.\n" +
                                    "Please remove the Final Grade before deleting.\n" +
                                    "To do that, click on 'Manage Final Grade'");
                }

                bindingSourceEnrollments.DataSource = Data.Enrollments.GetEnrollmentsView();
                dataGridView1.DataSource = bindingSourceEnrollments;
            }
        }

        internal static void msgIdStudentNotCompatible()
        {
            MessageBox.Show("The Student ID must be in the format below:\n\n" +
                            "'S#########'\n\n" +
                            "One Capital S followed by 9 digits(numbers)");
        }

        internal static void msgIdCourseNotCompatible()
        {
            MessageBox.Show("The Course ID must be in the format below:\n\n" +
                            "'C######'\n\n" +
                            "One Capital C followed by 6 digits(numbers)");
        }

        internal static void msgIdProgramNotCompatible()
        {
            MessageBox.Show("The Program ID must be in the format below:\n\n" +
                            "'P####'\n\n" +
                            "One Capital P followed by 4 digits(numbers)");
        }
    }
}
