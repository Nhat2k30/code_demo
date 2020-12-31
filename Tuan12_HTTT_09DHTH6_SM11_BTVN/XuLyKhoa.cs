using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Tuan12_HTTT_09DHTH6_SM11_BTVN
{
    class XuLyKhoa
    {
        Connect con = new Connect();
        public DataTable loadDSKhoa()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Khoa", con.conSQL);
            da.Fill(ds, "Khoa");
            return ds.Tables["Khoa"];

        }
        public bool ktTrungKhoaChinh(string makhoa)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Khoa", con.conSQL);
            da.Fill(ds, "Khoa");

            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["Khoa"].Columns[0];
            ds.Tables["Khoa"].PrimaryKey = key;
            DataRow dr = ds.Tables["Khoa"].Rows.Find(makhoa);
            if (dr != null)
            {
                return false;
            }
            return true;
        }
        public bool ktKhoaNgoai(string makhoa)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Lop where makhoa = '" + makhoa + "'", con.conSQL);
            da.Fill(ds, "Lop");
            if (ds.Tables["Lop"].Rows.Count > 0)
            {
                return false;
            }
            return true;
        }
        public bool them(string makhoa, string tenkhoa)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Khoa", con.conSQL);
            da.Fill(ds, "Khoa");
            DataRow dr = ds.Tables["Khoa"].NewRow();
            if (dr != null)
            {
                dr["makhoa"] = makhoa;
                dr["tenkhoa"] = tenkhoa;
            }
            ds.Tables["Khoa"].Rows.Add(dr);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            da.Update(ds, "Khoa");
            return true;
        }
        public bool xoa(string makhoa)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Khoa", con.conSQL);
            da.Fill(ds, "Khoa");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["Khoa"].Columns[0];
            ds.Tables["Khoa"].PrimaryKey = key;
            DataRow dr = ds.Tables["Khoa"].Rows.Find(makhoa);
            if (dr != null)
            {
                dr.Delete();
            }
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            da.Update(ds, "Khoa");
            return true;
        }
        public bool sua(string makhoa, string tenkhoa)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Khoa", con.conSQL);
            da.Fill(ds, "Khoa");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["Khoa"].Columns[0];
            ds.Tables["Khoa"].PrimaryKey = key;
            DataRow dr = ds.Tables["Khoa"].Rows.Find(makhoa);

            if (dr != null)
            {
                dr["tenkhoa"] = tenkhoa;
            }
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            da.Update(ds, "Khoa");
            return true;
        }
    }
}
