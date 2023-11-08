namespace FinalProject_SchoolRegister
{
    partial class ModifyForm
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
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnModifyExistingEnroll = new System.Windows.Forms.Button();
            this.txtCName = new System.Windows.Forms.TextBox();
            this.txtStName = new System.Windows.Forms.TextBox();
            this.comboBoxCId = new System.Windows.Forms.ComboBox();
            this.txtStId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.Location = new System.Drawing.Point(75, 26);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(350, 32);
            this.lblFormTitle.TabIndex = 5;
            this.lblFormTitle.Text = "Modify Existing Enrollment";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(262, 205);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnModifyExistingEnroll
            // 
            this.btnModifyExistingEnroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifyExistingEnroll.Location = new System.Drawing.Point(105, 205);
            this.btnModifyExistingEnroll.Name = "btnModifyExistingEnroll";
            this.btnModifyExistingEnroll.Size = new System.Drawing.Size(100, 40);
            this.btnModifyExistingEnroll.TabIndex = 12;
            this.btnModifyExistingEnroll.Text = "Modify";
            this.btnModifyExistingEnroll.UseVisualStyleBackColor = true;
            this.btnModifyExistingEnroll.Click += new System.EventHandler(this.btnModifyExistingEnroll_Click);
            // 
            // txtCName
            // 
            this.txtCName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCName.Location = new System.Drawing.Point(262, 135);
            this.txtCName.Name = "txtCName";
            this.txtCName.ReadOnly = true;
            this.txtCName.Size = new System.Drawing.Size(206, 30);
            this.txtCName.TabIndex = 11;
            this.txtCName.Text = "[Course Name]";
            // 
            // txtStName
            // 
            this.txtStName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStName.Location = new System.Drawing.Point(262, 79);
            this.txtStName.Name = "txtStName";
            this.txtStName.ReadOnly = true;
            this.txtStName.Size = new System.Drawing.Size(206, 30);
            this.txtStName.TabIndex = 10;
            this.txtStName.Text = "[Student Name]";
            // 
            // comboBoxCId
            // 
            this.comboBoxCId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCId.FormattingEnabled = true;
            this.comboBoxCId.Location = new System.Drawing.Point(26, 140);
            this.comboBoxCId.Name = "comboBoxCId";
            this.comboBoxCId.Size = new System.Drawing.Size(179, 26);
            this.comboBoxCId.TabIndex = 9;
            this.comboBoxCId.SelectionChangeCommitted += new System.EventHandler(this.comboBoxCId_SelectionChangeCommitted);
            // 
            // txtStId
            // 
            this.txtStId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStId.Location = new System.Drawing.Point(26, 79);
            this.txtStId.Name = "txtStId";
            this.txtStId.ReadOnly = true;
            this.txtStId.Size = new System.Drawing.Size(179, 30);
            this.txtStId.TabIndex = 14;
            this.txtStId.Text = "[Student ID]";
            // 
            // ModifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 282);
            this.Controls.Add(this.txtStId);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnModifyExistingEnroll);
            this.Controls.Add(this.txtCName);
            this.Controls.Add(this.txtStName);
            this.Controls.Add(this.comboBoxCId);
            this.Controls.Add(this.lblFormTitle);
            this.Name = "ModifyForm";
            this.Text = "ModifyForm";
            this.Load += new System.EventHandler(this.ModifyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnModifyExistingEnroll;
        private System.Windows.Forms.TextBox txtCName;
        private System.Windows.Forms.TextBox txtStName;
        private System.Windows.Forms.ComboBox comboBoxCId;
        private System.Windows.Forms.TextBox txtStId;
    }
}