using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfVectorViewer.Services
{
    public class MessagingService : IMessagingService
    {
        public void DisplayMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
