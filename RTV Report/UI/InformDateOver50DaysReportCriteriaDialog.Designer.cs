namespace RTV_Report.UI
{
    partial class InformDateOver50DaysReportCriteriaDialog
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
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.numInformDaysUpperLimit = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numInformDaysUpperLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // btnContinue
            // 
            this.btnContinue.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnContinue.Location = new System.Drawing.Point(119, 81);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(75, 23);
            this.btnContinue.TabIndex = 0;
            this.btnContinue.Text = "继续";
            this.btnContinue.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(200, 81);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(35, 30);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(175, 18);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "50  <=  通知天数  <=   ";
            // 
            // numInformDaysUpperLimit
            // 
            this.numInformDaysUpperLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numInformDaysUpperLimit.Location = new System.Drawing.Point(200, 27);
            this.numInformDaysUpperLimit.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numInformDaysUpperLimit.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numInformDaysUpperLimit.Name = "numInformDaysUpperLimit";
            this.numInformDaysUpperLimit.Size = new System.Drawing.Size(75, 26);
            this.numInformDaysUpperLimit.TabIndex = 3;
            this.numInformDaysUpperLimit.Tag = "";
            this.numInformDaysUpperLimit.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // InformDateOver50DaysReportCriteriaDialog
            // 
            this.AcceptButton = this.btnContinue;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(314, 113);
            this.Controls.Add(this.numInformDaysUpperLimit);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnContinue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InformDateOver50DaysReportCriteriaDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "超50天通知日期报告 - 条件选择";
            ((System.ComponentModel.ISupportInitialize)(this.numInformDaysUpperLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.NumericUpDown numInformDaysUpperLimit;
    }
}