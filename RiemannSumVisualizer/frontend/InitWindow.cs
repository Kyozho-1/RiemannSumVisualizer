using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using RiemannSumVisualizer.backend;

namespace RiemannSumVisualizer.frontend
{
    public class InitWindow : Form
    {
        private readonly int[] windowSize = [800, 800];

        public InitWindow()
        {
            this.ClientSize = new(windowSize[0], windowSize[1]);
            this.WindowState = FormWindowState.Maximized;

            _ = new RiemannApplication(this);
        }
    }
}
