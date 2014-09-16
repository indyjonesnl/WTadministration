namespace WTnote
{
    partial class EditPlanesForm
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
            this.lbPlanes = new System.Windows.Forms.ListBox();
            this.tbPlaneName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnFinished = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddList = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbPlanes
            // 
            this.lbPlanes.FormattingEnabled = true;
            this.lbPlanes.Location = new System.Drawing.Point(12, 14);
            this.lbPlanes.Name = "lbPlanes";
            this.lbPlanes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbPlanes.Size = new System.Drawing.Size(317, 420);
            this.lbPlanes.TabIndex = 0;
            // 
            // tbPlaneName
            // 
            this.tbPlaneName.Location = new System.Drawing.Point(12, 440);
            this.tbPlaneName.Name = "tbPlaneName";
            this.tbPlaneName.Size = new System.Drawing.Size(317, 20);
            this.tbPlaneName.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(106, 466);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnFinished
            // 
            this.btnFinished.Location = new System.Drawing.Point(271, 466);
            this.btnFinished.Name = "btnFinished";
            this.btnFinished.Size = new System.Drawing.Size(59, 23);
            this.btnFinished.TabIndex = 3;
            this.btnFinished.Text = "Finished";
            this.btnFinished.UseVisualStyleBackColor = true;
            this.btnFinished.Click += new System.EventHandler(this.btnFinished_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(52, 466);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(48, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddList
            // 
            this.btnAddList.Location = new System.Drawing.Point(148, 466);
            this.btnAddList.Name = "btnAddList";
            this.btnAddList.Size = new System.Drawing.Size(58, 23);
            this.btnAddList.TabIndex = 5;
            this.btnAddList.Text = "Add a list";
            this.btnAddList.UseVisualStyleBackColor = true;
            this.btnAddList.Click += new System.EventHandler(this.btnAddList_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(12, 466);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(34, 23);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // EditPlanesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 500);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAddList);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnFinished);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbPlaneName);
            this.Controls.Add(this.lbPlanes);
            this.Name = "EditPlanesForm";
            this.Text = "EditPlanesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbPlanes;
        private System.Windows.Forms.TextBox tbPlaneName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnFinished;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddList;
        private System.Windows.Forms.Button btnEdit;
    }
}