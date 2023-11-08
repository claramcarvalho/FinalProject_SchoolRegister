namespace FinalProject_SchoolRegister
{
    partial class AddForm
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
            this.components = new System.ComponentModel.Container();
            this.comboBoxStId = new System.Windows.Forms.ComboBox();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.comboBoxCId = new System.Windows.Forms.ComboBox();
            this.txtStName = new System.Windows.Forms.TextBox();
            this.txtCName = new System.Windows.Forms.TextBox();
            this.btnAddNewEnroll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.bindingSourceStudents = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxStId
            // 
            this.comboBoxStId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxStId.FormattingEnabled = true;
            this.comboBoxStId.Location = new System.Drawing.Point(28, 72);
            this.comboBoxStId.Name = "comboBoxStId";
            this.comboBoxStId.Size = new System.Drawing.Size(179, 26);
            this.comboBoxStId.TabIndex = 1;
            this.comboBoxStId.SelectionChangeCommitted += new System.EventHandler(this.comboBoxStId_SelectionChangeCommitted);
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.Location = new System.Drawing.Point(114, 9);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(272, 32);
            this.lblFormTitle.TabIndex = 2;
            this.lblFormTitle.Text = "Add New Enrollment";
            // 
            // comboBoxCId
            // 
            this.comboBoxCId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCId.FormattingEnabled = true;
            this.comboBoxCId.Location = new System.Drawing.Point(28, 128);
            this.comboBoxCId.Name = "comboBoxCId";
            this.comboBoxCId.Size = new System.Drawing.Size(179, 26);
            this.comboBoxCId.TabIndex = 3;
            this.comboBoxCId.SelectionChangeCommitted += new System.EventHandler(this.comboBoxCId_SelectionChangeCommitted);
            // 
            // txtStName
            // 
            this.txtStName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStName.Location = new System.Drawing.Point(264, 67);
            this.txtStName.Name = "txtStName";
            this.txtStName.ReadOnly = true;
            this.txtStName.Size = new System.Drawing.Size(206, 30);
            this.txtStName.TabIndex = 4;
            this.txtStName.Text = "[Student Name]";
            // 
            // txtCName
            // 
            this.txtCName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCName.Location = new System.Drawing.Point(264, 123);
            this.txtCName.Name = "txtCName";
            this.txtCName.ReadOnly = true;
            this.txtCName.Size = new System.Drawing.Size(206, 30);
            this.txtCName.TabIndex = 5;
            this.txtCName.Text = "[Course Name]";
            // 
            // btnAddNewEnroll
            // 
            this.btnAddNewEnroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewEnroll.Location = new System.Drawing.Point(107, 193);
            this.btnAddNewEnroll.Name = "btnAddNewEnroll";
            this.btnAddNewEnroll.Size = new System.Drawing.Size(100, 40);
            this.btnAddNewEnroll.TabIndex = 6;
            this.btnAddNewEnroll.Text = "Add";
            this.btnAddNewEnroll.UseVisualStyleBackColor = true;
            this.btnAddNewEnroll.Click += new System.EventHandler(this.btnAddNewEnroll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(264, 193);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 265);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddNewEnroll);
            this.Controls.Add(this.txtCName);
            this.Controls.Add(this.txtStName);
            this.Controls.Add(this.comboBoxCId);
            this.Controls.Add(this.lblFormTitle);
            this.Controls.Add(this.comboBoxStId);
            this.Name = "AddForm";
            this.Text = "AddForm";
            this.Load += new System.EventHandler(this.AddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxStId;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.ComboBox comboBoxCId;
        private System.Windows.Forms.TextBox txtStName;
        private System.Windows.Forms.TextBox txtCName;
        private System.Windows.Forms.Button btnAddNewEnroll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.BindingSource bindingSourceStudents;
    }
}