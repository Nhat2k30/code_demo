using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Tuan12_HTTT_09DHTH6_SM11_BTVN
{
    class XuLySinhVien
    {
        Connect con = new Connect();
        public DataTable loadDSSV()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("Select * from SinhVien", con.conSQL);
            da.Fill(ds, "SinhVien");
            return ds.Tables["SinhVien"];
        }
       
        public bool ktKhoaChinh(string masv)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from SinhVien", con.conSQL);
            da.Fill(ds, "SinhVien");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["SinhVien"].Columns[0];
            ds.Tables["SinhVien"].PrimaryKey = key;
            DataRow dr = ds.Tables["SinhVien"].Rows.Find(masv);
            if (dr != null)
            {
                return false;
            }
            return true;
        }
        public bool ktKhoaNgoai(string masv)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from Diem", con.conSQL);
            da.Fill(ds, "Diem");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["Diem"].Columns[0];
            ds.Tables["Diem"].PrimaryKey = key;
            DataRow dr = ds.Tables["Diem"].Rows.Find(masv);
            if (dr != null)
            {
                return false;
            }
            return true;
        }
        public bool them(string masv, string hoten, string ngaysinh, string malop)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("Select * from SinhVien", con.conSQL);
            da.Fill(ds, "SinhVien");
            DataRow dr = ds.Tables["SinhVien"].NewRow();
            if (dr != null)
            {
                dr["masinhvien"] = masv;
                dr["hoten"] = hoten;
                dr["ngaysinh"] = ngaysinh;
                dr["malop"] = malop;
            }
            ds.Tables["SinhVien"].Rows.Add(dr);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            da.Update(ds, "SinhVien");
            return true;


        }
        public bool xoa(string masv)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("Select * from SinhVien", con.conSQL);
            da.Fill(ds, "SinhVien");            
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["SinhVien"].Columns[0];
            ds.Tables["SinhVien"].PrimaryKey = key;
            DataRow dr = ds.Tables["SinhVien"].Rows.Find(masv);
            if (dr != null)
            {
                dr.Delete();
            }
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            da.Update(ds, "SinhVien");
            return true;
        }
        public bool sua(string masv, string hoten, string ngaysinh)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("Select * from SinhVien", con.conSQL);
            da.Fill(ds, "SinhVien");
            DataColumn[] key = new DataColumn[1];
            key[0] = ds.Tables["SinhVien"].Columns[0];
            ds.Tables["SinhVien"].PrimaryKey = key;
            DataRow dr = ds.Tables["SinhVien"].Rows.Find(masv);
            if (dr != null)
            {
                dr["hoten"] = hoten;
                dr["ngaysinh"] = ngaysinh;
                
            }
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            da.Update(ds, "SinhVien");
            return true;

        }
    }
    
}
