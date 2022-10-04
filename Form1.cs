using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace Bettafish
{
    public partial class Form1 : Form
    {
        Ping pinger = new Ping();
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            lbDebug.Items.Clear();
            try
            {
                if (tbStore.Text.Length != 5)
                {
                    throw new Exception("Store Id is 5 digit.");
                }
                tbStore.Enabled = false;
                btnCheck.Enabled = false;
                await checking(tbStore.Text);
            }
            catch (Exception exc)
            {
                tbStore.Enabled = true;
                btnCheck.Enabled = true;
                MessageBox.Show(exc.Message, "Error occurs.");
            }
        }

        private async Task checking(string storeId)
        {
            AddListItemText("<==============Program Start===========>");
            string scIP = $"11{storeId[0]}.11";
            // check network of sc
            bool networkStatus = await PingIp(scIP);
            if (!networkStatus)
            {
                throw new Exception($"SC of {storeId} ping fails.");
            }
            AddListItemText("Succeed ping to store 30002.");
            // connect to database sc

            // check one click files
            // run script transaction
            // run script promotion
            // run script for exchange rate
            // run script for exchange rate pos back
            // check network of pos
            // connect to database pos
            // run script for exchange rate pos front
            tbStore.Enabled = true;
            btnCheck.Enabled = true;
        }

        private void AddListItemText(string text)
        {
            lbDebug.Items.Add($"{DateTime.Now:dd-MMM-yyyy}|{text}");
        }

        private async Task<bool> PingIp(string ip, int index = 0)
        {
            List<string> results = new List<string>();
            PingReply prl = await pinger.SendPingAsync(ip);
            results.Add(prl.Status.ToString());
            return prl.Status.ToString() == "Success";
        }

        static void executeQuery(string query, SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
        }

        static string getConnection(string source, string db_name)
        {
            return $"Data Source={source};Initial Catalog=master;Integrated Security=true";
        }
    }
}
