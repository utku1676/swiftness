using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cpg.Swiftness.Forms
{
    [Serializable]
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
            menuStrip1.MdiWindowListItem = windowsToolStripMenuItem;

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            new frmPluginManager(this);
            new frmLog(this).Show(); ;

            Log.Write("test");
        }

        private void pluginManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowChild(typeof(frmPluginManager));
        }

        private void ShowChild(Type tchild)
        {
            foreach (Form child in MdiChildren)
            {
                if (child.GetType() == tchild)
                {
                    child.Show();
                    return;
                }
            }
        }

        #region Private Form-Things
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            //// Ask for exit
            //DialogResult res = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo);

            //// If not yes, cancel exit
            //if (res != DialogResult.Yes)
            //    e.Cancel = true;
        }
        #endregion
    }
}
