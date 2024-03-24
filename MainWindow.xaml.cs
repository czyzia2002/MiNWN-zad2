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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MiNWN_zad2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int cenaValue;
        private int platnoscValue;
        private int dostawaValue;
        public MainWindow()
        {
            InitializeComponent();
            InitializeEventHandlers();
        }

        private void InitializeEventHandlers()
        {
            // Grupa dla pierwszego GroupBox
            if (boxCena.Content is StackPanel cenaStackPanel)
            {
                foreach (RadioButton radioButton in cenaStackPanel.Children)
                {
                    radioButton.Checked += RadioButton_Checked;
                }
            }

            // Grupa dla drugiego GroupBox
            if (boxPlatnosc.Content is StackPanel platnoscStackPanel)
            {
                foreach (RadioButton radioButton in platnoscStackPanel.Children)
                {
                    radioButton.Checked += RadioButton_Checked;
                }
            }

            // Grupa dla trzeciego GroupBox
            if (boxDostawa.Content is StackPanel dostawaStackPanel)
            {
                foreach (RadioButton radioButton in dostawaStackPanel.Children)
                {
                    radioButton.Checked += RadioButton_Checked;
                }
            }
        }


        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton clickedRadioButton = (RadioButton)sender;
            int selectedValue = Convert.ToInt32(clickedRadioButton.Tag);

            // Teraz 'selectedValue' zawiera wartość 1, 2, 3 lub 4 w zależności od wyboru użytkownika

            if (boxCena.Content is StackPanel cenaStackPanel && cenaStackPanel.Children.Contains(clickedRadioButton))
            {
                //oknoCena.Content = $"Wybrana wartość: {selectedValue}";
                cenaValue = selectedValue;
            }
            else if (boxPlatnosc.Content is StackPanel platnoscStackPanel && platnoscStackPanel.Children.Contains(clickedRadioButton))
            {
                //oknoPlatnosc.Content = $"Wybrana wartość: {selectedValue}";
                platnoscValue = selectedValue;
            }
            else if (boxDostawa.Content is StackPanel dostawaStackPanel && dostawaStackPanel.Children.Contains(clickedRadioButton))
            {
                //oknoDostawa.Content = $"Wybrana wartość: {selectedValue}";
                dostawaValue = selectedValue;
            }
        }

        void Oblicz(int x, int y, int z)
        {
            int wynik = 4 * x + y + 2 * z;
            oknoWynik.Content = $"Wynik: {wynik}";

            // Zmiana koloru tekstu w zależności od wyniku i przypisanie etykiety
            if (wynik >= 28 && wynik <= 31)
            {
                oknoWynik.Foreground = Brushes.Green;
                oknoWynik.Content += "\nNajlepsza oferta";
            }
            else if (wynik >= 23 && wynik <= 27)
            {
                oknoWynik.Foreground = Brushes.LightGreen;
                oknoWynik.Content += "\nDobra oferta";
            }
            else if (wynik >= 18 && wynik <= 22)
            {
				oknoWynik.Foreground = Brushes.Orange;
                oknoWynik.Content += "\nAkceptowalna oferta";
            }
            else if (wynik >= 13 && wynik <= 17)
            {
                oknoWynik.Foreground = Brushes.OrangeRed;
                oknoWynik.Content += "\nNiepewna oferta";
            }
            else if (wynik >= 7 && wynik <= 12)
            {
                oknoWynik.Foreground = Brushes.Red;
                oknoWynik.Content += "\nNajgorsza oferta";
            }
            else
            {
                oknoWynik.Foreground = Brushes.Black;
                oknoWynik.Content += "\nNieznany przedział";
            }
        }



        private void oblicz_Click(object sender, RoutedEventArgs e)
        {
            Oblicz(cenaValue, platnoscValue, dostawaValue);
        }
    }

}
