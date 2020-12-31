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
    public partial class Khoa : Form
    {
        public Khoa()
        {
            InitializeComponent();
        }
        XuLyKhoa xl = new XuLyKhoa();
        private void SinhVien_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = xl.loadDSKhoa();
            btnXoa.Enabled = btnSua.Enabled = btnLuu.Enabled = false;
            txtMaKhoa.Enabled = txtTenKhoa.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKhoa.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenKhoa.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            btnXoa.Enabled = btnSua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            txtMaKhoa.Enabled = txtTenKhoa.Enabled = true;
            txtMaKhoa.Clear();
            txtTenKhoa.Clear();
            txtMaKhoa.Focus();
            btnLuu.Enabled = true;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                if (xl.ktKhoaNgoai(txtMaKhoa.Text))
                {
                    if (xl.xoa(txtMaKhoa.Text))
                    {
                        MessageBox.Show("Xóa thành công");
                        dataGridView1.DataSource = xl.loadDSKhoa();
                    }
                    else
                        MessageBox.Show("Xóa thất bại");
                }
                else
                {
                    MessageBox.Show("Khoa này không thể xóa vì có tồn tại lớp trong khoa");
                }
            }
            else
                MessageBox.Show("Xác nhận không xóa");


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            txtMaKhoa.Enabled = false;
            txtTenKhoa.Focus();
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaKhoa.Enabled == true)
            {
                if (xl.ktTrungKhoaChinh(txtMaKhoa.Text))
                {
                    if (xl.them(txtMaKhoa.Text, txtTenKhoa.Text))
                    {
                        MessageBox.Show("Thêm thành công");
                        txtMaKhoa.Clear();
                        txtTenKhoa.Clear();
                        dataGridView1.DataSource = xl.loadDSKhoa();
                    }
                    else
                    {
                        MessageBox.Show("Không thành công");

                    }
                }
                else
                {
                    MessageBox.Show("Trùng khóa chính");

                }
            }
            else
            {




                if (xl.sua(txtMaKhoa.Text, txtTenKhoa.Text))
                {
                    MessageBox.Show("Sửa thành công");
                    dataGridView1.DataSource = xl.loadDSKhoa();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
        }

        private void txtTenKhoa_TextChanged(object sender, EventArgs e)
        {
            if (txtMaKhoa.Text.Length > 0 && txtTenKhoa.Text.Length > 0)
            {
                btnLuu.Enabled = true;
            }
            else
                btnLuu.Enabled = false;
        }
    }
    
}
