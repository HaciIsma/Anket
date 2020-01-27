using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Anket
{
    public partial class Form1 : Form
    {
        List<User> users = null;
        private delegate void UserAddSystem(User user);
        string path = $@"{Directory.GetCurrentDirectory()}\JsonFile\File.json";
        public Form1()
        {
            string str = File.ReadAllText(path);
            users = JsonConvert.DeserializeObject<List<User>>(str);
            if (users == null)
            {
                users = new List<User>();
            }
            InitializeComponent();
        }

        private void save_Click(object sender, EventArgs e)
        {
            UserAddSystem userAddSystem = SetUserInfo;
            userAddSystem += JsonSerialization;
            userAddSystem += users.Add;
            userAddSystem += comboBoxAdd;
            userAddSystem.Invoke(new User());
        }
        private void SetUserInfo(User user)
        {
            user.Name = nameBox.Text;
            user.LastName = lastNameBox.Text;
            user.MiddleName = middleNameBox.Text;
            user.Country = countryBox.Text;
            user.City = cityBox.Text;
            user.Phone = phoneBox.Text;
            user.Birthday = dateTimePicker1.Value;
            if (radioButton1.Checked == true)
            {
                user.Gender = "Male";
            }
            else if (radioButton2.Checked == true)
            {
                user.Gender = "Female";
            }
            users.Add(user);
        }
        private void JsonSerialization(User user)
        {
            string jsonString = JsonConvert.SerializeObject(user);
            File.AppendAllText(path, jsonString);
        }


        private void comboBoxAdd(User user)
        {
            comboBox1.Items.Add((object)user);
        }
        private void comboBoxSetUser(User user)
        {
            nameBox.Text = user.Name;
            lastNameBox.Text = user.LastName;
            middleNameBox.Text = user.MiddleName;
            countryBox.Text = user.Country;
            cityBox.Text = user.City;
            phoneBox.Text = user.Phone;
            dateTimePicker1.Value = user.Birthday;
            if (user.Gender == "Male")
            {
                radioButton1.Checked = true;
            }
            else if (user.Gender == "Female")
            {
                radioButton2.Checked = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            User user = (User)comboBox1.SelectedItem;
            comboBoxSetUser(user);
        }

    }
}
