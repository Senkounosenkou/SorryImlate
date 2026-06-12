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
    public partial class 生徒ダッシュボード : Form
    {
        public 生徒ダッシュボード()
        {
            InitializeComponent();
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // ログイン中のユーザー情報を表示
            // デザイナーで作成したラベルの名前を「lblUserName」と仮定しています
            if (UserSession.IsLoggedIn)
            {
                label1.Text = UserSession.CurrentUser.Name + " さん";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            生徒ダッシュボード studentForm = new 生徒ダッシュボード();
            studentForm.Show();
        }
    }
}
