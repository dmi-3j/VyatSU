using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vaccinecalend;

namespace App
{
    public partial class ReactionsForm : Form
    {
        public ReactionsForm(Guid id, bool flag)
        {
            InitializeComponent();
            reactionsTable.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.flag = flag;
            this.id = id;
        }
        private bool flag;
        private Guid id;
        private void Init()
        {
            reactionsTable.Rows.Clear();
            if (flag) reactionsTable.Columns["action"].Visible = false;
            using (var context = new VaccineCalendarContext())
            {
                List<ReactionOnVaccination> reactions = context.Reactions
                    .Where(r => r.VaccinationId == id).ToList();
                if (reactions.Count != 0)
                {
                    foreach (ReactionOnVaccination r in reactions)
                    {
                        string date = r.DateOfReaction.Date.ToString("yyyy-MM-dd");
                        string text = r.DescriptionOfReaction;
                        reactionsTable.Rows.Add(r.ReactionId, date, text);
                    }
                }
                else
                {
                    MessageBox.Show("Нет реакций на данную вакцинацию!", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    return;
                }
            }
        }

        private void reactionsTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == reactionsTable.Columns["action"].Index)
            {
                if (reactionsTable.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
                {
                    using (var context = new VaccineCalendarContext())
                    {
                        DBService service = new DBService(context);

                        ReactionOnVaccination? reaction = context.Reactions
                            .Where(r => r.ReactionId == Guid.Parse(reactionsTable.Rows[e.RowIndex].Cells["idr"].Value.ToString()))
                                .FirstOrDefault();
                        if (reaction != null) service.DeleteReactionOnVaccination(reaction);
                        Init();
                    }
                }
            }
        }

        private void ReactionsForm_Load(object sender, EventArgs e)
        {
            Init();
        }
    }
}
