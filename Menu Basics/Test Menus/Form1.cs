using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test_Menus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mnuQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to Quit ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectedText != "")
            {
                textBox1.Cut();
            }
        }

        private void mnuUndo_Click(object sender, EventArgs e)
        {
            if (textBox1.CanUndo)
            {
                textBox1.Undo();
                textBox1.ClearUndo();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            if (textBox1.SelectionLength > 0)
            {
                textBox1.Copy();
            }
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                textBox2.Paste();
             //   Clipboard.Clear();
            }
        }

        private void mnuViewTextBoxes_Click(object sender, EventArgs e)
        {
            mnuViewTextBoxes.Checked = !mnuViewTextBoxes.Checked;

            if (mnuViewTextBoxes.Checked)
            {
                textBox1.Visible = true;
                textBox2.Visible = true;
            }
            else
            {
                textBox1.Visible = false;
                textBox2.Visible = false;
            }
        }

        private void mnuViewLabels_Click(object sender, EventArgs e)
        {
            mnuViewLabels.Checked = !mnuViewLabels.Checked;

            if (mnuViewLabels.Checked)
            {
                label1.Visible = true;
                label2.Visible = true;
            }
            else
            {
                label1.Visible = false;
                label2.Visible = false;
            }
        }

        private void mnuViewImages_Click(object sender, EventArgs e)
        {
            string ChosenFile = "";
            
            openFD.Title = "Select an image file ...";
            openFD.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFD.FileName = "";
            openFD.Filter = "JPEG Images|*.jpg|GIF Images|*.gif|BITMAPS|*.bmp";

  //          openFD.ShowDialog();              // was getting two Dialog boxes, doh!
            ChosenFile = openFD.FileName;

            if (openFD.ShowDialog() == DialogResult.OK)     //  check ok or cancel before open
            {
                ChosenFile = openFD.FileName;
                pictureBox1.Image = Image.FromFile(ChosenFile);
            }

        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            string ChosenFile = "";

            openFD.Title = "Select a RichText file ...";
            openFD.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFD.FileName = "";
            openFD.Filter = "Rich Text|*.rtf|Word|*.doc";

  //          openFD.ShowDialog();                
            ChosenFile = openFD.FileName;

            if (openFD.ShowDialog() == DialogResult.Cancel)     // Alternate ok/cancel check
                {
                MessageBox.Show("Operation Cancelled");
                }
            else
                {
                    ChosenFile = openFD.FileName;
                    richTextBox1.LoadFile(ChosenFile, RichTextBoxStreamType.PlainText);
                }
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            string SaveFile = "";

            saveFD.Title = "Save a Text file ...";
            saveFD.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFD.FileName = "";
            saveFD.Filter = "Text files|*.txt|Rich files|*.rtf|All files|*.*";

   //         saveFD.ShowDialog();                          
            SaveFile = saveFD.FileName;

            if (saveFD.ShowDialog() != DialogResult.Cancel)     //  another way to check
            {
                SaveFile = saveFD.FileName;
                richTextBox1.SaveFile(SaveFile, RichTextBoxStreamType.PlainText);
            }
        }
    }
}
