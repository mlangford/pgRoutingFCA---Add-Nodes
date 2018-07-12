using System;
using System.Windows.Forms;
using Npgsql;

namespace pgRoutingFCA
{
    public partial class Form1a : Form
    {
        public Form1a(string inConStr)
        {
            InitializeComponent();
            conString = inConStr;
        }
        string conString;

        private void Form1b_Load(object sender, EventArgs e)
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
                                cboNwkSchm.Items.Add(dbReader[0].ToString());
                            }
                            dbConnection.Close();
                            cboNwkSchm.SelectedIndex = 0;
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
                cboNwkTbl.Items.Clear();
                cboNwkTbl.SelectedIndex = -1;
                cboNwkTbl.Text = "";
                cboNwkTbl.Enabled = true;
                //repopulate table names
                using (NpgsqlConnection dbConnection = new NpgsqlConnection(conString))
                {
                    using (NpgsqlCommand dbCmd = dbConnection.CreateCommand())
                    {
                        dbCmd.CommandText =
                            @"select f_table_name from geometry_columns"
                            + @" where f_table_schema = @schm"
                           + @" and f_table_name NOT LIKE '%_vertices_%'"
                           + @" and f_table_name NOT LIKE '%_backup'"
                            + @" order by f_table_name;";

                        dbCmd.Parameters.AddWithValue("schm", cboNwkSchm.SelectedItem.ToString());
                        dbConnection.Open();
                        using (NpgsqlDataReader dbReader = dbCmd.ExecuteReader())
                        {
                            while (dbReader.Read())
                            {
                                cboNwkTbl.Items.Add(dbReader[0].ToString());
                            }
                            dbConnection.Close();
                        }
                        cboNwkTbl.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Form1b frm1b = new Form1b(conString, txtOutTbl.Text,
                cboNwkSchm.SelectedItem.ToString(),
                cboNwkTbl.SelectedItem.ToString(),
                cboNwkGeom.SelectedItem.ToString());
            this.Hide(); 
            frm1b.Show();
        }

        private void txtTargetTbl_TextChanged(object sender, EventArgs e)
        {
            btnExecute.Enabled = (txtOutTbl.Text.Length > 0);
        }

        private void cboSourceTbl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNwkTbl.SelectedIndex != -1)
            {
                try
                {
                    cboNwkGeom.Items.Clear();
                    using (NpgsqlConnection dbConnection = new NpgsqlConnection(conString))
                    {
                        using (NpgsqlCommand dbCmd = dbConnection.CreateCommand())
                        {
                            dbConnection.Open();
                            dbCmd.CommandText =
                                "select column_name from information_schema.columns"
                                + " where table_schema = @schm"
                                + " and table_name = @tbl;";
                            dbCmd.Parameters.AddWithValue("schm", cboNwkSchm.SelectedItem.ToString());
                            dbCmd.Parameters.AddWithValue("tbl", cboNwkTbl.SelectedItem.ToString());
                            using (NpgsqlDataReader dbReader = dbCmd.ExecuteReader())
                            {
                                while (dbReader.Read())
                                {
                                    cboNwkGeom.Items.Add(dbReader[0].ToString());
                                }
                            }
                            int i = cboNwkGeom.FindString("geom");
                            if (i == -1)
                            {
                                i = cboNwkGeom.FindString("the_geom");
                                if (i == -1)
                                    i = 0;
                            }
                            cboNwkGeom.SelectedIndex = i;
                            dbConnection.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
