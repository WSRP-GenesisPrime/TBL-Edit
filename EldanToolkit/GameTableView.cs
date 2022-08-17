using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EldanToolkit
{
    public partial class GameTableView : UserControl
    {
        TableWrapper wrapper;

        public GameTableView(TableWrapper wrapper)
        {
            this.wrapper = wrapper;
            InitializeComponent();
        }
    }
}
