using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NgelakShop.Controller;
using NgelakShop.Model;

namespace NgelakShop
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        MenuController menuController;
        OnMenuChangedListener listener;
        public Menu()
        {

            InitializeComponent();
            menuController = new MenuController();
            listMenu.ItemsSource = menuController.getItems();

            generateContentMenu();
        }

        public void SetOnItemSelectedListener(OnMenuChangedListener listener)
        {
            this.listener = listener;
        }
        private void listMenuOnDoubleClicked(object sender, MouseButtonEventArgs e)
        {
            ListBox listbox = sender as ListBox;
            Item item = listbox.SelectedItem as Item;
            this.listener.OnMenuSelected(item);


        }

        private void generateContentMenu()
        {
            Item Menu1 = new Item("Green Tea", 20000);
            Item Menu2 = new Item("Original Tea", 20000);
            Item Menu3 = new Item("Taro", 25000);
            Item Menu4 = new Item("Manggo Yakult", 15000);
            Item Menu5 = new Item("Leci Yakult", 15000);
            Item Menu6 = new Item("Vanila Latte", 30000);
            Item Menu7 = new Item("Coffe Latte", 30000);

            menuController.addItem(Menu1);
            menuController.addItem(Menu2);
            menuController.addItem(Menu3);
            menuController.addItem(Menu4);
            menuController.addItem(Menu5);
            menuController.addItem(Menu6);
            menuController.addItem(Menu7);

            listMenu.Items.Refresh();

        }

    }
    public interface OnMenuChangedListener
    {
        void OnMenuSelected(Item item);
    }
}