namespace RTV_Report.UI
{
    partial class ActivationDialog
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
            this.btnActivate = new System.Windows.Forms.Button();
            this.txtActivationCode = new System.Windows.Forms.TextBox();
            this.lblActivationCode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnActivate
            // 
            this.btnActivate.Location = new System.Drawing.Point(143, 72);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(75, 23);
            this.btnActivate.TabIndex = 0;
            this.btnActivate.Text = "¼¤»î";
            this.btnActivate.UseVisualStyleBackColor = true;
            // 
            // txtActivationCode
            // 
            this.txtActivationCode.Location = new System.Drawing.Point(86, 28);
            this.txtActivationCode.MaxLength = 20;
            this.txtActivationCode.Name = "txtActivationCode";
            this.txtActivationCode.Size = new System.Drawing.Size(132, 20);
            this.txtActivationCode.TabIndex = 1;
            // 
            // lblActivationCode
            // 
            this.lblActivationCode.AutoSize = true;
            this.lblActivationCode.Location = new System.Drawing.Point(25, 31);
            this.lblActivationCode.Name = "lblActivationCode";
            this.lblActivationCode.Size = new System.Drawing.Size(55, 13);
            this.lblActivationCode.TabIndex = 2;
            this.lblActivationCode.Text = "¼¤»îÂë£º";
            // 
            // ActivationDialog
            // 
            this.AcceptButton = this.btnActivate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 107);
            this.ControlBox = false;
            this.Controls.Add(this.lblActivationCode);
            this.Controls.Add(this.txtActivationCode);
            this.Controls.Add(this.btnActivate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ActivationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "¼¤»î";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.TextBox txtActivationCode;
        private System.Windows.Forms.Label lblActivationCode;
    }
}