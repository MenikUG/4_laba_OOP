namespace _4_laba_OOP
{
    partial class Main
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
            this.paint_box = new System.Windows.Forms.Panel();
            this.label_paintbox = new System.Windows.Forms.Label();
            this.label_x = new System.Windows.Forms.Label();
            this.label_y = new System.Windows.Forms.Label();
            this.paint_box.SuspendLayout();
            this.SuspendLayout();
            // 
            // paint_box
            // 
            this.paint_box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paint_box.BackColor = System.Drawing.SystemColors.Info;
            this.paint_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paint_box.Controls.Add(this.label_paintbox);
            this.paint_box.Location = new System.Drawing.Point(12, 12);
            this.paint_box.Name = "paint_box";
            this.paint_box.Size = new System.Drawing.Size(605, 438);
            this.paint_box.TabIndex = 0;
            this.paint_box.MouseMove += new System.Windows.Forms.MouseEventHandler(this.paint_box_MouseMove);
            // 
            // label_paintbox
            // 
            this.label_paintbox.AutoSize = true;
            this.label_paintbox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_paintbox.Location = new System.Drawing.Point(4, 4);
            this.label_paintbox.Name = "label_paintbox";
            this.label_paintbox.Size = new System.Drawing.Size(203, 28);
            this.label_paintbox.TabIndex = 0;
            this.label_paintbox.Text = "Окно для рисования";
            // 
            // label_x
            // 
            this.label_x.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_x.AutoSize = true;
            this.label_x.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label_x.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_x.Location = new System.Drawing.Point(623, 12);
            this.label_x.Name = "label_x";
            this.label_x.Size = new System.Drawing.Size(153, 28);
            this.label_x.TabIndex = 1;
            this.label_x.Text = "Координаты X: ";
            // 
            // label_y
            // 
            this.label_y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_y.AutoSize = true;
            this.label_y.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label_y.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_y.Location = new System.Drawing.Point(623, 40);
            this.label_y.Name = "label_y";
            this.label_y.Size = new System.Drawing.Size(152, 28);
            this.label_y.TabIndex = 2;
            this.label_y.Text = "Координаты Y: ";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 462);
            this.Controls.Add(this.label_y);
            this.Controls.Add(this.label_x);
            this.Controls.Add(this.paint_box);
            this.Name = "Main";
            this.Text = "Form1";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            this.paint_box.ResumeLayout(false);
            this.paint_box.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel paint_box;
        private System.Windows.Forms.Label label_paintbox;
        private System.Windows.Forms.Label label_x;
        private System.Windows.Forms.Label label_y;
    }
}

