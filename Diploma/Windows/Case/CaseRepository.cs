using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Diploma.DataContext;
using Diploma.ClientCore;
using Diploma.Utils;

namespace Diploma.Windows.Case
{
    public class CaseRepository
    {
        public DataContext.Case SelectedCase = new DataContext.Case();
        public List<DataContext.Case> FillCaseList()
        {
            //TODO: Find a solution to optimize Relationships in Database

            using DiplomaDataContext db = new DiplomaDataContext();
            if (Core.CaseList.Count > 0) return Core.CaseList;
            foreach (var cases in db.Cases)
            {
                Core.CaseList.Add(cases);
            }

            return Core.CaseList;
        }
        
        public void FillCaseViewList(CaseListWindow caseListWindow)
        {
            caseListWindow.ListViewDataBinding.ItemsSource = FillCaseList();
        }

        public void FillCurrentCase(CaseWindow caseWindow)
        {
            using DiplomaDataContext db = new DiplomaDataContext();
            
         // DataContext.Profile casePublisher = Core.ProfileList.FirstOrDefault(p => p.ID == SelectedCase.Profile.ID);
            
            caseWindow.NumberLabel.Content = SelectedCase.CaseNumber;
            //caseWindow.PublisherLabel.Content = $"{casePublisher.Surname} {casePublisher.Firstname[0]}.{casePublisher.Secondname[0]}";
            caseWindow.PubDateLabel.Content = SelectedCase.PublishedDate;

            caseWindow.FirstnameTextBox.Text = SelectedCase.Firstname;
            caseWindow.SurnameTextBox.Text = SelectedCase.Surname;
            caseWindow.SecondnameTextBox.Text = SelectedCase.Secondname;
            caseWindow.NicknameTextBox.Text = SelectedCase.Nickname;
            caseWindow.DateBirthTextBox.Text = SelectedCase.DateBirth;
            caseWindow.PlaceBirthTextBox.Text = SelectedCase.PlaceBirth;
            caseWindow.CitizenshipTextBox.Text = SelectedCase.Citizenship;
        //    caseWindow.NationalityTextBox.Text = SelectedCase.Nationality;
          //  caseWindow.GenderTextBox.Text = SelectedCase.Gender;
            caseWindow.HeightTextBox.Text = SelectedCase.Height;
            caseWindow.ConvictionTextBlock.Text = SelectedCase.Conviction;
            //caseWindow.ExtremistOrgTextBox.Text = SelectExtremistOrg(SelectedCase);
            caseWindow.OCGMemberTextBox.Text = SelectedCase.OCGMember;
            caseWindow.LivingPlaceTextBox.Text = SelectedCase.LivingPlace;
            //caseWindow.FamilyCompositionTextBox.Text = SelectedCase.FamilyComposition;
            caseWindow.HumanFormTextBox.Text = SelectedCase.HumanForm;
            caseWindow.DescriptionTextBlock.Text = SelectedCase.Description;
            caseWindow.ContactsTextBlock.Text = SelectedCase.Contacts;
            caseWindow.SocialNetworkTextBlock.Text = SelectedCase.SocialNetwork;
            caseWindow.NoteTextBlock.Text = SelectedCase.Note;
        }

        public bool EnableCaseEditMode(CaseWindow caseWindow, bool isCaseEditModeEnabled)
        {
            isCaseEditModeEnabled = !isCaseEditModeEnabled;

            caseWindow.FirstnameTextBox.IsEnabled = isCaseEditModeEnabled;
            caseWindow.SurnameTextBox.IsEnabled = isCaseEditModeEnabled;
            caseWindow.SecondnameTextBox.IsEnabled = isCaseEditModeEnabled;
            caseWindow.NicknameTextBox.IsEnabled = isCaseEditModeEnabled;
            caseWindow.DateBirthTextBox.IsEnabled = isCaseEditModeEnabled;
            caseWindow.PlaceBirthTextBox.IsEnabled = isCaseEditModeEnabled;
            caseWindow.CitizenshipTextBox.IsEnabled = isCaseEditModeEnabled;
          //  caseWindow.NationalityTextBox.IsEnabled = isCaseEditModeEnabled;
        //    caseWindow.GenderTextBox.IsEnabled = isCaseEditModeEnabled;
            caseWindow.HeightTextBox.IsEnabled = isCaseEditModeEnabled;
            caseWindow.ConvictionTextBlock.IsEnabled = isCaseEditModeEnabled;
        //    caseWindow.ExtremistOrgTextBox.IsEnabled = isCaseEditModeEnabled;
            caseWindow.OCGMemberTextBox.IsEnabled = isCaseEditModeEnabled;
            caseWindow.LivingPlaceTextBox.IsEnabled = isCaseEditModeEnabled;
       //     caseWindow.FamilyCompositionTextBox.IsEnabled = isCaseEditModeEnabled;
            caseWindow.HumanFormTextBox.IsEnabled = isCaseEditModeEnabled;
            caseWindow.DescriptionTextBlock.IsEnabled = isCaseEditModeEnabled;
            caseWindow.ContactsTextBlock.IsEnabled = isCaseEditModeEnabled;
            caseWindow.SocialNetworkTextBlock.IsEnabled = isCaseEditModeEnabled;
            caseWindow.NoteTextBlock.IsEnabled = isCaseEditModeEnabled;
            caseWindow.CaseEditMode.Content = "Закончить редактирование";

            if (!isCaseEditModeEnabled)
            {
                SaveCaseInformation(caseWindow);
                caseWindow.CaseEditMode.Content = "Редактировать досье";
            }

            return isCaseEditModeEnabled;
        }

