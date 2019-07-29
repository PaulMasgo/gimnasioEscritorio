using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public class Config
    {
        public void enumerarDataGrid(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        public void limpiarTextbox(Control.ControlCollection formulario)
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(formulario);
        }


       /* Action<Control.ControlCollection> func = null;

        func = (controls) =>
                        {
                            foreach (Control control in controls)
                                if (control is TextBox)
                                    (control as TextBox).Clear();
                                else
                                    func(control.Controls);
    };

    func(Controls);*/

}
}
