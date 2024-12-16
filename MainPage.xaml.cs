namespace CiciovanBogdanIonutLab7
{
    public partial class MainPage : ContentPage
    {
        //int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }
        private void OnLearnMoreClicked(object sender, EventArgs e)
        {
            DisplayAlert("Informații suplimentare", "Aceasta este pagina principală personalizată pentru laboratorul 7.", "OK");
        }

        //private void OnCounterClicked(object sender, EventArgs e)
        //{
        //    count++;

        //    if (count == 1)
        //        CounterBtn.Text = $"Clicked {count} time";
        //    else
        //        CounterBtn.Text = $"Clicked {count} times";

        //    SemanticScreenReader.Announce(CounterBtn.Text);
        //}
    }

}
