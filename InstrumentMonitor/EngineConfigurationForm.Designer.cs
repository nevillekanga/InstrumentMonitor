
namespace InstrumentMonitor
{
    partial class EngineConfigurationForm
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
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBoxPriceSources = new System.Windows.Forms.GroupBox();
            this.panelPriceSources = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxPriceSources.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStop.Location = new System.Drawing.Point(493, 274);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(350, 100);
            this.btnStop.TabIndex = 10;
            this.btnStop.Text = "Stop Simulation Engine";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStart.Location = new System.Drawing.Point(80, 274);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(350, 100);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Start Simulation Engine";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // groupBoxPriceSources
            // 
            this.groupBoxPriceSources.Controls.Add(this.panelPriceSources);
            this.groupBoxPriceSources.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxPriceSources.Location = new System.Drawing.Point(25, 39);
            this.groupBoxPriceSources.Name = "groupBoxPriceSources";
            this.groupBoxPriceSources.Size = new System.Drawing.Size(878, 184);
            this.groupBoxPriceSources.TabIndex = 8;
            this.groupBoxPriceSources.TabStop = false;
            this.groupBoxPriceSources.Text = "Select Price Source(s)";
            // 
            // panelPriceSources
            // 
            this.panelPriceSources.AutoScroll = true;
            this.panelPriceSources.Location = new System.Drawing.Point(18, 38);
            this.panelPriceSources.Name = "panelPriceSources";
            this.panelPriceSources.Padding = new System.Windows.Forms.Padding(10);
            this.panelPriceSources.Size = new System.Drawing.Size(836, 117);
            this.panelPriceSources.TabIndex = 0;
            // 
            // EngineConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 421);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBoxPriceSources);
            this.Name = "EngineConfigurationForm";
            this.Text = "Simulation Engine Configuration";
            this.Load += new System.EventHandler(this.EngineConfigurationForm_Load);
            this.groupBoxPriceSources.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBoxPriceSources;
        private System.Windows.Forms.FlowLayoutPanel panelPriceSources;
    }
}