﻿using System;
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
using Cinemas_Subbotin.Classes;

namespace Cinemas_Subbotin.Pages.Afisha
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        AfishaContext afisha;
        List<KInoteatrContext> AllKinoteatrs = KInoteatrContext.Select();
        public Add(AfishaContext afisha = null)
        {
            InitializeComponent();
            foreach (var item in AllKinoteatrs)
                kinoteatrs.Items.Add(item.Name);
            kinoteatrs.Items.Add("Выберите ...");
            if (afisha != null)
            {
                this.afisha = afisha;
                kinoteatrs.SelectedIndex = AllKinoteatrs.FindIndex(x => x.Id == afisha.IdKinoteatr);
                name.Text = afisha.Name;
                date.Text = afisha.Time.ToString("yyyy-MM-dd");
                time.Text = afisha.Time.ToString("HH:mm");
                price.Text = afisha.Price.ToString();
                btnAdd.Content = "Изменить";
            }
            else
            {
                kinoteatrs.SelectedIndex = kinoteatrs.Items.Count - 1;
            }
        }

        private void AddRecord(object sender, RoutedEventArgs e)
        {
            TimeSpan timeAfisha;
            DateTime dateAfisha;
            int Price = -1;
            if (name.Text == "")
            {
                MessageBox.Show("Необходимо указать наименование");
                return;
            }
            if (kinoteatrs.SelectedIndex == kinoteatrs.Items.Count - 1)
            {
                MessageBox.Show("Выберите кинотеатр");
                return;
            }
            if (date.Text == "")
            {
                MessageBox.Show("Необходимо указать дату");
                return;
            }
            if (time.Text == "" || TimeSpan.TryParse(time.Text, out timeAfisha) == false)
            {
                MessageBox.Show("Необходимо указать время");
                return;
            }
            if (price.Text == "" || int.TryParse(price.Text, out Price) == false)
            {
                MessageBox.Show("Необходимо указать стоимость");
                return;
            }
            DateTime.TryParse(date.Text, out dateAfisha);
            dateAfisha = dateAfisha.Add(timeAfisha);
            if (afisha == null)
            {
                AfishaContext newAfisha = new AfishaContext(
                0,
                    AllKinoteatrs.Find(x => x.Name == kinoteatrs.SelectedItem).Id,
                    name.Text,
                    dateAfisha,
                    Price);
                newAfisha.Add();
                MessageBox.Show("Запись добавлена");
            }
            else
            {
                afisha = new AfishaContext(
                afisha.Id,
                    AllKinoteatrs.Find(x => x.Name == kinoteatrs.SelectedItem).Id,
                    name.Text,
                    dateAfisha,
                    Price);
                afisha.Update();
                MessageBox.Show("Запись обновлена");
            }
            MainWindow.init.OpenPage(new Pages.Afisha.Main());
        }
    }
}
