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
using System.IO;

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
            string scIP = $"11{storeId[0]}.1{storeId.Substring(1, 2)}.1{storeId.Substring(3, 2)}.119";
            // check network of sc
            AddListItemText($"Try to ping to {scIP}");
            bool networkStatus = await PingIp(scIP);
            if (!networkStatus)
            {
                throw new Exception($"SC of store {storeId} ping fails.");
            }
            AddListItemText($"Succeed pinging to store {storeId}.");
            // check one click file
            AddListItemText("Check one click file openstore*.pdf");
            using (SqlConnection conn = new SqlConnection($@"Data Source={scIP}\SQLEXPRESS2008R2;Initial Catalog=SC_DB;Integrated Security=false;User ID=sa;Password=Admin2000;"))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                AddListItemText("Succeed connecting to SC_DB");

                // run script exchange rate
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    SqlCommand command = new SqlCommand($"SELECT * FROM T_EXCHANGE_RATE WHERE STORE_CD = '{storeId}' AND START_DT IN (SELECT MAX(START_DT) FROM T_EXCHANGE_RATE)", conn);
                    SqlDataReader reader = command.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            AddListItemText(reader[0] + ",  " + reader[1] + ",  " + reader[2] + ",  " + reader[3] + ",  " + reader[4] + ",  " + reader[5]);
                        }
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
            }

            // run script promotion
            // run script for exchange rate
            // run script for exchange rate pos back

            // check network of pos
            // check one click file
            // connect to database pos
            // run script for exchange rate pos front
            AddListItemText("<==============Program End===========>");
            tbStore.Enabled = true;
            btnCheck.Enabled = true;
        }

        private void AddListItemText(string text)
        {
            lbDebug.Items.Add($"{DateTime.Now:dd-MMM-yyyy}| {text}");
        }

        private async Task<bool> PingIp(string ip, int index = 0)
        {
            List<string> results = new List<string>();
            PingReply prl = await pinger.SendPingAsync(ip);
            results.Add(prl.Status.ToString());
            return prl.Status.ToString() == "Success";
        }

    }
}
