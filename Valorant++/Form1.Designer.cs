
namespace Valorant__
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.txtValorantPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageLogs = new System.Windows.Forms.TabPage();
            this.txtBoxLogs = new System.Windows.Forms.TextBox();
            this.tabPageClientApi = new System.Windows.Forms.TabPage();
            this.txtBoxClientApi = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.tabPageLogs.SuspendLayout();
            this.tabPageClientApi.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageSettings);
            this.tabControl1.Controls.Add(this.tabPageLogs);
            this.tabControl1.Controls.Add(this.tabPageClientApi);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(938, 1012);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.txtValorantPath);
            this.tabPageSettings.Controls.Add(this.label3);
            this.tabPageSettings.Controls.Add(this.label2);
            this.tabPageSettings.Controls.Add(this.label1);
            this.tabPageSettings.Location = new System.Drawing.Point(8, 39);
            this.tabPageSettings.Margin = new System.Windows.Forms.Padding(6);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(6);
            this.tabPageSettings.Size = new System.Drawing.Size(922, 965);
            this.tabPageSettings.TabIndex = 1;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // txtValorantPath
            // 
            this.txtValorantPath.Location = new System.Drawing.Point(219, 25);
            this.txtValorantPath.Name = "txtValorantPath";
            this.txtValorantPath.ReadOnly = true;
            this.txtValorantPath.Size = new System.Drawing.Size(656, 31);
            this.txtValorantPath.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valorant Path";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tabPageLogs
            // 
            this.tabPageLogs.Controls.Add(this.txtBoxLogs);
            this.tabPageLogs.Location = new System.Drawing.Point(8, 39);
            this.tabPageLogs.Margin = new System.Windows.Forms.Padding(6);
            this.tabPageLogs.Name = "tabPageLogs";
            this.tabPageLogs.Size = new System.Drawing.Size(922, 965);
            this.tabPageLogs.TabIndex = 2;
            this.tabPageLogs.Text = "Logs";
            this.tabPageLogs.UseVisualStyleBackColor = true;
            // 
            // txtBoxLogs
            // 
            this.txtBoxLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxLogs.Location = new System.Drawing.Point(0, 0);
            this.txtBoxLogs.Margin = new System.Windows.Forms.Padding(6);
            this.txtBoxLogs.Multiline = true;
            this.txtBoxLogs.Name = "txtBoxLogs";
            this.txtBoxLogs.ReadOnly = true;
            this.txtBoxLogs.Size = new System.Drawing.Size(922, 965);
            this.txtBoxLogs.TabIndex = 0;
            // 
            // tabPageClientApi
            // 
            this.tabPageClientApi.Controls.Add(this.txtBoxClientApi);
            this.tabPageClientApi.Location = new System.Drawing.Point(8, 39);
            this.tabPageClientApi.Margin = new System.Windows.Forms.Padding(6);
            this.tabPageClientApi.Name = "tabPageClientApi";
            this.tabPageClientApi.Size = new System.Drawing.Size(922, 965);
            this.tabPageClientApi.TabIndex = 3;
            this.tabPageClientApi.Text = "Client API";
            this.tabPageClientApi.UseVisualStyleBackColor = true;
            // 
            // txtBoxClientApi
            // 
            this.txtBoxClientApi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxClientApi.Location = new System.Drawing.Point(0, 0);
            this.txtBoxClientApi.Margin = new System.Windows.Forms.Padding(6);
            this.txtBoxClientApi.Multiline = true;
            this.txtBoxClientApi.Name = "txtBoxClientApi";
            this.txtBoxClientApi.ReadOnly = true;
            this.txtBoxClientApi.Size = new System.Drawing.Size(922, 965);
            this.txtBoxClientApi.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 1012);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Valorant++";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.tabPageLogs.ResumeLayout(false);
            this.tabPageLogs.PerformLayout();
            this.tabPageClientApi.ResumeLayout(false);
            this.tabPageClientApi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.TabPage tabPageLogs;
        private System.Windows.Forms.TextBox txtBoxLogs;
        private System.Windows.Forms.TabPage tabPageClientApi;
        private System.Windows.Forms.TextBox txtBoxClientApi;
        private System.Windows.Forms.TextBox txtValorantPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

