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
using Bettafish.Class;

namespace Bettafish
{
    public partial class f1 : Form
    {
        Ping pinger = new Ping();
        public DateTime runningTime = DateTime.MinValue;
        public string CurrentDirectory = Environment.CurrentDirectory;
        public f1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            runningTime = DateTime.Now;
            lbDebug.Items.Clear();
            btnSaveLog.Enabled = false;
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
            finally
            {
                btnSaveLog.Enabled = true;
            }
        }

        private async Task checking(string storeId)
        {
            string scIP = $"11{storeId[0]}.1{storeId.Substring(1, 2)}.1{storeId.Substring(3, 2)}.119";
            bool oneclick = false;
            bool promo = false;
            bool tranX = false;
            List<ExchangeRate> exrSC = new List<ExchangeRate>();
            List<ExchangeRatePos> exrPOSBack = new List<ExchangeRatePos>();
            List<ExchangeRatePos> exrPOSFront = new List<ExchangeRatePos>();

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
            using (SqlConnection conn = new SqlConnection($@"Data Source={scIP}\SQLEXPRESS2008R2;Initial Catalog=master;Integrated Security=false;User ID=sa;Password=Admin2000;"))
            {
                conn.Open();
                AddListItemText("Connecting to database master success");
                SqlCommand cmd = new SqlCommand(@"create table #output (output nvarchar(255) null); insert into #output exec xp_cmdshell 'dir C:\OneClick\OpenStore';select * from #output where output like '%openstore_STC9_%.pdf'; drop table #output", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                try
                {
                    if (rdr.Read())
                    {
                        var rr = rdr[0].ToString();
                        var show = rr.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                        AddListItemText($"Found the file, {show[show.Length - 1]}");
                        oneclick = true;
                    }
                    else
                    {
                        AddListItemText("Not found any openstore_STC9%.pdf");
                        throw new Exception("Not found openstore file, OneClick is not yet run.");
                    }
                }
                catch (Exception exc)
                {
                    throw new Exception(exc.Message);
                }
            }

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
                SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) from LPE_PromotionBucketEntity", conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                try
                {
                    while (rdr.Read())
                    {
                        if (Int32.Parse(rdr[0].ToString()) > 0)
                        {
                            AddListItemText($"Promotion database, LPE_PromotionBucketEntity has DATA, {rdr[0]} rows.");
                            promo = true;
                        } else
                        {
                            AddListItemText($"Promotion database, LPE_PromotionBucketEntity has NO data.");
                        }
                    }
                }
                finally
                {
                    rdr.Close();
                }
                conn.Close();
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
                SqlCommand cmdTrx = new SqlCommand($"SELECT COUNT(*) FROM T_TRANSACTION_HISTORY", conn);
                SqlDataReader rdr_Trx = cmdTrx.ExecuteReader();
                try
                {
                    while (rdr_Trx.Read())
                    {
                        if (Int32.Parse(rdr_Trx[0].ToString()) > 0)
                        {
                            AddListItemText($"SC database, T_TRANSACTION_HISTORY has DATA, {rdr_Trx[0]} rows.");
                        }
                        else
                        {
                            AddListItemText($"SC database, T_TRANSACTION_HISTORY has NO data.");
                            tranX = true;
                        }
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
                        var txt = rdr_ExRate[0] + ",  " + rdr_ExRate[1] + ",  " + rdr_ExRate[2] + ",  " + rdr_ExRate[3] + ",  " + rdr_ExRate[4] + ",  " + rdr_ExRate[5];
                        ExchangeRate exrsc1 = new ExchangeRate();
                        exrsc1.Store_CD = rdr_ExRate[0].ToString();
                        exrsc1.EX_From = rdr_ExRate[1].ToString();
                        exrsc1.EX_To = rdr_ExRate[2].ToString();
                        exrsc1.Rate_AMT = decimal.Parse(rdr_ExRate[3].ToString());
                        exrsc1.Start_DT = DateTime.Parse(rdr_ExRate[4].ToString());
                        exrsc1.End_DT = DateTime.Parse(rdr_ExRate[5].ToString());
                        exrSC.Add(exrsc1);
                        AddListItemText(txt);
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
                        ExchangeRatePos exrp = new ExchangeRatePos();
                        exrp.Store_ID = rdr[0].ToString();
                        exrp.Source = rdr[1].ToString();
                        exrp.Destination = rdr[2].ToString();
                        exrp.Exchange_Rate = decimal.Parse(rdr[3].ToString());
                        exrp.Effective_Datetime = DateTime.Parse(rdr[4].ToString());
                        exrp.Expired_Datetime = DateTime.Parse(rdr[5].ToString());
                        exrp.Create_Datetime = DateTime.Parse(rdr[6].ToString());
                        exrPOSBack.Add(exrp);
                        var txt = rdr[0] + ",  " + rdr[1] + ",  " + rdr[2] + ",  " + rdr[3] + ",  " + rdr[4] + ",  " + rdr[5];
                        AddListItemText(txt);
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
            //AddListItemText("Checking one click file openstore*.pdf");

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
                        ExchangeRatePos exrp = new ExchangeRatePos();
                        exrp.Store_ID = rdr[0].ToString();
                        exrp.Source = rdr[1].ToString();
                        exrp.Destination = rdr[2].ToString();
                        exrp.Exchange_Rate = decimal.Parse(rdr[3].ToString());
                        exrp.Effective_Datetime = DateTime.Parse(rdr[4].ToString());
                        exrp.Expired_Datetime = DateTime.Parse(rdr[5].ToString());
                        exrp.Create_Datetime = DateTime.Parse(rdr[6].ToString());
                        exrPOSFront.Add(exrp);
                        var txt = rdr[0] + ",  " + rdr[1] + ",  " + rdr[2] + ",  " + rdr[3] + ",  " + rdr[4] + ",  " + rdr[5];
                        AddListItemText(txt);

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
            f2 checklistForm = new f2(storeId, oneclick, promo, tranX, exrSC, exrPOSBack, exrPOSFront);
            checklistForm.ShowDialog();
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

        private void btnSaveLog_Click(object sender, EventArgs e)
        {
            try
            {
                using (FileStream fs = File.Create(CurrentDirectory + $"\\log_{runningTime:yyyyMMdd_HHmm}.txt"))
                {
                    var str = "";
                    for (int i = 0; i < lbDebug.Items.Count; i++)
                    {
                        str+=lbDebug.Items[i].ToString()+ Environment.NewLine;
                    }
                    Byte[] data = new UTF8Encoding(true).GetBytes(str);
                    fs.Write(data, 0, data.Length);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            if (MessageBox.Show("Log file is saved.", "Saving Log", MessageBoxButtons.OK) == DialogResult.OK)
            {
                btnSaveLog.Enabled = false;
            }
        }
    }
}
