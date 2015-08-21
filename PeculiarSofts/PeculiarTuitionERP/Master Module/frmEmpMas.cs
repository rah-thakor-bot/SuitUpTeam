using System;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
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
        private string _strBtnActionType = string.Empty;
        private string REQUIRED = "REQUIRED";
        private char action_flg = 'I';
        private EmpMas libEmpMas;
        private Utility uti;
        private DataSet dsEmpData;
        private string errMsg = string.Empty;
        string branch, emp_type, fname, mname, lname, sex, bldGrp, ph1, ph2, adr1, adr2, city, state, pincode, email_id, entity_id;



        public frmEmpMas()
        {
            InitializeComponent();
        }

        private void frmEmpMas_Load(object sender, EventArgs e)
        {
            try
            {
                SetDefaultState();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }


        public void SetDefaultState()
        {
            //Global.DisableControls(this);
            grpEmpType.Enabled = flMainData.Enabled = grpSearchBox.Enabled = false;
            getLibraryInstance("UTILITY");
            uti.SetPanelStatus(this.btnMainPanel1, "LOAD");
            branch = emp_type = fname = mname = lname = sex = bldGrp = ph1 = ph2 = adr1 = adr2 = city = state = pincode = email_id = entity_id = string.Empty;
            dob = doj = DateTime.Now;
            DatetimeCulture = new CultureInfo("en-US", false);
            btnMainPanel1.SetFocus(Private.MyUserControls.ButtonPanelControl.Action.Add);

        }

        private void getLibraryInstance(string libName)
        {
            if (libName.ToUpper() == "EMP")
            {
                if (libEmpMas == null)
                    libEmpMas = new EmpMas();
            }
            else if (libName.ToUpper() == "UTILITY")
            {
                if (uti == null)
                    uti = new Utility();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnMainPanel1.ButtonAddText == "&Add")
                {
                    action_flg = 'I';
                    grpEmpType.Enabled = true;
                    flMainData.Enabled = true;
                    grpSearchBox.Enabled = false;
                    _strBtnActionType = "ADD";
                    getLibraryInstance("UTILITY");
                    uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                    grpEmpType.Select();
                    grpEmpType.Focus();
                }
                else//btnAdd Text = Save
                {
                    Hashtable htValidate = ValidateValues();
                    if ((bool)htValidate["RESULT"])
                    {
                        Hashtable saveSummary = Savedata();
                        if (saveSummary.Contains("p_flg"))
                        {
                            if (saveSummary["p_flg"].ToString() == "Y")
                            {
                                MessageBox.Show("Saved Successfully");
                                grpEmpType.Enabled = true;
                                flMainData.Enabled = true;
                                grpSearchBox.Enabled = false;
                                getLibraryInstance("UTILITY");
                                _strBtnActionType = "SAVE";
                                uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                                flMainData.Enabled = false;
                                btnMainPanel1.Select();
                                btnMainPanel1.Focus();
                            }
                            else //Problem handle with error msg from back end
                            {
                                MessageBox.Show(saveSummary["p_msg"].ToString());
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please fill required fields");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnMainPanel_btnRefreshClick(object sender, EventArgs e)
        {
            try
            {
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void btnMainPanel_btnEditClick(object sender, EventArgs e)
        {
            try
            {
                if (btnMainPanel1.ButtonEditText == "&Edit")
                {
                    _strBtnActionType = "EDIT";
                    action_flg = 'U';
                    getLibraryInstance("UTILITY");
                    uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                    grpEmpType.Enabled = true;
                    flMainData.Enabled = true;
                    grpSearchBox.Enabled = false;
                }
                else//Cancel 
                {
                    SetDefaultState();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

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
                _strBtnActionType = "SEARCH";
                getLibraryInstance("UTILITY");
                uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                grpEmpType.Enabled = true;
                flMainData.Enabled = false;
                grpSearchBox.Enabled = true;
                grpSearchBox.Select();
                grpSearchBox.Focus();

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

        private Hashtable ValidateValues()
        {
            Hashtable htResult = new Hashtable();
            htResult.Add("RESULT", false);
            string notValidatedCtrlName = string.Empty;
            List<Control> lstControls = Global.GetAllControls(this.Controls);
            foreach (Control ctrl in lstControls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    try
                    {
                        if (!(string.IsNullOrWhiteSpace(((TextBox)ctrl).Tag.ToString())))
                        {
                            if (((TextBox)ctrl).Tag.ToString().Contains(REQUIRED))
                            {
                                if ((string.IsNullOrEmpty(((TextBox)ctrl).Text.ToString())))
                                {
                                    notValidatedCtrlName += ctrl.Name.ToString() + ",";
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (!(ex.GetType() == typeof(NullReferenceException)))
                        {
                            throw ex;
                        }
                    }
                }
                else if (ctrl.GetType() == typeof(MaskedTextBox))
                {
                    try
                    {
                        if (!(string.IsNullOrWhiteSpace(((MaskedTextBox)ctrl).Tag.ToString())))
                        {
                            if (((MaskedTextBox)ctrl).Tag.ToString().Contains(REQUIRED))
                            {
                                if (((MaskedTextBox)ctrl).MaskCompleted)
                                {
                                    notValidatedCtrlName += ctrl.Name.ToString() + ",";
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (!(ex.GetType() == typeof(NullReferenceException)))
                        {
                            throw ex;
                        }
                    }
                    
                }
                else if (ctrl.GetType() == typeof(ComboBox))
                {
                    try
                    {
                        if (!(string.IsNullOrWhiteSpace(((ComboBox)ctrl).Tag.ToString())))
                        {
                            if (((ComboBox)ctrl).Tag.ToString().Contains(REQUIRED))
                            {
                                if ((string.IsNullOrEmpty(((ComboBox)ctrl).Text.ToString())))
                                {
                                    notValidatedCtrlName += ctrl.Name.ToString() + ",";
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (!(ex.GetType() == typeof(NullReferenceException)))
                        {
                            throw ex;
                        }
                    }
                    
                }
                else if (ctrl.HasChildren)
                {

                }
            }
            if ((string.IsNullOrWhiteSpace(notValidatedCtrlName)))
            {
                htResult["RESULT"] = true;
            }
            else
            {
                htResult.Add("CTRL_LIST", notValidatedCtrlName);
            }

            return htResult;
        }

        private Hashtable Savedata()
        {
            Hashtable Response = new Hashtable();
            try
            {
                GetCurrentValues();
                if (true/*GetNullParamters.Keys.Count == 0*/)
                {
                    getLibraryInstance("EMP");
                    if (action_flg == 'I')//Action flag for insert
                    {
                        Response = libEmpMas.insertData(Global.LoginBranch, emp_type, fname, mname, lname, dob, doj, sex, bldGrp, ph1, ph2, adr1, adr2, city, state, pincode, email_id, Global.LoginUser, Environment.MachineName.ToString(), out errMsg);
                        if (!string.IsNullOrEmpty(errMsg)) throw new Exception(errMsg);
                        if (Response.Contains("p_flg"))
                        {
                            if (Response["p_flg"].ToString() == "Y")
                            {
                                MessageBox.Show("Saved Successfully");
                                getLibraryInstance("UTILITY");
                                _strBtnActionType = "SAVE";
                                uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                                flMainData.Enabled = false;
                                btnMainPanel1.Select();
                            }
                            else //Problem handle with error msg from back end
                            {
                                MessageBox.Show(Response["p_msg"].ToString());
                            }

                        }
                    }
                    else//Action flag for update
                    {
                        Response = libEmpMas.updateData(Global.LoginBranch, emp_type, entity_id, fname, mname, lname, dob, doj, sex, bldGrp, ph1, ph2, adr1, adr2, city, state, pincode, email_id, Global.LoginUser, Environment.MachineName.ToString(), null, out errMsg);
                        if (!string.IsNullOrEmpty(errMsg)) throw new Exception(errMsg);
                        if (Response.Contains("p_flg"))
                        {
                            if (Response["p_flg"].ToString() == "Y")
                            {
                                MessageBox.Show("Saved Successfully");
                                getLibraryInstance("UTILITY");
                                _strBtnActionType = "SAVE";
                                uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                                flMainData.Enabled = false;
                                btnMainPanel1.Select();
                            }
                            else //Problem handle with error msg from back end
                            {
                                MessageBox.Show(Response["p_msg"].ToString());
                            }

                        }
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


        private void RefreshData()
        {
            if (!(string.IsNullOrWhiteSpace(txtSearchBox.Text)))
            {
                getLibraryInstance("Emp");
                string criteria = string.Empty;

                if (rdbtnStd.Checked)
                    emp_type = "Student";
                else if (rdbtnTeacher.Checked)
                    emp_type = "Teacher";
                else
                    emp_type = "Other";
                criteria = "A.ENTITY_ID = '" + txtSearchBox.Text + "'";
                criteria += emp_type == null ? "" : " AND B.ENTITY_TYPE_ID IN (SELECT C.ENTITY_TYPE_ID FROM ENTITY_TYPE_MAS C WHERE C.ENTITY_TYPE_NAME LIKE '%" + emp_type.ToUpper() + "%') ";
                dsEmpData = libEmpMas.FetchData(criteria, out errMsg);
                if (!string.IsNullOrEmpty(errMsg)) throw new Exception(errMsg);
                if (dsEmpData.Tables["EmpMas"].Rows.Count > 0)
                {
                    _strBtnActionType = "REFRESH";
                    getLibraryInstance("UTILITY");
                    uti.SetPanelStatus(btnMainPanel1, _strBtnActionType);
                    DisplayData(dsEmpData.Tables["EmpMas"].Rows[0]);
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
           
        }
        private void DisplayData(DataRow drResult)
        {
            emp_type = drResult["ENTITY_TYPE_ID"].ToString();
            entity_id = drResult["ENTITY_ID"].ToString();
            fname = drResult["F_NAME"].ToString();
            lname = drResult["L_NAME"].ToString(); 
            mname = drResult["M_NAME"].ToString();
            sex = drResult["SEX"].ToString();
            ph1 = drResult["PHONE1"].ToString();
            ph2 = drResult["PHONE2"].ToString();
            adr1 = drResult["ADD1"].ToString();
            adr2 = drResult["ADD2"].ToString();
            bldGrp = drResult["BLOOD_GRP"].ToString();
            city = drResult["CITY"].ToString();
            state = drResult["STATE"].ToString();
            pincode = drResult["PINCODE"].ToString();
            email_id = drResult["EMAIL_ID"].ToString();
            {//Emp Type

                if (emp_type == "Student".ToUpper())
                    rdbtnStd.Checked = true;
                else if (emp_type == "Teacher".ToUpper())
                    rdbtnTeacher.Checked = true;
                else
                    rdbtnOther.Checked = true;
            }

            {//First Name
                if (!string.IsNullOrEmpty(fname))
                    txtbxFname.Text = fname;
            }

            {//Middle Name
                if (!string.IsNullOrEmpty(mname))
                    txtbxMname.Text = mname;
            }

            {//Last Name
                if (!string.IsNullOrEmpty(lname))
                    txtbxLname.Text = lname;
            }

            //Peding Code for Datetime format

            {//Sex 
                if (!string.IsNullOrEmpty(sex))
                    cmbSex.Text = sex;
            }
            {//Primary Phone
                if (!string.IsNullOrEmpty(ph1))
                    txtbxPh1.Text = ph1;
            }
            {//Secondary Phone
                if (!string.IsNullOrEmpty(ph2))
                    txtbxPh2.Text = ph2;
            }
            {
                if (!string.IsNullOrEmpty(bldGrp))
                    txtbxBldGrp.Text = bldGrp;
            }
            {//Address 1
                if (!string.IsNullOrEmpty(adr1))
                    txtbxAdr1.Text = adr1;
            }
            {//Address 2
                if (!string.IsNullOrEmpty(adr2))
                    txtbxAdr2.Text = adr2;
            }
            {//City
                if (!string.IsNullOrEmpty(city))
                    txtbxCity.Text = city;

            }
            {//State
                if (!string.IsNullOrEmpty(state))
                    txtbxState.Text = state;

            }
            {//Pincode
                if (!string.IsNullOrEmpty(pincode))
                    txtbxPincode.Text = pincode;

            }
            {//Email
                if (!string.IsNullOrEmpty(email_id))
                    txtbxEmail.Text = email_id;
            }
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
                    sex = cmbSex.Text.ToString() == "Male" ? "M" : "F";
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
