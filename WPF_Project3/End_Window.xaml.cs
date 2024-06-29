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
    /// Логика взаимодействия для End_Window.xaml
    /// </summary>
    public partial class End_Window : Window
    {
        public End_Window()
        {
            InitializeComponent();
            DataToDoList.ItemsSource = MainWindow.toDoList;
        }
        private void ButtonDeleteToDo(object sender, RoutedEventArgs e)
        {
            MainWindow.toDoList.Remove((ToDo)DataToDoList.SelectedItem);
            DataToDoList.ItemsSource = null;
            DataToDoList.ItemsSource = MainWindow.toDoList;
        }
        private void ButtonAddToDo(object sender, RoutedEventArgs e)
        {
            CreateToDo second_Window = new CreateToDo();
            second_Window.Show();
            second_Window.Owner = this;
        }
        private void CheckboxEnableToDo_Checked(object sender, RoutedEventArgs e)
        {
            if (DataToDoList.SelectedItem == null || AddToDo == null) return;
            MainWindow.toDoList[DataToDoList.SelectedIndex].Doing = true;
        }
        private void CheckboxEnableToDo_Unchecked(object sender, RoutedEventArgs e)
        {
            if (DataToDoList.SelectedItem == null || AddToDo == null) return;
            MainWindow.toDoList[DataToDoList.SelectedIndex].Doing = false;
        }
    }
}
