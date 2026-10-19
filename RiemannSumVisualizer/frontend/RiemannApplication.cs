using RiemannSumVisualizer.backend;
using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;

namespace RiemannSumVisualizer.frontend
{
    public class RiemannApplication : Form
    {
        private readonly Form _form;

        private readonly Font _defaultFont = new("Segoe UI", 16.0f);

        private SplitContainer _splitContainer;

        private TableLayoutPanel _tableLayoutPanel;

        private TrackBar _intervalsTrackBar;

        private RiemannApplication _riemann;

        private TextBox _functionTextBox, _lowerBoundTextBox, _upperBoundTextBox;

        private ComboBox _endpointsComboBox;

        public RiemannApplication(Form form)
        {
            this._form = form;

            _splitContainer = new()
            {
                Orientation = Orientation.Vertical,
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = MidnightMathColors.GetColor(MidnightMath.TwilightBlack),
                SplitterDistance = _form.Width / 12
            };

            _tableLayoutPanel = new()
            {
                RowCount = 8,
                ColumnCount = 3,
                Dock = DockStyle.Fill,
                Padding = new(10),
                BackColor = MidnightMathColors.GetColor(MidnightMath.TwilightGray)
            };

            _form.Controls.Add(_splitContainer);

            _splitContainer.Panel1.Controls.Add(_tableLayoutPanel);

            /* Adding Inputs and labels to the 1st panel. */
            AddFunctionInput();
            AddBoundInputs();
            AddIntervalsInput();
            AddEndpointInputs();
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

            _functionTextBox = new()
            {
                BackColor = MidnightMathColors.GetColor(MidnightMath.RoyalPlum),
                ForeColor = Color.AntiqueWhite,
                Size = new(_splitContainer.SplitterDistance, 80),
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Left,
                Font = _defaultFont
            };

            _tableLayoutPanel.Controls.Add(functionLabel, 0, 0);
            _tableLayoutPanel.Controls.Add(_functionTextBox, 1, 0);
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

            _lowerBoundTextBox = new()
            {
                BackColor = MidnightMathColors.GetColor(MidnightMath.RoyalPlum),
                ForeColor = Color.AntiqueWhite,
                Size = new(_splitContainer.SplitterDistance, 80),
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Left,
                Font = _defaultFont
            };

            Label upperBoundLabel = new()
            {
                Text = "Upper Bound (b) =",
                Font = _defaultFont,
                AutoSize = true,
                ForeColor = Color.AntiqueWhite
            };

            _upperBoundTextBox = new()
            {
                BackColor = MidnightMathColors.GetColor(MidnightMath.RoyalPlum),
                ForeColor = Color.AntiqueWhite,
                Size = new(_splitContainer.SplitterDistance, 80),
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Left,
                Font = _defaultFont
            };

            _tableLayoutPanel.Controls.Add(lowerBoundLabel, 0, 1);
            _tableLayoutPanel.Controls.Add(_lowerBoundTextBox, 1, 1);
            _tableLayoutPanel.Controls.Add(upperBoundLabel, 0, 2);
            _tableLayoutPanel.Controls.Add(_upperBoundTextBox, 1, 2);
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
                Text = "Intervals: 0",
                Font = _defaultFont,
                AutoSize = true,
                ForeColor = Color.AntiqueWhite
            };

            _intervalsTrackBar = new()
            {
                Minimum = 1,
                Maximum = 100,
                TickFrequency = 1,
                TickStyle = TickStyle.BottomRight,
                Size = new(_splitContainer.SplitterDistance, 80),
            };

            _intervalsTrackBar.Scroll += ScrollChange;

            _tableLayoutPanel.Controls.Add(intervalsLabel, 0, 3);
            _tableLayoutPanel.Controls.Add(_intervalsTrackBar, 1, 3);
            _tableLayoutPanel.Controls.Add(tickCounterLabel, 2, 3);

            void ScrollChange(object? s, EventArgs _)
            {
                TrackBar trackBar = (TrackBar)s;

                tickCounterLabel.Text = "Intervals: " + trackBar.Value.ToString();
            }
        }

        public void AddEndpointInputs()
        {
            var endpointTitles = new[] { "Right", "Mid", "Left", "Trapezoidal" };

            Label endpointTypeLabel = new()
            {
                Text = "Endpoint Type",
                Font = _defaultFont,
                AutoSize = true,
                ForeColor = Color.AntiqueWhite
            };

            _endpointsComboBox = new()
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                BackColor = MidnightMathColors.GetColor(MidnightMath.RoyalPlum),
                ForeColor = Color.AntiqueWhite,
                Font = _defaultFont,
                Size = new(200, 0)
            };

            _endpointsComboBox.Items.AddRange(endpointTitles);

            _tableLayoutPanel.Controls.Add(endpointTypeLabel, 0, 4);
            _tableLayoutPanel.Controls.Add(_endpointsComboBox, 0, 5);
        }
    }
}
