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
        private DbConnector connector;
        
        public MainWindow()
        {
            InitializeComponent();
            connector = new DbConnector();
        }

        private void BtnCreate_OnClick(object sender, RoutedEventArgs e)
        {
            Create createWindow = new Create(connector);
            createWindow.ShowDialog();
        }

        private void BtnGet_OnClick(object sender, RoutedEventArgs e)
        {
            Get getWindow = new Get(connector);
            getWindow.ShowDialog();
        }
    }
}