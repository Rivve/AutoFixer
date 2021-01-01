using System;
using System.Windows.Forms;

namespace AutoFixer
{
    /// <summary>
    /// From MSDN
    /// </summary>
    class DataGridViewDisableButtonColumn : DataGridViewButtonColumn
    {
        public DataGridViewDisableButtonColumn()
        {
            this.CellTemplate = new DataGridViewDisableButtonCell();
        }
    }
}
