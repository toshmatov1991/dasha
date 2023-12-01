using HumanResourcesDepartmentWPFApp.Models;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;

namespace HumanResourcesDepartmentWPFApp
{
    /// <summary>
    /// Логика взаимодействия для BaseWindow.xaml
    /// </summary>
    public partial class BaseWindow : Window
    {

        public static List<Area>? AreaCombobox { get; set; }
        public static List<JobTitle>? JobCombobox { get; set; }
        public static List<SubDivision>? SubCombobox { get; set; }


        public BaseWindow()
        {
            InitializeComponent();
            StartTable();
        }


        private void StartTable()
        {
            using OkContext ok = new();

            dataGrid.ItemsSource =  ok.Personals.ToList();


            //Заполнение Comboboxes
            AreaCombobox =  [.. ok.Areas];
            JobCombobox = [.. ok.JobTitles];
            SubCombobox = [.. ok.SubDivisions];
        }



        private void BaseClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //MainWindow mainWindow = new();
            //mainWindow.Show();
        }
    }
}
