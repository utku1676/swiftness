﻿namespace Swiftness.Forms
{
    partial class frmPluginManager
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flp_plugincontainer = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_UpdatePluginList = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flp_plugincontainer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(507, 396);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // flp_plugincontainer
            // 
            this.flp_plugincontainer.AutoScroll = true;
            this.flp_plugincontainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flp_plugincontainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_plugincontainer.Location = new System.Drawing.Point(3, 3);
            this.flp_plugincontainer.Name = "flp_plugincontainer";
            this.flp_plugincontainer.Size = new System.Drawing.Size(501, 355);
            this.flp_plugincontainer.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_UpdatePluginList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 364);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 29);
            this.panel1.TabIndex = 2;
            // 
            // btn_UpdatePluginList
            // 
            this.btn_UpdatePluginList.Location = new System.Drawing.Point(3, 3);
            this.btn_UpdatePluginList.Name = "btn_UpdatePluginList";
            this.btn_UpdatePluginList.Size = new System.Drawing.Size(118, 23);
            this.btn_UpdatePluginList.TabIndex = 0;
            this.btn_UpdatePluginList.Text = "Rescan for Plugins";
            this.btn_UpdatePluginList.UseVisualStyleBackColor = true;
            this.btn_UpdatePluginList.Click += new System.EventHandler(this.btn_UpdatePluginList_Click);
            // 
            // frmPluginManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 396);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmPluginManager";
            this.Text = "Plugin-Manager";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flp_plugincontainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_UpdatePluginList;

    }
}