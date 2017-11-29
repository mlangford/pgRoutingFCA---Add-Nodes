using System;
using System.Windows.Forms;
using Npgsql;

namespace pgRoutingFCA
{
    public partial class Form1b : Form
    {
        public Form1b(string inString)
        {
            InitializeComponent();
            conString = inString;

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
                          //  + @" and type = 'POINT'"
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
            Form2 frm2 = new Form2(conString, cboNwkSchm.SelectedItem.ToString(),
                                                        cboNwkTbl.SelectedItem.ToString(),
                                                        tbNwkGeom.Text, tbEPSG.Text);
            this.Hide(); 
            frm2.Show();
        }
    }
}
