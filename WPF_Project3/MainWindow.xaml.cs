using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Project3.src;

namespace WPF_Project3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<ToDo> toDoList = new List<ToDo>();

        public MainWindow()
        {
            InitializeComponent();
            descriptionToDo.Text = "Описания нет";
            dateTodo.SelectedDate = DateTime.Today.AddDays(1);

            toDoList.Add(new ToDo("Родиться", new DateTime(2024, 01, 10), "Важно"));
            toDoList.Add(new ToDo("Посадить сына", new DateTime(2024, 01, 11), "Важно"));
            toDoList.Add(new ToDo("Построить дерево", new DateTime(2024, 01, 12), "Важно"));
            toDoList.Add(new ToDo("Вырастить дом", new DateTime(2024, 01, 13), "Важно"));
            toDoList.Add(new ToDo("Умереть", new DateTime(2024, 01, 14), "Важно"));
            RefreshToDoList();
            CheckboxEnableToDo_Unchecked(Owner, new RoutedEventArgs());
        }

        private void RefreshToDoList()
        {
            listToDo.ItemsSource = null;
            listToDo.ItemsSource = toDoList;
        }

        private void CheckboxEnableToDo_Checked(object sender, EventArgs e)
        {
            if(groupBoxToDo == null|| buttonAdd == null) return;
            groupBoxToDo.Visibility = Visibility.Visible;
            buttonAdd.Visibility = Visibility.Visible;
            CreateToDo createToDo = new CreateToDo();
            createToDo.Show();
            
            this.Close();
        }

        private void CheckboxEnableToDo_Unchecked(object sender, EventArgs e)
        {
            if (groupBoxToDo == null || buttonAdd == null) return;
            groupBoxToDo.Visibility = Visibility.Hidden;
            buttonAdd.Visibility = Visibility.Hidden;
        }

        private void ButtonRemoveToDo_Click(object sender, RoutedEventArgs e)
        {
            toDoList.Remove(listToDo.SelectedItem as ToDo);
            RefreshToDoList();
        }
        private void ButtonAddToDo_Click(object sender, RoutedEventArgs e)
        {
            if (!dateTodo.SelectedDate.HasValue)
            {
                MessageBox.Show("Дата повесилась", Name = "ошибка");
                return;
            }
            toDoList.Add(
                new ToDo(
                    titleToDo.Text,
                    (DateTime)dateTodo.SelectedDate,
                    descriptionToDo.Text
                    )
                );
            titleToDo.Text = null;
            descriptionToDo.Text = "Описания неи=т";
            RefreshToDoList() ;
        }


    }
}