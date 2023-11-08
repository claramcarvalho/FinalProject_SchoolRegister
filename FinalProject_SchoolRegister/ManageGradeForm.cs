using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject_SchoolRegister
{
    public partial class ManageGradeForm : Form
    {
        DataGridViewRow rowSelected;

        public ManageGradeForm(DataGridViewRow rowSelected)
        {
            InitializeComponent();
            this.rowSelected = rowSelected;
        }

        private void ManageGradeForm_Load(object sender, EventArgs e)
        {
            btnSaveGrade.Enabled = false;

            String stId, stName, cId, cName, grade;

            stId = rowSelected.Cells[0].Value.ToString();
            stName = rowSelected.Cells[1].Value.ToString();
            cId = rowSelected.Cells[2].Value.ToString();
            cName = rowSelected.Cells[3].Value.ToString();
            grade = rowSelected.Cells[4].Value.ToString();

            txtStId.Text = stId;
            txtStName.Text = stName;
            txtCId.Text = cId;
            txtCName.Text = cName;
            txtGrade.Text = grade;

            txtGrade.Select();
        }

        private void txtGrade_TextChanged(object sender, EventArgs e)
        {
            String oldGrade = rowSelected.Cells[4].Value.ToString();
            String newGrade = txtGrade.Text;

            if(oldGrade==newGrade)
            {
                btnSaveGrade.Enabled = false;
            }
            else
            {
                btnSaveGrade.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveGrade_Click(object sender, EventArgs e)
        {
            String grade = txtGrade.Text;

            switch (Business.Enrollments.ValidGrade(grade))
            {
                case -1:
                    //error: msg in business layer
                    break;
                case -2:
                    //null
                    Data.Enrollments.UpdateGrade(
                                    rowSelected.Cells[0].Value.ToString(),
                                    rowSelected.Cells[2].Value.ToString(),
                                    null);
                    this.Close();
                    break;
                default:
                    //valid grade
                    Data.Enrollments.UpdateGrade(
                                    rowSelected.Cells[0].Value.ToString(),
                                    rowSelected.Cells[2].Value.ToString(),
                                    grade);
                    this.Close();
                    break;
            }
        }

        internal static void msgGradeBelowZero()
        {
            MessageBox.Show("Grade rejected!\nGrade must be at least 0!!");
        }

        internal static void msgGradeAbove100()
        {
            MessageBox.Show("Grade rejected!\nGrade cannot be over 100!!");
        }
    }
}
