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
                using (NpgsqlConnection dbConnection = new NpgsqlConnection())
                {
                    dbConnection.ConnectionString = conString;
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
                using (NpgsqlConnection dbConnection = new NpgsqlConnection())
                {
                    dbConnection.ConnectionString = conString;
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

                using (NpgsqlConnection dbConnection = new NpgsqlConnection())
                {
                    dbConnection.ConnectionString = conString;
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
                    using (NpgsqlConnection dbConnection = new NpgsqlConnection())
                    {
                        dbConnection.ConnectionString = conString;
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
            btnExecute.Enabled = false;
            DateTime startTime = DateTime.Now;
            Application.DoEvents();

            Dictionary<int, double> demCounts = new Dictionary<int, double>();
            StringBuilder sb = new StringBuilder();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            List<int> snaps = new List<int>();
            string cmdText;

            string supSchm = cboSupSchm.SelectedItem.ToString();
            string supTbl = cboSupTbl.SelectedItem.ToString();
            string supName = supSchm + "." + supTbl;
            string supCode = cboSupID.SelectedItem.ToString();
            string supVolm = cboSupVol.SelectedItem.ToString();

            string demSchm = cboDemSchm.SelectedItem.ToString();
            string demTbl = cboDemTbl.SelectedItem.ToString();
            string demName = demSchm + "." + demTbl;
            string demCode = cboDemID.SelectedItem.ToString();
            string demVolm = cboDemVol.SelectedItem.ToString();
            string demScor = cboFCAOut.SelectedItem.ToString();
            string fcaSize = nud_Size.Value.ToString();

            using (NpgsqlConnection dbConnection = new NpgsqlConnection())
            {
                dbConnection.ConnectionString = conString;
                using (NpgsqlCommand dbCmd1 = dbConnection.CreateCommand())
                {
                    //determine if a 'snapid' column exists in the supply table
                    dbCmd1.CommandText =
                    @"Select Exists(Select 1 From information_schema.columns"
                    + @" Where table_schema = '" + supSchm + "'"
                    + @" And table_name = '" + supTbl + "'"
                    + @" And column_name ='snapid');";
                    dbConnection.Open();
                    Boolean test = Convert.ToBoolean(dbCmd1.ExecuteScalar());

                    //if needed, or requested, recompute network snapids
                    if (cbSnapSup.Checked || !test)
                    {
                        showlabel("snapping supplies", 1000);
                        dbCmd1.CommandText =
                        @"Alter Table " + supName + " Drop Column If Exists snapid;" +
                        @"Alter Table " + supName + " Add Column snapid Integer;";
                        dbCmd1.ExecuteNonQuery();
                        //get all supply point coordinates stored in a datatable
                        cmdText = @"Select " + supCode + ", St_X(geom), St_Y(geom) From " + supName + ";";
                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmdText, dbConnection))
                        {
                            da.Fill(dt1);
                        }
                        //find nearest network node for each supply point, store in a List
                        foreach (DataRow dr in dt1.Rows)
                        {
                            dbCmd1.CommandText =
                            @"Select id::integer From or_apr17.jst_wales_vertices_pgr"
                            + @" Order By the_geom <-> ST_SetSrid(ST_MakePoint("
                            + dr[1].ToString() + "," + dr[2].ToString() + @"), 27700)  LIMIT 1;";
                            snaps.Add(Convert.ToInt32(dbCmd1.ExecuteScalar()));
                        }
                        //build Insert String to update table with snapids
                        int k = 0;
                        foreach (DataRow dr in dt1.Rows)
                        {
                            sb.Append("Update " + supName + " Set snapid = " + snaps[k++].ToString());
                            sb.AppendLine(" Where " + supCode + " = " + dr[0].ToString() + ";");
                        }
                        dbCmd1.CommandText = sb.ToString();
                        dbCmd1.ExecuteNonQuery();
                    }

                    //repeat for Demand points
                    dbCmd1.CommandText =
                    @"Select Exists(Select 1 From information_schema.columns"
                    + @" Where table_schema = '" + demSchm + "'"
                    + @" And table_name = '" + demTbl + "'"
                    + @" And column_name ='snapid');";
                    test = Convert.ToBoolean(dbCmd1.ExecuteScalar());
                    if (cbSnapDem.Checked || !test)
                    {
                        showlabel("snapping demands", 1000);
                        dbCmd1.CommandText =
                        @"Alter Table " + demName + " Drop Column If Exists snapid;" +
                        @"Alter Table " + demName + " Add Column snapid Integer;";
                        dbCmd1.ExecuteNonQuery();
                        dt1.Clear();
                        snaps.Clear();
                        cmdText = @"Select " + demCode + ", St_X(geom), St_Y(geom) From " + demName + ";";
                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmdText, dbConnection))
                        {
                            da.Fill(dt1);
                        }
                        foreach (DataRow dr in dt1.Rows)
                        {
                            dbCmd1.CommandText =
                            @"Select id::integer From or_apr17.jst_wales_vertices_pgr"
                            + @" Order By the_geom <-> ST_SetSrid(ST_MakePoint("
                            + dr[1].ToString() + "," + dr[2].ToString() + @"), 27700)  LIMIT 1;";
                            snaps.Add(Convert.ToInt32(dbCmd1.ExecuteScalar()));
                        }
                        sb.Clear();
                        int k = 0;
                        foreach (DataRow dr in dt1.Rows)
                        {
                            sb.Append("Update " + demName + " Set snapid = " + snaps[k++].ToString());
                            sb.AppendLine(" Where " + demCode + " = " + dr[0].ToString() + ";");
                        }
                        dbCmd1.CommandText = sb.ToString();
                        dbCmd1.ExecuteNonQuery();
                    }

                    // get list of candidate Demand points - those within the
                    // straight-line FCA threshold distance of each Supply point...
                    //    if using a time cost field must translate this to a worst-case
                    //    distance measure - distance travelling at fastest road speed 
                    showlabel("computing network distances", 1000);
                    cmdText = @"Drop Table If Exists candidates;"
                    + @"Create Table candidates As"
                    + @" Select supply." + supCode + " as supid, supply.snapid as supsnp,"
                    + @" demand." + demCode + " as demid, demand.snapid as demsnp,"
                    + @" demand." + demVolm + " as vol, St_Distance(supply.geom,demand.geom) as sld"
                    + @" From " + supName + " As supply"
                    + @" Join " + demName + " As demand"
                    + @" On ST_DWithin(supply.geom, demand.geom, " + fcaSize + ")"
                    + @" Order by supid, demid;"
                    + @" Alter Table candidates Add Column nwd Float;"
                    + @" Alter Table candidates Add Primary Key (supid, demid);";
                    dbCmd1.CommandText = cmdText;
                    dbCmd1.ExecuteNonQuery();

                    //compute network distance/cost between supply-demand pair

                    //get list of supply ids
                    dt1.Clear();
                    string dacmdText = @"Select " + supCode + ", snapid From " + supName +";";
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(dacmdText, dbConnection))
                    {
                        da.Fill(dt1);
                    }

                    //for each supply id compute network distance to all candidate demands
                    int i = 0;
                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        String da2cmdText = "Select * from pgr_dijkstraCost("
                        + "'select id, source, target, cost_len as cost from or_apr17.jst_wales', "
                        + dr1[1].ToString() + ", array(select demsnp from candidates where supsnp = " + dr1[1].ToString() + "), false)";
                        dt2.Clear();
                        try
                        {
                            using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(da2cmdText, dbConnection))
                            {
                                da.Fill(dt2);
                            }
                            foreach (DataRow dr2 in dt2.Rows)
                            {
                                dbCmd1.CommandText = "Update candidates Set nwd = " + dr2[2].ToString()
                                + " Where (supid = " + dr1[0].ToString() + " And demsnp = " + dr2[1].ToString() + ");";
                                dbCmd1.ExecuteNonQuery();
                            }
                            i++;
                        }
                        catch
                        {
                        }
                    }

                    dbConnection.Close();
                    MessageBox.Show("Done: " + i.ToString() );
                }
            }

        }


        // final check; is network distance/cost within FCA threshold
        //if (nwd <= fca)
        //{
        // indistance += 1
        // get demand feature's attributes
        //         demAttrs = demFeat.attributes()
        // scale demand volume using distance decay function
        // and add to current demand tally for this supply point
        // scale with a linear distance-decay
        //          demAmnt = demAttrs[demFld] * (1.0 - (float(dist) / float(fca)))             
        //}

        // FCA step 1: insert or update demand volume for this supply feature
        //if (demCounts.ContainsKey(cboSupID))
        //{
        //    demCounts.Add(cboSupID, demandVol);
        //}
        //else
        //{
        //    demCounts[cboSupID] += demandVol;
        //}

        //REPEAT FOR STEP 2 FCA

        //DateTime endTime = DateTime.Now;
        //Double elapsedMillisecs = ((TimeSpan)(endTime - startTime)).TotalMilliseconds;
        //label13.Text = "Last computation time (milliseconds): " + elapsedMillisecs.ToString();
        //btnExecute.Enabled = true;

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
                    using (NpgsqlConnection dbConnection = new NpgsqlConnection())
                    {
                        dbConnection.ConnectionString = conString;
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