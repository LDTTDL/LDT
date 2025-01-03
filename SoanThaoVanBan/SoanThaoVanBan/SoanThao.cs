using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SoanThaoVanBan
{
    public partial class SoanThao : Form
    {
        public SoanThao()
        {
            InitializeComponent();
        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbContent.Clear();
            this.Text = "Untitled - Text Editor";
        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rtbContent.Text = File.ReadAllText(openFileDialog.FileName);
                this.Text = openFileDialog.FileName;
            }
        }

        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rtbContent.Text = File.ReadAllText(openFileDialog.FileName);
                this.Text = openFileDialog.FileName;
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void thayĐổiFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                rtbContent.Font = fontDialog.Font;
            }
        }

        private void inĐậmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtbContent.SelectionFont != null)
            {
                Font currentFont = rtbContent.SelectionFont;
                FontStyle newStyle = currentFont.Style ^ FontStyle.Bold; 
                rtbContent.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
            }
        }

        private void inNghiêngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtbContent.SelectionFont != null)
            {
                Font currentFont = rtbContent.SelectionFont;
                FontStyle newStyle = currentFont.Style ^ FontStyle.Italic; 
                rtbContent.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
            }
        }

        private void gạchChânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtbContent.SelectionFont != null)
            {
                Font currentFont = rtbContent.SelectionFont;
                FontStyle newStyle = currentFont.Style ^ FontStyle.Underline;
                rtbContent.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            rtbContent.Clear();
            this.Text = "Untitled - Text Editor";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, rtbContent.Text);
                MessageBox.Show("File saved successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void cmbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rtbContent.SelectionFont != null)
            {
                Font currentFont = rtbContent.SelectionFont;
                string selectedFont = cmbFont.SelectedItem.ToString();
                rtbContent.SelectionFont = new Font(selectedFont, currentFont.Size, currentFont.Style);
            }
        }
        private void cmbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rtbContent.SelectionFont != null)
            {
                Font currentFont = rtbContent.SelectionFont;
                float newSize = float.Parse(cmbFontSize.SelectedItem.ToString());
                rtbContent.SelectionFont = new Font(currentFont.FontFamily, newSize, currentFont.Style);
            }
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            if (rtbContent.SelectionFont != null)
            {
                Font currentFont = rtbContent.SelectionFont;
                FontStyle newStyle = currentFont.Style ^ FontStyle.Bold;
                rtbContent.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
            }
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            if (rtbContent.SelectionFont != null)
            {
                Font currentFont = rtbContent.SelectionFont;
                FontStyle newStyle = currentFont.Style ^ FontStyle.Italic; 
                rtbContent.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
            }
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            if (rtbContent.SelectionFont != null)
            {
                Font currentFont = rtbContent.SelectionFont;
                FontStyle newStyle = currentFont.Style ^ FontStyle.Underline; 
                rtbContent.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
            }
        }

        private void SoanThao_Load(object sender, EventArgs e)
        {
            foreach (FontFamily font in FontFamily.Families)
            {
                cmbFont.Items.Add(font.Name);
            }
            cmbFont.SelectedIndex = 0;

            for (int i = 8; i <= 72; i += 2)
            {
                cmbFontSize.Items.Add(i.ToString());
            }
            cmbFontSize.SelectedIndex = 2; 
        }
    }
}
