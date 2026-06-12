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
using SorryImlate.Utilities;

namespace SorryImlate
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ログインボタン押下時の処理
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string inputCode = txtUserCode.Text.Trim();
            string inputPassword = txtPassword.Text.Trim();

            // 未入力バリデーション
            if (string.IsNullOrEmpty(inputCode) || string.IsNullOrEmpty(inputPassword))
            {
                MessageBox.Show("学籍番号/教職員番号とパスワードを入力してください。", "入力チェック", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // パスワードのハッシュ化
                string hashedInput = PasswordHasher.HashPassword(inputPassword);

                // ユーザー情報の取得
                Repositories.UserRepository repo = new Repositories.UserRepository();
                Models.User user = repo.GetUserByCode(inputCode);

                // ==========================================
                // 【デバッグ用】情報をすべて画面に表示する
                // ==========================================
                string debugInfo = $"【入力情報】\n" +
                                   $"入力ID: [{inputCode}]\n" +
                                   $"入力パスワード: [{inputPassword}]\n" +
                                   $"入力ハッシュ: \n[{hashedInput}]\n\n" +
                                   $"【DB情報】\n";

                if (user != null)
                {
                    debugInfo += $"検索結果: [見つかりました！]\n" +
                                 $"DB側ハッシュ: \n[{user.Password}]";
                }
                else
                {
                    debugInfo += $"検索結果: [ユーザーが見つかりませんでした (null)]";
                }

                // ログをポップアップで表示
                MessageBox.Show(debugInfo, "デバッグログ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // ==========================================


                if (user != null && user.Password == hashedInput)
                {
                    // ログイン成功！セッションにユーザー情報を保持
                    Models.UserSession.Login(user);

                    // ==========================================
                    // ロール（権限）に応じて遷移先の画面を振り分ける
                    // ==========================================
                    if (user.Role == "student")
                    {
                        // 生徒なら Form1（生徒用ダッシュボード）へ
                        生徒ダッシュボード studentForm = new 生徒ダッシュボード();
                        studentForm.Show();
                    }
                    else if (user.Role == "teacher")
                    {
                        // 教員なら Form2（教員用画面）へ
                        教師ダッシュボード teacherForm = new 教師ダッシュボード();
                        teacherForm.Show();
                    }

                    this.Hide(); // ログイン画面を隠す
                }
                else
                {
                    MessageBox.Show("学籍番号またはパスワードが違います。", "認証失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("データベース接続に失敗しました。\n" + ex.Message, "接続エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}