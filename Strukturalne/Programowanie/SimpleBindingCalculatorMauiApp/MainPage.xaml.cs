namespace SimpleBindingCalculatorMauiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public string AdditionFirstNumber { get; set; }

        public string AdditionSecondNumber {  get; set; }

        private string returnAddition;

        public string ReturnAddition
        {
            get { return returnAddition; }
            set
            {
                returnAddition = value;
                OnPropertyChanged();
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            //pobrać dane wejsciowe
            //var firstNumber = int.Parse(firstNumberEntry.text)
            //int firstNumber;
            /*if (int.TryParse(firstNumberEntry.Text, out int firstNumber)
                && int.TryParse(secondNumberEntry.Text, out int secondNumber))
            {
                resultLabel.Text = $"Wynik dodawania to {firstNumber + secondNumber}";
                resultLabel.BackgroundColor = Colors.Green;
            }
            else
            {
                resultLabel.Text = $"Podales nieprawidlowe dane.";
                resultLabel.BackgroundColor = Colors.Red;
            }*/
            if (int.TryParse(AdditionFirstNumber, out int firstNumber)
                && int.TryParse(AdditionSecondNumber, out int secondNumber))
            {
                ReturnAddition = $"Wynik dodawania to {firstNumber + secondNumber}";
                resultLabel.BackgroundColor = Colors.Green;
            }
            else
            {
                ReturnAddition = $"Podales nieprawidlowe dane.";
                resultLabel.BackgroundColor = Colors.Red;
            }
        }
    }
}
