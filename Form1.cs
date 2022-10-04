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
                AddListItemText("<==============Program Start===========>");
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
                AddListItemText("<==============Program End===========>");
                MessageBox.Show(exc.Message, "Error occurs.");
            }
        }

        private async Task checking(string storeId)
        {
            string scIP = $"11{storeId[0]}.1{storeId.Substring(1, 2)}.1{storeId.Substring(3, 2)}.119";

            // check network of sc
            AddListItemText($"Pinging to SC of store {storeId}");
            bool networkStatus = await PingIp(scIP);
            if (!networkStatus)
            {
                throw new Exception($"Pinging to SC of store {storeId} fails.");
            }
            AddListItemText($"Pinging to SC of store {storeId} success.");

            // check one click file
            AddListItemText("Checking one click file openstore*.pdf");

            // check promotion
            AddListItemText("Connecting to database LPE_PROM");
            using (SqlConnection conn = new SqlConnection($@"Data Source={scIP}\SQLEXPRESS2008R2;Initial Catalog=LPE_PROM;Integrated Security=false;User ID=sa;Password=Admin2000;"))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                AddListItemText("Connecting to database LPE_PROM success");
                AddListItemText("Querying from table LPE_PromotionBucketEntity");
                SqlCommand cmd_LPE = new SqlCommand($"SELECT TOP 5 * from LPE_PromotionBucketEntity", conn);
                SqlDataReader rdr_LPE = cmd_LPE.ExecuteReader();
                try
                {
                    var columns = rdr_LPE.GetName(0);

                    for (int i = 1; i < 6; i++)
                    {
                        columns+= ",  " + rdr_LPE.GetName(i);
                    }
                    AddListItemText(columns);
                    while (rdr_LPE.Read())
                    {
                        AddListItemText(rdr_LPE[0] + ",  " + rdr_LPE[1] + ",  " + rdr_LPE[2] + ",  " + rdr_LPE[3] + ",  " + rdr_LPE[4] + ",  " + rdr_LPE[5]);
                    }
                }
                finally
                {
                    rdr_LPE.Close();
                }
            }

            // sc_db relation
            AddListItemText("Connecting to SC_DB");
            using (SqlConnection conn = new SqlConnection($@"Data Source={scIP}\SQLEXPRESS2008R2;Initial Catalog=SC_DB;Integrated Security=false;User ID=sa;Password=Admin2000;"))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                AddListItemText("Connecting to SC_DB success");
                AddListItemText("Querying from table T_TRANSACTION_HISTORY");
                SqlCommand cmdTrx = new SqlCommand($"SELECT TOP 30 * FROM T_TRANSACTION_HISTORY", conn);
                SqlDataReader rdr_Trx = cmdTrx.ExecuteReader();
                try
                {
                    var columns = rdr_Trx.GetName(0);

                    for (int i = 1; i < rdr_Trx.FieldCount; i++)
                    {
                        columns += ",  " + rdr_Trx.GetName(i);
                    }
                    AddListItemText(columns);
                    while (rdr_Trx.Read())
                    {
                        AddListItemText(rdr_Trx[0] + ",  " + rdr_Trx[1] + ",  " + rdr_Trx[2] + ",  " + rdr_Trx[3]);
                    }
                }
                finally
                {

                    rdr_Trx.Close();
                }

                AddListItemText("Querying from table T_EXCHANGE_RATE latest START_DT");
                SqlCommand cmdExRate = new SqlCommand($"SELECT * FROM T_EXCHANGE_RATE WHERE STORE_CD = '{storeId}' AND START_DT IN (SELECT MAX(START_DT) FROM T_EXCHANGE_RATE)", conn);
                SqlDataReader rdr_ExRate = cmdExRate.ExecuteReader();
                try
                {
                    var columns = rdr_ExRate.GetName(0);

                    for (int i = 1; i < rdr_ExRate.FieldCount; i++)
                    {
                        columns += ",  " + rdr_ExRate.GetName(i);
                    }
                    AddListItemText(columns);
                    while (rdr_ExRate.Read())
                    {
                        AddListItemText(rdr_ExRate[0] + ",  " + rdr_ExRate[1] + ",  " + rdr_ExRate[2] + ",  " + rdr_ExRate[3] + ",  " + rdr_ExRate[4] + ",  " + rdr_ExRate[5]);
                    }
                }
                finally
                {
                    rdr_ExRate.Close();
                }
            }

            AddListItemText("Connecting to POSG2 Back");
            using (SqlConnection conn = new SqlConnection($@"Data Source={scIP}\SQLEXPRESS2008R2;Initial Catalog=POSG2;Integrated Security=false;User ID=sa;Password=Admin2000;"))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                AddListItemText("Connecting to POSG2 Back success");
                AddListItemText("Querying from table MA_GATEWAY_EXCHANGE");
                SqlCommand cmd = new SqlCommand($"SELECT * FROM MA_GATEWAY_EXCHANGE WHERE EFFECTIVE_DATETIME IN (SELECT MAX(EFFECTIVE_DATETIME) FROM MA_GATEWAY_EXCHANGE)", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                try
                {
                    var columns = rdr.GetName(0);

                    for (int i = 1; i < rdr.FieldCount; i++)
                    {
                        columns += ",  " + rdr.GetName(i);
                    }
                    AddListItemText(columns);
                    while (rdr.Read())
                    {
                        AddListItemText(rdr[0] + ",  " + rdr[1] + ",  " + rdr[2] + ",  " + rdr[3]);
                    }
                }
                finally
                {

                    rdr.Close();
                }
            }


            AddListItemText($"Pinging to POS1 of store {storeId}");
            string posIP = $"11{storeId[0]}.1{storeId.Substring(1, 2)}.1{storeId.Substring(3, 2)}.111";
            networkStatus = await PingIp(posIP);
            if (!networkStatus)
            {
                throw new Exception($"Pinging to POS1 of store {storeId} fails.");
            }
            AddListItemText($"Pinging to POS1 of store {storeId} success.");

            // check one click file
            AddListItemText("Checking one click file openstore*.pdf");

            // run script for exchange rate pos front
            AddListItemText("Connecting to POSG2 Front");
            using (SqlConnection conn = new SqlConnection($@"Data Source={posIP}\SQLEXPRESS2008R2;Initial Catalog=POSG2;Integrated Security=false;User ID=sa;Password=Admin2000;"))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                AddListItemText("Connecting to POSG2 Front success");
                AddListItemText("Querying from table MA_EXCHANGE_RATE");
                SqlCommand cmd = new SqlCommand($"SELECT * FROM MA_EXCHANGE_RATE WHERE EFFECTIVE_DATETIME in (SELECT MAX(EFFECTIVE_DATETIME) from MA_EXCHANGE_RATE)", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                try
                {
                    var columns = rdr.GetName(0);

                    for (int i = 1; i < rdr.FieldCount; i++)
                    {
                        columns += ",  " + rdr.GetName(i);
                    }
                    AddListItemText(columns);
                    while (rdr.Read())
                    {
                        AddListItemText(rdr[0] + ",  " + rdr[1] + ",  " + rdr[2] + ",  " + rdr[3]);
                    }
                }
                finally
                {

                    rdr.Close();
                }
            }
            AddListItemText("<==============Program End===========>");
            tbStore.Enabled = true;
            btnCheck.Enabled = true;
        }

        private void AddListItemText(string text, bool hasDate = true)
        {
            lbDebug.Items.Add(hasDate ? $"{DateTime.Now:dd-MMM-yyyy HH:mm:ss}| {text}" : $"            | {text}");
            lbDebug.SelectedIndex = lbDebug.Items.Count - 1;
            System.Threading.Thread.Sleep(150);
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
