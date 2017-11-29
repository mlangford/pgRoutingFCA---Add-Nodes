using System;
using System.Windows.Forms;
using System.Data;
using System.Text;
using Npgsql;

namespace pgRoutingFCA
{
    public partial class Form2 : Form
    {
        public Form2(string inString, string inNwkSchm, string inNwkTbl, string inNwkGeom, string inNkwEPSG)
        {
            InitializeComponent();
            conString = inString;
            nwkSchm = inNwkSchm;
            nwkTbl = inNwkTbl;
            nwkGeom = inNwkGeom;
            nwkEPSG = inNkwEPSG;
            nwkName = inNwkSchm + "." + inNwkTbl;
        }

        string conString;
        string nwkSchm;
        string nwkTbl;
        string nwkName;
        string nwkGeom;
        string nwkEPSG;
        Form4 frm4 = new Form4();

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                //Create log
                frm4.Hide();

                using (NpgsqlConnection dbConnection = new NpgsqlConnection(conString))
                {
                    using (NpgsqlCommand dbCmd = dbConnection.CreateCommand())
                    {
                        dbCmd.CommandText =
                        "select schema_name from information_schema.schemata"
                        + " where schema_name NOT LIKE 'pg_%'"
                        + " and schema_name NOT LIKE 'information_schema'"
                        + " order by schema_name;";

                        dbConnection.Open();
                        using (NpgsqlDataReader dbReader = dbCmd.ExecuteReader())
                        {
                            while (dbReader.Read())
                            {
                                cboSupSchm.Items.Add(dbReader[0].ToString());
                                cboDemSchm.Items.Add(dbReader[0].ToString());
                            }
                            dbConnection.Close();
                            cboSupSchm.SelectedIndex = 0;
                            cboDemSchm.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cboSupSchm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //clear list of table names
                cboSupTbl.Items.Clear();
                cboSupTbl.SelectedIndex = -1;
                cboSupTbl.Text = "";
                cboSupTbl.Enabled = true;
                //clear list of demand volume fields
                cboSupVol.Items.Clear();
                cboSupVol.SelectedIndex = -1;
                cboSupVol.Text = "";
                cboSupVol.Enabled = false;
                //clear list if ID fields
                cboSupID.Items.Clear();
                cboSupID.SelectedIndex = -1;
                cboSupID.Text = "";
                cboSupID.Enabled = false;
                //repopulate all of above
                using (NpgsqlConnection dbConnection = new NpgsqlConnection(conString))
                {
                    using (NpgsqlCommand dbCmd = dbConnection.CreateCommand())
                    {
                        dbCmd.CommandText =
                            "select f_table_name from geometry_columns"
                            + " where f_table_schema = @schm"
                            + " and type = 'POINT'"
                            + " order by f_table_name;";

                        dbCmd.Parameters.AddWithValue("schm", cboSupSchm.SelectedItem.ToString());
                        dbConnection.Open();
                        using (NpgsqlDataReader dbReader = dbCmd.ExecuteReader())
                        {
                            while (dbReader.Read())
                            {
                                cboSupTbl.Items.Add(dbReader[0].ToString());
                            }
                        }
                        dbConnection.Close();
                        cboSupTbl.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cboDemSchm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboDemTbl.Items.Clear();
                cboDemTbl.SelectedIndex = -1;
                cboDemTbl.Text = "";
                cboDemTbl.Enabled = true;

                cboDemVol.Items.Clear();
                cboDemVol.SelectedIndex = -1;
                cboDemVol.Text = "";
                cboDemVol.Enabled = false;

                cboDemID.Items.Clear();
                cboDemID.SelectedIndex = -1;
                cboDemID.Text = "";
                cboDemID.Enabled = false;

                using (NpgsqlConnection dbConnection = new NpgsqlConnection(conString))
                {
                    using (NpgsqlCommand dbCmd = dbConnection.CreateCommand())
                    {
                        dbCmd.CommandText =
                            "select f_table_name from geometry_columns"
                            + " where f_table_schema = @schm"
                            + " and type = 'POINT'"
                            + " order by f_table_name;";

                        dbCmd.Parameters.AddWithValue("schm", cboDemSchm.SelectedItem.ToString());
                        dbConnection.Open();
                        using (NpgsqlDataReader dbReader = dbCmd.ExecuteReader())
                        {
                            while (dbReader.Read())
                            {
                                cboDemTbl.Items.Add(dbReader[0].ToString());
                            }
                        }
                        dbConnection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cboDemTbl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDemTbl.SelectedIndex != -1)
            {
                try
                {
                    cboDemID.Items.Clear();
                    cboDemVol.Items.Clear();
                    using (NpgsqlConnection dbConnection = new NpgsqlConnection(conString))
                    {
                        using (NpgsqlCommand dbCmd = dbConnection.CreateCommand())
                        {
                            dbCmd.CommandText =
                                "select column_name from information_schema.columns"
                                + " where table_schema = @schm"
                                + " and table_name = @tbl;";
                            dbCmd.Parameters.AddWithValue("schm", cboDemSchm.SelectedItem.ToString());
                            dbCmd.Parameters.AddWithValue("tbl", cboDemTbl.SelectedItem.ToString());
                            dbConnection.Open();
                            using (NpgsqlDataReader dbReader = dbCmd.ExecuteReader())
                            {
                                while (dbReader.Read())
                                {
                                    cboDemID.Items.Add(dbReader[0].ToString());
                                    cboDemVol.Items.Add(dbReader[0].ToString());
                                }
                            }
                            dbConnection.Close();
                            cboDemID.SelectedIndex = 0;
                            cboDemID.Enabled = true;
                            cboDemVol.SelectedIndex = 0;
                            cboDemVol.Enabled = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void btnExecute_Click(object sender, EventArgs e)
        {
            //update UI, start process timer
            btnExecute.Enabled = false;
            DateTime startTime = DateTime.Now;
            Application.DoEvents();
            if (cb3.Checked)
                frm4.Show();
            frm4.textBox1.AppendText("Model run begins at " + startTime.ToString() + Environment.NewLine);
            frm4.textBox1.AppendText("dbConnection: " + conString + Environment.NewLine);

            //setup data storage structures
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            StringBuilder sb = new StringBuilder();
            string cmdText;
            string ODname;
            Boolean test;

            //gather model settings from UI
            string supSchm = cboSupSchm.SelectedItem.ToString();
            string supTbl = cboSupTbl.SelectedItem.ToString();
            string supName = supSchm + "." + supTbl;
            string supCode = cboSupID.SelectedItem.ToString();
            string supVol = cboSupVol.SelectedItem.ToString();
            string fcaSize = nud_Size.Value.ToString();

            string demSchm = cboDemSchm.SelectedItem.ToString();
            string demTbl = cboDemTbl.SelectedItem.ToString();
            string demName = demSchm + "." + demTbl;
            string demCode = cboDemID.SelectedItem.ToString();
            string demVol = cboDemVol.SelectedItem.ToString();
            string demScore = tbFCA.Text;

            frm4.textBox1.AppendText("Supply table: " + supName + Environment.NewLine);
            frm4.textBox1.AppendText("Demand table: " + demName + Environment.NewLine);
            frm4.textBox1.AppendText("FCA threshold: " + fcaSize + Environment.NewLine);

            //create OD table name for this model
            ODname = supTbl + demTbl + fcaSize;

            //create a Command connected to the db
            using (NpgsqlConnection dbConnection = new NpgsqlConnection(conString))
            {
                dbConnection.Open();
                using (NpgsqlCommand dbCmd = dbConnection.CreateCommand())
                {
                    //determine if 'snapid' column exists in supply table
                    dbCmd.CommandText =
                    "Select Exists(Select 1 From information_schema.columns"
                    + " Where table_schema = '" + supSchm + "'" + " And table_name = '" + supTbl + "'"
                    + " And column_name ='snapid');";
                    test = Convert.ToBoolean(dbCmd.ExecuteScalar());
                    //if needed or requested, compute network snapids for supply points
                    if (cbSnapSup.Checked || !test)
                    {
                        showlabel("Snapping suppy points to network", 1000);
                        uswfcaEngine.snap_to_network(conString, nwkName + "_vertices_pgr", nwkEPSG, supSchm, supTbl, supCode);
                        frm4.textBox1.AppendText("Supply points snap-ids computed" + Environment.NewLine);
                    }
                    //if needed or requested, compute network snapids for demand points
                    dbCmd.CommandText =
                    "Select Exists(Select 1 From information_schema.columns"
                    + " Where table_schema = '" + demSchm + "'" + " And table_name = '" + demTbl + "'"
                    + " And column_name ='snapid');";
                    test = Convert.ToBoolean(dbCmd.ExecuteScalar());
                    if (cbSnapDem.Checked || !test)
                    {
                        showlabel("Snapping demand points to network", 1000);
                        uswfcaEngine.snap_to_network(conString, nwkName + "_vertices_pgr", nwkEPSG, demSchm, demTbl, demCode);
                        frm4.textBox1.AppendText("Demand points snap-ids computed" + Environment.NewLine);
                    }

                    //construct list of supply ids and service capacities
                    dt1.Clear();
                    cmdText = "Select " + supCode + ", snapid, " + supVol + " From " + supName + " order by " + supCode + ";";
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmdText, dbConnection))
                    {
                        da.Fill(dt1);
                    }

                    //test if OD table already exists, and if so, whether to re-use?
                    DialogResult ans = DialogResult.No;
                    dbCmd.CommandText =
                       "Select Exists(Select 1 From information_schema.tables"
                    + " Where table_schema = 'public' And table_name = '" + ODname + "');";
                    test = Convert.ToBoolean(dbCmd.ExecuteScalar());
                    if (test)
                    {
                        Form3 frm3 = new Form3();
                        ans = frm3.ShowDialog();
                    }
                    if (ans != DialogResult.Yes)
                    {
                        //compute new OD table
                        showlabel("Computing network distances", 1000);
                        frm4.textBox1.AppendText("Network tracing started at " + DateTime.Now.ToString() + Environment.NewLine);

                        //create straight-line OD list - all Demand points that fall within 
                        // straight-line FCA threshold distance of each Supply point...
                        //    if using time must translate this to a worst-case distance
                        //    e.g. distance travelled if moving at fastest road speed 

                        cmdText = "Drop Table If Exists " + ODname + ";"
                        + "Create Table " + ODname + " As"
                        + " Select supply." + supCode + " as supid, supply.snapid as supsnp,"
                        + " supply." + supVol + " as supvol,"
                        + " demand." + demCode + " as demid, demand.snapid as demsnp,"
                        + " demand." + demVol + " as demvol, ST_Distance(supply.geom,demand.geom) as sld"
                        + " From " + supName + " As supply"
                        + " Join " + demName + " As demand"
                        + " On ST_DWithin(supply.geom, demand.geom, " + fcaSize + ")"
                        + " Order by supid, sld;"
                        + " Alter Table " + ODname + " Add Column nwd Float;"
                        + " Alter Table " + ODname + " Add Primary Key (supid, demid);";
                        dbCmd.CommandText = cmdText;
                        dbCmd.ExecuteNonQuery();

                        //
                        //compute network distances
                        //

                        //for each supply id, compute network distance to all candidate demands
                        int i = 0;
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = dt1.Rows.Count;
                        progressBar1.Visible = true;

                        double lostCapacity=0.0;
                        int lostPoints=0;
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            cmdText = "Select * from pgr_dijkstraCost("
                            + "'select id, source, target, cost_len as cost from " + nwkName + "', "
                            + dr1["snapid"].ToString()
                            + ", array(Select demsnp from " + ODname + " where supid = " + dr1[0].ToString() + "), false)";
                            try
                            {
                                using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmdText, dbConnection))
                                {
                                    dt2.Clear();
                                    da.Fill(dt2);
                                }
                            }
                            catch
                            {
                                //no demand points found for this supply point
                                frm4.textBox1.AppendText("No demands for supply id " + dr1[0].ToString() + " with capacity " + dr1[2].ToString() + Environment.NewLine);
                                lostPoints++;
                                lostCapacity += Convert.ToDouble(dr1[2]);
                            }

                            //write network distance of demand point to OD table
                            sb.Clear();
                            foreach (DataRow dr2 in dt2.Rows)
                            {
                                sb.Append("Update " + ODname + " Set nwd = " + dr2["agg_cost"].ToString()
                                + " Where (supid = " + dr1[0].ToString() + " And demsnp = " + dr2[1].ToString() + ");");
                            }
                            dbCmd.CommandText = sb.ToString();
                            dbCmd.ExecuteNonQuery();
                            i++;
                            progressBar1.Value = i;
                         }

                        frm4.textBox1.AppendText("Network tracing ended at " + DateTime.Now.ToString() + Environment.NewLine);
                        frm4.textBox1.AppendText("Unreached supply points: " + lostPoints.ToString() + Environment.NewLine);
                        frm4.textBox1.AppendText("Unreached supply capacity: " + lostCapacity.ToString() + Environment.NewLine);

                        //if supply and demand points snap to same node (nwd = 0)
                        // set network distance to be the straight-line distance
                        if (cb1.Checked)
                        {
                            dbCmd.CommandText = "Update " + ODname + " Set nwd = sld Where supsnp = demsnp;";
                            int k = dbCmd.ExecuteNonQuery();
                            frm4.textBox1.AppendText("snap zero nwds reset: " + k.ToString() + Environment.NewLine);
                        }
                        //if snapped nodes are closer than start locations (nwd < sld)
                        // set  network distance to be the straight-line distance
                        if (cb2.Checked)
                        {
                            dbCmd.CommandText = "Update " + ODname + " Set nwd = sld Where nwd < sld;";
                            int k = dbCmd.ExecuteNonQuery();
                            frm4.textBox1.AppendText("snap small nwds reset: " + k.ToString() + Environment.NewLine);
                        }
                        progressBar1.Visible = false;
                    }


                    // E2SFCA calculations
                    showlabel("Computing E2SFCA, step1...", 2000);

                    //create 'Ak' column
                    dbCmd.CommandText =
                    "Alter Table " + supName + " Drop Column If Exists Ak;" +
                    "Alter Table " + supName + " Add Column Ak Float;";
                    dbCmd.ExecuteNonQuery();

                    //calculate total demand volume for each supply
                    sb.Clear();
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        dbCmd.CommandText =
                        "Select sum(demvol) from " + ODname + " Where supid = " + dr1[0].ToString()
                        + " And nwd <= " + fcaSize + " And nwd is not null;";
                        object ret = dbCmd.ExecuteScalar();
                        if (ret != DBNull.Value)
                        {
                            //store availability score of supply point
                            sb.Append("Update " + supName + " Set Ak = "
                            + (Convert.ToDouble(dr1[2]) / Convert.ToDouble(ret)).ToString()
                            + " Where " + supCode + " = " + dr1[0].ToString() + ";");
                        }
                    }
                    dbCmd.CommandText = sb.ToString();
                    dbCmd.ExecuteNonQuery();

                    showlabel("Computing E2SFCA step2...", 2000);
                    //calculate FCA score for each demand point
                    dbCmd.CommandText =
                    "Drop Table If Exists demtotals;"
                    + "Create Table demtotals As"
                    + " Select a.demid, sum(b.Ak) As fca From " + ODname + " As a"
                    + " Join " + supName + " As b"
                    + " On a.supid = b." + supCode + " And nwd <= " + fcaSize
                    + " Group by a.demid;";
                    dbCmd.ExecuteNonQuery();

                    //create output column
                    dbCmd.CommandText =
                    "Alter Table " + demName + " Drop Column If Exists " + demScore + ";" 
                    + "Alter Table " + demName + " Add Column " + demScore + " Float;";
                    dbCmd.ExecuteNonQuery();
                    //copy scores to demand table
                    dbCmd.CommandText = "Update " + demName
                    + " Set  "+ demScore + " = demtotals.fca"
                    + " From demtotals" 
                    + " Where demtotals.demid = " + demCode + ";";
                    dbCmd.ExecuteNonQuery();

                    //using (NpgsqlDataReader dbReader = dbCmd.ExecuteReader())
                    //{
                    //    while (dbReader.Read())
                    //    {
                    //    }
                    //}

                    ////construct list of demand ids
                    //dt1.Clear();
                    //cmdText = @"Select " + demCode + " From " + demName + " order by " + demCode + ";";
                    //using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmdText, dbConnection))
                    //{
                    //    da.Fill(dt1);
                    //}

                    ////sum availability scores for each demand point
                    //double fcascore;
                    //foreach (DataRow dr1 in dt1.Rows)
                    //{
                    //    dbCmd.CommandText = @"Select supid from " + ODname + " where demid = "
                    //        + dr1[0].ToString() + " And nwd <= " + fcaSize + ";";
                    //    using (NpgsqlDataReader dbReader = dbCmd.ExecuteReader())
                    //    {
                    //        fcascore = 0;
                    //        while (dbReader.Read())
                    //        {
                    //            fcascore += supCounts[Convert.ToInt32(dbReader[0])];
                    //        }
                    //    }
                    //    dbCmd.CommandText = "Update " + demName + " Set " + demScore
                    //        + " = " + fcascore + " where " + demCode + " = " + dr1[0].ToString() + ";";
                    //    dbCmd.ExecuteNonQuery();
                    //}
                }
            }

            DateTime endTime = DateTime.Now;
            frm4.textBox1.AppendText("Model ends begins at " + endTime.ToString() + Environment.NewLine);
            lbFeedbac.Text = "Run completed in: " + (endTime - startTime).ToString("hh':'mm':'ss");
            lbFeedbac.Visible = true;
            btnExecute.Enabled = true;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void cboSupTbl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSupTbl.SelectedIndex != -1)
            {
                try
                {
                    cboSupID.Items.Clear();
                    cboSupVol.Items.Clear();
                    using (NpgsqlConnection dbConnection = new NpgsqlConnection(conString))
                    {
                        using (NpgsqlCommand dbCmd = dbConnection.CreateCommand())
                        {
                            dbCmd.CommandText =
                                "select column_name from information_schema.columns"
                                + " where table_schema = @schm"
                                + " and table_name = @tbl;";
                            dbCmd.Parameters.AddWithValue("schm", cboSupSchm.SelectedItem.ToString());
                            dbCmd.Parameters.AddWithValue("tbl", cboSupTbl.SelectedItem.ToString());
                            dbConnection.Open();
                            using (NpgsqlDataReader dbReader = dbCmd.ExecuteReader())
                            {
                                while (dbReader.Read())
                                {
                                    cboSupID.Items.Add(dbReader[0].ToString());
                                    cboSupVol.Items.Add(dbReader[0].ToString());
                                }
                                dbConnection.Close();
                            }
                            cboSupID.SelectedIndex = 0;
                            cboSupID.Enabled = true;
                            cboSupVol.SelectedIndex = 0;
                            cboSupVol.Enabled = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        //display a feedback label
        private void showlabel(string detail, int time)
        {
            lbFeedbac.Text = detail;
            lbFeedbac.Visible = true;
            Application.DoEvents();
            timer1.Interval = time;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbFeedbac.Visible = false;
            Application.DoEvents();
            timer1.Stop();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void tbFCA_Leave(object sender, EventArgs e)
        {
            if (tbFCA.Text.Length==0)
            {
                showlabel("Error: FCA output field mandatory",1000);
                tbFCA.Focus();
                btnExecute.Enabled = false;
            }
            else
            {
                btnExecute.Enabled = true;
            }
        }

        private void tbFCA_TextChanged(object sender, EventArgs e)
        {
            if (tbFCA.Text.Length > 0)
                btnExecute.Enabled = true;
        }

    }
}