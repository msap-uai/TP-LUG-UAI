using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class MiForm : Form
    {
        protected void button1_Click(object sender, EventArgs e)
        {
            if (HayCambios())
            {
                if (!ConfirmarCambios())
                {
                    return;
                }
            }

            ModoNuevoRegistro();
        }

        protected void Cierre(object? sender, FormClosingEventArgs e)
        {
            if (HayCambios())
            {
                if (!ConfirmarCambios())
                {
                    e.Cancel = true;
                }
            }
        }

        protected virtual bool HayCambios()
        {
            return false;
        }

        protected virtual bool ConfirmarCambios()
        {
            return true;
        }

        protected virtual void ModoNuevoRegistro()
        {
        }
    }
}
