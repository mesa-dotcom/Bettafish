namespace Bettafish
{
    partial class f2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f2));
            this.gbResults = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblExrPosFrontPass = new System.Windows.Forms.Label();
            this.lblExrPosFront = new System.Windows.Forms.Label();
            this.dtgvExrPosFront = new System.Windows.Forms.DataGridView();
            this.gbExrPosBack = new System.Windows.Forms.GroupBox();
            this.lblExrPosBackPass = new System.Windows.Forms.Label();
            this.lblExrPosBack = new System.Windows.Forms.Label();
            this.dtgvExrPosBack = new System.Windows.Forms.DataGridView();
            this.gbExSC = new System.Windows.Forms.GroupBox();
            this.lblExrSCPass = new System.Windows.Forms.Label();
            this.lblExrExpect = new System.Windows.Forms.Label();
            this.dtgvExrSC = new System.Windows.Forms.DataGridView();
            this.cbTranX = new System.Windows.Forms.CheckBox();
            this.cbPromo = new System.Windows.Forms.CheckBox();
            this.cbOneClick = new System.Windows.Forms.CheckBox();
            this.btnSaveResult = new System.Windows.Forms.Button();
            this.cbTarget = new System.Windows.Forms.CheckBox();
            this.gbResults.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvExrPosFront)).BeginInit();
            this.gbExrPosBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvExrPosBack)).BeginInit();
            this.gbExSC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvExrSC)).BeginInit();
            this.SuspendLayout();
            // 
            // gbResults
            // 
            this.gbResults.Controls.Add(this.cbTarget);
            this.gbResults.Controls.Add(this.groupBox1);
            this.gbResults.Controls.Add(this.gbExrPosBack);
            this.gbResults.Controls.Add(this.gbExSC);
            this.gbResults.Controls.Add(this.cbTranX);
            this.gbResults.Controls.Add(this.cbPromo);
            this.gbResults.Controls.Add(this.cbOneClick);
            this.gbResults.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbResults.Location = new System.Drawing.Point(9, 6);
            this.gbResults.Name = "gbResults";
            this.gbResults.Size = new System.Drawing.Size(623, 742);
            this.gbResults.TabIndex = 0;
            this.gbResults.TabStop = false;
            this.gbResults.Text = "Checklist Result";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblExrPosFrontPass);
            this.groupBox1.Controls.Add(this.lblExrPosFront);
            this.groupBox1.Controls.Add(this.dtgvExrPosFront);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 536);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(611, 198);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exchange Rate Pos Front (MA_Exchange_Rate)";
            // 
            // lblExrPosFrontPass
            // 
            this.lblExrPosFrontPass.AutoSize = true;
            this.lblExrPosFrontPass.ForeColor = System.Drawing.Color.Red;
            this.lblExrPosFrontPass.Location = new System.Drawing.Point(226, 25);
            this.lblExrPosFrontPass.Name = "lblExrPosFrontPass";
            this.lblExrPosFrontPass.Size = new System.Drawing.Size(26, 15);
            this.lblExrPosFrontPass.TabIndex = 2;
            this.lblExrPosFrontPass.Text = "Fail";
            // 
            // lblExrPosFront
            // 
            this.lblExrPosFront.AutoSize = true;
            this.lblExrPosFront.Location = new System.Drawing.Point(7, 25);
            this.lblExrPosFront.Name = "lblExrPosFront";
            this.lblExrPosFront.Size = new System.Drawing.Size(189, 15);
            this.lblExrPosFront.TabIndex = 1;
            this.lblExrPosFront.Text = "All Exchange Same Effective Date:";
            // 
            // dtgvExrPosFront
            // 
            this.dtgvExrPosFront.AllowUserToAddRows = false;
            this.dtgvExrPosFront.AllowUserToDeleteRows = false;
            this.dtgvExrPosFront.AllowUserToResizeColumns = false;
            this.dtgvExrPosFront.AllowUserToResizeRows = false;
            this.dtgvExrPosFront.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvExrPosFront.Location = new System.Drawing.Point(6, 53);
            this.dtgvExrPosFront.Name = "dtgvExrPosFront";
            this.dtgvExrPosFront.RowHeadersVisible = false;
            this.dtgvExrPosFront.RowHeadersWidth = 51;
            this.dtgvExrPosFront.RowTemplate.Height = 24;
            this.dtgvExrPosFront.Size = new System.Drawing.Size(599, 138);
            this.dtgvExrPosFront.TabIndex = 0;
            // 
            // gbExrPosBack
            // 
            this.gbExrPosBack.Controls.Add(this.lblExrPosBackPass);
            this.gbExrPosBack.Controls.Add(this.lblExrPosBack);
            this.gbExrPosBack.Controls.Add(this.dtgvExrPosBack);
            this.gbExrPosBack.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbExrPosBack.Location = new System.Drawing.Point(6, 329);
            this.gbExrPosBack.Name = "gbExrPosBack";
            this.gbExrPosBack.Size = new System.Drawing.Size(611, 198);
            this.gbExrPosBack.TabIndex = 4;
            this.gbExrPosBack.TabStop = false;
            this.gbExrPosBack.Text = "Exchange Rate Pos Back (MA_Gateway_Exchange)";
            // 
            // lblExrPosBackPass
            // 
            this.lblExrPosBackPass.AutoSize = true;
            this.lblExrPosBackPass.ForeColor = System.Drawing.Color.Red;
            this.lblExrPosBackPass.Location = new System.Drawing.Point(226, 25);
            this.lblExrPosBackPass.Name = "lblExrPosBackPass";
            this.lblExrPosBackPass.Size = new System.Drawing.Size(26, 15);
            this.lblExrPosBackPass.TabIndex = 2;
            this.lblExrPosBackPass.Text = "Fail";
            // 
            // lblExrPosBack
            // 
            this.lblExrPosBack.AutoSize = true;
            this.lblExrPosBack.Location = new System.Drawing.Point(7, 25);
            this.lblExrPosBack.Name = "lblExrPosBack";
            this.lblExrPosBack.Size = new System.Drawing.Size(189, 15);
            this.lblExrPosBack.TabIndex = 1;
            this.lblExrPosBack.Text = "All Exchange Same Effective Date:";
            // 
            // dtgvExrPosBack
            // 
            this.dtgvExrPosBack.AllowUserToAddRows = false;
            this.dtgvExrPosBack.AllowUserToDeleteRows = false;
            this.dtgvExrPosBack.AllowUserToResizeColumns = false;
            this.dtgvExrPosBack.AllowUserToResizeRows = false;
            this.dtgvExrPosBack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvExrPosBack.Location = new System.Drawing.Point(6, 53);
            this.dtgvExrPosBack.Name = "dtgvExrPosBack";
            this.dtgvExrPosBack.RowHeadersVisible = false;
            this.dtgvExrPosBack.RowHeadersWidth = 51;
            this.dtgvExrPosBack.RowTemplate.Height = 24;
            this.dtgvExrPosBack.Size = new System.Drawing.Size(599, 138);
            this.dtgvExrPosBack.TabIndex = 0;
            // 
            // gbExSC
            // 
            this.gbExSC.Controls.Add(this.lblExrSCPass);
            this.gbExSC.Controls.Add(this.lblExrExpect);
            this.gbExSC.Controls.Add(this.dtgvExrSC);
            this.gbExSC.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbExSC.Location = new System.Drawing.Point(6, 126);
            this.gbExSC.Name = "gbExSC";
            this.gbExSC.Size = new System.Drawing.Size(611, 198);
            this.gbExSC.TabIndex = 3;
            this.gbExSC.TabStop = false;
            this.gbExSC.Text = "Exchange Rate SC (T_EXCHANGE_RATE)";
            // 
            // lblExrSCPass
            // 
            this.lblExrSCPass.AutoSize = true;
            this.lblExrSCPass.ForeColor = System.Drawing.Color.Red;
            this.lblExrSCPass.Location = new System.Drawing.Point(226, 25);
            this.lblExrSCPass.Name = "lblExrSCPass";
            this.lblExrSCPass.Size = new System.Drawing.Size(26, 15);
            this.lblExrSCPass.TabIndex = 2;
            this.lblExrSCPass.Text = "Fail";
            // 
            // lblExrExpect
            // 
            this.lblExrExpect.AutoSize = true;
            this.lblExrExpect.Location = new System.Drawing.Point(7, 25);
            this.lblExrExpect.Name = "lblExrExpect";
            this.lblExrExpect.Size = new System.Drawing.Size(189, 15);
            this.lblExrExpect.TabIndex = 1;
            this.lblExrExpect.Text = "All Exchange Same Effective Date:";
            // 
            // dtgvExrSC
            // 
            this.dtgvExrSC.AllowUserToAddRows = false;
            this.dtgvExrSC.AllowUserToDeleteRows = false;
            this.dtgvExrSC.AllowUserToResizeColumns = false;
            this.dtgvExrSC.AllowUserToResizeRows = false;
            this.dtgvExrSC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvExrSC.Location = new System.Drawing.Point(6, 53);
            this.dtgvExrSC.Name = "dtgvExrSC";
            this.dtgvExrSC.RowHeadersVisible = false;
            this.dtgvExrSC.RowHeadersWidth = 51;
            this.dtgvExrSC.RowTemplate.Height = 24;
            this.dtgvExrSC.Size = new System.Drawing.Size(599, 138);
            this.dtgvExrSC.TabIndex = 0;
            // 
            // cbTranX
            // 
            this.cbTranX.AutoSize = true;
            this.cbTranX.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTranX.Location = new System.Drawing.Point(6, 77);
            this.cbTranX.Name = "cbTranX";
            this.cbTranX.Size = new System.Drawing.Size(342, 19);
            this.cbTranX.TabIndex = 2;
            this.cbTranX.Text = "No Transaction in SC_DB (T_TRANSACTION_HISTORY)";
            this.cbTranX.UseVisualStyleBackColor = true;
            // 
            // cbPromo
            // 
            this.cbPromo.AutoSize = true;
            this.cbPromo.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPromo.Location = new System.Drawing.Point(6, 51);
            this.cbPromo.Name = "cbPromo";
            this.cbPromo.Size = new System.Drawing.Size(210, 19);
            this.cbPromo.TabIndex = 1;
            this.cbPromo.Text = "Promotion (LPE_PROM) has data.";
            this.cbPromo.UseVisualStyleBackColor = true;
            // 
            // cbOneClick
            // 
            this.cbOneClick.AutoSize = true;
            this.cbOneClick.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOneClick.Location = new System.Drawing.Point(6, 25);
            this.cbOneClick.Name = "cbOneClick";
            this.cbOneClick.Size = new System.Drawing.Size(155, 19);
            this.cbOneClick.TabIndex = 0;
            this.cbOneClick.Text = "One Click is already run";
            this.cbOneClick.UseVisualStyleBackColor = true;
            // 
            // btnSaveResult
            // 
            this.btnSaveResult.Location = new System.Drawing.Point(254, 754);
            this.btnSaveResult.Name = "btnSaveResult";
            this.btnSaveResult.Size = new System.Drawing.Size(112, 31);
            this.btnSaveResult.TabIndex = 1;
            this.btnSaveResult.Text = "Save Result";
            this.btnSaveResult.UseVisualStyleBackColor = true;
            this.btnSaveResult.Click += new System.EventHandler(this.btnSaveResult_Click);
            // 
            // cbTarget
            // 
            this.cbTarget.AutoSize = true;
            this.cbTarget.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTarget.Location = new System.Drawing.Point(6, 102);
            this.cbTarget.Name = "cbTarget";
            this.cbTarget.Size = new System.Drawing.Size(216, 19);
            this.cbTarget.TabIndex = 6;
            this.cbTarget.Text = "Has Target in SC_DB (T_TARGET)";
            this.cbTarget.UseVisualStyleBackColor = true;
            // 
            // f2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 797);
            this.Controls.Add(this.btnSaveResult);
            this.Controls.Add(this.gbResults);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "f2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Checklist Result";
            this.Load += new System.EventHandler(this.f2_Load);
            this.gbResults.ResumeLayout(false);
            this.gbResults.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvExrPosFront)).EndInit();
            this.gbExrPosBack.ResumeLayout(false);
            this.gbExrPosBack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvExrPosBack)).EndInit();
            this.gbExSC.ResumeLayout(false);
            this.gbExSC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvExrSC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbResults;
        private System.Windows.Forms.CheckBox cbOneClick;
        private System.Windows.Forms.CheckBox cbTranX;
        private System.Windows.Forms.CheckBox cbPromo;
        private System.Windows.Forms.GroupBox gbExSC;
        private System.Windows.Forms.Label lblExrExpect;
        private System.Windows.Forms.DataGridView dtgvExrSC;
        private System.Windows.Forms.Label lblExrSCPass;
        private System.Windows.Forms.GroupBox gbExrPosBack;
        private System.Windows.Forms.Label lblExrPosBackPass;
        private System.Windows.Forms.Label lblExrPosBack;
        private System.Windows.Forms.DataGridView dtgvExrPosBack;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblExrPosFrontPass;
        private System.Windows.Forms.Label lblExrPosFront;
        private System.Windows.Forms.DataGridView dtgvExrPosFront;
        private System.Windows.Forms.Button btnSaveResult;
        private System.Windows.Forms.CheckBox cbTarget;
    }
}