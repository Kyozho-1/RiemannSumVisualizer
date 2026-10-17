using System;
using System.Windows.Forms;
using RiemannSumVisualizer.frontend;

namespace RiemannSumVisualizer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new RiemannSumVisualizer.frontend.MainWindow());
        }
    }
}