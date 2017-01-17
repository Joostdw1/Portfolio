namespace Assignment_1_dev_op_1
{
    partial class projects
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
            this.btn_execute_project = new System.Windows.Forms.Button();
            this.cb_modify_project = new System.Windows.Forms.CheckBox();
            this.cb_delete_project = new System.Windows.Forms.CheckBox();
            this.cb_add_project = new System.Windows.Forms.CheckBox();
            this.tb_allocated_hours2 = new System.Windows.Forms.TextBox();
            this.tb_budget2 = new System.Windows.Forms.TextBox();
            this.lb_headquarter = new System.Windows.Forms.Label();
            this.lb_allocated_hours = new System.Windows.Forms.Label();
            this.lb_budget = new System.Windows.Forms.Label();
            this.lb_project_id = new System.Windows.Forms.Label();
            this.tb_headquarter = new System.Windows.Forms.TextBox();
            this.tb_allocated_hours = new System.Windows.Forms.TextBox();
            this.tb_budget = new System.Windows.Forms.TextBox();
            this.tb_project_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_get_projects = new System.Windows.Forms.Button();
            this.cB_projects_id2 = new System.Windows.Forms.ComboBox();
            this.cB_headquarter2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_execute_project
            // 
            this.btn_execute_project.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_execute_project.Location = new System.Drawing.Point(517, 545);
            this.btn_execute_project.Name = "btn_execute_project";
            this.btn_execute_project.Size = new System.Drawing.Size(164, 64);
            this.btn_execute_project.TabIndex = 7;
            this.btn_execute_project.Text = "Execute project";
            this.btn_execute_project.UseVisualStyleBackColor = true;
            this.btn_execute_project.Click += new System.EventHandler(this.btn_execute_project_Click);
            // 
            // cb_modify_project
            // 
            this.cb_modify_project.AutoSize = true;
            this.cb_modify_project.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_modify_project.Location = new System.Drawing.Point(705, 515);
            this.cb_modify_project.Name = "cb_modify_project";
            this.cb_modify_project.Size = new System.Drawing.Size(136, 24);
            this.cb_modify_project.TabIndex = 6;
            this.cb_modify_project.Text = "modify project";
            this.cb_modify_project.UseVisualStyleBackColor = true;
            this.cb_modify_project.CheckedChanged += new System.EventHandler(this.cb_modify_project_CheckedChanged);
            // 
            // cb_delete_project
            // 
            this.cb_delete_project.AutoSize = true;
            this.cb_delete_project.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_delete_project.Location = new System.Drawing.Point(529, 515);
            this.cb_delete_project.Name = "cb_delete_project";
            this.cb_delete_project.Size = new System.Drawing.Size(132, 24);
            this.cb_delete_project.TabIndex = 5;
            this.cb_delete_project.Text = "delete project";
            this.cb_delete_project.UseVisualStyleBackColor = true;
            this.cb_delete_project.CheckedChanged += new System.EventHandler(this.cb_delete_project_CheckedChanged);
            // 
            // cb_add_project
            // 
            this.cb_add_project.AutoSize = true;
            this.cb_add_project.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_add_project.Location = new System.Drawing.Point(378, 515);
            this.cb_add_project.Name = "cb_add_project";
            this.cb_add_project.Size = new System.Drawing.Size(114, 24);
            this.cb_add_project.TabIndex = 4;
            this.cb_add_project.Text = "add project";
            this.cb_add_project.UseVisualStyleBackColor = true;
            this.cb_add_project.CheckedChanged += new System.EventHandler(this.cb_add_project_CheckedChanged);
            // 
            // tb_allocated_hours2
            // 
            this.tb_allocated_hours2.Location = new System.Drawing.Point(597, 487);
            this.tb_allocated_hours2.Name = "tb_allocated_hours2";
            this.tb_allocated_hours2.Size = new System.Drawing.Size(263, 22);
            this.tb_allocated_hours2.TabIndex = 2;
            // 
            // tb_budget2
            // 
            this.tb_budget2.Location = new System.Drawing.Point(328, 487);
            this.tb_budget2.Name = "tb_budget2";
            this.tb_budget2.Size = new System.Drawing.Size(263, 22);
            this.tb_budget2.TabIndex = 1;
            // 
            // lb_headquarter
            // 
            this.lb_headquarter.AutoSize = true;
            this.lb_headquarter.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_headquarter.Location = new System.Drawing.Point(861, 151);
            this.lb_headquarter.Name = "lb_headquarter";
            this.lb_headquarter.Size = new System.Drawing.Size(155, 29);
            this.lb_headquarter.TabIndex = 62;
            this.lb_headquarter.Text = "headquarter:";
            // 
            // lb_allocated_hours
            // 
            this.lb_allocated_hours.AutoSize = true;
            this.lb_allocated_hours.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_allocated_hours.Location = new System.Drawing.Point(592, 151);
            this.lb_allocated_hours.Name = "lb_allocated_hours";
            this.lb_allocated_hours.Size = new System.Drawing.Size(192, 29);
            this.lb_allocated_hours.TabIndex = 61;
            this.lb_allocated_hours.Text = "allocated hours:";
            // 
            // lb_budget
            // 
            this.lb_budget.AutoSize = true;
            this.lb_budget.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_budget.Location = new System.Drawing.Point(323, 151);
            this.lb_budget.Name = "lb_budget";
            this.lb_budget.Size = new System.Drawing.Size(97, 29);
            this.lb_budget.TabIndex = 60;
            this.lb_budget.Text = "budget:";
            // 
            // lb_project_id
            // 
            this.lb_project_id.AutoSize = true;
            this.lb_project_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_project_id.Location = new System.Drawing.Point(54, 151);
            this.lb_project_id.Name = "lb_project_id";
            this.lb_project_id.Size = new System.Drawing.Size(123, 29);
            this.lb_project_id.TabIndex = 59;
            this.lb_project_id.Text = "project id:";
            // 
            // tb_headquarter
            // 
            this.tb_headquarter.Location = new System.Drawing.Point(866, 183);
            this.tb_headquarter.Multiline = true;
            this.tb_headquarter.Name = "tb_headquarter";
            this.tb_headquarter.ReadOnly = true;
            this.tb_headquarter.Size = new System.Drawing.Size(263, 298);
            this.tb_headquarter.TabIndex = 58;
            // 
            // tb_allocated_hours
            // 
            this.tb_allocated_hours.Location = new System.Drawing.Point(597, 183);
            this.tb_allocated_hours.Multiline = true;
            this.tb_allocated_hours.Name = "tb_allocated_hours";
            this.tb_allocated_hours.ReadOnly = true;
            this.tb_allocated_hours.Size = new System.Drawing.Size(263, 298);
            this.tb_allocated_hours.TabIndex = 57;
            // 
            // tb_budget
            // 
            this.tb_budget.Location = new System.Drawing.Point(328, 183);
            this.tb_budget.Multiline = true;
            this.tb_budget.Name = "tb_budget";
            this.tb_budget.ReadOnly = true;
            this.tb_budget.Size = new System.Drawing.Size(263, 298);
            this.tb_budget.TabIndex = 56;
            // 
            // tb_project_id
            // 
            this.tb_project_id.Location = new System.Drawing.Point(59, 183);
            this.tb_project_id.Multiline = true;
            this.tb_project_id.Name = "tb_project_id";
            this.tb_project_id.ReadOnly = true;
            this.tb_project_id.Size = new System.Drawing.Size(263, 298);
            this.tb_project_id.TabIndex = 55;
            this.tb_project_id.TextChanged += new System.EventHandler(this.tb_project_id_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(584, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 48);
            this.label1.TabIndex = 71;
            this.label1.Text = "Projects";
            // 
            // btn_back
            // 
            this.btn_back.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_back.Location = new System.Drawing.Point(48, 33);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(144, 51);
            this.btn_back.TabIndex = 9;
            this.btn_back.Text = "Back to menu";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // btn_get_projects
            // 
            this.btn_get_projects.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_get_projects.Location = new System.Drawing.Point(1135, 239);
            this.btn_get_projects.Name = "btn_get_projects";
            this.btn_get_projects.Size = new System.Drawing.Size(167, 83);
            this.btn_get_projects.TabIndex = 8;
            this.btn_get_projects.Text = "Get all projects";
            this.btn_get_projects.UseVisualStyleBackColor = true;
            this.btn_get_projects.Click += new System.EventHandler(this.btn_get_projects_Click);
            // 
            // cB_projects_id2
            // 
            this.cB_projects_id2.FormattingEnabled = true;
            this.cB_projects_id2.Location = new System.Drawing.Point(59, 487);
            this.cB_projects_id2.Name = "cB_projects_id2";
            this.cB_projects_id2.Size = new System.Drawing.Size(263, 24);
            this.cB_projects_id2.TabIndex = 0;
            this.cB_projects_id2.TextChanged += new System.EventHandler(this.cB_projects_id2_TextChanged);
            this.cB_projects_id2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cB_projects_id2_KeyPress);
            // 
            // cB_headquarter2
            // 
            this.cB_headquarter2.FormattingEnabled = true;
            this.cB_headquarter2.Location = new System.Drawing.Point(866, 487);
            this.cB_headquarter2.Name = "cB_headquarter2";
            this.cB_headquarter2.Size = new System.Drawing.Size(263, 24);
            this.cB_headquarter2.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(385, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(586, 33);
            this.label6.TabIndex = 80;
            this.label6.Text = "Choose/write only in the small textboxes!";
            // 
            // projects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1357, 642);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cB_headquarter2);
            this.Controls.Add(this.cB_projects_id2);
            this.Controls.Add(this.btn_get_projects);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_execute_project);
            this.Controls.Add(this.cb_modify_project);
            this.Controls.Add(this.cb_delete_project);
            this.Controls.Add(this.cb_add_project);
            this.Controls.Add(this.tb_allocated_hours2);
            this.Controls.Add(this.tb_budget2);
            this.Controls.Add(this.lb_headquarter);
            this.Controls.Add(this.lb_allocated_hours);
            this.Controls.Add(this.lb_budget);
            this.Controls.Add(this.lb_project_id);
            this.Controls.Add(this.tb_headquarter);
            this.Controls.Add(this.tb_allocated_hours);
            this.Controls.Add(this.tb_budget);
            this.Controls.Add(this.tb_project_id);
            this.Name = "projects";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "projects";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_execute_project;
        private System.Windows.Forms.CheckBox cb_modify_project;
        private System.Windows.Forms.CheckBox cb_delete_project;
        private System.Windows.Forms.CheckBox cb_add_project;
        private System.Windows.Forms.TextBox tb_allocated_hours2;
        private System.Windows.Forms.TextBox tb_budget2;
        private System.Windows.Forms.Label lb_headquarter;
        private System.Windows.Forms.Label lb_allocated_hours;
        private System.Windows.Forms.Label lb_budget;
        private System.Windows.Forms.Label lb_project_id;
        private System.Windows.Forms.TextBox tb_headquarter;
        private System.Windows.Forms.TextBox tb_allocated_hours;
        private System.Windows.Forms.TextBox tb_budget;
        private System.Windows.Forms.TextBox tb_project_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_get_projects;
        private System.Windows.Forms.ComboBox cB_projects_id2;
        private System.Windows.Forms.ComboBox cB_headquarter2;
        private System.Windows.Forms.Label label6;
    }
}