namespace cpg.Swiftness.Controls
{
    partial class ctrlPlugin
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.gb_plugin = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lbl_link = new System.Windows.Forms.LinkLabel();
            this.btn_endisable = new System.Windows.Forms.Button();
            this.btn_loadunload = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_author = new System.Windows.Forms.Label();
            this.lbl_desc = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_plugin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_plugin
            // 
            this.gb_plugin.Controls.Add(this.checkBox1);
            this.gb_plugin.Controls.Add(this.lbl_link);
            this.gb_plugin.Controls.Add(this.btn_endisable);
            this.gb_plugin.Controls.Add(this.btn_loadunload);
            this.gb_plugin.Controls.Add(this.pictureBox1);
            this.gb_plugin.Controls.Add(this.lbl_author);
            this.gb_plugin.Controls.Add(this.lbl_desc);
            this.gb_plugin.Controls.Add(this.label2);
            this.gb_plugin.Controls.Add(this.label1);
            this.gb_plugin.Location = new System.Drawing.Point(3, 0);
            this.gb_plugin.Name = "gb_plugin";
            this.gb_plugin.Size = new System.Drawing.Size(371, 92);
            this.gb_plugin.TabIndex = 10;
            this.gb_plugin.TabStop = false;
            this.gb_plugin.Text = "Plugin-Name";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(290, 38);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 17);
            this.checkBox1.TabIndex = 23;
            this.checkBox1.Text = "Auto-Load";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lbl_link
            // 
            this.lbl_link.AutoSize = true;
            this.lbl_link.Location = new System.Drawing.Point(301, 70);
            this.lbl_link.Name = "lbl_link";
            this.lbl_link.Size = new System.Drawing.Size(64, 13);
            this.lbl_link.TabIndex = 22;
            this.lbl_link.TabStop = true;
            this.lbl_link.Text = "Plugin-Page";
            this.lbl_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_link_LinkClicked);
            // 
            // btn_endisable
            // 
            this.btn_endisable.Location = new System.Drawing.Point(209, 11);
            this.btn_endisable.Name = "btn_endisable";
            this.btn_endisable.Size = new System.Drawing.Size(75, 23);
            this.btn_endisable.TabIndex = 20;
            this.btn_endisable.Text = "Enable";
            this.btn_endisable.UseVisualStyleBackColor = true;
            // 
            // btn_loadunload
            // 
            this.btn_loadunload.Location = new System.Drawing.Point(290, 11);
            this.btn_loadunload.Name = "btn_loadunload";
            this.btn_loadunload.Size = new System.Drawing.Size(75, 23);
            this.btn_loadunload.TabIndex = 21;
            this.btn_loadunload.Text = "Load";
            this.btn_loadunload.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_author
            // 
            this.lbl_author.AutoSize = true;
            this.lbl_author.Location = new System.Drawing.Point(117, 21);
            this.lbl_author.Name = "lbl_author";
            this.lbl_author.Size = new System.Drawing.Size(60, 13);
            this.lbl_author.TabIndex = 18;
            this.lbl_author.Text = "The-Author";
            // 
            // lbl_desc
            // 
            this.lbl_desc.Location = new System.Drawing.Point(86, 56);
            this.lbl_desc.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.lbl_desc.Name = "lbl_desc";
            this.lbl_desc.Size = new System.Drawing.Size(198, 31);
            this.lbl_desc.TabIndex = 16;
            this.lbl_desc.Text = "Some Plugin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Author:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Description:";
            // 
            // ctrlPlugin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_plugin);
            this.Name = "ctrlPlugin";
            this.Size = new System.Drawing.Size(377, 92);
            this.gb_plugin.ResumeLayout(false);
            this.gb_plugin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_plugin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_author;
        private System.Windows.Forms.Label lbl_desc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lbl_link;
        private System.Windows.Forms.Button btn_endisable;
        private System.Windows.Forms.Button btn_loadunload;
        private System.Windows.Forms.CheckBox checkBox1;

    }
}
