using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Npgsql;

namespace pgRoutingFCA
{
    public partial class Form2 : Form
    {
        public Form2(string inString)
        {
            InitializeComponent();
            conString = inString;
        }

        string conString;

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection dbConnection = new NpgsqlConnection(conString))
                {
                    using (NpgsqlCommand dbCmd = dbConnection.CreateCommand())
                    {
                        dbCmd.CommandText =
                        @"select schema_name from information_schema.schemata"
                        + @" where schema_name NOT LIKE 'pg_%'"
                        + @" and schema_name NOT LIKE 'information_schema'"
                        + @" order by schema_name;";

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
                //clear list if table names
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
                            @"select f_table_name from geometry_columns"
                            + @" where f_table_schema = @schm"
                            + @" and type = 'POINT'"
                            + @" order by f_table_name;";

                        dbCmd.Parameters.AddWithValue("schm", cboSupSchm.SelectedItem.ToString());
                        dbConnection.Open();
                        using (NpgsqlDataReader dbReader = dbCmd.ExecuteReader())
                        {
                            while (dbReader.Read())
                            {
                                cboSupTbl.Items.Add(dbReader[0].ToString());
                            }
                            dbConnection.Close();
                        }
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

                cboFCAOut.Items.Clear();
                cboFCAOut.SelectedIndex = -1;
                cboFCAOut.Text = "";
                cboFCAOut.Enabled = false;

                using (NpgsqlConnection dbConnection = new NpgsqlConnection(conString))
                {
                    using (NpgsqlCommand dbCmd = dbConnection.CreateCommand())
                    {
                        dbCmd.CommandText =
                            @"select f_table_name from geometry_columns"
                            + @" where f_table_schema = @schm"
                            + @" and type = 'POINT'"
                            + @" order by f_table_name;";

                        dbCmd.Parameters.AddWithValue("schm", cboDemSchm.SelectedItem.ToString());
                        dbConnection.Open();
                        using (NpgsqlDataReader dbReader = dbCmd.ExecuteReader())
                        {
                            while (dbReader.Read())
                            {
                                cboDemTbl.Items.Add(dbReader[0].ToString());
                            }
                            dbConnection.Close();
                        }
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
                    cboFCAOut.Items.Clear();
                    using (NpgsqlConnection dbConnection = new NpgsqlConnection(conString))
                    {
                        using (NpgsqlCommand dbCmd = dbConnection.CreateCommand())
                        {
                            dbCmd.CommandText =
                                @"select column_name from information_schema.columns"
                                + @" where table_schema = @schm"
                                + @" and table_name = @tbl;";
                            dbCmd.Parameters.AddWithValue("schm", cboDemSchm.SelectedItem.ToString());
                            dbCmd.Parameters.AddWithValue("tbl", cboDemTbl.SelectedItem.ToString());
                            dbConnection.Open();
                            using (NpgsqlDataReader dbReader = dbCmd.ExecuteReader())
                            {
                                while (dbReader.Read())
                                {
                                    cboDemID.Items.Add(dbReader[0].ToString());
                                    cboDemVol.Items.Add(dbReader[0].ToString());
                                    cboFCAOut.Items.Add(dbReader[0].ToString());
                                }
                                dbConnection.Close();
                            }
                            cboDemID.SelectedIndex = 0;
                            cboDemID.Enabled = true;
                            cboDemVol.SelectedIndex = 0;
                            cboDemVol.Enabled = true;
                            cboFCAOut.SelectedIndex = 0;
                            cboFCAOut.Enabled = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void cboSupVol_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboSupVol.Enabled = true;
            //try
            //{
            //    using (NpgsqlConnection dbConnection = new NpgsqlConnection())
            //    {
            //        dbConnection.ConnectionString = conString;
            //        using (NpgsqlCommand dbCmd = dbConnection.CreateCommand())
            //        {
            //            dbCmd.CommandText =
            //                @"select column_name from information_schema.columns"
            //                + @" where table_schema = @schm"
            //                + @" and table_name = @tbl;";
            //            dbCmd.Parameters.AddWithValue("schm", cboSupSchm.SelectedItem.ToString());
            //            dbCmd.Parameters.AddWithValue("tbl", cboSupTbl.SelectedItem.ToString());
            //            dbConnection.Open();

            //            using (NpgsqlDataReader dbReader = dbCmd.ExecuteReader())
            //            {
            //                while (dbReader.Read())
            //                {
            //                    cboSupVol.Items.Add(dbReader[0].ToString());
            //                }
            //                dbConnection.Close();
            //            }
            //        }
            //    }
            //    cboSupVol.SelectedIndex = 0;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: " + ex.Message);
            //}
        }

        private void cboDemVol_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboDemVol.Enabled = true;
            //try
            //{
            //    using (NpgsqlConnection dbConnection = new NpgsqlConnection())
            //    {
            //        dbConnection.ConnectionString = conString;
            //        using (NpgsqlCommand dbCmd = dbConnection.CreateCommand())
            //        {
            //            dbCmd.CommandText =
            //                @"select column_name from information_schema.columns"
            //                + @" where table_schema = @schm"
            //                + @" and table_name = @tbl;";
            //            dbCmd.Parameters.AddWithValue("schm", cboDemSchm.SelectedItem.ToString());
            //            dbCmd.Parameters.AddWithValue("tbl", cboDemTbl.SelectedItem.ToString());
            //            dbConnection.Open();
            //            using (NpgsqlDataReader dbReader = dbCmd.ExecuteReader())
            //            {
            //                while (dbReader.Read())
            //                {
            //                    cboDemVol.Items.Add(dbReader[0].ToString());
            //                }
            //                dbConnection.Close();
            //            }
            //        }
            //    }
            //    cboDemVol.SelectedIndex = 0;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error: " + ex.Message);
            //}
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            //update UI, start process timer
            btnExecute.Enabled = false;
            DateTime startTime = DateTime.Now;
            Application.DoEvents();

            //setup data storage structures
            Dictionary<int, double> demCounts = new Dictionary<int, double>();
            Dictionary<int, double> supCounts = new Dictionary<int, double>();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            List<int> snaps = new List<int>();
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
            string demScore = cboFCAOut.SelectedItem.ToString();

            //construct a OD tabel name for this model
            ODname = supTbl + demTbl + fcaSize;

            //connect to db, and set up a Command object
            using (NpgsqlConnection dbConnection = new NpgsqlConnection(conString))
            {
                dbConnection.Open();
                using (NpgsqlCommand dbCmd = dbConnection.CreateCommand())
                {
                    //determine if a 'snapid' column exists in selected supply table
                    dbCmd.CommandText =
                    @"Select Exists(Select 1 From information_schema.columns"
                    + @" Where table_schema = '" + supSchm + "'"
                    + @" And table_name = '" + supTbl + "'"
                    + @" And column_name ='snapid');";
                    test = Convert.ToBoolean(dbCmd.ExecuteScalar());
                    //if required, or requested, recompute the network snapids for supply points
                    if (cbSnapSup.Checked || !test)
                    {
                        showlabel("Snapping suppy points to network", 1000);
                        //create snapid column
                        dbCmd.CommandText =
                        @"Alter Table " + supName + " Drop Column If Exists snapid;" +
                        @"Alter Table " + supName + " Add Column snapid Integer;";
                        dbCmd.ExecuteNonQuery();
                        //put all supply point coordinates into datatable dt1
                        cmdText = @"Select " + supCode + " as id, St_X(geom) as x, St_Y(geom) as y From " + supName + ";";
                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmdText, dbConnection))
                        {
                            da.Fill(dt1);
                        }
                        //find nearest network node for each supply point, storing result in List "snaps"
                        foreach (DataRow dr in dt1.Rows)
                        {
                            dbCmd.CommandText =
                            @"Select id::integer From or_apr17.jst_wales_vertices_pgr"
                            + @" Order By the_geom <-> ST_SetSrid(ST_MakePoint("
                            + dr["x"].ToString() + "," + dr["y"].ToString() + @"), 27700)  LIMIT 1;";
                            snaps.Add(Convert.ToInt32(dbCmd.ExecuteScalar()));
                        }
                        //build Insert String to update Supply table with computed snapids
                        int k = 0;
                        foreach (DataRow dr in dt1.Rows)
                        {
                            sb.Append("Update " + supName + " Set snapid = " + snaps[k++].ToString());
                            sb.AppendLine(" Where " + supCode + " = " + dr["id"].ToString() + ";");
                        }
                        dbCmd.CommandText = sb.ToString();
                        dbCmd.ExecuteNonQuery();
                    }

                    //repeat process for Demand points
                    dbCmd.CommandText =
                    @"Select Exists(Select 1 From information_schema.columns"
                    + @" Where table_schema = '" + demSchm + "'"
                    + @" And table_name = '" + demTbl + "'"
                    + @" And column_name ='snapid');";
                    test = Convert.ToBoolean(dbCmd.ExecuteScalar());
                    //if required, or requested, recompute the network snapids for demand points
                    if (cbSnapDem.Checked || !test)
                    {
                        showlabel("Snapping demand points to network", 1000);
                        //create snapid column
                        dbCmd.CommandText =
                        @"Alter Table " + demName + " Drop Column If Exists snapid;" +
                        @"Alter Table " + demName + " Add Column snapid Integer;";
                        dbCmd.ExecuteNonQuery();
                        //put all supply point coordinates into datatable dt1
                        cmdText = @"Select " + demCode + " as id, St_X(geom) as x, St_Y(geom) as y From " + demName + ";";
                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmdText, dbConnection))
                        {
                            dt1.Clear();
                            da.Fill(dt1);
                        }
                        //find nearest network node for each demand point, storing result in List "snaps"
                        snaps.Clear();
                        foreach (DataRow dr in dt1.Rows)
                        {
                            dbCmd.CommandText =
                            @"Select id::integer From or_apr17.jst_wales_vertices_pgr"
                            + @" Order By the_geom <-> ST_SetSrid(ST_MakePoint("
                            + dr["x"].ToString() + "," + dr["y"].ToString() + @"), 27700)  LIMIT 1;";
                            snaps.Add(Convert.ToInt32(dbCmd.ExecuteScalar()));
                        }
                        //build Insert String to update Demand table with computed snapids
                        sb.Clear();
                        int k = 0;
                        foreach (DataRow dr in dt1.Rows)
                        {
                            sb.Append("Update " + demName + " Set snapid = " + snaps[k++].ToString());
                            sb.AppendLine(" Where " + demCode + " = " + dr["id"].ToString() + ";");
                        }
                        dbCmd.CommandText = sb.ToString();
                        dbCmd.ExecuteNonQuery();
                    }

                    //construct a list of all supply ids, and supply-side capacity
                    dt1.Clear();
                    cmdText = @"Select " + supCode + ", " + supVol + " From " + supName + " order by " + supCode + ";";
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmdText, dbConnection))
                    {
                        da.Fill(dt1);
                    }

                    //test if a OD table for the model already exists
                    DialogResult ans = DialogResult.No;
                    dbCmd.CommandText =
                       @"Select Exists(Select 1 From information_schema.tables"
                    + @" Where table_schema = 'public' And table_name = '" + ODname + "');";
                    test = Convert.ToBoolean(dbCmd.ExecuteScalar());
                    if (test)
                    {
                        Form3 frm3 = new Form3();
                        ans = frm3.ShowDialog();
                    }

                    //determine whether to compute OD table
                    if (ans != DialogResult.Yes)
                    {
                        showlabel("Computing network distances", 1000);

                        //first create straight-line OD list - all Demand points within the
                        // straight-line FCA threshold distance of each Supply point...
                        //    if using a time cost field must translate this to a worst-case
                        //    distance measure - distance travelling at fastest road speed 

                        cmdText = @"Drop Table If Exists " + ODname + ";"
                        + @"Create Table " + ODname + " As"
                        + @" Select supply." + supCode + " as supid, supply.snapid as supsnp,"
                        + @" supply." + supVol + " as supvol,"
                        + @" demand." + demCode + " as demid, demand.snapid as demsnp,"
                        + @" demand." + demVol + " as demvol, St_Distance(supply.geom,demand.geom) as sld"
                        + @" From " + supName + " As supply"
                        + @" Join " + demName + " As demand"
                        + @" On ST_DWithin(supply.geom, demand.geom, " + fcaSize + ")"
                        + @" Order by supid, demid;"
                        + @" Alter Table " + ODname + " Add Column nwd Float;"
                        + @" Alter Table " + ODname + " Add Primary Key (supid, demid);";
                        dbCmd.CommandText = cmdText;
                        dbCmd.ExecuteNonQuery();

                        //
                        //compute network distance/cost between supply-demand pairs
                        //

                        //for each supply id, compute network distance to all candidate demands
                        int i = 0;
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = dt1.Rows.Count;
                        progressBar1.Visible = true;
                        foreach (DataRow dr1 in dt1.Rows)
                        {
                            cmdText = "Select * from pgr_dijkstraCost("
                            + "'select id, source, target, cost_len as cost from or_apr17.jst_wales', "
                            + dr1["snapid"].ToString()
                            + ", array(Select demsnp from " + ODname + " where supsnp = " + dr1["snapid"].ToString() + "), false)";
                            try
                            {
                                using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmdText, dbConnection))
                                {
                                    dt2.Clear();
                                    da.Fill(dt2);
                                }
                                //for each candidate demand point, write network distance back to OD table
                                foreach (DataRow dr2 in dt2.Rows)
                                {
                                    dbCmd.CommandText = "Update " + ODname + " Set nwd = " + dr2[2].ToString()
                                    + " Where (supid = " + dr1[0].ToString() + " And demsnp = " + dr2[1].ToString() + ");";
                                    dbCmd.ExecuteNonQuery();
                                }
                                i++;
                                progressBar1.Value = i;

                                //if supply and demand snap to same node, set the
                                // network distance to equal straight-line distance
                                dbCmd.CommandText = "Update " + ODname + " Set nwd = sld Where supsnp = demsnp;";
                                MessageBox.Show("Supply and demand snaps to same node: " + dbCmd.ExecuteNonQuery().ToString());
                            }
                            catch
                            {
                            }
                        }
                    }
                    progressBar1.Visible = false;


                    // E2SFCA calculations

                    //compute demand totals for each supply
                    showlabel("Computing E2SFCA, step1...", 2000);
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        dbCmd.CommandText = @"Select sum(demvol) from " + ODname
                    + " Where supid = " + dr1[0].ToString()
                    + " And nwd <= " + fcaSize + " And nwd is not null;";
                        object ret = dbCmd.ExecuteScalar();
                        if (ret != DBNull.Value)
                        {
                            supCounts.Add(Convert.ToInt32(dr1[0]), Convert.ToDouble(ret));
                        }
                    }
                
                    //compute availability score of each supply point
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        if (supCounts.TryGetValue(Convert.ToInt32(dr1[0]), out double value))
                        {
                            supCounts[Convert.ToInt32(dr1[0])] = Convert.ToDouble(dr1[1]) / value;
                        }
                    }

                    showlabel("Computing E2SFCA step2...", 2000);
                    //construct list of all demand ids
                    dt1.Clear();
                    cmdText = @"Select " + demCode + " From " + demName + " order by " + demCode + ";";
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmdText, dbConnection))
                    {
                        da.Fill(dt1);
                    }

                    //sum availability scores for each demand point
                    double fcascore;
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        dbCmd.CommandText = @"Select supid from " + ODname + " where demid = "
                            + dr1[0].ToString() + " And nwd <= " + fcaSize + ";";
                        using (NpgsqlDataReader dbReader = dbCmd.ExecuteReader())
                        {
                            fcascore = 0;
                            while (dbReader.Read())
                            {
                                fcascore += supCounts[Convert.ToInt32(dbReader[0])];
                            }
                        }
                        dbCmd.CommandText = "Update " + demName + " Set " + demScore
                            + " = " + fcascore + " where " + demCode + " = " + dr1[0].ToString() + ";";
                        dbCmd.ExecuteNonQuery();
                    }
                }
            }
            DateTime endTime = DateTime.Now;
            Double elapsedMillisecs = ((TimeSpan)(endTime - startTime)).TotalMilliseconds;
            lbFeedbac.Text = "Run completed in (milliseconds): " + elapsedMillisecs.ToString();
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
                    cboFCAOut.Items.Clear();
                    using (NpgsqlConnection dbConnection = new NpgsqlConnection(conString))
                    {
                        using (NpgsqlCommand dbCmd = dbConnection.CreateCommand())
                        {
                            dbCmd.CommandText =
                                @"select column_name from information_schema.columns"
                                + @" where table_schema = @schm"
                                + @" and table_name = @tbl;";
                            dbCmd.Parameters.AddWithValue("schm", cboSupSchm.SelectedItem.ToString());
                            dbCmd.Parameters.AddWithValue("tbl", cboSupTbl.SelectedItem.ToString());
                            dbConnection.Open();
                            using (NpgsqlDataReader dbReader = dbCmd.ExecuteReader())
                            {
                                while (dbReader.Read())
                                {
                                    cboSupID.Items.Add(dbReader[0].ToString());
                                    cboSupVol.Items.Add(dbReader[0].ToString());
                                    cboFCAOut.Items.Add(dbReader[0].ToString());
                                }
                                dbConnection.Close();
                            }
                            cboSupID.SelectedIndex = 0;
                            cboSupID.Enabled = true;
                            cboSupVol.SelectedIndex = 0;
                            cboSupVol.Enabled = true;
                            cboFCAOut.SelectedIndex = 0;
                            cboFCAOut.Enabled = true;
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
    }
}