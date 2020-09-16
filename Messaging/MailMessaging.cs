using SOLID_Start.Loggen;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_Start.Messaging
{
    class MailMessaging
    {
        Logger logger;
        public MailMessaging()
        {
            logger = new Logger();
        }
        public void SendComfirmationMessage(Klant klant)
        {
            logger.Log("stuur een mail naar de klant");
            logger.Log("SENDING MAIL...");
        }
    }
}
