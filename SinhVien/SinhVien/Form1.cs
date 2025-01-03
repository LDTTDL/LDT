using System;
using System.Linq;
using System.Windows.Forms;
using SinhVien.ENFW;

namespace SinhVien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var context = new QuanLySinhVienEntities1())
            {
    
                var students = context.Student.Select(s => new
                {
                    s.StudentID,
                    s.FullName,
                    s.AverageScore,
                    FacultyName = s.Faculty.FacultyName
                }).ToList();

  
                dgvSinhVien.DataSource = students;

    
                cmbKhoa.DataSource = context.Faculty.ToList();
                cmbKhoa.DisplayMember = "FacultyName";
                cmbKhoa.ValueMember = "FacultyID";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            using (var context = new QuanLySinhVienEntities1())
            {
                var student = new Student
                {
                    StudentID = txtMaSV.Text,
                    FullName = txtHoTen.Text,
                    AverageScore = double.Parse(txtDiemTB.Text),
                    FacultyID = (int)cmbKhoa.SelectedValue
                };

                context.Student.Add(student);
                context.SaveChanges();

                MessageBox.Show("Thêm sinh viên thành công!");
                Form1_Load(sender, e);
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            using (var context = new QuanLySinhVienEntities1())
            {
                var studentID = txtMaSV.Text;
                var student = context.Student.FirstOrDefault(s => s.StudentID == studentID);

                if (student != null)
                {
                    student.FullName = txtHoTen.Text;
                    student.AverageScore = double.Parse(txtDiemTB.Text);
                    student.FacultyID = (int)cmbKhoa.SelectedValue;

                    context.SaveChanges();

                    MessageBox.Show("Sửa thông tin sinh viên thành công!");
                    Form1_Load(sender, e); 
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên!");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (var context = new QuanLySinhVienEntities1())
            {
                var studentID = txtMaSV.Text;
                var student = context.Student.FirstOrDefault(s => s.StudentID == studentID);

                if (student != null)
                {
                    context.Student.Remove(student);
                    context.SaveChanges();

                    MessageBox.Show("Xóa sinh viên thành công!");
                    Form1_Load(sender, e); 
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên!");
                }
            }
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSinhVien.Rows[e.RowIndex];

                txtMaSV.Text = row.Cells["StudentID"].Value.ToString();
                txtHoTen.Text = row.Cells["FullName"].Value.ToString();
                txtDiemTB.Text = row.Cells["AverageScore"].Value.ToString();

                // Chọn đúng khoa trong ComboBox
                cmbKhoa.Text = row.Cells["FacultyName"].Value.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
