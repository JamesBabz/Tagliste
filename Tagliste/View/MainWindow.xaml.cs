﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Tagliste.Model;
using Tagliste.View;
using Tagliste.ViewModel;

namespace Tagliste
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_OnAutoGeneratedColumns(object sender, EventArgs e)
        {
            var grid = (DataGrid)sender;
            foreach (var item in grid.Columns)
            {
                if (item.IsAutoGenerated) continue;
                item.DisplayIndex = grid.Columns.Count - 1;
            }
        }

        private void DeleteTag_OnClick(object sender, RoutedEventArgs e)
        {
            var tag = (Tag)((Button)sender).DataContext;
            if (MessageBox.Show( // Create and show the popup
                $"Are you sure you want to delete {tag.Name}?", // Text inside the popup
                "Delete confirmation", // Title of the popup
                MessageBoxButton.YesNo, // Available buttons
                MessageBoxImage.Exclamation) // Popup icon
                == MessageBoxResult.Yes) // Is yes clicked?
                ((MainWindowViewModel)DataContext).Tags.Remove(tag);
        }

        private void EditTag_OnClick(object sender, RoutedEventArgs e)
        {
            var tag = (Tag)((Button)sender).DataContext;
            ShowSingleTagWindow(tag);
        }

        private void CreateTag_OnClick(object sender, RoutedEventArgs e)
        {
            ShowSingleTagWindow(new Tag{Name = "New Tag"});
        }

        private static void ShowSingleTagWindow(Tag tag)
        {
            var singleTagWindow = new SingleTagWindow();
            var dataContext = new SingleTagWindowViewModel {CurrentTag = tag};
            singleTagWindow.DataContext = dataContext;
            singleTagWindow.Show();
        }

    }


}
