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
            Boolean test;
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
                    //determine if 'snapid' column exists in selected table
                    dbCmd.CommandText =
                    @"Select Exists(Select 1 From information_schema.columns"
                    + @" Where table_schema = '" + dbschema + "'"
                    + @" And table_name = '" + dbtable + "'"
                    + @" And column_name ='snapid');";
                    test = Convert.ToBoolean(dbCmd.ExecuteScalar());

                    //create a 'snapid' column
                    dbCmd.CommandText =
                    @"Alter Table " + fullname + " Drop Column If Exists snapid;" +
                    @"Alter Table " + fullname + " Add Column snapid Integer;";
                    dbCmd.ExecuteNonQuery();

                    //place all point coordinates into datatable
                    daCmdTxt = @"Select " + idcode + " as id, St_X(geom) as x, St_Y(geom) as y From " + fullname + ";";
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(daCmdTxt, dbConnection))
                    {
                        da.Fill(dtCoords);
                    }

                    //find nearest network node for each point, placing result in List "snaps"
                    foreach (DataRow dr in dtCoords.Rows)
                    {
                        dbCmd.CommandText =
                        "Select id::integer From " + dbnetwork
                        + " Order By the_geom <-> ST_SetSrid(ST_MakePoint("
                        + dr["x"].ToString() + "," + dr["y"].ToString() + "), " + epsg + ")  LIMIT 1;";

                        sb.AppendLine("Update " + fullname + " Set snapid = "
                            + dbCmd.ExecuteScalar().ToString()
                            + " Where " + idcode + " = " + dr["id"].ToString() + ";");
                    }
                    dbCmd.CommandText = sb.ToString();
                    dbCmd.ExecuteNonQuery();
                }
                dbConnection.Close();
            }
        }

        public static void computeODmatrix()
        {
        //    //first create straight-line OD list - all Demand points within the
        //    // straight-line FCA threshold distance of each Supply point...
        //    //    if using a time cost field must translate this to a worst-case
        //    //    distance measure - distance travelling at fastest road speed 

        //    cmdText = @"Drop Table If Exists " + ODname + ";"
        //    + @"Create Table " + ODname + " As"
        //    + @" Select supply." + supCode + " as supid, supply.snapid as supsnp,"
        //    + @" supply." + supVol + " as supvol,"
        //    + @" demand." + demCode + " as demid, demand.snapid as demsnp,"
        //    + @" demand." + demVol + " as demvol, St_Distance(supply.geom,demand.geom) as sld"
        //    + @" From " + supName + " As supply"
        //    + @" Join " + demName + " As demand"
        //    + @" On ST_DWithin(supply.geom, demand.geom, " + fcaSize + ")"
        //    + @" Order by supid, demid;"
        //    + @" Alter Table " + ODname + " Add Column nwd Float;"
        //    + @" Alter Table " + ODname + " Add Primary Key (supid, demid);";
        //    dbCmd.CommandText = cmdText;
        //    dbCmd.ExecuteNonQuery();

        //    //
        //    //compute network distance/cost between supply-demand pairs
        //    //

        //    //for each supply id, compute network distance to all candidate demands
        //    int i = 0;
        //    progressBar1.Minimum = 0;
        //    progressBar1.Maximum = dt1.Rows.Count;
        //    progressBar1.Visible = true;
        //    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmdText, dbConnection))
        //    {
        //        foreach (DataRow dr1 in dt1.Rows)
        //        {
        //            cmdText = "Select * from pgr_dijkstraCost("
        //            + "'select id, source, target, cost_len as cost from or_apr17.jst_wales', "
        //            + dr1[0].ToString()
        //            + ", array(Select demsnp from " + ODname + " where supsnp = " + dr1[0].ToString() + "), false)";
        //            try
        //            {
        //                {
        //                    dt2.Clear();
        //                    da.Fill(dt2);
        //                }
        //                //for each candidate demand point, write network distance back to OD table
        //                sb.Clear();
        //                foreach (DataRow dr2 in dt2.Rows)
        //                {
        //                    sb.AppendLine("Update " + ODname + " Set nwd = " + dr2[2].ToString()
        //                    + " Where (supid = " + dr1[0].ToString() + " And demsnp = " + dr2[1].ToString() + ");");
        //                    dbCmd.ExecuteNonQuery();
        //                }
        //                dbCmd.CommandText = sb.ToString();
        //                dbCmd.ExecuteNonQuery();
        //                i++;
        //                progressBar1.Value = i;

        //                //if supply and demand snap to same node, set the
        //                // network distance to equal straight-line distance
        //                dbCmd.CommandText = "Update " + ODname + " Set nwd = sld Where supsnp = demsnp;";
        //                dbCmd.ExecuteNonQuery().ToString();
        //                //                                MessageBox.Show("Supply and demand snaps to same node: " + dbCmd.ExecuteNonQuery().ToString());
        //            }
        //            catch
        //            {
        //            }
        //        }
        //    }
        //}
        //progressBar1.Visible = false;
        }

    }
}
