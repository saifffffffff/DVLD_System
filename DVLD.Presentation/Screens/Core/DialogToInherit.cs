using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_WindowsForms.Screens.Core
{
    public partial class DialogToInherit : ScreenToInherit
    {
        public DialogToInherit()
        {
            InitializeComponent();
        }

        bool movePosition;
        int xCoordinate;
        int yCoordinate;

        private void DialogToInherit_MouseDown(object sender, MouseEventArgs e)
        {
            movePosition = true;
            xCoordinate = e.X;
            yCoordinate = e.Y;
        }

        private void DialogToInherit_MouseMove(object sender, MouseEventArgs e)
        {
            if (movePosition)
            {
                this.SetDesktopLocation(MousePosition.X - xCoordinate, MousePosition.Y - yCoordinate);
            }
        }

        private void DialogToInherit_MouseUp(object sender, MouseEventArgs e)
        {
            movePosition = false;

        }
    }
}
