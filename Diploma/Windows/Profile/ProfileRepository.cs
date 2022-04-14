using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Diploma.DataContext;
using System.Security.Cryptography;
using Diploma.Windows.Profile;
using Diploma.ClientCore;

namespace Diploma.Windows.Profile
{
    public class ProfileRepository
    {
        DataContext.Profile Profile = new DataContext.Profile();
        public void FillProfileWindowLables(ProfileWindow profileWindow)
        {
            // TODO: ADD to Render Profile Image
            using DiplomaDataContext db = new DiplomaDataContext();
            Profile = db.Profiles.FirstOrDefault(p => p.Login == Core.Main.Login);
            if (Profile == null)
            {
                profileWindow.ProfileNameTextBox.Text = "";
                profileWindow.ProfileSurnameTextBox.Text = "";
                profileWindow.ProfileLastnameTextBox.Text = "";
               // profileWindow.ProfilePositionTextBox.Text = "";
               // profileWindow.ProfileRankTextBox.Text = "";
                profileWindow.ProfilePrivateNumberTextBox.Text = "";
            }
            else
            {
                profileWindow.ProfileNameTextBox.Text = Profile.Firstname;
                profileWindow.ProfileSurnameTextBox.Text = Profile.Surname;
                profileWindow.ProfileLastnameTextBox.Text = Profile.Secondname;
             //   profileWindow.ProfilePositionTextBox.Text = Profile.Position;
              //  profileWindow.ProfileRankTextBox.Text = Profile.Rank;
                profileWindow.ProfilePrivateNumberTextBox.Text = Profile.PrivateNumber;
            }
        }

        public bool EnableProfileEditMode(ProfileWindow profileWindow, bool isProfileEditModeEnabled)
        {
            isProfileEditModeEnabled = !isProfileEditModeEnabled;

            profileWindow.ProfileNameTextBox.IsEnabled = isProfileEditModeEnabled;
            profileWindow.ProfileSurnameTextBox.IsEnabled = isProfileEditModeEnabled;
            profileWindow.ProfileLastnameTextBox.IsEnabled = isProfileEditModeEnabled;
           // profileWindow.ProfilePositionTextBox.IsEnabled = isProfileEditModeEnabled;
           // profileWindow.ProfileRankTextBox.IsEnabled = isProfileEditModeEnabled;
            profileWindow.ProfilePrivateNumberTextBox.IsEnabled = isProfileEditModeEnabled;
            profileWindow.ProfileEditBtn.Content = "Закончить редактирование";

            if (!isProfileEditModeEnabled)
            {
                SaveProfileInformation(profileWindow);
                profileWindow.ProfileEditBtn.Content = "Редактировать профиль";
            }

            return isProfileEditModeEnabled;
        }

        public void SaveProfileInformation(ProfileWindow profileWindow)
        {
            using DiplomaDataContext db = new DiplomaDataContext();
            
            Profile.Firstname = profileWindow.ProfileNameTextBox.Text;
            Profile.Surname = profileWindow.ProfileSurnameTextBox.Text;
            Profile.Secondname = profileWindow.ProfileLastnameTextBox.Text;
          //  Profile.Position = profileWindow.ProfilePositionTextBox.Text;
            //Profile.Rank = profileWindow.ProfileRankTextBox.Text;
            Profile.PrivateNumber = profileWindow.ProfilePrivateNumberTextBox.Text;

            db.Profiles.Update(Profile);
            db.SaveChanges();
        }

        public void FillProfileAddedCases(ProfileWindow profileWindow)
        {

        }

        public void BanProfile(DataContext.Profile profile)
        {
            using DiplomaDataContext db = new DiplomaDataContext();
            profile.Blocked = true;
            db.Profiles.Update(profile);
            db.SaveChanges();

        }
    }
}