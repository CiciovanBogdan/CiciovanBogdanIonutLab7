namespace CiciovanBogdanIonutLab7
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void OnLearnMoreClicked(object sender, EventArgs e)
        {
            DisplayAlert("Informații suplimentare", "Aceasta este pagina principală personalizată pentru laboratorul 7.", "OK");
        }
    }

}
