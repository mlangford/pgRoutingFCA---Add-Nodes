using System;
using System.Windows.Forms;
using System.IO;
using System.Text;
using Npgsql;

namespace pgRoutingFCA
{
    public partial class Form2 : Form
    {
        public Form2(string inConStr, string inOutTbl,
            string inNwkSch, string inNwkTbl, string inNwkGeom,
            string inPntSch, string inPntTbl, string inPntGeom, string inSRID)
        {
            InitializeComponent();
            conString = inConStr + ";Command Timeout=0";
            nwksch = inNwkSch;
            nwktbl = inNwkTbl;
            nwkgeom = inNwkGeom;
            pntsch = inPntSch;
            pnttbl = inPntTbl;
            pntgeom = inPntGeom;
            srid = inSRID;
            nwkfull = nwksch + "." + nwktbl;
            pntfull = pntsch + "." + pnttbl;
            outtbl = inOutTbl;
            outfull = nwksch + "." + outtbl;
        }
        string conString;
        string nwksch, nwktbl, nwkgeom, nwkfull;
        string pntsch, pnttbl, pntgeom, pntfull, srid;
        string outtbl, outfull;

        string test;
        string step;
        string[] steps;
        Form4 frm4 = new Form4();
        StringBuilder sb = new StringBuilder();

