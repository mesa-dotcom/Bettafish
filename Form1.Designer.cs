namespace Bettafish
{
    partial class f1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f1));
            this.gbMain = new System.Windows.Forms.GroupBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.lblStore = new System.Windows.Forms.Label();
            this.tbStore = new System.Windows.Forms.TextBox();
            this.lbDebug = new System.Windows.Forms.ListBox();
            this.btnSaveLog = new System.Windows.Forms.Button();
            this.gbMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMain
            // 
            this.gbMain.Controls.Add(this.btnCheck);
            this.gbMain.Controls.Add(this.lblStore);
            this.gbMain.Controls.Add(this.tbStore);
            this.gbMain.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMain.Location = new System.Drawing.Point(12, 12);
            this.gbMain.Name = "gbMain";
            this.gbMain.Size = new System.Drawing.Size(708, 83);
            this.gbMain.TabIndex = 0;
            this.gbMain.TabStop = false;
            this.gbMain.Text = "Betta Fish: Checklist new opening store";
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(225, 34);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(103, 33);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblStore
            // 
            this.lblStore.AutoSize = true;
            this.lblStore.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStore.Location = new System.Drawing.Point(6, 40);
            this.lblStore.Name = "lblStore";
            this.lblStore.Size = new System.Drawing.Size(68, 19);
            this.lblStore.TabIndex = 1;
            this.lblStore.Text = "Store Id:";
            // 
            // tbStore
            // 
            this.tbStore.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStore.Location = new System.Drawing.Point(92, 37);
            this.tbStore.MaxLength = 5;
            this.tbStore.Name = "tbStore";
            this.tbStore.Size = new System.Drawing.Size(125, 27);
            this.tbStore.TabIndex = 0;
            // 
            // lbDebug
            // 
            this.lbDebug.FormattingEnabled = true;
            this.lbDebug.ItemHeight = 16;
            this.lbDebug.Location = new System.Drawing.Point(12, 103);
            this.lbDebug.Name = "lbDebug";
            this.lbDebug.Size = new System.Drawing.Size(708, 340);
            this.lbDebug.TabIndex = 1;
            // 
            // btnSaveLog
            // 
            this.btnSaveLog.Enabled = false;
            this.btnSaveLog.Location = new System.Drawing.Point(317, 454);
            this.btnSaveLog.Name = "btnSaveLog";
            this.btnSaveLog.Size = new System.Drawing.Size(98, 36);
            this.btnSaveLog.TabIndex = 2;
            this.btnSaveLog.Text = "Save Log";
            this.btnSaveLog.UseVisualStyleBackColor = true;
            this.btnSaveLog.Click += new System.EventHandler(this.btnSaveLog_Click);
            // 
            // f1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 502);
            this.Controls.Add(this.btnSaveLog);
            this.Controls.Add(this.lbDebug);
            this.Controls.Add(this.gbMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "f1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bettafish";
            this.gbMain.ResumeLayout(false);
            this.gbMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMain;
        private System.Windows.Forms.TextBox tbStore;
        private System.Windows.Forms.Label lblStore;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.ListBox lbDebug;
        private System.Windows.Forms.Button btnSaveLog;
    }
}

