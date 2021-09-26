
namespace InstrumentMonitor
{
    partial class SimulationControllerForm
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
            this.tbAssumptions = new System.Windows.Forms.TextBox();
            this.btnConfigureEngine = new System.Windows.Forms.Button();
            this.btnShowClient = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbAssumptions
            // 
            this.tbAssumptions.Enabled = false;
            this.tbAssumptions.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbAssumptions.Location = new System.Drawing.Point(32, 31);
            this.tbAssumptions.Multiline = true;
            this.tbAssumptions.Name = "tbAssumptions";
            this.tbAssumptions.Size = new System.Drawing.Size(1459, 517);
            this.tbAssumptions.TabIndex = 0;
            // 
            // btnConfigureEngine
            // 
            this.btnConfigureEngine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnConfigureEngine.Location = new System.Drawing.Point(113, 622);
            this.btnConfigureEngine.Name = "btnConfigureEngine";
            this.btnConfigureEngine.Size = new System.Drawing.Size(400, 100);
            this.btnConfigureEngine.TabIndex = 1;
            this.btnConfigureEngine.Text = "Configure Engine";
            this.btnConfigureEngine.UseVisualStyleBackColor = true;
            this.btnConfigureEngine.Click += new System.EventHandler(this.BtnConfigureEngine_Click);
            // 
            // btnShowClient
            // 
            this.btnShowClient.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnShowClient.Location = new System.Drawing.Point(562, 622);
            this.btnShowClient.Name = "btnShowClient";
            this.btnShowClient.Size = new System.Drawing.Size(400, 100);
            this.btnShowClient.TabIndex = 2;
            this.btnShowClient.Text = "Show Client";
            this.btnShowClient.UseVisualStyleBackColor = true;
            this.btnShowClient.Click += new System.EventHandler(this.BtnShowClient_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnExit.Location = new System.Drawing.Point(1011, 622);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(400, 100);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // SimulationControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1528, 783);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnShowClient);
            this.Controls.Add(this.btnConfigureEngine);
            this.Controls.Add(this.tbAssumptions);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "SimulationControllerForm";
            this.Text = "Simulation Controller";
            this.Load += new System.EventHandler(this.SimulationControllerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbAssumptions;
        private System.Windows.Forms.Button btnConfigureEngine;
        private System.Windows.Forms.Button btnShowClient;
        private System.Windows.Forms.Button btnExit;
    }
}