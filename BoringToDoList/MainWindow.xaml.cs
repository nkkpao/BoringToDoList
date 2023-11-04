using BoringToDoList.DataModels;
using BoringToDoList.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace BoringToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BindingList<ToDoModel> _toDoModels;
        private SaveLoadTool _saveLoadTool;
        private readonly string SLPath = $"{Environment.CurrentDirectory}\\savedList.json";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _toDoModels = new BindingList<ToDoModel>();
            _saveLoadTool = new SaveLoadTool(SLPath);
            try
            {
                _toDoModels = _saveLoadTool.LoadDG();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                Close();
            }
            dgToDoTable.ItemsSource = _toDoModels;
            _toDoModels.ListChanged += _toDoModels_ListChanged;
        }

        private void _toDoModels_ListChanged(object? sender, ListChangedEventArgs e)
        {
            if(e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _saveLoadTool.SaveDG((BindingList<ToDoModel>)sender);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }
    }
}