        private void Form2_Load(object sender, EventArgs e)
        {
            //Read in SQL instructions
            try
            {
                using (StreamReader sr = new StreamReader("AddNodes.sql"))
                {
                    step = sr.ReadToEnd();
                }
                btnQuit.Location = new System.Drawing.Point(405, 378);
                //pre-process SQL instructions
                step = step.Replace("#nwksch", nwksch);
                step = step.Replace("#nwkfull", nwkfull);
                step = step.Replace("#outfull", outfull);
                step = step.Replace("#nwkgeom", nwkgeom);
                step = step.Replace("#outtbl", outtbl);
                step = step.Replace("#pntsch", pntsch);
                step = step.Replace("#pnttbl", pnttbl);
                step = step.Replace("#pntfull", pntfull);
                step = step.Replace("#pntgeom", pntgeom);
                step = step.Replace("#srid", srid);
                steps = step.Split('!');
                btnExecute.Text = "Execute";
                btnExecute.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                Application.Exit();
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            btnQuit.Visible = false;
            btnExecute.Enabled = false;
            if (chkShow.Checked) frm4.Show();
            using (NpgsqlConnection dbConnection = new NpgsqlConnection(conString))
            {
                dbConnection.Open();
                using (NpgsqlCommand dbCmd = dbConnection.CreateCommand())
                {
                    lb1.ForeColor = System.Drawing.Color.White;
                    Application.DoEvents();
                    //--0 prepare network table
                    dbCmd.CommandText = steps[0];
                    frm4.txtFeedback.AppendText(dbCmd.CommandText + Environment.NewLine);
                    if (chkRun.Checked) dbCmd.ExecuteNonQuery();
                    //--check geometry type
                    dbCmd.CommandText = steps[1];
                    frm4.txtFeedback.AppendText(dbCmd.CommandText + Environment.NewLine);
                    if (chkRun.Checked)
                    {
                        test = (dbCmd.ExecuteScalar()).ToString();
                    }
                    else
                    {
                        test = "LINESTRING/MULTILINESTRING";
                    }
                    //--ensure 2D geometry
                    step = steps[2].Replace("#type", test);
                    dbCmd.CommandText = step;
                    frm4.txtFeedback.AppendText(dbCmd.CommandText + Environment.NewLine);
                    if (chkRun.Checked) dbCmd.ExecuteNonQuery();
                    //--build indexes
                    dbCmd.CommandText = steps[3];
                    frm4.txtFeedback.AppendText(dbCmd.CommandText + Environment.NewLine);
                    if (chkRun.Checked) dbCmd.ExecuteNonQuery();
                    //--ensure serial id
                    dbCmd.CommandText = steps[4];
                    frm4.txtFeedback.AppendText(dbCmd.CommandText + Environment.NewLine);
                    if (chkRun.Checked) dbCmd.ExecuteNonQuery();
                    lb1.ForeColor = System.Drawing.Color.DimGray;
                    pb1.Visible = true;

                    //--1 near table:: point id, nearest road id, and snap_distance
                    lb2.ForeColor = System.Drawing.Color.White;
                    Application.DoEvents();
                    dbCmd.CommandText = steps[5];
                    frm4.txtFeedback.AppendText(dbCmd.CommandText + Environment.NewLine);
                    if (chkRun.Checked) dbCmd.ExecuteNonQuery();
                    //--point table:: road id, intersection point
                    dbCmd.CommandText = steps[6];
                    frm4.txtFeedback.AppendText(dbCmd.CommandText + Environment.NewLine);
                    if (chkRun.Checked) dbCmd.ExecuteNonQuery();
                    lb2.ForeColor = System.Drawing.Color.DimGray;
                    pb2.Visible = true;

                    //--2 blades table:: road id, and blade's linestring
                    //--then combine blades by common road id
                    lb3.ForeColor = System.Drawing.Color.White;
                    Application.DoEvents();
                    dbCmd.CommandText = steps[7];
                    frm4.txtFeedback.AppendText(dbCmd.CommandText + Environment.NewLine);
                    if (chkRun.Checked) dbCmd.ExecuteNonQuery();
                    //--split existing road links
                    step = steps[8];
                    try
                    {
                        using (NpgsqlCommand dbCmd2 = dbConnection.CreateCommand())
                        {
                            //build a list of fields in the roadlinks table
                            dbCmd2.CommandText =
                                "select column_name from information_schema.columns"
                                + " where table_schema = @schm"
                                + " and table_name = @tbl;";
                            dbCmd2.Parameters.AddWithValue("schm", nwksch);
                            dbCmd2.Parameters.AddWithValue("tbl", nwktbl);
                            using (NpgsqlDataReader dbReader = dbCmd2.ExecuteReader())
                            {
                                while (dbReader.Read())
                                {
                                    if (dbReader[0].ToString() != nwkgeom)
                                    {
                                        sb.Append(dbReader[0].ToString() + ",");
                                    }
                                    else
                                    {
                                        sb.Append("(ST_Dump(ST_Split(r." + nwkgeom + ", b.geom))).geom As " + nwkgeom + ",");
                                    }
                                }
                            }
                        }
                        step = step.Replace("#fields#", sb.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    dbCmd.CommandText = step;
                    frm4.txtFeedback.AppendText(dbCmd.CommandText + Environment.NewLine);
                    if (chkRun.Checked) dbCmd.ExecuteNonQuery();
                    //--check geometry type
                    if (test == "MULTILINESTRING")
                    {
                        sb.Replace("(ST_Dump(ST_Split(r." + nwkgeom + ", b.geom))).geom", "ST_Multi(" + nwkgeom + ")");
                        dbCmd.CommandText = steps[9].Replace("#fields#", sb.ToString());
                        frm4.txtFeedback.AppendText(dbCmd.CommandText + Environment.NewLine);
                    }
                    else
                    {
                        dbCmd.CommandText = steps[10];
                        frm4.txtFeedback.AppendText(dbCmd.CommandText + Environment.NewLine);
                    }
                    if (chkRun.Checked) dbCmd.ExecuteNonQuery();
                    lb3.ForeColor = System.Drawing.Color.DimGray;
                    pb3.Visible = true;

                    //--5 remove old road links 
                    lb4.ForeColor = System.Drawing.Color.White;
                    Application.DoEvents();
                    dbCmd.CommandText = steps[11];
                    frm4.txtFeedback.AppendText(dbCmd.CommandText + Environment.NewLine);
                    if (chkRun.Checked) dbCmd.ExecuteNonQuery();
                    //--insert new road links
                    dbCmd.CommandText = steps[12];
                    frm4.txtFeedback.AppendText(dbCmd.CommandText + Environment.NewLine);
                    if (chkRun.Checked) dbCmd.ExecuteNonQuery();
                    lb4.ForeColor = System.Drawing.Color.DimGray;
                    pb4.Visible = true;
                }
                frm4.txtFeedback.AppendText("Task Completed @ " + DateTime.Now.ToShortTimeString());
                dbConnection.Close();
                btnQuit.Location = new System.Drawing.Point(553, 378);
                btnQuit.Visible = true;
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}