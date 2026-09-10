namespace EventVsBindingMauiApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (rotationLabel is not null && sender is Slider slider)
            {
                rotationLabel.Rotation = slider.Value;
                rotationLabel.Text = slider.Value.ToString();
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            resultLabel.Text = entryLabel.Text;
            entryLabel.Text = "";
        }

        public string Message { get; set; }

        private string returnMessage {  get; set; }

        public string ReturnMessage
        {
            get { return returnMessage; }
            set
            {
                returnMessage = value;
                OnPropertyChanged();
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            ReturnMessage = Message;
        }
    }
}
