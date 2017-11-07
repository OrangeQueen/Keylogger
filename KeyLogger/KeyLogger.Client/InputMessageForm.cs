using System;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace KeyLogger.Client
{
    public partial class InputMessageForm : MetroForm
    {
        public InputMessageForm()
        {
            InitializeComponent();
        }

        private void metroButton_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void metroButton_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}