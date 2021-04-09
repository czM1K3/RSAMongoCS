using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Mongo
{
    public partial class Get : Window
    {
        public Get()
        {
            InitializeComponent();
        }

        private void SwScroll_OnLoaded(object sender, RoutedEventArgs e)
        {
            updateData();
        }

        public void updateData()
        {
            DbConnector connector = new DbConnector();
            var list = connector.FindAll();
            var grid = new Grid();
            grid.Margin = new Thickness(5);
            for (int i = 0; i < list.Count; i++)
            {
                grid.Children.Add(new Item(list[i], this)
                {
                    Margin = new Thickness(10, i * 30, 0, 0),
                    VerticalAlignment = VerticalAlignment.Top,
                });
            }
            swScroll.Content = grid;
        }
    }
}