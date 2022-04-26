namespace ResourceManager.Client
{
    partial class ExcelExport
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
            this.cbkExportDiff = new System.Windows.Forms.CheckBox();
            this.cbkExportComments = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.cbkAutoAdjustLayout = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.projects = new ResourceManager.Client.Controls.ProjectsListView();
            this.lbCultures = new System.Windows.Forms.Label();
            this.lbProjects = new System.Windows.Forms.Label();
            this.cultures = new ResourceManager.Client.Controls.CulturesListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbkExportDiff
            // 
            this.cbkExportDiff.AutoSize = true;
            this.cbkExportDiff.Location = new System.Drawing.Point(24, 18);
            this.cbkExportDiff.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbkExportDiff.Name = "cbkExportDiff";
            this.cbkExportDiff.Size = new System.Drawing.Size(110, 24);
            this.cbkExportDiff.TabIndex = 0;
            this.cbkExportDiff.Text = "Export Diff";
            this.cbkExportDiff.UseVisualStyleBackColor = true;
            // 
            // cbkExportComments
            // 
            this.cbkExportComments.AutoSize = true;
            this.cbkExportComments.Location = new System.Drawing.Point(24, 55);
            this.cbkExportComments.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbkExportComments.Name = "cbkExportComments";
            this.cbkExportComments.Size = new System.Drawing.Size(162, 24);
            this.cbkExportComments.TabIndex = 1;
            this.cbkExportComments.Text = "Export Comments";
            this.cbkExportComments.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(156, 9);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(34, 9);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(112, 35);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cbkAutoAdjustLayout
            // 
            this.cbkAutoAdjustLayout.AutoSize = true;
            this.cbkAutoAdjustLayout.Checked = true;
            this.cbkAutoAdjustLayout.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbkAutoAdjustLayout.Location = new System.Drawing.Point(24, 91);
            this.cbkAutoAdjustLayout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbkAutoAdjustLayout.Name = "cbkAutoAdjustLayout";
            this.cbkAutoAdjustLayout.Size = new System.Drawing.Size(162, 24);
            this.cbkAutoAdjustLayout.TabIndex = 5;
            this.cbkAutoAdjustLayout.Text = "Auto adjust layout";
            this.cbkAutoAdjustLayout.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 693);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(708, 58);
            this.panel1.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnExport);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(422, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(286, 58);
            this.panel3.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.projects, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbCultures, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbProjects, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cultures, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 11, 0, 0);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(708, 531);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // projects
            // 
            this.projects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projects.ItemHeight = 20;
            this.projects.Location = new System.Drawing.Point(4, 47);
            this.projects.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.projects.Name = "projects";
            this.projects.ScrollAlwaysVisible = true;
            this.projects.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.projects.Size = new System.Drawing.Size(346, 479);
            this.projects.Solution = null;
            this.projects.TabIndex = 6;
            // 
            // lbCultures
            // 
            this.lbCultures.AutoSize = true;
            this.lbCultures.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCultures.Location = new System.Drawing.Point(358, 11);
            this.lbCultures.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCultures.Name = "lbCultures";
            this.lbCultures.Size = new System.Drawing.Size(59, 20);
            this.lbCultures.TabIndex = 8;
            this.lbCultures.Text = "label2";
            // 
            // lbProjects
            // 
            this.lbProjects.AutoSize = true;
            this.lbProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProjects.Location = new System.Drawing.Point(4, 11);
            this.lbProjects.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbProjects.Name = "lbProjects";
            this.lbProjects.Size = new System.Drawing.Size(59, 20);
            this.lbProjects.TabIndex = 7;
            this.lbProjects.Text = "label1";
            // 
            // cultures
            // 
            this.cultures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cultures.FormattingEnabled = true;
            this.cultures.ItemHeight = 20;
            this.cultures.Location = new System.Drawing.Point(358, 47);
            this.cultures.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cultures.Name = "cultures";
            this.cultures.ScrollAlwaysVisible = true;
            this.cultures.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.cultures.Size = new System.Drawing.Size(346, 479);
            this.cultures.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbkExportDiff);
            this.panel2.Controls.Add(this.cbkExportComments);
            this.panel2.Controls.Add(this.cbkAutoAdjustLayout);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 531);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(708, 162);
            this.panel2.TabIndex = 12;
            // 
            // ExcelExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 751);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExcelExport";
            this.Text = "ExcelExport";
            this.Load += new System.EventHandler(this.ExcelExport_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cbkExportDiff;
        private System.Windows.Forms.CheckBox cbkExportComments;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
          private System.Windows.Forms.CheckBox cbkAutoAdjustLayout;
          private System.Windows.Forms.Panel panel1;
          private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
          private System.Windows.Forms.Label lbCultures;
          private System.Windows.Forms.Label lbProjects;
          private Controls.ProjectsListView projects;
          private System.Windows.Forms.Panel panel2;
          private System.Windows.Forms.Panel panel3;
          private Controls.CulturesListBox cultures;
    }
}