        public void SaveCaseInformation(CaseWindow caseWindow)
        {
            using DiplomaDataContext db = new DiplomaDataContext();
            CaseListWindow caseListwindow = new CaseListWindow();
            SelectedCase.Fullname = $"{caseWindow.FirstnameTextBox.Text} {caseWindow.SecondnameTextBox.Text} {caseWindow.SecondnameTextBox.Text}";
            SelectedCase.Firstname = caseWindow.FirstnameTextBox.Text;
            SelectedCase.Surname = caseWindow.SurnameTextBox.Text;
            SelectedCase.Secondname = caseWindow.SecondnameTextBox.Text;
            SelectedCase.Nickname = caseWindow.NicknameTextBox.Text;
            SelectedCase.DateBirth = caseWindow.DateBirthTextBox.Text;
            SelectedCase.PlaceBirth = caseWindow.PlaceBirthTextBox.Text;
            SelectedCase.Citizenship = caseWindow.CitizenshipTextBox.Text;
          //  SelectedCase.Nationality = caseWindow.NationalityTextBox.Text;
          //  SelectedCase.Gender = caseWindow.GenderTextBox.Text;
            SelectedCase.Height = caseWindow.HeightTextBox.Text;
            SelectedCase.Conviction = caseWindow.ConvictionTextBlock.Text;
           // SelectedCase.ExtremistOrgID = Convert.ToInt32(caseWindow.ExtremistOrgTextBox.Text);
            SelectedCase.OCGMember = caseWindow.OCGMemberTextBox.Text;
            SelectedCase.LivingPlace = caseWindow.LivingPlaceTextBox.Text;
          //  SelectedCase.FamilyComposition = caseWindow.FamilyCompositionTextBox.Text;
            SelectedCase.HumanForm = caseWindow.HumanFormTextBox.Text;
            SelectedCase.Description = caseWindow.DescriptionTextBlock.Text;
            SelectedCase.Contacts = caseWindow.ContactsTextBlock.Text;
            SelectedCase.SocialNetwork = caseWindow.SocialNetworkTextBlock.Text;
            SelectedCase.Note = caseWindow.NoteTextBlock.Text;

            db.Cases.Update(SelectedCase);
            db.SaveChanges();
            Core.CaseList[Core.CaseList.FindIndex(c => c.ID == SelectedCase.ID)] = SelectedCase;
            FillCaseViewList(caseListwindow);
        }
        public void SelectCase()
        {
            using DiplomaDataContext db = new DiplomaDataContext();
            SelectedCase = db.Cases.Find(Core.Main.CaseID);
        }
        public string SelectExtremistOrg(DataContext.Case currentCase)
        {
            return Core.ExtremistOrgs.FirstOrDefault(e => e.ID == currentCase.ExtremistOrgID).Name;
        }
        public string SelectNationality(DataContext.Case currentCase)
        {
            return Core.NationalityList.FirstOrDefault(n => n.ID == currentCase.NationalityID).Name;
        }

        public List<DataContext.Case> CaseSearchResult(CaseListWindow caseListWindow, string searhText, string searchType )
        {
            List<DataContext.Case> filteredCaseList = new List<DataContext.Case>();
            switch(searchType)
            {
                case Structure.SearchType.Organization:
                    filteredCaseList = (from currentCase in Core.CaseList
                                            where SelectExtremistOrg(currentCase).ToLower().Contains(searhText.ToLower())
                                            select currentCase).ToList();
                    break;
                case Structure.SearchType.Nationality:
                    filteredCaseList = (from currentCase in Core.CaseList
                                            where SelectNationality(currentCase).ToLower().Contains(searhText.ToLower())
                                            select currentCase).ToList();
                    break;
                case Structure.SearchType.FIO:
                    filteredCaseList = (from currentCase in Core.CaseList
                                            where currentCase.Fullname.ToLower().Contains(searhText.ToLower())
                                            select currentCase).ToList();
                    break;
                case Structure.SearchType.Citizenship:
                    filteredCaseList = (from currentCase in Core.CaseList
                                            where currentCase.Citizenship.ToLower().Contains(searhText.ToLower())
                                            select currentCase).ToList();
                    break;
            }
            return filteredCaseList;
        }
    }
}