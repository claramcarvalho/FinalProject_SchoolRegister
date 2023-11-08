using System;
using System.Data;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace FinalProject_SchoolRegister
{
    public partial class ModifyForm : Form
    {
        DataGridViewRow rowSelected;

        public ModifyForm(DataGridViewRow rowSelected)
        {
            InitializeComponent();
            this.rowSelected = rowSelected;
        }

        private void ModifyForm_Load(object sender, EventArgs e)
        {
            btnModifyExistingEnroll.Enabled = false;
            
            String stId, stName, cId, cName, progId;

            stId = rowSelected.Cells[0].Value.ToString();
            stName = rowSelected.Cells[1].Value.ToString();
            cId = rowSelected.Cells[2].Value.ToString();
            cName = rowSelected.Cells[3].Value.ToString();

            txtStId.Text = stId;
            txtStName.Text = stName;

            progId = Data.Students.GetStudentProgram(stId);
            DataTable coursesFromProgram = Data.Courses.GetCoursesFromProgram(progId);

            comboBoxCId.DataSource = coursesFromProgram;
            comboBoxCId.DisplayMember = "CId";
            
            comboBoxCId.Text = cId;
            txtCName.Text = cName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxCId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataRowView comboSelected = comboBoxCId.SelectedItem as DataRowView;

            String selectedCourseName = comboSelected.Row["CName"] as String;
            txtCName.Text = selectedCourseName;

            String selectedCourseId = comboSelected.Row["CId"] as String;

            if (selectedCourseId != rowSelected.Cells[2].Value.ToString() )
            {
                btnModifyExistingEnroll.Enabled = true;
            }
            else
            {
                btnModifyExistingEnroll.Enabled = false;
            }
        }

        private void btnModifyExistingEnroll_Click(object sender, EventArgs e)
        {
            String stId = txtStId.Text;
            String oldCId = rowSelected.Cells[2].Value.ToString();
            String newCId = ((DataRowView)comboBoxCId.SelectedItem).Row["CID"] as String;

            if (Data.Enrollments.UpdateRow(stId, oldCId, newCId) == -1)
            {
                MessageBox.Show($"The student ID {stId} is already enrolled in the course ID {newCId}");
            }
            else
            {
                this.Close();
            }            
        }
    }
}
