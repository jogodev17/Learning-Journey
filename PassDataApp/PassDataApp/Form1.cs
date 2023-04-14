using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PassDataApp
{
    public partial class Form1 : Form
    {
        static List<String> names = new List<string>();
        BindingSource bindingSourceNames = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            // form1 opens form 2

            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bindingSourceNames.DataSource = names;

            listBox1.DataSource = bindingSourceNames;
        }

        internal void receiveData(string newName)
        {
            names.Add(newName);
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            bindingSourceNames.ResetBindings(false);
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;

            if (i >= 0)
            {
                DialogResult result = MessageBox.Show($"Would you like to delete {names[i]}?", "Confirm delete", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    names.RemoveAt(i);
                    bindingSourceNames.ResetBindings(false);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "A -> Z")
            {
                names.Sort();
            }
            else
            {
                names.Sort();
                names.Reverse();
            }
            bindingSourceNames.ResetBindings(false);

        }
    }
}
