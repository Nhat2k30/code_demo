using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tuan12_HTTT_09DHTH6_SM11_BTVN
{
    public partial class SinhVien : Form
    {
        public SinhVien()
        {
            InitializeComponent();
        }
        Connect con = new Connect();
        XuLySinhVien xl = new XuLySinhVien();
        private void SinhVien_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            dataGridView1.DataSource = xl.loadDSSV();
            loadKhoa();
            loadLop(cbKhoa.SelectedValue.ToString());
        }
        public void loadKhoa()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Khoa", con.conSQL);
            da.Fill(dt);
            cbKhoa.DataSource = dt;
            cbKhoa.DisplayMember = "tenkhoa";
            cbKhoa.ValueMember = "makhoa";
        }
        public void loadLop(string makhoa)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Lop where makhoa='" + makhoa + "'", con.conSQL);
            da.Fill(dt);
            cbLop.DataSource = dt;
            cbLop.DisplayMember = "tenLop";
            cbLop.ValueMember = "malop";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbLop.SelectedValue = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtMaSV.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtHoTen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtNgaySinh.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (txtMaSV.Text.Length > 0 && txtHoTen.Text.Length > 0 && txtNgaySinh.Text.Length > 0)
            {
                if (xl.ktKhoaChinh(txtMaSV.Text))
                {
                    if (xl.them(txtMaSV.Text, txtHoTen.Text, txtNgaySinh.Text, cbLop.SelectedValue.ToString()))
                    {
                        MessageBox.Show("Thêm thành công");
                        dataGridView1.DataSource = xl.loadDSSV();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                }
                else
                    MessageBox.Show("Trùng");
            }
            else
                MessageBox.Show("Vui lòng nhập đủ thông tin");

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (xl.ktKhoaNgoai(txtMaSV.Text))
            {
                if (xl.xoa(txtMaSV.Text))
                {
                    MessageBox.Show("Xóa thành công");
                    dataGridView1.DataSource = xl.loadDSSV();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }
            else
                MessageBox.Show("Sinh viên không thể xóa");

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (xl.sua(txtMaSV.Text, txtHoTen.Text, txtNgaySinh.Text))
            {
                MessageBox.Show("sỬA tahnhf coogn");
                dataGridView1.DataSource = xl.loadDSSV();
            }
            else
                MessageBox.Show("Sửa thất bại");

        }

        private void cbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadLop(cbKhoa.SelectedValue.ToString());
        }

    }
}
