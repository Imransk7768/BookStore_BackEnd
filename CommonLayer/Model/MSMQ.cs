﻿using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace CommonLayer.Model
{
    public class MSMQ
    {
        MessageQueue messageQ = new MessageQueue();
        public void sendData2Queue(String token)
        {
            messageQ.Path = @".\private$\token";

            if (!MessageQueue.Exists(messageQ.Path))
            {
                MessageQueue.Create(messageQ.Path);
            }

            messageQ.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
            messageQ.ReceiveCompleted += MessageQ_ReceiveCompleted;
            messageQ.Send(token);
            messageQ.BeginReceive();
            messageQ.Close();
        }

        private void MessageQ_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                var msg = messageQ.EndReceive(e.AsyncResult);
                string token = msg.Body.ToString();
<<<<<<< HEAD
                string subject = "BookStore reset link";
                //string body = "http://localhost:4200/resetpassword?" + token;
=======
                string subject = "FundooNoteApp reset link";
>>>>>>> 1998636c45e217741994d1041f7eaae98a488d86
                string body = token;
                var SMTP = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("imransk0113@gmail.com", "qwhychjhpoustwnd"),
                    EnableSsl = true
                };
                SMTP.Send("imransk0113@gmail.com", "imransk0113@gmail.com", subject, body);
                // Process the logic be sending the message
                //Restart the asynchronous receive operation.
                messageQ.BeginReceive();
            }
            catch (MessageQueueException qexception)
            {
            }
        }
    }
}
