using System.Windows.Forms;

namespace Swiftness.Forms
{
    public class MDIChild : Form
    {
        private bool _nohide = false;
        
        #region Constructor
        public MDIChild() { }

        public MDIChild(Form parent)
        {
            _ctor(parent);
        }

        public MDIChild(Form parent, bool nohide)
        {
            _nohide = nohide;
            _ctor(parent);
        }

        private void _ctor(Form parent)
        {
            this.MdiParent = parent;
            InitializeComponent();
        }
        #endregion

        #region Properties
        public bool NoHide
        {
            get { return _nohide; }
            set { _nohide = value; }
        }
        #endregion

        #region Privates
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDIChild_FormClosing);
            this.ResumeLayout(false);
        }

        private void MDIChild_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.MdiFormClosing)
            {
                e.Cancel = true;
                if (!_nohide)
                    this.Hide();
            }

            System.Console.WriteLine("MdiChild {3} close-request:\r\n\tReason: {0}\r\n\tSender: {1}\r\n\tAction: {2}",
                e.CloseReason.ToString(),
                sender.GetType().ToString(),
                (e.Cancel) ? (!_nohide) ? "Hidden" : "Nothing (NoHide)" : "Closed",
                this.Name);

        }
        #endregion
    }
}
