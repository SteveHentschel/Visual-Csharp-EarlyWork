using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Web_Browser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bntGo_Click(object sender, EventArgs e)
        {
            string webPage = txtAddress.Text.Trim();
            webBrowser1.Navigate(webPage);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack)
            {
                webBrowser1.GoBack();
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward)
            {
                webBrowser1.GoForward();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void btnHome_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnHome, "Home, James");
        }

        private void btnBack_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnBack, "Back, Jack");
        }

        private void btnForward_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnForward, "Forward Ho!");
        }

        private void btnStop_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnStop, "Stop the Load");
        }

        private void btnRefresh_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnRefresh, "Refresh Me");
            btnRefresh.Image = imageList1.Images[5];
        }

        private void btnRefresh_MouseLeave(object sender, EventArgs e)
        {
            btnRefresh.Image = imageList1.Images[4];
        }
    }
}
