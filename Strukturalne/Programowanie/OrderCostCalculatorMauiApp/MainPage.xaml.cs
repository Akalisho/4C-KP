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
namespace OrderCostCalculatorMauiApp
{
    public partial class MainPage : ContentPage
    {

        private int stepperValue;
        public int StepperValue
        {
            get { return stepperValue; }
            set { stepperValue = value; OnPropertyChanged(); }
        }

        private bool isOn;
        public bool IsOn
        {
            get { return isOn; }
            set { isOn = value; OnPropertyChanged(); }
        }

        private double result;
        public double Result
        {
            get { return result; }
            set { result = value; OnPropertyChanged(); }
        }

        private Command calculate;
        public Command Calculate
        {
            get
            {
                if (calculate == null)
                    calculate = new Command(
                        () =>
                        {
                            if (IsOn == true)
                            {
                                result = Entry.nazwaProd * Entry.cenaSztuk + 15;
                            }
                        }
                        );
                return calculate;
            }
        }

        public MainPage()
        {
            InitializeComponent();
        }


    }
}
