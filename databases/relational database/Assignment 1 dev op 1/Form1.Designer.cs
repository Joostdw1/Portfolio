namespace Assignment_1_dev_op_1
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_employees = new System.Windows.Forms.Button();
            this.btn_Projects = new System.Windows.Forms.Button();
            this.btn_headquarters = new System.Windows.Forms.Button();
            this.btn_budget = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(236, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Assignment 1";
            // 
            // btn_employees
            // 
            this.btn_employees.Location = new System.Drawing.Point(269, 121);
            this.btn_employees.Name = "btn_employees";
            this.btn_employees.Size = new System.Drawing.Size(206, 32);
            this.btn_employees.TabIndex = 1;
            this.btn_employees.Text = "Employees";
            this.btn_employees.UseVisualStyleBackColor = true;
            this.btn_employees.Click += new System.EventHandler(this.btn_employees_Click);
            // 
            // btn_Projects
            // 
            this.btn_Projects.Location = new System.Drawing.Point(269, 159);
            this.btn_Projects.Name = "btn_Projects";
            this.btn_Projects.Size = new System.Drawing.Size(206, 32);
            this.btn_Projects.TabIndex = 2;
            this.btn_Projects.Text = "Projects";
            this.btn_Projects.UseVisualStyleBackColor = true;
            this.btn_Projects.Click += new System.EventHandler(this.btn_Projects_Click);
            // 
            // btn_headquarters
            // 
            this.btn_headquarters.Location = new System.Drawing.Point(269, 197);
            this.btn_headquarters.Name = "btn_headquarters";
            this.btn_headquarters.Size = new System.Drawing.Size(206, 32);
            this.btn_headquarters.TabIndex = 3;
            this.btn_headquarters.Text = "Headquarters";
            this.btn_headquarters.UseVisualStyleBackColor = true;
            this.btn_headquarters.Click += new System.EventHandler(this.btn_headquarters_Click);
            // 
            // btn_budget
            // 
            this.btn_budget.Location = new System.Drawing.Point(269, 235);
            this.btn_budget.Name = "btn_budget";
            this.btn_budget.Size = new System.Drawing.Size(206, 32);
            this.btn_budget.TabIndex = 4;
            this.btn_budget.Text = "Check budgets";
            this.btn_budget.UseVisualStyleBackColor = true;
            this.btn_budget.Click += new System.EventHandler(this.btn_budget_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(269, 316);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(206, 32);
            this.btn_exit.TabIndex = 5;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 362);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(578, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Made by: Joost de Wilde(0905965), Eljakim Herrewijnen(0912374), Chiel Broere(0892" +
    "218)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 388);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_budget);
            this.Controls.Add(this.btn_headquarters);
            this.Controls.Add(this.btn_Projects);
            this.Controls.Add(this.btn_employees);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assignment 1";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_employees;
        private System.Windows.Forms.Button btn_Projects;
        private System.Windows.Forms.Button btn_headquarters;
        private System.Windows.Forms.Button btn_budget;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label label2;
    }
}

