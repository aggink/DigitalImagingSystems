using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIS.Manager
{
    public static class ManagerError
    {
        //вывод сообщения об ошибки
        public static DialogResult ErrorOK(string text, string error = "Ошибка")
        {
            DialogResult result = MessageBox.Show(
                                                    text,
                                                    error,
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Error,
                                                    MessageBoxDefaultButton.Button1,
                                                    MessageBoxOptions.DefaultDesktopOnly
                                                  );
            return result;
        }
    }
}
