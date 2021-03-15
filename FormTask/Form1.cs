using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Person person = new Person
            {
                Name = nameTxtb.Text,
                Surname = surnameTxtb.Text,
                Email = emailTxtb.Text,
                Phone = phoneMtxtb.Text,
                Languages = new List<string>
                {
                    langGrpbx.Text
                }
            };
            if (maleRbtn.Checked) person.Gender = "Male";
            else if (femaleRbtn.Checked) person.Gender = "Female";
            FileHelper.JsonSerialize(person.Name, person);
            nameTxtb.Clear();
            surnameTxtb.Clear();
            emailTxtb.Clear();
            phoneMtxtb.Clear();
            maleRbtn.Checked = false;
            femaleRbtn.Checked = false;
            MessageBox.Show("Saved succesfully");
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            var p = FileHelper.JsonDeserialize(nameTxtb.Text);
            nameTxtb.Text = p.Name;
            surnameTxtb.Text = p.Surname;
            emailTxtb.Text = p.Email;
            phoneMtxtb.Text = p.Phone;
            if (p.Gender == "Male") maleRbtn.Checked = true;
            else if (p.Gender == "Female") femaleRbtn.Checked = true;
        }
    }
}
