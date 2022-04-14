using Diploma.Windows.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Diploma.DataContext;
using Diploma.Windows.Auth;
using Diploma.ClientCore;
using Diploma.Utils;

namespace Diploma
{
    /// <summary>
    /// Interaction logic for AuthWindows.xaml
    /// </summary>
    public partial class AuthWindows : Window
    {
        private AuthRepository AuthRepository = new AuthRepository();
        private ProfileRepository ProfileRepository = new ProfileRepository();

        private int FailCounter = 0;
        public AuthWindows()
        {
            InitializeComponent();
        }
        
        private void AuthBtn_Click(object sender, RoutedEventArgs e)
        {
            int authResult = AuthRepository.Auth(LoginTextBox.Text, PasswordTextBox.Password.ToString());

            if(FailCounter > 3)
            {
                using DiplomaDataContext db = new DiplomaDataContext();
                DataContext.Profile profile = db.Profiles.FirstOrDefault(p => p.Login == LoginTextBox.Text);
                ProfileRepository.BanProfile(profile);
                authResult = Structure.AuthEventError.PROFILE_BLOCKED;
            }
            switch(authResult)
            {
                case Structure.AuthEventError.PROFILE_WRONG_AUTH:
                    AuthInfoLabel.Content = "Неправильные данные";
                    FailCounter++;
                    return;
                case Structure.AuthEventError.PROFILE_BLOCKED:
                    AuthInfoLabel.Content = "Профиль заблокирован";
                    return;
                case Structure.AuthEventError.PROFILE_SID_ERROR:
                    AuthInfoLabel.Content = "Пользователь привязан к другому ПК";
                    return;
                case Structure.AuthEventError.PROFILE_MANY_ATTEMPTS:
                    AuthInfoLabel.Content = "Слишком много попыток входа";
                    return;
                case Structure.AuthEventError.PROFILE_SUCCESS:
                    AuthInfoLabel.Content = "";
                    Core.Main.Login = LoginTextBox.Text;
                    Core.Main.Password = PasswordTextBox.Password.ToString();
                    ProfileWindow profile = new ProfileWindow();
                    profile.Show();
                    return;
            }
        }
    }
}