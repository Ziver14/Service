using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (!FSWork.IsFileExist("AutoService.db")) MakeStore();
            FillMechanicsNames();
        }
        private void MakeStore()
        {
            if (DBWork.MakeDB())
            {
                MessageBox.Show($"База данных существует");
            } ;
        }
        private void FillMechanicsNames()
        {
            foreach (string name in DBWork.GetMechanics())
            {
                cmbMechanic.Items.Add(name);
            }
        }

        private void picBoxAvatar_Click(object sender, EventArgs e)
        {
            if(cmbMechanic.SelectedItem  != null)
            {
                byte[] _image = FSWork.GetImage();
                string _name = cmbMechanic.SelectedItem.ToString();
                DBWork.AddAvatar(_name,_image);
            }
            
        }

        private void SetImage2PictureBox()
        {   string _name = cmbMechanic.SelectedItem.ToString();
            //picBoxAvatar.Image = Image.FromStream(DBWork.GetAvatar(_name));
            MemoryStream ms = DBWork.GetAvatar(_name);
            if(ms != null)
            {
                picBoxAvatar.Image = Image.FromStream(DBWork.GetAvatar(_name));
            }
            else { picBoxAvatar.BackColor = Color.Black; }
            
        }

        private void cmbMechanic_SelectedValueChanged(object sender, EventArgs e)
        {
            SetImage2PictureBox();
        }
    }
}
