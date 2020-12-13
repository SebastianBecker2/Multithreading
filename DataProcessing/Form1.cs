using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataProcessing
{
    public partial class Form1 : Form
    {
        private IList<string> Filenames = new List<string>
        {
            "01 - Eat The Elephant.mp3",
            "02 - Disillusioned.mp3",
            "03 - The Contrarian.mp3",
            "04 - The Doomed [Explicit].mp3",
            "05 - So Long, And Thanks For All The Fish.mp3",
            "06 - TalkTalk [Explicit].mp3",
            "07 - By And Down The River.mp3",
            "08 - Delicious.mp3",
            "09 - DLB.mp3",
            "10 - Hourglass.mp3",
            "11 - Feathers.mp3",
            "12 - Get The Lead Out.mp3",
            "01 - The Hollow.mp3",
            "02 - Magdalena.mp3",
            "03 - Rose.mp3",
            "04 - Judith.mp3",
            "05 - Orestes.mp3",
            "06 - 3 Libras.mp3",
            "07 - Sleeping Beauty.mp3",
            "08 - Thomas.mp3",
            "09 - Renholdër.mp3",
            "10 - Thinking of You.mp3",
            "11 - Breña.mp3",
            "12 - Over.mp3",
            "01 - Open Your Eyes [Explicit].mp3",
            "02 - Pressure [Explicit].mp3",
            "03 - Fade.mp3",
            "04 - It's Been Awhile [Explicit].mp3",
            "05 - Change [Explicit].mp3",
            "06 - Can't Believe [Explicit].mp3",
            "07 - Epiphany.mp3",
            "08 - Suffer.mp3",
            "09 - Warm Safe Place.mp3",
            "10 - For You [Explicit].mp3",
            "11 - Outside.mp3",
            "12 - Waste [Explicit].mp3",
            "13 - Take It [Explicit].mp3",
            "14 - It's Been Awhile (Acoustic Version) [Explicit].mp3",
            "01 - Inception The Bleeding Skies.mp3",
            "02 - Pillars Of Serpents.mp3",
            "03 - If I Could Collapse The Masses.mp3",
            "04 - Fugue (A Revelation).mp3",
            "05 - Requiem.mp3",
            "06 - Ember To Inferno.mp3",
            "07 - Ashes.mp3",
            "08 - To Burn The Eye.mp3",
            "09 - Falling To Grey.mp3",
            "10 - My Hatred.mp3",
            "11 - When All Light Dies.mp3",
            "12 - A View Of Burning Empires.mp3",
            "13 - Blinding Tears Will Break The Skies.mp3",
            "14 - The Deceived.mp3",
            "15 - Demon.mp3",
            "01 - Following Caligula.mp3",
            "02 - Calibrate The Virus.mp3",
            "03 - Watcher.mp3",
            "04 - Courtesy Bow.mp3",
            "05 - The Fall Of Rome.mp3",
            "06 - Malice In Wonderland.mp3",
            "07 - 55_23.mp3",
            "08 - The Hampton Roads Fourth Annual Parade For The Blind.mp3",
            "09 - To The Nines.mp3",
            "10 - L'Aeroport.mp3",
            "01 - Fear Inoculum.mp3",
            "02 - Pneuma.mp3",
            "03 - Litanie contre la Peur.mp3",
            "04 - Invincible.mp3",
            "05 - Legion Inoculant.mp3",
            "06 - Descending.mp3",
            "07 - Culling Voices.mp3",
            "08 - Chocolate Chip Trip.mp3",
            "09 - 7empest [Explicit].mp3",
            "10 - Mockingbeat.mp3",
            "01 - HereWithMe.mp3",
            "02 - Hunter.mp3",
            "03 - Don'tThinkOfMe.mp3",
            "04 - MyLover'sGone.mp3",
            "05 - AllYouWant.mp3",
            "06 - ThankYou.mp3",
            "07 - HonestlyOk.mp3",
            "08 - Slide.mp3",
            "09 - Isobel.mp3",
            "10 - I'mNoAngel.mp3",
            "11 - MyLife.mp3",
            "12 - TakeMyHand (BonusTrack).mp3",
            "01 - Explosia.mp3",
            "02 - L' Enfant Sauvage.mp3",
            "03 - The Axe.mp3",
            "04 - Liquid Fire.mp3",
            "05 - The Wild Healer.mp3",
            "06 - Planned Obsolescence.mp3",
            "07 - Mouth of Kala.mp3",
            "08 - The Gift of Guilt.mp3",
            "09 - Pain Is a Master.mp3",
            "10 - Born in Winter.mp3",
            "11 - The Fall.mp3",
            "12 - This Emptiness [-].mp3",
            "13 - My Last Creation [-].mp3",
            "01 - The Shooting Star.mp3",
            "02 - Silvera.mp3",
            "03 - The Cell.mp3",
            "04 - Stranded.mp3",
            "05 - Yellow Stone.mp3",
            "06 - Magma.mp3",
            "07 - Pray.mp3",
            "08 - Only Pain.mp3",
            "09 - Low Lands.mp3",
            "10 - Liberation.mp3",
        };

        private ConcurrentQueue<string> FilesToProcess;

        private volatile bool Cancel = false;
        private ThreadSafeRandom Random = new ThreadSafeRandom();

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            ResetDgvFilenames(Filenames);

            base.OnLoad(e);
        }

        public void OnFileFinished(string filename)
        {
            DgvFilenames.InvokeIfRequired(() =>
            {
                foreach (var row in DgvFilenames.Rows.Cast<DataGridViewRow>())
                {
                    if (filename != row.Cells[0].Value as string)
                    {
                        continue;
                    }

                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    this.Refresh();
                    return;
                }
            });
        }

        void ResetDgvFilenames(IList<string> filenames)
        {
            DgvFilenames.Rows.Clear();
            foreach (var file in filenames)
            {
                var cell = new DataGridViewTextBoxCell();
                cell.Value = file;
                var row = new DataGridViewRow();
                row.Cells.Add(cell);
                DgvFilenames.Rows.Add(row);
            }
            DgvFilenames.ClearSelection();
        }

        private void BtnProcessFilesSingleThreaded_Click(object sender, EventArgs e)
        {
            ResetDgvFilenames(Filenames);
            FilesToProcess = new ConcurrentQueue<string>(Filenames);
            Cancel = false;

            ProcessFiles();
        }

        private void BtnProcessFilesMultiThreaded_Click(object sender, EventArgs e)
        {
            ResetDgvFilenames(Filenames);
            FilesToProcess = new ConcurrentQueue<string>(Filenames);
            Cancel = false;

            foreach (var i in Enumerable.Range(0, Environment.ProcessorCount))
            {
                Task.Factory.StartNew(ProcessFiles);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Cancel = true;
        }

        private void ProcessFiles()
        {
            while (FilesToProcess.TryDequeue(out string filename)) {
                ProcessFile(filename);

                if (Cancel)
                {
                    return;
                }
            }
        }

        private void ProcessFile(string filename)
        {
            DateTime start = DateTime.Now;

            int time_in_milliseconds = Random.Next(1000, 3000);
            while (DateTime.Now - start < TimeSpan.FromMilliseconds(time_in_milliseconds))
            {
                string timestamp = DateTime.Now.ToString();
            }

            OnFileFinished(filename);
        }
    }
}
