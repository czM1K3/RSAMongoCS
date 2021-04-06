using System;
using System.Linq;
using System.Windows;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Mongo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCreate_OnClick(object sender, RoutedEventArgs e)
        {
            Create createWindow = new Create();
            createWindow.ShowDialog();
        }

        private void BtnGet_OnClick(object sender, RoutedEventArgs e)
        {
            Get getWindow = new Get();
            getWindow.ShowDialog();
        }
    }
}