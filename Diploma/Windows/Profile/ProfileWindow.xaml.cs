using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Diploma.Windows.Case;
using Diploma.DataContext;
using Diploma.ClientCore;

namespace Diploma.Windows.Profile
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class ProfileWindow: Window
    {
        ProfileRepository ProfileRepository = new ProfileRepository();
        public ProfileWindow()
        {
            InitializeComponent();
            ProfileRepository.FillProfileWindowLables(this);
            Core.LoadExtremistOrgs();
        }
        private void ProfileCaseBtn_Click(object sender, RoutedEventArgs e)
        {
            CaseListWindow caseListWindow = new CaseListWindow();
            caseListWindow.Show();
        }

        private void ProfileEditBtn_Click(object sender, RoutedEventArgs e)
        {
            Core.Main.IsProfileEditModeEnabled = ProfileRepository.EnableProfileEditMode(this, Core.Main.IsProfileEditModeEnabled);
        }
    }
}