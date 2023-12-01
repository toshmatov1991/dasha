using HumanResourcesDepartmentWPFApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
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

        // Заполнение таблицы
        private void StartTable()
        {
            using OkContext ok = new();

            dataGrid.ItemsSource = ok.Personals.ToList();


            //Заполнение Comboboxes
            AreaCombobox = [.. ok.Areas];
            JobCombobox = [.. ok.JobTitles];
            SubCombobox = [.. ok.SubDivisions];
        }


        //При закрытии открывается окно авторизации
        private void BaseClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //MainWindow mainWindow = new();
            //mainWindow.Show();
        }


        //Обновление записи
        private async void UpdateEntry(object sender, DataGridCellEditEndingEventArgs e)
        {
            Personal? a = e.Row.Item as Personal;

            using OkContext ok = new();

            if (a.Id != 0)
            {
                var upPer = await ok.Database.ExecuteSqlAsync($"UPDATE Personal SET family = {a.Family}, name = {a.Name}, lastname = {a.Lastname}, subDivision = {a.SubDivision}, jobTitle = {a.JobTitle}, adress = {a.Adress}, area = {a.Area}, inn = {a.Inn}, childrenCount = {a.ChildrenCount} WHERE id = {a.Id}");
                if (upPer == 0)
                    MessageBox.Show("Произошла ошибка при обновлении таблицы(Заявитель)\nПовторите попытку");
            }
        }

        private async void UpdateSub(object sender, EventArgs e)
        {
            if ((dataGrid.SelectedItem as Personal)?.Id == 0 || (dataGrid.SelectedItem as Personal)?.Id == null)
                return;
            else
            {
                try
                {
                    //Меняем подразделение Заявителю
                    using OkContext ok = new();

                    var GetId = await ok.SubDivisions.AsNoTracking().Where(u => u.NameDivisions == (sender as ComboBox).Text).FirstOrDefaultAsync();

                    if (GetId != null)
                        await ok.Database.ExecuteSqlRawAsync("UPDATE Personal SET subDivision = {0} WHERE Id = {1}", GetId.Id, (dataGrid.SelectedItem as Personal)?.Id);
                    else
                        MessageBox.Show("Произошла ошибка при обновлении данных");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка, повторите попытку", ex.Message);
                }
            }
        }

        private async void UpdateJob(object sender, EventArgs e)
        {
            if ((dataGrid.SelectedItem as Personal)?.Id == 0 || (dataGrid.SelectedItem as Personal)?.Id == null)
                return;
            else
            {
                try
                {
                    //Меняем подразделение Заявителю
                    using OkContext ok = new();

                    var GetId = await ok.JobTitles.AsNoTracking().Where(u => u.NameJobTitle == (sender as ComboBox).Text).FirstOrDefaultAsync();

                    if (GetId != null)
                        await ok.Database.ExecuteSqlRawAsync("UPDATE Personal SET jobTitle = {0} WHERE Id = {1}", GetId.Id, (dataGrid.SelectedItem as Personal)?.Id);
                    else
                        MessageBox.Show("Произошла ошибка при обновлении данных");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка, повторите попытку", ex.Message);
                }
            }
        }

        private async void UpdateArea(object sender, EventArgs e)
        {
            if ((dataGrid.SelectedItem as Personal)?.Id == 0 || (dataGrid.SelectedItem as Personal)?.Id == null)
                return;
            else
            {
                try
                {
                    //Меняем подразделение Заявителю
                    using OkContext ok = new();

                    var GetId = await ok.Areas.AsNoTracking().Where(u => u.NameArea == (sender as ComboBox).Text).FirstOrDefaultAsync();

                    if (GetId != null)
                        await ok.Database.ExecuteSqlRawAsync("UPDATE Personal SET area = {0} WHERE Id = {1}", GetId.Id, (dataGrid.SelectedItem as Personal)?.Id);
                    else
                        MessageBox.Show("Произошла ошибка при обновлении данных");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка, повторите попытку", ex.Message);
                }
            }
        }
    }
}
