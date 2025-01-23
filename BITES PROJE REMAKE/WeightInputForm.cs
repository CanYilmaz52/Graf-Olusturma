using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BITES_PROJE_REMAKE
{
    public partial class WeightInputForm : Form
    {
        public int Weight { get; private set; }

        public WeightInputForm(int node1, int node2)
        {
            InitializeComponent();

            labelNodes.Text = $"Node {node1} - Node {node2}";
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            // Kullanıcının girdiği ağırlığı alın
            if (int.TryParse(txtWeight.Text, out int weight) && weight >= 0)
            {
                Weight = weight;
                // DialogResult'ı OK olarak ayarlayarak formun kapanmasını sağlayalım.
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Enter valid weight (0 or higher).");
            }
        }

        private void WeightInputForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent the key press from being processed further
                DialogResult = DialogResult.OK; // Close the form with OK result
            }
        }


        //Tuş vuruşlarını yakalamak için microsoft'un bünyesinde bulunan komutu kullandık.
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (int.TryParse(txtWeight.Text, out int weight) && weight >= 0)
                {
                    Weight = weight;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Enter valid weight (0 or higher).");
                }
                return true; // Suppress further processing of the Enter key press
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

}

