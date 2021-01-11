using System;
using System.Collections.Generic;
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
    /// Interaction logic for Promo.xaml
    /// </summary>
    public partial class Promo : Window
    {
        PromoController promoController;
        OnPromoChangedListener promoListener;
        public Promo()
        {
            InitializeComponent();
            promoController = new PromoController();
            listBoxDaftarPromo.ItemsSource = promoController.getDiskon();

            generateContentPromo();
        }

        public void SetOnPromoSelectedListener(OnPromoChangedListener promoListener)
        {
            this.promoListener = promoListener;
        }

        private void generateContentPromo()
        {
            Diskon diskon1 = new Diskon("Promo Awal tahun\nDiskon 25 % ", 25000);
            Diskon diskon2 = new Diskon("Promo Tahun Baru\nDiskon 30 % atau maksimal 30.000", 30000);
            Diskon diskon3 = new Diskon("Promo Natal\nPotongan 10000", 10000);

            promoController.addPromo(diskon1);
            promoController.addPromo(diskon2);
            promoController.addPromo(diskon3);

            listBoxDaftarPromo.Items.Refresh();
        }

        public void onlistBoxDaftarPromoClicked(object sender, MouseButtonEventArgs e)
        {
            ListBox listbox = sender as ListBox;
            Diskon diskon = listbox.SelectedItem as Diskon;
            this.promoListener.OnPromoSelected(diskon);
        }
    }
    public interface OnPromoChangedListener
    {
        void OnPromoSelected(Diskon diskon);
    }
}