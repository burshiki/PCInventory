using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCInventory.Includes
{
    internal class UsableFunction
    {

        public void ResponsiveDtg(DataGridView dvg)
        {
            dvg.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        public void clearTxt(Control container)
        {
            try
            {
                //'for each txt as control in this(object).control
                foreach (Control txt in container.Controls)
                {
                    //conditioning the txt as control by getting it's type.
                    //the type of txt as control must be textbox.
                    if (txt is TextBox)
                    {
                        //if the object(textbox) is present. The result is, the textbox will be cleared.
                        txt.Text = "";
                    }
                    if (txt is RichTextBox)
                    {
                        txt.Text = "";
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
