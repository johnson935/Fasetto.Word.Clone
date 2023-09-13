using Fasetto.Word.ViewModel;
using Fasetto.Word.ViewModel.Base;
using System.Security;
using System.Windows;

namespace Fasetto.Word.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginViewModel>, IHavePassword
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public SecureString SecurePassword => PasswordText.SecurePassword;
    }
}
