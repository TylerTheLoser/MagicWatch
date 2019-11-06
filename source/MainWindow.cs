using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace MTG_App
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string dumbToken; //define the variable

        public void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchTerm = txtSearch.Text;
            var labelMulti = lblMID.Text;
            var labelEcho = lblEID.Text;
            var labelName = lblTheName.Text;
            var labelExp = lblExpansion.Text;
            var labelSet = lblSC.Text;

            var json = new WebClient().DownloadString("https://www.echomtg.com/api/data/card_reference/auth=" + dumbToken);
            var myCardRef = CardRef.FromJson(json);
            Console.WriteLine(myCardRef.Message);
            Console.WriteLine(myCardRef.Status);
            Console.WriteLine(myCardRef.Cards.Count);
            try
            {
                foreach (var item in myCardRef.Cards.Keys)
                {
                    if (myCardRef.Cards[item].Name.Equals(searchTerm, StringComparison.InvariantCultureIgnoreCase)) //TODO check if null
                                                                                                                    //TODO iterate through multiple responses. this is important!
                    {
                        string imagelink = ("https://assets.echomtg.com/magic/cards/original/" + myCardRef.Cards[item].EchoId.ToString() + ".jpg");
                        picBox.ImageLocation = imagelink;
                        picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        lblTheName.Text = myCardRef.Cards[item].Name;
                        lblMID.Text = myCardRef.Cards[item].MultiverseId.ToString();
                        lblEID.Text = myCardRef.Cards[item].EchoId.ToString();
                        lblExpansion.Text = myCardRef.Cards[item].Expansion.ToString();
                        lblSC.Text = myCardRef.Cards[item].SetCode.ToString();
                        break;
                    }
                }
            } catch(NullReferenceException)
            {
                MessageBox.Show("Card not found, please enter a valid card name.", "Error");
            }

        }

        private void btnGetInv_Click(object sender, EventArgs e)
        {
            var json = new WebClient().DownloadString("https://www.echomtg.com/api/inventory/view/start=0&limit=100&auth=" + dumbToken);
            var myInventory = MyInventory.FromJson(json);
            var test = JObject.Parse(json);
            JArray itemcount = (JArray)test["items"];
            int length = itemcount.Count;
            Console.WriteLine(length);
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            int i = 0;
            while (i < length)
            {
                //TODO add to dgv
                var rowindex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowindex].Cells["cardName"].Value = myInventory.Items[i].Name.ToString();
                dataGridView1.Rows[rowindex].Cells["inventoryID"].Value = myInventory.Items[i].InventoryId.ToString();
                dataGridView1.Rows[rowindex].Cells["rarity"].Value = myInventory.Items[i].Rarity.ToString();
                dataGridView1.Rows[rowindex].Cells["condition"].Value = myInventory.Items[i].Condition.ToString();
                dataGridView1.Rows[rowindex].Cells["set"].Value = myInventory.Items[i].Set.ToString();
                dataGridView1.Rows[rowindex].Cells["expansion"].Value = myInventory.Items[i].Expansion.ToString();
                dataGridView1.Rows[rowindex].Cells["colors"].Value = myInventory.Items[i].Colors.ToString();
                dataGridView1.Rows[rowindex].Cells["types"].Value = myInventory.Items[i].Types.ToString();
                dataGridView1.Rows[rowindex].Cells["currentprice"].Value = myInventory.Items[i].CurrentPrice.ToString();
                dataGridView1.Rows[rowindex].Cells["dateacquired"].Value = myInventory.Items[i].DateAcquired.ToString();
                i++;
            }
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV|*.csv";
            sfd.Title = "Save your CSV file";
            sfd.FileName = "MTG_Inventory.csv";

            if(sfd.ShowDialog() == DialogResult.OK)
            {
                var sb = new StringBuilder();

                var headers = dataGridView1.Columns.Cast<DataGridViewColumn>();
                sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var cells = row.Cells.Cast<DataGridViewCell>();
                    sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
                }
                System.IO.StreamWriter file = new System.IO.StreamWriter(Path.GetFullPath(sfd.FileName).ToString());
                file.WriteLine(sb.ToString());
                file.Close();
                MessageBox.Show("File saved successfully.", "File Saved");
            }

        }

        private void btnAddInv_Click(object sender, EventArgs e)
        {
            if(lblEID.Text != null)
            {
                //TODO: use a better reference, allow the user to change the condition, acquire date, and quantity. etc. this is too simple.
                var json = new WebClient().DownloadString("https://www.echomtg.com/api/inventory/add/mid=" + lblMID.Text.ToString() + "&auth=" + dumbToken);
                MessageBox.Show("Successfully added " + lblTheName.Text + " to your inventory!", "Card Added!");
            } else
            {
                MessageBox.Show("Error");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }

}
