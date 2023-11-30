using System.Data;

namespace SfDataGridDemo
{
    public class ViewModel
    {
        public DataTable DataGridDataTable { get; set; }
        public DataTable comboBoxDataTable { get; set; }
        
        public ViewModel()
        {
            DataGridDataTable = new DataTable();
            comboBoxDataTable = new DataTable();
            GetDatatable();
            GetComboBoxDatatable();
        }

        //DataGrid Data
        private void GetDatatable()
        {
            DataGridDataTable.Columns.Add("Id", typeof(string));
            DataGridDataTable.Columns.Add("Description", typeof(string));
            DataGridDataTable.Columns.Add("Password", typeof(string));
            DataGridDataTable.Columns.Add("Country", typeof(int));

            DataGridDataTable.Rows.Add(1, "Chocolate Cake", Form1.GetSHA256Hash("cake"), 2);
            DataGridDataTable.Rows.Add(2, "Apple Pie", Form1.GetSHA256Hash("pie"), 1);
            DataGridDataTable.Rows.Add(3, "Ice Cream", Form1.GetSHA256Hash("cream"), 3);
            DataGridDataTable.Rows.Add(4, "Cheesecake", Form1.GetSHA256Hash("cheese"), 1);
            DataGridDataTable.Rows.Add(5, "Cupcake", Form1.GetSHA256Hash("cup"), 3);
            DataGridDataTable.Rows.Add(6, "Brownie", Form1.GetSHA256Hash("brownie"), 2);

        }

        //ComboBox Data
        private void GetComboBoxDatatable()
        {
            comboBoxDataTable.Columns.Add("Id", typeof(int));
            comboBoxDataTable.Columns.Add("Country", typeof(string));

            comboBoxDataTable.Rows.Add(1, "India");
            comboBoxDataTable.Rows.Add(2, "US");
            comboBoxDataTable.Rows.Add(3, "UK");
        }
    }
}