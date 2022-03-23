
namespace OOP_Detyra1F2_Projekti11_SH.B
{
    partial class ForecastDailyUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForecastDailyUC));
            this.picBoxIcon = new System.Windows.Forms.PictureBox();
            this.lblDayTime = new System.Windows.Forms.Label();
            this.lblTemp = new System.Windows.Forms.Label();
            this.lblPressure = new System.Windows.Forms.Label();
            this.lblWind = new System.Windows.Forms.Label();
            this.lblCon = new System.Windows.Forms.Label();
            this.lblDes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxIcon
            // 
            this.picBoxIcon.Location = new System.Drawing.Point(17, 18);
            this.picBoxIcon.Name = "picBoxIcon";
            this.picBoxIcon.Size = new System.Drawing.Size(97, 103);
            this.picBoxIcon.TabIndex = 0;
            this.picBoxIcon.TabStop = false;
            // 
            // lblDayTime
            // 
            this.lblDayTime.AutoSize = true;
            this.lblDayTime.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblDayTime.ForeColor = System.Drawing.Color.White;
            this.lblDayTime.Location = new System.Drawing.Point(80, 7);
            this.lblDayTime.Name = "lblDayTime";
            this.lblDayTime.Size = new System.Drawing.Size(35, 19);
            this.lblDayTime.TabIndex = 1;
            this.lblDayTime.Text = "Day";
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.BackColor = System.Drawing.Color.Transparent;
            this.lblTemp.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblTemp.ForeColor = System.Drawing.Color.White;
            this.lblTemp.Location = new System.Drawing.Point(212, 7);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(69, 19);
            this.lblTemp.TabIndex = 1;
            this.lblTemp.Text = "Temp(°C)";
            // 
            // lblPressure
            // 
            this.lblPressure.AutoSize = true;
            this.lblPressure.BackColor = System.Drawing.Color.Transparent;
            this.lblPressure.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblPressure.ForeColor = System.Drawing.Color.White;
            this.lblPressure.Location = new System.Drawing.Point(212, 32);
            this.lblPressure.Name = "lblPressure";
            this.lblPressure.Size = new System.Drawing.Size(100, 19);
            this.lblPressure.TabIndex = 1;
            this.lblPressure.Text = "Presioni(hpa)";
            // 
            // lblWind
            // 
            this.lblWind.AutoSize = true;
            this.lblWind.BackColor = System.Drawing.Color.Transparent;
            this.lblWind.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblWind.ForeColor = System.Drawing.Color.White;
            this.lblWind.Location = new System.Drawing.Point(212, 58);
            this.lblWind.Name = "lblWind";
            this.lblWind.Size = new System.Drawing.Size(76, 19);
            this.lblWind.TabIndex = 1;
            this.lblWind.Text = "Era(mp/s)";
            // 
            // lblCon
            // 
            this.lblCon.AutoSize = true;
            this.lblCon.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblCon.ForeColor = System.Drawing.Color.White;
            this.lblCon.Location = new System.Drawing.Point(80, 32);
            this.lblCon.Name = "lblCon";
            this.lblCon.Size = new System.Drawing.Size(75, 19);
            this.lblCon.TabIndex = 1;
            this.lblCon.Text = "Condition";
            // 
            // lblDes
            // 
            this.lblDes.AutoSize = true;
            this.lblDes.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblDes.ForeColor = System.Drawing.Color.White;
            this.lblDes.Location = new System.Drawing.Point(80, 58);
            this.lblDes.Name = "lblDes";
            this.lblDes.Size = new System.Drawing.Size(86, 19);
            this.lblDes.TabIndex = 1;
            this.lblDes.Text = "Description";
            // 
            // ForecastDailyUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.lblDayTime);
            this.Controls.Add(this.lblCon);
            this.Controls.Add(this.lblDes);
            this.Controls.Add(this.picBoxIcon);
            this.Controls.Add(this.lblWind);
            this.Controls.Add(this.lblPressure);
            this.Controls.Add(this.lblTemp);
            this.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.Name = "ForecastDailyUC";
            this.Size = new System.Drawing.Size(345, 86);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox picBoxIcon;
        public System.Windows.Forms.Label lblDayTime;
        public System.Windows.Forms.Label lblTemp;
        public System.Windows.Forms.Label lblPressure;
        public System.Windows.Forms.Label lblWind;
        public System.Windows.Forms.Label lblCon;
        public System.Windows.Forms.Label lblDes;
    }
}
