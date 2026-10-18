using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;

namespace RiemannSumVisualizer.frontend
{
    public class RiemannApplication : Form
    {
        private readonly Form _form;

        private readonly Font _defaultFont = new("Arial", 16.0f);

        private SplitContainer _splitContainer;

        private TableLayoutPanel _tableLayoutPanel;

        private TrackBar intervalsTrackBar;

        public RiemannApplication(Form form)
        {
            this._form = form;

            _splitContainer = new()
            {
                Orientation = Orientation.Vertical,
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = MidnightMathColors.GetColor(MidnightMath.TwilightBlack),
                SplitterDistance = _form.Width / 10
            };

            _tableLayoutPanel = new()
            {
                RowCount = 8,
                ColumnCount = 3,
                Dock = DockStyle.Fill,
                Padding = new(10),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                BackColor = MidnightMathColors.GetColor(MidnightMath.TwilightGray)
            };

            _form.Controls.Add(_splitContainer);

            _splitContainer.Panel1.Controls.Add(_tableLayoutPanel);

            /* Adding Inputs and labels to the 1st panel. */
            AddFunctionInput();
            AddBoundInputs();
            AddIntervalsInput();
        }

        private void AddFunctionInput()
        {
            Label functionLabel = new()
            {
                Text = "f(x) =",
                Font = _defaultFont,
                AutoSize = true,
                ForeColor = Color.AntiqueWhite
            };

            TextBox functionTextBox = new()
            {
                BackColor = MidnightMathColors.GetColor(MidnightMath.RoyalPlum),
                ForeColor = Color.AntiqueWhite,
                Size = new(_splitContainer.SplitterDistance, 80),
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Left,
            };

            _tableLayoutPanel.Controls.Add(functionLabel, 0, 0);
            _tableLayoutPanel.Controls.Add(functionTextBox, 1, 0);
        }

        private void AddBoundInputs()
        {
            Label lowerBoundLabel = new()
            {
                Text = "Lower Bound (a) =",
                Font = _defaultFont,
                AutoSize = true,
                ForeColor = Color.AntiqueWhite,
            };

            TextBox lowerBoundTextBox = new()
            {
                BackColor = MidnightMathColors.GetColor(MidnightMath.RoyalPlum),
                ForeColor = Color.AntiqueWhite,
                Size = new(_splitContainer.SplitterDistance, 80),
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Left
            };

            Label upperBoundLabel = new()
            {
                Text = "Upper Bound (b) =",
                Font = _defaultFont,
                AutoSize = true,
                ForeColor = Color.AntiqueWhite
            };

            TextBox upperBoundTextBox = new()
            {
                BackColor = MidnightMathColors.GetColor(MidnightMath.RoyalPlum),
                ForeColor = Color.AntiqueWhite,
                Size = new(_splitContainer.SplitterDistance, 80),
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Left
            };

            _tableLayoutPanel.Controls.Add(lowerBoundLabel, 0, 1);
            _tableLayoutPanel.Controls.Add(lowerBoundTextBox, 1, 1);
            _tableLayoutPanel.Controls.Add(upperBoundLabel, 0, 2);
            _tableLayoutPanel.Controls.Add(upperBoundTextBox, 1, 2);
        }

        private void AddIntervalsInput()
        {
            Label intervalsLabel = new()
            {
                Text = "Intervals (Δx) =",
                Font = _defaultFont,
                AutoSize = true,
                ForeColor = Color.AntiqueWhite
            };

            Label tickCounterLabel = new()
            {
                Text = "Intervals: ",
                Font = _defaultFont,
                AutoSize = true,
                ForeColor = Color.AntiqueWhite
            };

            intervalsTrackBar = new()
            {
                Minimum = 1,
                Maximum = 100,
                TickFrequency = 1,
                TickStyle = TickStyle.BottomRight,
                Size = new(_splitContainer.SplitterDistance, 80)
            };

            _tableLayoutPanel.Controls.Add(intervalsLabel, 0, 3);
            _tableLayoutPanel.Controls.Add(intervalsTrackBar, 1, 3);
            _tableLayoutPanel.Controls.Add(tickCounterLabel, 2, 3);
        }
    }
}
