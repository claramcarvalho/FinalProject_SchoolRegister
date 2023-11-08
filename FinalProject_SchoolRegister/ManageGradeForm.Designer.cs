namespace FinalProject_SchoolRegister
{
    partial class ManageGradeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtStId = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveGrade = new System.Windows.Forms.Button();
            this.txtCName = new System.Windows.Forms.TextBox();
            this.txtStName = new System.Windows.Forms.TextBox();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.txtCId = new System.Windows.Forms.TextBox();
            this.txtGrade = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtStId
            // 
            this.txtStId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStId.Location = new System.Drawing.Point(25, 81);
            this.txtStId.Name = "txtStId";
            this.txtStId.ReadOnly = true;
            this.txtStId.Size = new System.Drawing.Size(179, 30);
            this.txtStId.TabIndex = 21;
            this.txtStId.Text = "[Student ID]";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(261, 269);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveGrade
            // 
            this.btnSaveGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveGrade.Location = new System.Drawing.Point(104, 269);
            this.btnSaveGrade.Name = "btnSaveGrade";
            this.btnSaveGrade.Size = new System.Drawing.Size(100, 40);
            this.btnSaveGrade.TabIndex = 19;
            this.btnSaveGrade.Text = "Save";
            this.btnSaveGrade.UseVisualStyleBackColor = true;
            this.btnSaveGrade.Click += new System.EventHandler(this.btnSaveGrade_Click);
            // 
            // txtCName
            // 
            this.txtCName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCName.Location = new System.Drawing.Point(261, 137);
            this.txtCName.Name = "txtCName";
            this.txtCName.ReadOnly = true;
            this.txtCName.Size = new System.Drawing.Size(206, 30);
            this.txtCName.TabIndex = 18;
            this.txtCName.Text = "[Course Name]";
            // 
            // txtStName
            // 
            this.txtStName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStName.Location = new System.Drawing.Point(261, 81);
            this.txtStName.Name = "txtStName";
            this.txtStName.ReadOnly = true;
            this.txtStName.Size = new System.Drawing.Size(206, 30);
            this.txtStName.TabIndex = 17;
            this.txtStName.Text = "[Student Name]";
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.Location = new System.Drawing.Point(110, 28);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(273, 32);
            this.lblFormTitle.TabIndex = 15;
            this.lblFormTitle.Text = "Manage Final Grade";
            // 
            // txtCId
            // 
            this.txtCId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCId.Location = new System.Drawing.Point(25, 137);
            this.txtCId.Name = "txtCId";
            this.txtCId.ReadOnly = true;
            this.txtCId.Size = new System.Drawing.Size(179, 30);
            this.txtCId.TabIndex = 22;
            this.txtCId.Text = "[Course ID]";
            // 
            // txtGrade
            // 
            this.txtGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGrade.Location = new System.Drawing.Point(261, 202);
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.Size = new System.Drawing.Size(112, 30);
            this.txtGrade.TabIndex = 23;
            this.txtGrade.Text = "[Grade]";
            this.txtGrade.TextChanged += new System.EventHandler(this.txtGrade_TextChanged);
            // 
            // ManageGradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 346);
            this.Controls.Add(this.txtGrade);
            this.Controls.Add(this.txtCId);
            this.Controls.Add(this.txtStId);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSaveGrade);
            this.Controls.Add(this.txtCName);
            this.Controls.Add(this.txtStName);
            this.Controls.Add(this.lblFormTitle);
            this.Name = "ManageGradeForm";
            this.Text = "ManageGradeForm";
            this.Load += new System.EventHandler(this.ManageGradeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStId;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveGrade;
        private System.Windows.Forms.TextBox txtCName;
        private System.Windows.Forms.TextBox txtStName;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.TextBox txtCId;
        private System.Windows.Forms.TextBox txtGrade;
    }
}