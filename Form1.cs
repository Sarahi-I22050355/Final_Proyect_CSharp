using System.Data;
using System.Text;
using System.Xml;
using CsvHelper;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Formats.Asn1;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Final_Proyect_CSharp
{
    public partial class Form1 : Form
    {
        private Dictionary<string, string> cambios = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
            string query = "SELECT * FROM SongsDB.dbo.Songs";
            DataTable dataTable = Connection.GetDataTable(query);
            dgvSongs.DataSource = dataTable;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormClosed += MiFormulario_Closed;
        }

        private void MiFormulario_Closed(object sender, EventArgs e)
        {
            // Manejar el evento aquí
            MessageBox.Show("The window is closed.");
            Login.Instancia.Show();
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Files CSV (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.Title = "Save file CSV";

            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            ExportarDataGridViewCSV(saveFileDialog.FileName);
        }

        private void ExportarDataGridViewCSV(string fileName)
        {
            if (dgvSongs.Rows.Count == 0)
            {
                MessageBox.Show("No data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < dgvSongs.Columns.Count; i++)
            {
                sb.Append(dgvSongs.Columns[i].HeaderText);
                if (i < dgvSongs.Columns.Count - 1)
                {
                    sb.Append(",");
                }
            }
            sb.AppendLine();

            foreach (DataGridViewRow row in dgvSongs.Rows)
            {
                for (int i = 0; i < dgvSongs.Columns.Count; i++)
                {
                    sb.Append(row.Cells[i].Value);
                    if (i < dgvSongs.Columns.Count - 1)
                    {
                        sb.Append(",");
                    }
                }
                sb.AppendLine();
            }

            try
            {
                File.WriteAllText(fileName, sb.ToString());
                MessageBox.Show("The files was export " + fileName, "Succefuly", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error to export data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML Files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog.Title = "Save XML File";

            TextBox txtFileName = new TextBox();
            txtFileName.Text = "data";
            saveFileDialog.FileName = txtFileName.Text;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportDataGridViewToXML(dgvSongs, saveFileDialog.FileName);
            }
        }

        private void ExportDataGridViewToXML(DataGridView dataGridView, string fileName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement rootNode = xmlDocument.CreateElement("Data");
            xmlDocument.AppendChild(rootNode);

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                XmlElement rowElement = xmlDocument.CreateElement("Row");

                foreach (DataGridViewCell cell in row.Cells)
                {
                    string cellValue = cell.Value?.ToString() ?? "";
                    XmlElement cellElement = xmlDocument.CreateElement("Cell");
                    cellElement.InnerText = cellValue;
                    rowElement.AppendChild(cellElement);
                }
                rootNode.AppendChild(rowElement);
            }

            try
            {
                xmlDocument.Save(fileName);
                MessageBox.Show("Data exported successfully to " + fileName, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnJSON_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog.Title = "Save JSON File";
            saveFileDialog.FileName = "data";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportDataGridViewToJSON(dgvSongs, saveFileDialog.FileName);
            }
        }

        private void ExportDataGridViewToJSON(DataGridView dataGridView, string fileName)
        {
            List<Dictionary<string, object>> dataList = new List<Dictionary<string, object>>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                Dictionary<string, object> rowData = new Dictionary<string, object>();

                foreach (DataGridViewCell cell in row.Cells)
                {
                    rowData[dataGridView.Columns[cell.ColumnIndex].HeaderText] = cell.Value;
                }

                dataList.Add(rowData);
            }

            string jsonData = JsonConvert.SerializeObject(dataList, Newtonsoft.Json.Formatting.Indented);

            try
            {
                File.WriteAllText(fileName, jsonData);
                MessageBox.Show("Data exported successfully to " + fileName, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*";
            saveFileDialog.Title = "Save PDF File";
            saveFileDialog.FileName = "data";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                ExportDataGridViewToPDF(dgvSongs, saveFileDialog.FileName);
            }
        }

        private void ExportDataGridViewToPDF(DataGridView dataGridView, string fileName)
        {
            try
            {
 
                PdfWriter pdfWriter = new PdfWriter(fileName);
                PdfDocument pdfDocument = new PdfDocument(pdfWriter);
                iText.Layout.Document document = new iText.Layout.Document(pdfDocument);


                Table table = new Table(dataGridView.Columns.Count);

                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    table.AddHeaderCell(column.HeaderText);
                }

                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        table.AddCell(cell.Value?.ToString());
                    }
                }
                document.Add(table);

                document.Close();

                MessageBox.Show("Data exported successfully to " + fileName, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSongs_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string firstCellValue = dgvSongs.Rows[e.RowIndex].Cells[0].Value.ToString();

                string columnName = dgvSongs.Columns[e.ColumnIndex].Name;

                string key = $"{firstCellValue}-{columnName}";

                cambios[key] = dgvSongs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
        }

        private void btnSaveSQL_Click(object sender, EventArgs e)
        {
            foreach (var cambio in cambios)
            {
                string[] indices = cambio.Key.Split('-');
                string firstCellValue = indices[0];
                string columnName = indices[1];
                string newValue = cambio.Value;

                string query = $"UPDATE Songs_Sp.dbo.spotify_songs SET {columnName} = @NewValue WHERE track_id = @FirstCellValue";

                Connection.ExecuteQuery(query, new SqlParameter("@NewValue", newValue), new SqlParameter("@FirstCellValue", firstCellValue));

                MessageBox.Show($"Cell updated in row {firstCellValue} and column {columnName} with value {newValue}");

            }

            cambios.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cambios.Clear();
            string query = "SELECT * FROM Songs_Sp.dbo.spotify_songs";
            DataTable dataTable = Connection.GetDataTable(query);
            dgvSongs.DataSource = null;
            dgvSongs.DataSource = dataTable;
            MessageBox.Show("Changes have been reverted.");
        }


    }

}
