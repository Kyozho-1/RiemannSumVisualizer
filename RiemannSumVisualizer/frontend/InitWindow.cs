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

        private readonly string applicationTitle = "Riemann Sum Visualizer";

        public InitWindow()
        {
            this.ClientSize = new(windowSize[0], windowSize[1]);
            this.WindowState = FormWindowState.Maximized;
            this.Text = applicationTitle;

            _ = new RiemannApplication(this);
        }
    }
}
