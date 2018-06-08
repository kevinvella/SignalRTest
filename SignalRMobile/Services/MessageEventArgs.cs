using System;
namespace SignalRMobile.Services
{
    public class MessageEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the command.
        /// </summary>
        public string Command { get; private set; }

        /// <summary>
        /// Gets the command.
        /// </summary>
        public string Message { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="T:TestSignalR.Services.MessageEventArgs"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public MessageEventArgs(string command, string message)
        {
            Command = command;
            Message = message;
        }
    }
}
