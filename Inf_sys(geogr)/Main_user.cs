using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inf_sys_geogr_
{
    public partial class Main_user : Form
    {
        Form1 Form1;
        public Main_user(Form1 form1)
        {
            InitializeComponent();
            this.Form1 = form1;
        }
    }
}
