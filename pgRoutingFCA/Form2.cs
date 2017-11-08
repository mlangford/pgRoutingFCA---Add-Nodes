using System;
using System.Windows.Forms;
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
                cboSupTbl.Items.Clear();
                cboSupTbl.SelectedIndex = -1;
                cboSupTbl.Text = "";
                cboSupTbl.Enabled = true;

                cboSupVol.Items.Clear();
                cboSupVol.SelectedIndex = -1;
                cboSupVol.Text = "";
                cboSupVol.Enabled = false;

                cboSupID.Items.Clear();
                cboSupID.SelectedIndex = -1;
                cboSupID.Text = "";
                cboSupID.Enabled = false;

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

            using (NpgsqlConnection dbConnection = new NpgsqlConnection())
            {
                dbConnection.ConnectionString = conString;
                using (NpgsqlCommand dbCmd = dbConnection.CreateCommand())
                {

                    string supName = cboSupSchm.SelectedItem.ToString() + "." + cboSupTbl.SelectedItem.ToString();
                    string supCode = cboSupID.SelectedItem.ToString();
                    string supVolm = cboSupVol.SelectedItem.ToString();

                    string demName = cboDemSchm.SelectedItem.ToString() + "." + cboDemTbl.SelectedItem.ToString();
                    string demCode = cboDemID.SelectedItem.ToString();
                    string demVolm = cboDemVol.SelectedItem.ToString();
                    string demScor = cboFCAOut.SelectedItem.ToString();

                    string fcaSize = nud_Size.Value.ToString();

                    string sql1 = "";
                    if (rbNone.Checked)
                    {
                        sql1 = @"Create Table fcastep1a As"
                               + @" Select supply." + supCode + ", sum(demand." + demVolm + ") As demand"
                               + @" From " + supName + " As supply"
                               + @" Join " + demName + " As demand"
                               + @" On ST_DWithin(supply.geom, demand.geom, " + fcaSize + ")"
                               + @" Group By (supply." + supCode + ")";
                    }
                    else
                    {
                        sql1 = @"Create Table fcastep1a As"
                               + @" Select supply." + supCode + ", sum(cast(demand." + demVolm + " as double precision) * "
                               + @"(1.0 - (ST_Distance(supply.geom, demand.geom) / cast(" + fcaSize + " as double precision)))) As demand"
                               + @" From " + supName + " As supply"
                               + @" Join " + demName + " As demand"
                               + @" On ST_DWithin(supply.geom, demand.geom, " + fcaSize + ")"
                               + @" Group By (supply." + supCode + ")";
                    }

                    string sql2 = @"Create Table fcastep1b As"
                                     + @" Select a." + supCode + ", cast(a." + supVolm + " as double precision) / cast(b.demand as double precision) As avail, a.geom"
                                     + @" From " + supName + " As a  Join fcastep1a As b On a." + supCode + " = b." + supCode + ";";

                    string sql3 = "";
                    if (rbNone.Checked)
                    {
                        sql3 = @"Create Table fcascores As"
                               + @" Select demand." + demCode + ", sum(step1.avail) As fca_score"
                               + @" From " + demName + " As demand"
                               + @" Join fcastep1b As step1"
                               + @" On ST_DWithin(demand.geom, step1.geom, " + fcaSize + ")"
                               + @" Group By (demand." + demCode + ");";
                    }
                    else
                    {
                        sql3 = @"Create Table fcascores As"
                               + @" Select demand." + demCode + ", sum(step1.avail * "
                               + @"(1.0 - (ST_Distance(demand.geom, step1.geom)/cast(" + fcaSize + " as double precision)))) as fca_score"
                               + @" From " + demName + " As demand"
                               + @" Join fcastep1b As step1"
                               + @" On ST_DWithin(demand.geom, step1.geom, " + fcaSize + ")"
                               + @" Group By (demand." + demCode + ");";
                    }

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
    }
}