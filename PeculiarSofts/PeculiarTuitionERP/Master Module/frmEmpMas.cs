using System;
using System.Windows.Forms;
using System.Collections;
using PeculiarTuitionBase.MasterBase;
using System.Globalization;
using PeculiarTuitionERP.Utility_Module;



namespace PeculiarTuitionERP.Master_Module
{
    public partial class frmEmpMas : frmBaseChild
    {
        DateTime dob, doj;
        CultureInfo DatetimeCulture;
        Hashtable GetNullParamters;
        private string CurrentAction = string.Empty;
        private char action_flg = 'I';
        private EmpMas libEmpMas;
        private Utility uti;
        private string errMsg = string.Empty;
        string branch, emp_type, fname, mname, lname, sex, bldGrp, ph1, ph2, adr1, adr2, city, state, pincode, email_id;

        

        public frmEmpMas()
        {
            InitializeComponent();
        }

        private void frmEmpMas_Load(object sender, EventArgs e)
        {
            libEmpMas = new EmpMas();
            uti = new Utility();
            SetDefaultState();
        }


        public void SetDefaultState()
        {
            uti.SetPanelStatus(btnMainPanel, "LOAD");
            branch = emp_type = fname = mname = lname = sex = bldGrp = ph1 = ph2 = adr1 = adr2 = city = state = pincode = email_id = string.Empty;
            dob = doj = DateTime.Now;
            DatetimeCulture = new CultureInfo("en-US", false);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnMainPanel.ButtonAddText == "&Add")
            {
                action_flg = 'I';
                CurrentAction = "ADD";
                btnMainPanel.ButtonAddText = "&Save";
                btnMainPanel.ButtonEditText = "&Cancel";
                btnMainPanel.ButtonDeleteEnable = true;
                btnMainPanel.ButtonSearchEnable = btnMainPanel.ButtonRefreshEnable = false;
            }
            else//btnAdd Text = Save
            {
                Hashtable saveSummary = Savedata();
            }
        }
        private void btnMainPanel_btnRefreshClick(object sender, EventArgs e)
        {

        }

        private void btnMainPanel_btnEditClick(object sender, EventArgs e)
        {

        }

        private void btnMainPanel_btnDeleteClick(object sender, EventArgs e)
        {

        }

        private void btnMainPanel_btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                CurrentAction= "SEARCH";
                btnMainPanel.ButtonEditText = "&Cancel";
                uti.SetPanelStatus(btnMainPanel, false, true, false, true, false, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void txtbxFname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private Hashtable Savedata()
        {
            Hashtable Response = new Hashtable();
            try
            {
                GetCurrentValues();
                if (GetNullParamters.Keys.Count == 0)
                {
                    if (libEmpMas == null)
                        libEmpMas = new EmpMas();
                    if (action_flg == 'I')//Action flag for insert
                    {
                        Response = libEmpMas.insertData(branch, action_flg, emp_type, fname, mname, lname, dob, doj, sex, bldGrp, ph1, ph2, adr1, adr2, city, state, pincode, email_id, null, Environment.MachineName.ToString(), out errMsg);
                        if (!string.IsNullOrEmpty(errMsg)) throw new Exception(errMsg);
                        if (Response.Contains("p_flg"))
                        {
                            if (Response["p_flg"].ToString() == "Y")
                            {

                            }
                            else //Problem handle with error msg from back end
                            {

                            }

                        }
                    }
                    else//Action flag for update
                    {

                    }
                }
                else// Some Null Value are there
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            } 
           
            return Response;
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
