using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomadoShop.Exceptions
{
  public  class ConnectionException: Exception
    {
        public ConnectionException()
        {
            //AlertDialog.Builder alert = new AlertDialog.Builder(myApp.Context);
            //alert.SetTitle("Failure");
            //alert.SetMessage("Request failed. No connection.");
            //alert.SetPositiveButton("OK", (senderAlert, args) =>
            //{
            //});

            //Dialog dialog = alert.Create();
            //dialog.Show();
        }

        public ConnectionException(string message)
            : base(message)
        { }

        public ConnectionException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
