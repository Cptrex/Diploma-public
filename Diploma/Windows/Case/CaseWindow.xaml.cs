using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Diploma.ClientCore;
namespace Diploma.Windows.Case
{
    /// <summary>
    /// Логика взаимодействия для CaseWindow.xaml
    /// </summary>
    public partial class CaseWindow : Window
    {
        CaseRepository CaseRepository = new CaseRepository();
        public CaseWindow()
        {
            InitializeComponent();
            CaseRepository.SelectCase();
           
            CaseRepository.FillCurrentCase(this);
        }

        private void CaseEditMode_Click(object sender, RoutedEventArgs e)
        {
            Core.Main.IsCaseEditModeEnabled = CaseRepository.EnableCaseEditMode(this, Core.Main.IsCaseEditModeEnabled);
        }
    }
}