using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid.Events;

namespace SfDataGridDemo
{
    public partial class Form1 : Form
    {
        ViewModel viewModel;

        public Form1()
        {
            InitializeComponent();

            //Initialize the ViewModel
            viewModel = new ViewModel();

            sfDataGrid1.AutoGenerateColumns = false;
            sfDataGrid1.DataSource = viewModel.DataGridDataTable;
           
            //Set the EditMode as SingleClick
            sfDataGrid1.EditMode = EditMode.SingleClick;

            //Add the columns to the SfDataGrid
            sfDataGrid1.Columns.Add(new GridNumericColumn() { MappingName = "ID", HeaderText = "ID" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Description", HeaderText = "Description" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Password", HeaderText = "Password" });
            sfDataGrid1.Columns.Add(new GridComboBoxColumn() { MappingName = "Country", HeaderText = "Country", DisplayMember = "Country", ValueMember = "ID", DataSource = viewModel.comboBoxDataTable });

            //Event subscription
            sfDataGrid1.CurrentCellValidated += OnCurrentCellValidated;
        }

        //Event customization
        private void OnCurrentCellValidated(object sender, CurrentCellValidatedEventArgs e)
        {
            // Customize based on your requirement
            if (e.Column.MappingName == "Password")
            {
                //Get the current row
                var column = e.RowData as System.Data.DataRowView;
                //Set the Password column value as SHA256 hash
                column["Password"] = GetSHA256Hash((string)e.NewValue);
            }
        }

        //Helper method to get SHA256 hash
        public static string GetSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // ComputeHash returns a byte array
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert the byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // "x2" formats as a two-digit hexadecimal number
                }
                return builder.ToString();
            }
        }
    }    
}