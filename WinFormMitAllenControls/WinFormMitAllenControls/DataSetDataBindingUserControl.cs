using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormMitAllenControls
{
    public partial class DataSetDataBindingUserControl : UserControl
    {
        public DataSetDataBindingUserControl()
        {
            InitializeComponent();
            employeesTableAdapter.Fill(dataSet1.Employees);
        }

        private void employeesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dataSet1);

        }
    }
}
