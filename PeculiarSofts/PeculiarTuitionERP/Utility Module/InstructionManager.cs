using System;
using System.Windows.Forms;
using PeculiarTuitionBase;

namespace PeculiarTuitionERP.Utility_Module
{
    public static class InstructionManager
    {
        private static TuitionBase _base;
        public static DialogResult Information(string p_Message, string headerText)
        {

            return Message(new Exception(p_Message), headerText, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Prompt Error Message on the Form.
        /// </summary>
        /// <param name="e"><para>Exception whose Message to be displayed on the form.</para></param>
        /// <param name="headerText"><para>Title to be displayed on the dialog box.</para></param>
        /// <returns>DialogResult object.</returns>
        public static DialogResult Error(Exception e, string headerText)
        {

            try
            {
                //if (!e.Message.StartsWith("#TutionInformationSystem : "))
                //{
                //    if (e.GetType() == typeof(InformationException))
                //        return Information(e.Message, headerText);
                //    else if (e.GetType() == typeof(WarningException))
                //        return Warning(e.Message, headerText);
                //    else
                //    {

                //    }
                //}
                return Error(e.Message, headerText);
            }
            catch (Exception ex)
            {
                return Message(ex, "Error in Writing Log", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            finally { }
        }

        /// <summary>
        /// Prompt Error Message on the Form.
        /// </summary>
        /// <param name="p_Message"><para>Message to be displayed on the form.</para></param>
        /// <param name="headerText"><para>Title to be displayed on the dialog box.</para></param>
        /// <returns>DialogResult object.</returns>
        public static DialogResult Error(string p_Message, string headerText)
        {
            return Message(new Exception(p_Message), headerText, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Prompt Confirmation Message on the Form.
        /// </summary>
        /// <param name="p_Message"><para>Message to be displayed on the form.</para></param>
        /// <param name="headerText"><para>Title to be displayed on the dialog box.</para></param>
        /// <returns>DialogResult object.</returns>
        public static DialogResult Confirmation(string p_Message, string headerText)
        {
            return Message(new Exception(p_Message), headerText, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }
        /// <summary>
        /// Prompt Confirmation Message on the Form.
        /// </summary>
        /// <param name="p_Message"><para>Message to be displayed on the form.</para></param>
        /// <param name="headerText"><para>Title to be displayed on the dialog box.</para></param>
        /// <param name="mboxbtn"></param>
        /// <param name="mboxdefbtn"></param>
        /// <returns>DialogResult object.</returns>
        public static DialogResult Confirmation(string p_Message, string headerText, MessageBoxButtons mboxbtn, MessageBoxDefaultButton mboxdefbtn)
        {

            return Message(new Exception(p_Message), headerText, mboxbtn, MessageBoxIcon.Question, mboxdefbtn);
        }

        /// <summary>
        /// Prompt Warning Message on the Form.
        /// </summary>
        /// <param name="p_Message"><para>Message to be displayed on the form.</para></param>
        /// <param name="headerText"><para>Title to be displayed on the dialog box.</para></param>
        /// <returns>DialogResult object.</returns>
        public static DialogResult Warning(string p_Message, string headerText)
        {
            return Message(new Exception(p_Message), headerText, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Prompt any type of Message on the Form.
        /// </summary>
        /// <param name="e"><para>Exception whose Message to be displayed on the form.</para></param>
        /// <param name="headerText"><para>Title to be displayed on the dialog box.</para></param>
        /// <param name="mboxbtn"></param>
        /// <param name="mboxicon"></param>
        /// <param name="mboxdefbtn"></param>
        /// <param name="mboxopt"></param>
        /// <returns>DialogResult object.</returns>
        public static DialogResult Message(Exception e, string headerText, MessageBoxButtons mboxbtn, MessageBoxIcon mboxicon, MessageBoxDefaultButton mboxdefbtn, MessageBoxOptions mboxopt)
        {
            return MessageBox.Show(e.Message, headerText, mboxbtn, mboxicon, mboxdefbtn, mboxopt);
        }

        /// <summary>
        /// Prompt any type of Message on the Form.
        /// </summary>
        /// <param name="e"><para>Exception whose Message to be displayed on the form.</para></param>
        /// <param name="headerText"><para>Title to be displayed on the dialog box.</para></param>
        /// <param name="mboxbtn"></param>
        /// <param name="mboxicon"></param>
        /// <param name="mboxdefbtn"></param>
        /// <returns>DialogResult object.</returns>
        public static DialogResult Message(Exception e, string headerText, MessageBoxButtons mboxbtn, MessageBoxIcon mboxicon, MessageBoxDefaultButton mboxdefbtn)
        {
            return MessageBox.Show(e.Message, headerText, mboxbtn, mboxicon, mboxdefbtn);

        }
    }
}
