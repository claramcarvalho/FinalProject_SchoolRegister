using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FinalProject_SchoolRegister.Form1;

namespace FinalProject_SchoolRegister
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {          
            bindingSourceStudents.DataSource = Data.Students.GetStudents();
            bindingSourceStudents.Sort = "StId";

            comboBoxStId.DataSource = bindingSourceStudents.DataSource;
            comboBoxStId.DisplayMember = "StId";
            comboBoxStId.Text = "";

            comboBoxCId.Enabled = false;
            btnAddNewEnroll.Enabled = false;
        }

        private void comboBoxStId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBoxCId.Enabled = true;

            DataRowView comboSelected = comboBoxStId.SelectedItem as DataRowView;

            String progId = comboSelected.Row["ProgId"] as String;
            String studentName = comboSelected.Row["StName"] as String;

            txtStName.Text = studentName;
            txtCName.Text = "[Course Name]";

            DataTable coursesFromProgram = Data.Courses.GetCoursesFromProgram(progId);

            comboBoxCId.DataSource = coursesFromProgram;
            comboBoxCId.DisplayMember = "CId";
            comboBoxCId.Text = "";
        }

        private void comboBoxCId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btnAddNewEnroll.Enabled = true;

            DataRowView comboSelected = comboBoxCId.SelectedItem as DataRowView;

            String courseName = comboSelected.Row["CName"] as String;
            txtCName.Text = courseName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNewEnroll_Click(object sender, EventArgs e)
        {
            String stId = ((DataRowView)comboBoxStId.SelectedItem).Row["StID"] as String;
            String cId = ((DataRowView)comboBoxCId.SelectedItem).Row["CID"] as String;

            if (Data.Enrollments.AddNewRow(stId, cId) == -1)
            {
                MessageBox.Show($"The student ID {stId} is already enrolled in the course ID {cId}");
            }
            else
            {
                this.Close();
            }
        }
    }
}
