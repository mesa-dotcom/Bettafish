using Bettafish.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bettafish
{
    public partial class f2 : Form
    {
        public string storeId = "";
        public bool oneClick = false;
        public bool promo = false;
        public bool tranX = false;
        public bool target = false;
        public List<ExchangeRate> exrSC = new List<ExchangeRate>();
        public List<ExchangeRatePos> exrPOSBack = new List<ExchangeRatePos>();
        public List<ExchangeRatePos> exrPOSFront = new List<ExchangeRatePos>();
        public int posAll = 0;

        public f2(string storeId, bool oneClick, bool promo, bool tranX, bool target, List<ExchangeRate> exrSC, List<ExchangeRatePos> exrPOSBack, List<ExchangeRatePos> exrPOSFront, int posAll)
        {
            this.storeId = storeId;
            this.oneClick = oneClick;
            this.promo = promo;
            this.tranX = tranX;
            this.target = target;
            this.exrSC = exrSC;
            this.exrPOSBack = exrPOSBack;
            this.exrPOSFront = exrPOSFront;
            this.posAll = posAll;
            InitializeComponent();
        }

        private void f2_Load(object sender, EventArgs e)
        {
            gbResults.Text = "Checklist Results: " + storeId;
            cbOneClick.Checked = oneClick;
            cbOneClick.ForeColor = oneClick ? Color.Green : Color.Red;
            cbPromo.Checked = promo;
            cbPromo.ForeColor = promo ? Color.Green : Color.Red;
            cbTranX.Checked = tranX;
            cbTranX.ForeColor = tranX ? Color.Green : Color.Red;
            cbTarget.Checked = target;
            cbTarget.ForeColor = target ? Color.Green : Color.Red;
            cbOneClick.AutoCheck = false;
            cbPromo.AutoCheck = false;
            cbTranX.AutoCheck = false;
            cbTarget.AutoCheck = false;

            AddDataToDTSC();
            AddDataToDTPosBack();
            AddDataToDTPosFront();
        }

        public void AddDataToDTSC()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Store_CD");
            dt.Columns.Add("EX_From");
            dt.Columns.Add("EX_To");
            dt.Columns.Add("Rate_AMT");
            dt.Columns.Add("Start_DT");
            dt.Columns.Add("End_DT");

            if (exrSC.Count == 3)
            {
                lblExrSCPass.Text = "PASS";
                lblExrSCPass.ForeColor = Color.Green;
            }
            else
            {
                lblExrSCPass.Text = "FAIL";
                lblExrSCPass.ForeColor = Color.Red;
            }

            foreach (ExchangeRate exr in exrSC)
            {
                DataRow dr = dt.NewRow();
                dr["Store_CD"] = exr.Store_CD;
                dr["EX_From"] = exr.EX_From;
                dr["EX_To"] = exr.EX_To;
                dr["Rate_AMT"] = exr.Rate_AMT;
                dr["Start_DT"] = exr.Start_DT;
                dr["End_DT"] = exr.End_DT;
                dt.Rows.Add(dr);
            }

            dtgvExrSC.DataSource = dt;
            dtgvExrSC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public void AddDataToDTPosBack()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Store_ID");
            dt.Columns.Add("Source");
            dt.Columns.Add("Destination");
            dt.Columns.Add("Exchange_Rate");
            dt.Columns.Add("Effective_Datetime");
            dt.Columns.Add("Expired_Datetime");
            dt.Columns.Add("Create_Datetime");

            if (exrPOSBack.Count == 3)
            {
                lblExrPosBackPass.Text = "PASS";
                lblExrPosBackPass.ForeColor = Color.Green;
            }
            else
            {
                lblExrPosBackPass.Text = "FAIL";
                lblExrPosBackPass.ForeColor = Color.Red;
            }

            foreach (ExchangeRatePos exr in exrPOSBack)
            {
                DataRow dr = dt.NewRow();
                dr["Store_ID"] = exr.Store_ID;
                dr["Source"] = exr.Source;
                dr["Destination"] = exr.Destination;
                dr["Exchange_Rate"] = exr.Exchange_Rate;
                dr["Effective_Datetime"] = exr.Effective_Datetime;
                dr["Expired_Datetime"] = exr.Expired_Datetime;
                dr["Create_Datetime"] = exr.Create_Datetime;
                dt.Rows.Add(dr);
            }

            dtgvExrPosBack.DataSource = dt;
            dtgvExrPosBack.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public void AddDataToDTPosFront()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Store_ID");
            dt.Columns.Add("POS_No");
            dt.Columns.Add("Source");
            dt.Columns.Add("Destination");
            dt.Columns.Add("Exchange_Rate");
            dt.Columns.Add("Effective_Datetime");
            dt.Columns.Add("Expired_Datetime");
            dt.Columns.Add("Create_Datetime");

            if (exrPOSFront.Count == 3 * posAll)
            {
                lblExrPosFrontPass.Text = "PASS";
                lblExrPosFrontPass.ForeColor = Color.Green;
            }
            else
            {
                lblExrPosFrontPass.Text = "FAIL";
                lblExrPosFrontPass.ForeColor = Color.Red;
            }

            foreach (ExchangeRatePos exr in exrPOSFront)
            {
                DataRow dr = dt.NewRow();
                dr["Store_ID"] = exr.Store_ID;
                dr["POS_No"] = exr.POS_No;
                dr["Source"] = exr.Source;
                dr["Destination"] = exr.Destination;
                dr["Exchange_Rate"] = exr.Exchange_Rate;
                dr["Effective_Datetime"] = exr.Effective_Datetime;
                dr["Expired_Datetime"] = exr.Expired_Datetime;
                dr["Create_Datetime"] = exr.Create_Datetime;
                dt.Rows.Add(dr);
            }

            dtgvExrPosFront.DataSource = dt;
            dtgvExrPosFront.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnSaveResult_Click(object sender, EventArgs e)
        {
            try
            {
                using (Bitmap bmp = new Bitmap(this.Width, this.Height))
                {
                    this.DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));
                    bmp.Save($@"{Environment.CurrentDirectory}\Checklist_{storeId}_{DateTime.Now:yyyyMMdd_HHmmss}.png", ImageFormat.Png); // make sure path exists!
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            } finally
            {
                this.Close();
            }
        }
    }
}
