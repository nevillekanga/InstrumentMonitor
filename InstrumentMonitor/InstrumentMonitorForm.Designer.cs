
namespace InstrumentMonitor
{
    partial class InstrumentMonitorForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBoxInstruments = new System.Windows.Forms.GroupBox();
            this.checkBoxSubscribeAll = new System.Windows.Forms.CheckBox();
            this.panelInstruments = new System.Windows.Forms.FlowLayoutPanel();
            this.dataGridViewPrices = new System.Windows.Forms.DataGridView();
            this.lblLastUpdate = new System.Windows.Forms.Label();
            this.lblEngineStatus = new System.Windows.Forms.Label();
            this.groupBoxInstruments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrices)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxInstruments
            // 
            this.groupBoxInstruments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxInstruments.Controls.Add(this.checkBoxSubscribeAll);
            this.groupBoxInstruments.Controls.Add(this.panelInstruments);
            this.groupBoxInstruments.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBoxInstruments.Location = new System.Drawing.Point(36, 40);
            this.groupBoxInstruments.Name = "groupBoxInstruments";
            this.groupBoxInstruments.Size = new System.Drawing.Size(400, 890);
            this.groupBoxInstruments.TabIndex = 2;
            this.groupBoxInstruments.TabStop = false;
            this.groupBoxInstruments.Text = "Available Instruments";
            // 
            // checkBoxSubscribeAll
            // 
            this.checkBoxSubscribeAll.AutoSize = true;
            this.checkBoxSubscribeAll.Location = new System.Drawing.Point(22, 46);
            this.checkBoxSubscribeAll.Name = "checkBoxSubscribeAll";
            this.checkBoxSubscribeAll.Size = new System.Drawing.Size(195, 36);
            this.checkBoxSubscribeAll.TabIndex = 4;
            this.checkBoxSubscribeAll.Text = "Subscribe All";
            this.checkBoxSubscribeAll.UseVisualStyleBackColor = true;
            this.checkBoxSubscribeAll.Click += new System.EventHandler(this.CheckBoxSubscribeAll_Click);
            // 
            // panelInstruments
            // 
            this.panelInstruments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelInstruments.AutoScroll = true;
            this.panelInstruments.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panelInstruments.Location = new System.Drawing.Point(11, 88);
            this.panelInstruments.Name = "panelInstruments";
            this.panelInstruments.Padding = new System.Windows.Forms.Padding(10);
            this.panelInstruments.Size = new System.Drawing.Size(366, 782);
            this.panelInstruments.TabIndex = 3;
            // 
            // dataGridViewPrices
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dataGridViewPrices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewPrices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPrices.Location = new System.Drawing.Point(512, 94);
            this.dataGridViewPrices.Name = "dataGridViewPrices";
            this.dataGridViewPrices.ReadOnly = true;
            this.dataGridViewPrices.RowHeadersWidth = 82;
            this.dataGridViewPrices.RowTemplate.Height = 41;
            this.dataGridViewPrices.Size = new System.Drawing.Size(699, 836);
            this.dataGridViewPrices.TabIndex = 5;
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.AutoSize = true;
            this.lblLastUpdate.Location = new System.Drawing.Point(512, 40);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(144, 32);
            this.lblLastUpdate.TabIndex = 7;
            this.lblLastUpdate.Text = "Last Update:";
            // 
            // lblEngineStatus
            // 
            this.lblEngineStatus.AutoSize = true;
            this.lblEngineStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblEngineStatus.Location = new System.Drawing.Point(1006, 40);
            this.lblEngineStatus.Name = "lblEngineStatus";
            this.lblEngineStatus.Size = new System.Drawing.Size(92, 32);
            this.lblEngineStatus.TabIndex = 8;
            this.lblEngineStatus.Text = "Engine:";
            // 
            // InstrumentMonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 967);
            this.Controls.Add(this.lblEngineStatus);
            this.Controls.Add(this.lblLastUpdate);
            this.Controls.Add(this.dataGridViewPrices);
            this.Controls.Add(this.groupBoxInstruments);
            this.Name = "InstrumentMonitorForm";
            this.Text = "Instrument Monitor";
            this.groupBoxInstruments.ResumeLayout(false);
            this.groupBoxInstruments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxInstruments;
        private System.Windows.Forms.FlowLayoutPanel panelInstruments;
        private System.Windows.Forms.DataGridView dataGridViewPrices;
        private System.Windows.Forms.CheckBox checkBoxSubscribeAll;
        private System.Windows.Forms.Label lblLastUpdate;
        private System.Windows.Forms.Label lblEngineStatus;
    }
}

