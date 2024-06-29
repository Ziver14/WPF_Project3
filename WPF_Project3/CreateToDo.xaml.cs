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
using WPF_Project3.src;

namespace WPF_Project3
{
    /// <summary>
    /// Логика взаимодействия для CreateToDo.xaml
    /// </summary>
    public partial class CreateToDo : Window
    {
        public CreateToDo()
        {
            InitializeComponent();
            titleToDo.Text = "Названия нет";
            descriptionToDo.Text = "Описания нет";
            dateToDo.SelectedDate = DateTime.Today.AddDays(1);
        }

        private void ButtonSaveToDo(object sender, RoutedEventArgs e)
        {
            MainWindow.toDoList.Add(
                new ToDo(
                    titleToDo.Text,
                    (DateTime)dateToDo.SelectedDate,
                    descriptionToDo.Text,
                    false
                    )
                );
            if (this.Owner.ToString() == "MainWindow") 
            {
                (this.Owner as MainWindow).listToDo.ItemsSource = null;
                (this.Owner as MainWindow).listToDo.ItemsSource = MainWindow.toDoList;
            }
            if (this.Owner.ToString() == "End_Window")
            {
                (this.Owner as End_Window).DataToDoList.ItemsSource = null;
                (this.Owner as End_Window).DataToDoList.ItemsSource = MainWindow.toDoList;
            }
            this.Close();
            End_Window end_Window = new End_Window();
            end_Window.Show();
            this.Owner.Close();
        }
    }
}
