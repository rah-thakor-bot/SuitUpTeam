using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using PeculiarTuitionBase.MasterBase;
using System.Globalization;



namespace PeculiarTuitionERP.Master_Module
{
    public partial class frmEmpMas : frmBaseChild
    {
        private string CurrentAction = string.Empty;
        private char action_flg = 'I';
        private EmpMas libEmpMas;
        private string errMsg = string.Empty;
        string branch, emp_type, fname, mname, lname, sex, bldGrp, ph1, ph2, adr1, adr2, city, state, pincode, email_id;
        DateTime dob, doj;
        CultureInfo DatetimeCulture;
        Hashtable GetNullParamters;


        public frmEmpMas()
        {
            InitializeComponent();
        }

        private void frmEmpMas_Load(object sender, EventArgs e)
        {
            libEmpMas = new EmpMas();
            SetDefaultState();
        }


        public void SetDefaultState()
        {
            btnEdit.Enabled = btnDelete.Enabled = btnRefresh.Enabled = false;
            branch = emp_type = fname = mname = lname = sex = bldGrp = ph1 = ph2 = adr1 = adr2 = city = state = pincode = email_id = string.Empty;
            dob = doj = DateTime.Now;
            DatetimeCulture = new CultureInfo("en-US", false);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "&Add")
            {
                CurrentAction = "ADD";
                btnAdd.Text = "&Save";
                btnEdit.Text = "&Cancel";
                btnDelete.Enabled = true;
                btnSearch.Enabled = btnRefresh.Enabled = false;
            }
            else//btnAdd Text = Save
            {
                Hashtable saveSummary = Savedata();    
            }
        }

        private Hashtable Savedata()
        {
            Hashtable SaveResponse = new Hashtable();
            try
            {
                GetCurrentValues();
                if (GetNullParamters.Keys.Count == 0)
                {
                    if (libEmpMas == null)
                        libEmpMas = new EmpMas();
                    SaveResponse = libEmpMas.Savedata(branch, action_flg, emp_type, fname, mname, lname, dob, doj, sex, bldGrp, ph1, ph2, adr1, adr2, city, state, pincode, email_id, null, Environment.MachineName.ToString(), out errMsg);
                    if (!string.IsNullOrEmpty(errMsg)) throw new Exception(errMsg);
                    if (SaveResponse.Contains("p_flg"))
                    {
                        if (SaveResponse["p_flg"].ToString() == "Y")
                        {

                        }
                        else //Problem handle with error msg from back end
                        {

                        }

                    }
                }
                else// Some Null Value are there
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            } 
           
            return SaveResponse;
        }

        private void GetCurrentValues()
        {
            GetNullParamters = new Hashtable();

            {//Emp Type
                if (rdbtnStd.Checked)
                    emp_type = "Student";
                else if (rdbtnTeacher.Checked)
                    emp_type = "Teacher";
                else
                    emp_type = "Other";
            }

            {//First Name
                if (!string.IsNullOrEmpty(txtbxFname.Text))
                    fname = txtbxFname.Text;
                else
                    GetNullParamters.Add(txtbxFname, String.Empty);
            }

            {//Middle Name
                if (!string.IsNullOrEmpty(txtbxMname.Text))
                    mname = txtbxMname.Text;
                else
                    GetNullParamters.Add(txtbxMname, String.Empty);
            }

            {//Last Name
                if (!string.IsNullOrEmpty(txtbxLname.Text))
                    lname = txtbxLname.Text;
                else
                    GetNullParamters.Add(txtbxLname, String.Empty);
            }

            //Peding Code for Datetime format

            {//Sex 
                if (!string.IsNullOrEmpty(cmbSex.Text))
                    sex = cmbSex.Text;
                else
                    GetNullParamters.Add(cmbSex, String.Empty);
            }
            {//Primary Phone
                if (!string.IsNullOrEmpty(txtbxPh1.Text))
                    ph1 = txtbxPh1.Text;
                else
                    GetNullParamters.Add(txtbxPh1, String.Empty);
            }
            {//Secondary Phone
                if (!string.IsNullOrEmpty(txtbxPh2.Text))
                    ph2 = txtbxPh2.Text;
                else
                    GetNullParamters.Add(txtbxPh2, String.Empty);
            }
            {
                if (!string.IsNullOrEmpty(txtbxBldGrp.Text))
                    bldGrp = txtbxBldGrp.Text;
                else
                    GetNullParamters.Add(txtbxBldGrp, String.Empty);
            }
            {//Address 1
                if (!string.IsNullOrEmpty(txtbxAdr1.Text))
                    adr1 = txtbxAdr1.Text;
                else
                    GetNullParamters.Add(txtbxAdr1, String.Empty);
            }
            {//Address 2
                if (!string.IsNullOrEmpty(txtbxAdr2.Text))
                    adr2 = txtbxAdr2.Text;
                else
                    GetNullParamters.Add(txtbxAdr2, String.Empty);
            }
            {//City
                if (!string.IsNullOrEmpty(txtbxCity.Text))
                    city = txtbxCity.Text;
                else
                    GetNullParamters.Add(txtbxCity, String.Empty);
            }
            {//State
                if (!string.IsNullOrEmpty(txtbxState.Text))
                    state = txtbxState.Text;
                else
                    GetNullParamters.Add(txtbxState, String.Empty);
            }
            {//Pincode
                if (!string.IsNullOrEmpty(txtbxPincode.Text))
                    pincode = txtbxPincode.Text;
                else
                    GetNullParamters.Add(txtbxPincode, String.Empty);
            }
            {//Email
                if (!string.IsNullOrEmpty(txtbxEmail.Text))
                    email_id = txtbxEmail.Text;
                else
                    GetNullParamters.Add(txtbxEmail, String.Empty);
            }
        }
    }
}
