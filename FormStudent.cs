﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tast2
{
    public partial class FormStudent : Form
    {
        private readonly FormStudentinfo _parent;

        public string id, name, reg, @class, section;
        public FormStudent(FormStudentinfo parent)
        {
            InitializeComponent();
            _parent = parent;
        }
        public void UpdateInfo()
        {
            lbltext.Text = "Update Student";
            btnSave.Text = "Update";
            txtName.Text = name;
            txtReg.Text = reg;
            txtClass.Text = @class;
            txtSection.Text = section;
        }
        public void SaveInfo()
        {
            lbltext.Text = "Add Student";
            btnSave.Text = "Save";
        }
        public void Clear()
        {
            txtName.Text = txtReg.Text = txtClass.Text = txtSection.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtReg.Text.Trim().Length < 3)
            {
                MessageBox.Show("Student name is Empty ( > 3 )");
                return;
            }
            if (txtName.Text.Trim().Length < 1)
            {
                MessageBox.Show("Student reg  is Empty ( > 1 )");
                return;
            }
            if (txtClass.Text.Trim().Length == 0)
            {
                MessageBox.Show("Student class is Empty ( > 1 )");
                return;
            }
            if (txtSection.Text.Trim().Length == 0)
            {
                MessageBox.Show("Student section is Empty ( > 1 )");
                return;
            }
            if (btnSave.Text == "Save")
            {
                Student std = new Student(txtName.Text.Trim(), txtReg.Text.Trim(), txtClass.Text.Trim(), txtSection.Text.Trim());
                DbStudent.AddStudent(std);
                Clear();
            }
            if (btnSave.Text == "Update")
            {
                Student std = new Student(txtName.Text.Trim(), txtReg.Text.Trim(), txtClass.Text.Trim(), txtSection.Text.Trim());
                DbStudent.UpdateStudent(std, id);
            }
            _parent.Display();
        }
    }
}
