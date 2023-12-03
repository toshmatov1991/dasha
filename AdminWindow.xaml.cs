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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            StartAdminWindow();
        }


        private void StartAdminWindow()
        {
            using OkContext db = new();

            AreaX.ItemsSource = db.Areas.ToList();

            SubX.ItemsSource = db.SubDivisions.ToList();

            JobX.ItemsSource = db.JobTitles.ToList();


        }


        private void AdminClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
        }

        // Добавить Район
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using OkContext db = new();
            AreaX.CanUserAddRows = true;
            await db.Database.ExecuteSqlInterpolatedAsync($"INSERT INTO Area(AreaName) VALUES({a.AreaName})");
        }


        // Добавить подразделение
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using OkContext db = new();
            SubX.CanUserAddRows = true;
            
        }


        // Добавить должность и оклад
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using OkContext db = new();
            JobX.CanUserAddRows = true;

        }





        // Редактировать запись в таблице Районы
        private void AreaCell(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        // Редактировать записи в таблице Подразделение
        private void SubCell(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        // Редактировать записи в таблице Должности и оклады
        private void JobCell(object sender, DataGridCellEditEndingEventArgs e)
        {

        }
    }
}
