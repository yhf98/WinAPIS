using MetroFramework.Forms;
using System;
using System.Windows.Forms;
using WinAPIS.DBH;


namespace WinAPIS
{
    public partial class Message : MetroForm
    {
        public Message()
        {
            InitializeComponent();
        }

        private void Message_Load(object sender, EventArgs e)
        {

        }

        private void Carinformation_Click(object sender, EventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Enabled = true;
            if (comboBox2.Text == "会员车辆")
            {
                label9.Text = "会员车辆";               
                textBox4.Enabled = false;
                textBox4.Text = "无法输入";
            }
            else if (comboBox2.Text == "充值车辆")
            {
                label9.Text = "充值车辆";
                textBox4.Enabled = true;
                textBox4.Text = "";
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Main f = new Main();
            f.Show();
            this.Hide();
        }

        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsNumber(e.KeyChar))&&e.KeyChar!=(char)8)
            {
                e.Handled = true;
            }
          
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
          
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string type = comboBox2.Text;
            string name = textBox1.Text;
            string sex = comboBox1.Text;
            string  phone = textBox2.Text;
            string sfz = textBox3.Text;
            string money = textBox4.Text;
            DataServer.AddCar(type,name,sex,phone,sfz,money);
        }
    }
}
