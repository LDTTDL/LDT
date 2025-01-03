using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanVien
{
    public partial class ListViewForm : Form
    {
        public ListViewForm()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            NhanVienForm form = new NhanVienForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                dataGridViewNhanVien.Rows.Add(form.MSNV, form.TenNV, form.LuongCB);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridViewNhanVien.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewNhanVien.SelectedRows[0];
                NhanVienForm form = new NhanVienForm
                {
                    MSNV = row.Cells["MSNV"].Value.ToString(),
                    TenNV = row.Cells["TenNV"].Value.ToString(),
                    LuongCB = row.Cells["LuongCB"].Value.ToString()
                };

                if (form.ShowDialog() == DialogResult.OK)
                {
                    row.Cells["MSNV"].Value = form.MSNV;
                    row.Cells["TenNV"].Value = form.TenNV;
                    row.Cells["LuongCB"].Value = form.LuongCB;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewNhanVien.SelectedRows.Count > 0)
            {
                dataGridViewNhanVien.Rows.Remove(dataGridViewNhanVien.SelectedRows[0]);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa.");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
