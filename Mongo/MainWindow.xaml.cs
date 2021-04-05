using System;
using System.Linq;
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

            DbConnector connector = new DbConnector();
            //connector.Insert(new EncryptedItem("Ahoj2", "key", "zprava"));
            var founded = connector.FindAll();
            foreach (var encryptedItem in founded)
            {
                tbTest.Text += encryptedItem.Text + "\n";
            }
        }
    }
}