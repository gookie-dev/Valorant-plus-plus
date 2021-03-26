
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
            this.tabPageLogs = new System.Windows.Forms.TabPage();
            this.txtBoxLogs = new System.Windows.Forms.TextBox();
            this.tabPageClientApi = new System.Windows.Forms.TabPage();
            this.txtBoxClientApi = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
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
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(469, 526);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(520, 484);
            this.tabPageSettings.TabIndex = 1;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // tabPageLogs
            // 
            this.tabPageLogs.Controls.Add(this.txtBoxLogs);
            this.tabPageLogs.Location = new System.Drawing.Point(4, 22);
            this.tabPageLogs.Name = "tabPageLogs";
            this.tabPageLogs.Size = new System.Drawing.Size(520, 484);
            this.tabPageLogs.TabIndex = 2;
            this.tabPageLogs.Text = "Logs";
            this.tabPageLogs.UseVisualStyleBackColor = true;
            // 
            // txtBoxLogs
            // 
            this.txtBoxLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxLogs.Location = new System.Drawing.Point(0, 0);
            this.txtBoxLogs.Multiline = true;
            this.txtBoxLogs.Name = "txtBoxLogs";
            this.txtBoxLogs.ReadOnly = true;
            this.txtBoxLogs.Size = new System.Drawing.Size(520, 484);
            this.txtBoxLogs.TabIndex = 0;
            // 
            // tabPageClientApi
            // 
            this.tabPageClientApi.Controls.Add(this.txtBoxClientApi);
            this.tabPageClientApi.Location = new System.Drawing.Point(4, 22);
            this.tabPageClientApi.Name = "tabPageClientApi";
            this.tabPageClientApi.Size = new System.Drawing.Size(461, 500);
            this.tabPageClientApi.TabIndex = 3;
            this.tabPageClientApi.Text = "Client API";
            this.tabPageClientApi.UseVisualStyleBackColor = true;
            // 
            // txtBoxClientApi
            // 
            this.txtBoxClientApi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxClientApi.Location = new System.Drawing.Point(0, 0);
            this.txtBoxClientApi.Multiline = true;
            this.txtBoxClientApi.Name = "txtBoxClientApi";
            this.txtBoxClientApi.ReadOnly = true;
            this.txtBoxClientApi.Size = new System.Drawing.Size(461, 500);
            this.txtBoxClientApi.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 526);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Valorant++";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
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
    }
}

