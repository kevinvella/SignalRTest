using System;
using System.Diagnostics;
using System.Threading.Tasks;
using SignalRMobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SignalRMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        SignalRClient signalRClient;
        public MainPage()
        {
            InitializeComponent();

            signalRClient = new SignalRClient();
            signalRClient.Message += SignalRClient_Message;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Task.Run(() => 
            {
                signalRClient.SendMessage("Test...");
            });
        }

        void SignalRClient_Message(object sender, MessageEventArgs e)
        {
            Debug.WriteLine($"SignalR - {e.Message}");
        }

    }
}