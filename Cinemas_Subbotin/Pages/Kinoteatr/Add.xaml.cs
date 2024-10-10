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
using Cinemas_Subbotin.Models;
using MySql.Data.MySqlClient;
using Cinemas_Subbotin.Classes.Common;
using Cinemas_Subbotin.Classes;

namespace Cinemas_Subbotin.Pages.Kinoteatr
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        KInoteatrContext kinoteatr;
        public Add(KInoteatrContext kinoteatr = null)
        {
            InitializeComponent();

            if (kinoteatr != null)
            {
                this.kinoteatr = kinoteatr;
                name.Text = kinoteatr.Name;
                countZal.Text = kinoteatr.CountZal.ToString();
                count.Text = kinoteatr.Count.ToString();
                btnAdd.Content = "Изменить";
            }
        }

        private void AddRecord(object sender, RoutedEventArgs e)
        {
            int countZalInt = -1;
            int countInt = -1;
            if (name.Text == "")
            {
                MessageBox.Show("Необходимо указать наименование");
                return;
            }
            if (countZal.Text == "" || int.TryParse(countZal.Text, out countZalInt) == false)
            {
                MessageBox.Show("Необходимо указать кол-во залов");
                return;
            }
            if (count.Text == "" || int.TryParse(count.Text, out countInt) == false)
            {
                MessageBox.Show("Необходимо указать количество мест");
                return;
            }
            if (this.kinoteatr == null)
            {
                KInoteatrContext newKinoteatr = new KInoteatrContext(
                    0,
                    name.Text,
                    countZalInt,
                    countInt);
                newKinoteatr.Add();
                MessageBox.Show("Запись добавлена");
            }
            else
            {
                kinoteatr = new KInoteatrContext(
                    kinoteatr.Id,
                    name.Text,
                    countZalInt,
                    countInt);
                kinoteatr.Update();
                MessageBox.Show("Запись обновлена");
            }
            MainWindow.init.OpenPage(new Pages.Kinoteatr.Main());
        }
    }
}
