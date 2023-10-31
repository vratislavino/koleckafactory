using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Koleckarna2ITB
{
    public partial class Form1 : Form
    {
        List<Tvar> tvary = new List<Tvar>();

        Tvar active = null;

        List<Factory> factoryList;

        public Form1() {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;

            factoryList = new List<Factory>() {
                new KoleckoFactory() {
                barva = button1.BackColor,
                velikost = (int)numericUpDown1.Value,
                vyplnene = checkBox1.Checked
            },
                new CtverecekFactory() {
                barva = button1.BackColor,
                velikost = (int)numericUpDown1.Value,
                vyplnene = checkBox1.Checked
            }
            };

        }

        private void canvas1_Paint(object sender, PaintEventArgs e) {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            foreach (Tvar t in tvary) {
                t.Vykresli(e.Graphics, checkBox2.Checked);
            }
        }

        private void canvas1_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {

                tvary.Add(factoryList[comboBox1.SelectedIndex].GetTvar(e.Location));

                /*if (new Random().Next(0, 2) == 1) {
                    tvary.Add(new Kolecko() {
                        r = (int) numericUpDown1.Value,
                        stred = e.Location,
                        vyplnene = checkBox1.Checked,
                        barva = button1.BackColor
                    });
                } else {
                    tvary.Add(new Ctverecek() {
                        velikost = (int) numericUpDown1.Value,
                        stred = e.Location,
                        vyplnene = checkBox1.Checked,
                        barva = button1.BackColor
                    });
                }*/
            } else if (e.Button == MouseButtons.Right) {
                Tvar closest = GetClosestTvar(e.Location);
                if (closest != null && closest != active) {
                    if (active != null)
                        active.Deactivate();
                    active = closest;
                    active.Activate();
                }
            }
            Refresh();
        }

        private Tvar GetClosestTvar(Point clickLocation) {
            Tvar t = null;
            float minDist = 1000;
            float currDist;
            for (int i = 0; i < tvary.Count; i++) {
                if (tvary[i].IsMouseOver(clickLocation, out currDist)) {
                    if (currDist < minDist) {
                        t = tvary[i];
                        minDist = currDist;
                    }
                }
            }
            return t;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) {
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                button1.BackColor = colorDialog1.Color;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e) {
            // Nastavíme továrnu, aby si pamatovala nastavení
            factoryList.ForEach(f => f.velikost = (int) numericUpDown1.Value);
        }

        private void button1_BackColorChanged(object sender, EventArgs e) {
            factoryList.ForEach(f => f.barva = button1.BackColor);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            factoryList.ForEach(f => f.vyplnene = checkBox1.Checked);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            //MessageBox.Show(comboBox1.SelectedIndex.ToString());
        }
    }
}
