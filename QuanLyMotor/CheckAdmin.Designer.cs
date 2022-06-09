
namespace QuanLyMotor
{
    partial class CheckAdmin
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
            this.txbCheckAdmin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCheckAdmin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbCheckAdmin
            // 
            this.txbCheckAdmin.BackColor = System.Drawing.SystemColors.InfoText;
            this.txbCheckAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCheckAdmin.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.txbCheckAdmin.Location = new System.Drawing.Point(12, 36);
            this.txbCheckAdmin.Name = "txbCheckAdmin";
            this.txbCheckAdmin.Size = new System.Drawing.Size(361, 34);
            this.txbCheckAdmin.TabIndex = 0;
            this.txbCheckAdmin.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã bảo mật của Admin:";
            // 
            // btnCheckAdmin
            // 
            this.btnCheckAdmin.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCheckAdmin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCheckAdmin.Location = new System.Drawing.Point(261, 77);
            this.btnCheckAdmin.Name = "btnCheckAdmin";
            this.btnCheckAdmin.Size = new System.Drawing.Size(112, 36);
            this.btnCheckAdmin.TabIndex = 2;
            this.btnCheckAdmin.Text = "Xác nhận";
            this.btnCheckAdmin.UseVisualStyleBackColor = false;
            this.btnCheckAdmin.Click += new System.EventHandler(this.btnCheckAdmin_Click);
            // 
            // CheckAdmin
            // 
            this.AcceptButton = this.btnCheckAdmin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 125);
            this.Controls.Add(this.btnCheckAdmin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbCheckAdmin);
            this.Name = "CheckAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CheckAdmin";
            this.Load += new System.EventHandler(this.CheckAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbCheckAdmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCheckAdmin;
    }
}