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
using Diploma.ClientCore;
using Diploma.DataContext;

namespace Diploma.Windows.Case
{
    /// <summary>
    /// Логика взаимодействия для CaseListWindow.xaml
    /// </summary>
    public partial class CaseListWindow : Window
    {
        CaseRepository CaseRepository = new CaseRepository();
        public CaseListWindow()
        {
            InitializeComponent();
            CaseRepository.FillCaseViewList(this);
        }
        public void ListViewItemLeftMouseClick(object sender, MouseButtonEventArgs e)
        {
            DataContext.Case selectedCase = (DataContext.Case)ListViewDataBinding.SelectedItem;
            Core.Main.CaseID = selectedCase.ID;
            CaseWindow caseWindow = new CaseWindow();
            caseWindow.Show();
        }

        private void CaseListSearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchTypeComboBox.Text)) return;
            ListViewDataBinding.ItemsSource = CaseRepository.CaseSearchResult(this, SearchCaseTextBox.Text, SearchTypeComboBox.Text);
        }
    }
}