using System;
using System.Windows.Forms;
using Npgsql;


namespace pgRoutingFCA
{
    public partial class Form1b : Form
    {
        public Form1b(string inConStr, string inOutTbl,
            string inNwkSch, string inNwkTbl, string inNwkGeom)
        {
            InitializeComponent();
            conString = inConStr;
            nwksch = inNwkSch;
            nwktbl = inNwkTbl;
            nwkgeom = inNwkGeom;
            outtbl = inOutTbl;
            fullname = nwksch +  "." + nwktbl;
        }
        string conString;
        string nwksch;
        string nwktbl;
        string nwkgeom;
        string outtbl;
        string fullname;

        private void Form1c_Load(object sender, EventArgs e)
        {
            try
            {
                //populate dropdown with schema list
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
                                cboPntSchm.Items.Add(dbReader[0].ToString());
                            }
                            //set to display the first schema item
                            cboPntSchm.SelectedIndex = 0;
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

        private void cboPntSchm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //clear previous entries
                cboPntTbl.Items.Clear();
                cboPntTbl.SelectedIndex = -1;
                cboPntTbl.Text = "";
                //repopulate dropdown list of table names
                using (NpgsqlConnection dbConnection = new NpgsqlConnection(conString))
                {
                    using (NpgsqlCommand dbCmd = dbConnection.CreateCommand())
                    {
                        dbCmd.CommandText =
                            "select f_table_name from geometry_columns"
                            + " where f_table_schema = @schm"
                            + " and type = 'POINT'"
                            + " order by f_table_name;";
                        dbCmd.Parameters.AddWithValue("schm", cboPntSchm.SelectedItem.ToString());
                        dbConnection.Open();
                        using (NpgsqlDataReader dbReader = dbCmd.ExecuteReader())
                        {
                            while (dbReader.Read())
                            {
                                cboPntTbl.Items.Add(dbReader[0].ToString());
                            }
                        }
                        dbConnection.Close();
                        cboPntTbl.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cboPntTbl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPntTbl.SelectedIndex != -1)
            {
                try
                {
                    //clear previous entries
                    cboPntGeom.Items.Clear();
                    //display list of fields
                    using (NpgsqlConnection dbConnection = new NpgsqlConnection(conString))
                    {
                        using (NpgsqlCommand dbCmd = dbConnection.CreateCommand())
                        {
                            dbConnection.Open();
                            dbCmd.CommandText =
                                "select column_name from information_schema.columns"
                                + " where table_schema = @schm"
                                + " and table_name = @tbl;";
                            dbCmd.Parameters.AddWithValue("schm", cboPntSchm.SelectedItem.ToString());
                            dbCmd.Parameters.AddWithValue("tbl", cboPntTbl.SelectedItem.ToString());
                            using (NpgsqlDataReader dbReader = dbCmd.ExecuteReader())
                            {
                                while (dbReader.Read())
                                {
                                    cboPntGeom.Items.Add(dbReader[0].ToString());
                                }
                            }
                            int i = cboPntGeom.FindString("geom");
                            if (i == -1)
                            {
                                i = cboPntGeom.FindString("the_geom");
                                if (i == -1)
                                    i = 0;
                            }
                            cboPntGeom.SelectedIndex = i;
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

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(conString, outtbl,
                nwksch, nwktbl, nwkgeom, 
                cboPntSchm.SelectedItem.ToString(),
                cboPntTbl.SelectedItem.ToString(),
                cboPntGeom.SelectedItem.ToString(),
                txtSRID.Text);
            this.Hide();
            frm2.Show();
        }
    }
}
