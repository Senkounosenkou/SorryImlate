using SorryImlate.Models;

namespace SorryImlate.Models
{
    /// <summary>
    /// 現在ログインしているユーザー情報をアプリケーション全体で保持するための静的クラスです。
    /// </summary>
    public static class UserSession
    {
        // ログイン中のユーザー情報を保持
        public static User CurrentUser { get; private set; }

        /// <summary>
        /// ユーザーをセッションにログインさせます。
        /// </summary>
        public static void Login(User user)
        {
            CurrentUser = user;
        }

        /// <summary>
        /// セッションをクリアしてログアウトします。
        /// </summary>
        public static void Logout()
        {
            CurrentUser = null;
        }

        /// <summary>
        /// ユーザーがログイン状態であるかを判定します。
        /// </summary>
        public static bool IsLoggedIn => CurrentUser != null;
    }
}