namespace Service
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbMechanic = new System.Windows.Forms.ComboBox();
            this.lb1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbMechanic
            // 
            this.cmbMechanic.FormattingEnabled = true;
            this.cmbMechanic.Location = new System.Drawing.Point(40, 63);
            this.cmbMechanic.Name = "cmbMechanic";
            this.cmbMechanic.Size = new System.Drawing.Size(144, 21);
            this.cmbMechanic.TabIndex = 0;
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb1.Location = new System.Drawing.Point(37, 42);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(66, 18);
            this.lb1.TabIndex = 1;
            this.lb1.Text = "Мастер";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 718);
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.cmbMechanic);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMechanic;
        private System.Windows.Forms.Label lb1;
    }
}

