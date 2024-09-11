﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Service
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (!FSWork.IsFileExist("Servis.db")) MakeStore();
           
            
            FillMechanicsName();
        }
         private void MakeStore()
        {
            if (DBWork.MakeDB())
            {
                MessageBox.Show($"База данных существует");
            };
        }

        private void FillMechanicsName()
        {
            foreach (string name in DBWork.GetMechanics())
            {
                cmbMechanic.Items.Add(name);
            }
            DBWork.GetMechanics();
        }
            
    }
}
