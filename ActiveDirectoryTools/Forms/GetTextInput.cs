using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ActiveDirectoryTools.Forms
{
    public partial class GetTextInput : Form
    {
        public GetTextInput()
        {
            InitializeComponent();
        }
        public GetTextInput(string instructions)
        {
            InitializeComponent();
            textInputLabel.Text = instructions;
        }

        private void textInputButton_Click(object sender, EventArgs e)
        {
            MainWindow.TextInputResult = textInputBox.Text;
            this.Close();
        }

    }
}
