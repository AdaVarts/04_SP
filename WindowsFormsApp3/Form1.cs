using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        string process;

        public Form1()
        {
            InitializeComponent();
            
            var autostartProgramNames = key.GetValueNames();

            for (int i = 0; i < autostartProgramNames.Length; i++)
            {
                listBox1.Items.Add(autostartProgramNames[i]);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            key.DeleteValue(process);
            listBox1.Items.Remove(process);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                key.SetValue(openFileDialog.FileName, Application.ExecutablePath.ToString());
                listBox1.Items.Add(openFileDialog.FileName);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
                process = listBox1.SelectedItem.ToString();
        }
    }
}
