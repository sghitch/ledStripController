using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ledStripController
{
    public partial class serialQuery : Form
    {
        public serialQuery()
        {
            InitializeComponent();
        }

        private void proceedButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
