/*
Zadanie – Kalkulator kosztu zamówienia
Napisz aplikację w .NET MAUI, która pozwala obliczyć koszt prostego zamówienia.

Aplikacja powinna zawierać:
- pole Nazwa produktu (Entry),
- pole Cena za sztukę (Entry),
- wybór liczby sztuk za pomocą kontrolki Stepper (od 1 do 10),
- Label wyświetlający aktualnie wybraną liczbę sztuk,
- przełącznik Dostawa ekspresowa (Switch),
- przycisk Oblicz,
- Label wyświetlający podsumowanie zamówienia i końcową cenę.

Zasady obliczeń:
Koszt zamówienia oblicz według wzoru:
cena za sztukę × liczba sztuk
Jeśli użytkownik włączy dostawę ekspresową, do ceny zamówienia należy doliczyć 15 zł.

Przykład:
Produkt: Słuchawki
Cena za sztukę: 120 zł
Liczba sztuk: 3
Dostawa ekspresowa: TAK  
Wynik: 375 zł




*/
using System.ComponentModel;
using System.Windows.Input;

namespace OrderCostCalculatorMauiApp
{
    public partial class MainPage : ContentPage
    {

        private string nazwaProduktu;
        public string NazwaProduktu
        {
            get => nazwaProduktu;
            set { nazwaProduktu = value; OnPropertyChanged(nameof(NazwaProduktu)); }
        }

        private double cenaZaSztuke;
        public double CenaZaSztuke
        {
            get => cenaZaSztuke;
            set { cenaZaSztuke = value; OnPropertyChanged(nameof(CenaZaSztuke)); }
        }

        private double liczbaSztuk;
        public double LiczbaSztuk
        {
            get => liczbaSztuk;
            set { liczbaSztuk = value; OnPropertyChanged(nameof(LiczbaSztuk)); }
        }

        private bool czyEkspresowa;
        public bool CzyEkspresowa
        {
            get => czyEkspresowa;
            set { czyEkspresowa = value; OnPropertyChanged(nameof(CzyEkspresowa)); }
        }

        private string wynik;
        public string Wynik
        {
            get => wynik;
            set { wynik = value; OnPropertyChanged(nameof(Wynik)); }
        }

        public ICommand ObliczCommand { get;}

        public MainPage()
        {
            BindingContext = this;
            ObliczCommand = new Command(WykonajObliczenia);
            InitializeComponent();


        }

        private async void WykonajObliczenia()
        {
                double koszt = cenaZaSztuke * LiczbaSztuk;

                if (CzyEkspresowa)
                {
                    koszt += 15;
                }

                string produkt = string.IsNullOrWhiteSpace(NazwaProduktu) ? "Produkt" : NazwaProduktu;
                Wynik = $"Produkt: {produkt}\nCena końcowa: {koszt} zł"; 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}