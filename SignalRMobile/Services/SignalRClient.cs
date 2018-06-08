using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRMobile.Services
{
    public class SignalRClient
    {
        private HubConnection _hub;
        public event EventHandler<ValueChangedEventArgs> ValueChanged;
        public event EventHandler<MessageEventArgs> Message;

        public HubConnection Hub { get { return _hub; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="SignalRClient"/> class.
        /// </summary>
        public SignalRClient()
        {
            Debug.WriteLine("SignalR Initialized...");
            InitializeSignalR().ContinueWith(task =>
            {
                Debug.WriteLine("SignalR Started...");
            });
        }

        /// <summary>
        /// Initializes SignalR.
        /// </summary>
        public async Task InitializeSignalR()
        {
            try
            {
                _hub = new HubConnectionBuilder()
                    .WithUrl("http://127.0.0.1:47964/messanger")
                .Build();

                _hub.On<string>("Message",
                (value) => {
                    Message?.Invoke(this, new MessageEventArgs(value,string.Empty));
                });

                await _hub.StartAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SignalR Error...{ex.Message}");
            }

        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <returns>The message.</returns>
        /// <param name="message">Message.</param>
        public async Task SendMessage(string message)
        {
            try
            {
                await _hub?.InvokeAsync("Message", message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SignalR Error...{ex.Message}");
            }

        }
    }
}
