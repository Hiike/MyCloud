using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyCloud
{
    public partial class Form1 : Form
    {
        private DropNet.DropNetClient _client;
        private DropNet.Models.UserLogin _userLogin;

        public Form1()
        {
            InitializeComponent();
            _client = new DropNet.DropNetClient("gthmyk9qe4hh3sn", "rpoe69bag92239g");
            
            _client.GetAccessTokenAsync((userLogin) =>
                {
                    var tokenUrl = _client.BuildAuthorizeUrl("http://www.google.com");
                    brw.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(brw_DocumentCompleted);
                    brw.Navigate(tokenUrl);
                },
            (error) =>
            {
                MessageBox.Show(error.Response.Content);
            });
        }

        private void brw_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.Host.Contains("google"))
            {
                //Callback url reached, user has completed authorization

                //Now convert the request token into an access token
                _client.GetAccessTokenAsync((userLogin) =>
                    {
                        //Save the Token and Secret we get here to save future logins
                        _userLogin = userLogin;

                        LoadContents();
                    },
                    (error) =>
                    {
                        //Some sort of error
                        MessageBox.Show(error.Response.Content);
                    });
            }
        }
        private void LoadContents()
        {
            _client.GetMetaDataAsync("/", (response) =>
            {
                MessageBox.Show(response.Contents.Count(c => c.Is_Dir) + " Folders found.");
            },
            (error) =>
            {
                MessageBox.Show(error.Message);
            });
        }

    }
}
