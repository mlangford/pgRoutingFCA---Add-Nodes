using System;
using System.Data;
using System.Text;
using Npgsql;

namespace pgRoutingFCA
{
    class uswfcaEngine
    {
        public static void snap_to_network(string dbconnect, string dbnetwork, string epsg, string dbschema, string dbtable, string idcode)
        {
            String daCmdTxt;
            String fullname = dbschema + "." + dbtable;
            StringBuilder sb = new StringBuilder();
            DataTable dtCoords = new DataTable();

            //connect to database
            using (NpgsqlConnection dbConnection = new NpgsqlConnection(dbconnect))
            {
                dbConnection.Open();

                //create command object
                using (NpgsqlCommand dbCmd = dbConnection.CreateCommand())
                {
                    //create a 'snapid' column
                    dbCmd.CommandText =
                    @"Alter Table " + fullname + " Drop Column If Exists snapid;" +
                    @"Alter Table " + fullname + " Add Column snapid Integer;";
                    dbCmd.ExecuteNonQuery();

                    //place all point coordinates into a datatable

                    daCmdTxt = @"Select " + idcode + " as id, St_X(geom) as x, St_Y(geom) as y From " + fullname + ";";
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(daCmdTxt, dbConnection))
                    {
                        da.Fill(dtCoords);
                    }

                    //check if integer or character identifier column
                    dbCmd.CommandText =@"Select data_type From information_schema.columns Where"
                                        + " table_name = '" + dbtable + "' and column_name = '" + idcode + "';";
                    string typ = dbCmd.ExecuteScalar().ToString();

                    if (typ.Substring(0,3) == "cha")
                    {
                        //find nearest network node for each point, placing result in List "snaps"
                        foreach (DataRow dr in dtCoords.Rows)
                        {
                            dbCmd.CommandText =
                            "Select id::integer From " + dbnetwork
                            + " Order By the_geom <-> ST_SetSrid(ST_MakePoint("
                            + dr["x"].ToString() + "," + dr["y"].ToString() + "), " + epsg + ")  LIMIT 1;";

                            sb.Append("Update " + fullname + " Set snapid = "
                                + dbCmd.ExecuteScalar().ToString()
                                + " Where " + idcode + " = '" + dr["id"].ToString() + "';");
                        }
                    }
                    else if (typ.Substring(0, 3) == "int")
                    {
                        //find nearest network node for each point, placing result in List "snaps"
                        foreach (DataRow dr in dtCoords.Rows)
                        {
                            dbCmd.CommandText =
                            "Select id::integer From " + dbnetwork
                            + " Order By the_geom <-> ST_SetSrid(ST_MakePoint("
                            + dr["x"].ToString() + "," + dr["y"].ToString() + "), " + epsg + ")  LIMIT 1;";

                            sb.Append("Update " + fullname + " Set snapid = "
                                + dbCmd.ExecuteScalar().ToString()
                                + " Where " + idcode + " = " + dr["id"].ToString() + ";");
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Must select an integer or text field for point ids", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        Environment.Exit(1);
                    }
                    dbCmd.CommandText = sb.ToString();
                    dbCmd.ExecuteNonQuery();
                }
                dbConnection.Close();
            }
        }
    }
}
