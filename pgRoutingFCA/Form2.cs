using System;
using System.Windows.Forms;
using System.Collections.Generic;
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
            cboSupVol.Enabled = true;
            try
            {
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
                                cboSupVol.Items.Add(dbReader[0].ToString());
                            }
                            dbConnection.Close();
                        }
                    }
                }
                cboSupVol.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cboDemVol_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboDemVol.Enabled = true;
            try
            {
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
                                cboDemVol.Items.Add(dbReader[0].ToString());
                            }
                            dbConnection.Close();
                        }
                    }
                }
                cboDemVol.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            btnExecute.Enabled = false;
            DateTime startTime = DateTime.Now;
            Application.DoEvents();

            Dictionary<int, double> demCounts =  new Dictionary<int,double>();

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
                    dbCmd1.CommandText =
                    @"Select Exists(Select 1 From information_schema.columns"
                    +@" Where table_schema = '" + supSchm +"'"
                    +@" And table_name = '" + supTbl +"'"
                    +@" And column_name ='snapid');";

                    dbConnection.Open();
                    Boolean test = Convert.ToBoolean(dbCmd1.ExecuteScalar());
                    dbConnection.Close();

                    //check if need to recompute network snap IDs
                    if (cbSnapSup.Checked || !test)
                    {
                        dbCmd1.CommandText =
                        @"Alter Table " + supName + " Drop Column If Exists snapid;" +
                        @"Alter Table " + supName + " Add Column snapid Integer;";
                        dbConnection.Open();
                        dbCmd1.ExecuteNonQuery();
                        dbConnection.Close();
                    }
                    /*
                        @"Select st_x(geom), st_y(geom) from crowflies.lsoasupplys;";
                    dbConnection.Open();         



                    using (NpgsqlConnection dbConnection = new NpgsqlConnection())
                    {
                        dbConnection.ConnectionString = conString;
                        using (NpgsqlCommand dbCmd = dbConnection.CreateCommand())
                        {
                            dbCmd.CommandText =
                            @"Select st_x(geom), st_y(geom) from crowflies.lsoasupplys;";
                            dbConnection.Open();
                            using (NpgsqlDataReader dbReader = dbCmd.ExecuteReader())
                            {
                                while (dbReader.Read())
                                {
                                    dbCmd2.CommandText =
                                    @"Select id::integer From or_apr17.wales"
                                    + @" Order By geom <-> ST_SetSrid(ST_MakePoint("
                                    + @dbReader[0].ToString() + "," + dbReader[1].ToString()
                                    + @"), 27700)  LIMIT 1;";
                                    //executescalar
                                    //insert this value into the supplytble snapid field
                                }
                                dbConnection.Close();
                            }
                    }/*
                            //# Step2: for each feature in the demand layer        
                            //                    for demFeat in demLayer.getFeatures():
                            //                # get its coordinates and attributes
                            //                geom = demFeat.geometry()
                            //                        xD = geom.asPoint().x()
                            //                        yD = geom.asPoint().y()
                            //                        demAttrs = demFeat.attributes()
                            //                # get a list of supply features from the index that
                            //# are potentially within the fca threshold distance  
                            //                sids = supIdx.intersects(demFeat.geometry().buffer(fca, -1).boundingBox())
                            //                        for id in sids:
                            //                    # get each candidate feature 
                            //                    select = supLayer.getFeatures(QgsFeatureRequest().setFilterFid(id))
                            //                    for supFeat in select:
                            //                        geom = supFeat.geometry()
                            //                        xS = geom.asPoint().x()
                            //                        yS = geom.asPoint().y()

                            //                        # compute the crow-flies distance between demand and supply features
                            //                        dist = math.sqrt((xS - xD) * *2 + (yS - yD) * *2)

                            //                        # tally the total distance calcs
                            //                        totalpairs += 1
                            //                        if (not totalpairs % 1500):
                            //                            self.dlg.lblVer.setText(str(totalpairs))
                            //                            QApplication.processEvents()

                            //                        # FCA step 2: if supply and demand points are within threshold distance there must
                            //# be an entry in the depTotal dictionary associated with this supply point
                            //                    if dist <= fca:   
                            //                            indistance += 1
                            //                            # get supply feature's attributes
                            //                            supAttrs = supFeat.attributes()

                            //                            # scale the supply volume using a linear distance-decay formula
                            //                    supAmnt = float(supAttrs[supFld]) / float(demTotal[supAttrs[0]])
                            //                            supAmnt = supAmnt * (1.0 - (float(dist) / float(fca)))

                            //                            # insert or update the availability score for this demand point
                            //                    if supTotal.has_key(demAttrs[0]):
                            //                                supTotal[demAttrs[0]] += supAmnt
                            //                            else:
                            //                                supTotal[demAttrs[0]] = supAmnt

                            /*
                             * For each feature in the supply table create a list of the features
                             * in the demand table which might be inside FCA threshold distance
                             * 
                             * {if using a time cost field would have to translate this into a worst-case
                             *  distance measure - eg how far if tavelling at fastest toad speed }
                             */

                    //get set of candidate Demand points - those that lie within
                    //the straight-line FCA threshold distance...

                    /*string sql1 = @"Create Table Delete If Exists Candidates As"
                                  + @" Select supply." + supCode + ", supply.geom" 
                                  + @", demand." + demCode + ", demand.geom, demand." + demVolm
                                  + @" From " + supName + " As supply"
                                  + @" Join " + demName + " As demand"
                                  + @" On ST_DWithin(supply.geom, demand.geom, " + fcaSize + ");";

                    // use location of each supply-demand pair to compute network distance
                    // match each point to nearest network node
                    // then compute network distance/cost between supply-demand pair

                    // SELECT seq from ways order by geom <-> ST_SetSrid(ST_MakePoint(long, lat), 4326) limit 1;

                    // network tracing

                    // final check; is network distance/cost inside FCA threshold
                    if (nwd <= fca)
                    {
                        // indistance += 1
                        // get demand feature's attributes
                        //         demAttrs = demFeat.attributes()
                        // scale demand volume using distance decay function
                        // and add to current demand tally for this supply point
                        // scale with a linear distance-decay
                        //          demAmnt = demAttrs[demFld] * (1.0 - (float(dist) / float(fca)))             
                    }
                    
                    // FCA step 1: insert or update demand volume for this supply feature
                    if (demCounts.ContainsKey(cboSupID))
                    {
                        demCounts.Add(cboSupID, demandVol);
                    }
                    else
                    {
                        demCounts[cboSupID] += demandVol;
                    }

        //REPEAT FOR STEP 2 FCA

                    string sql4 = @"Update " + demName
                                     + @" Set(" + demScor + ") = (fcascores.fca_score)"
                                     + @" From fcascores"
                                     + @" Where " + demName + "." + demCode + " = fcascores." + demCode + ";";

                    dbConnection.Open();

                    //sum demand around each supply point
                    dbCmd.CommandText = @"Drop Table If Exists fcastep1a;";
                    dbCmd.ExecuteNonQuery();
                    dbCmd.CommandText = sql1;
                    dbCmd.ExecuteNonQuery();

                    dbCmd.CommandText = @"Drop Table If Exists fcastep1b;";
                    dbCmd.ExecuteNonQuery();
                    dbCmd.CommandText = sql2;
                    dbCmd.ExecuteNonQuery();

                    dbCmd.CommandText = @"Drop Table If Exists fcaScores;";
                    dbCmd.ExecuteNonQuery();
                    dbCmd.CommandText = sql3;
                    dbCmd.ExecuteNonQuery();

                    dbCmd.CommandText = sql4;
                    dbCmd.ExecuteNonQuery();

                    dbConnection.Close();
                    */
                }
            }

            DateTime endTime = DateTime.Now;
            Double elapsedMillisecs = ((TimeSpan)(endTime - startTime)).TotalMilliseconds;
            label13.Text = "Last computation time (milliseconds): " + elapsedMillisecs.ToString();
            btnExecute.Enabled = true;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void label7_Click(object sender, EventArgs e)
        {


        }
    }
}