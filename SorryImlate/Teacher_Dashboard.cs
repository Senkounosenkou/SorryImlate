using SorryImlate.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SorryImlate
{
    public partial class 教師ダッシュボード : Form
    {
        public 教師ダッシュボード()
        {
            InitializeComponent();
        }


        private void Form2_Load_1(object sender, EventArgs e)
        {
            if (UserSession.IsLoggedIn)
            {
                label1.Text = UserSession.CurrentUser.Name + " さん";
            }
        }
    }
}
