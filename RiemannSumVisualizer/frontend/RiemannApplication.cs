using RiemannSumVisualizer.backend;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Text;

using System.Windows.Forms;

namespace RiemannSumVisualizer.frontend
{
    public class RiemannApplication : Form
    {
        private readonly Form _form;

        private readonly Font _defaultFont = new("Calisto MT", 16.0f);

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
                BackColor = MidnightMathColors.TwilightBlack,
                SplitterDistance = _form.Width / 12,
                IsSplitterFixed = true
            };

            _tableLayoutPanel = new()
            {
                RowCount = 9,
                ColumnCount = 3,
                Dock = DockStyle.Fill,
                Padding = new(10),
                BackColor = MidnightMathColors.TwilightGray
            };

            _form.Controls.Add(_splitContainer);

            _splitContainer.Panel1.Controls.Add(_tableLayoutPanel);

            /* Adding Inputs and labels to the 1st panel. */
            AddFunctionInput();
            AddBoundInputs();
            AddIntervalsInput();
            AddEndpointInputs();
            AddSumResults();
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
                BackColor = MidnightMathColors.RoyalPlum,
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
                BackColor = MidnightMathColors.RoyalPlum,
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
                BackColor = MidnightMathColors.RoyalPlum,
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

        private void AddEndpointInputs()
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
                BackColor = MidnightMathColors.RoyalPlum,
                ForeColor = Color.AntiqueWhite,
                Font = _defaultFont,
                Size = new(200, 0)
            };

            _endpointsComboBox.Items.AddRange(endpointTitles);

            _tableLayoutPanel.Controls.Add(endpointTypeLabel, 0, 4);
            _tableLayoutPanel.Controls.Add(_endpointsComboBox, 0, 5);
        }

        private void AddSumResults()
        {
            Label approxLabel, exactLabel, approxValueLabel, exactValueLabel;

            CreateLabels();
            CreatePanels();

            void CreateLabels()
            {
                approxLabel = new()
                {
                    Text = "Approximate",
                    Font = _defaultFont,
                    AutoSize = true,
                    ForeColor = Color.AntiqueWhite,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };

                exactLabel = new()
                {
                    Text = "Exact",
                    Font = _defaultFont,
                    AutoSize = true,
                    ForeColor = Color.AntiqueWhite,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };

                approxValueLabel = new()
                {
                    Text = "0.0000",
                    Font = _defaultFont,
                    AutoSize = true,
                    ForeColor = MidnightMathColors.ChampagnePink,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };

                exactValueLabel = new()
                {
                    Text = "0.0000",
                    Font = _defaultFont,
                    AutoSize = true,
                    ForeColor = MidnightMathColors.ChampagnePink,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };
            }

            void CreatePanels()
            {
                int[] dimensions = [250, 100];     // Width, Height
                int[] margins    = [0, 20, 0, 20]; // Left, Top, Right, Bottom

                TableLayoutPanel approxTablePanel = new()
                {
                    Size = new(dimensions[0], dimensions[1]),
                    BackColor = MidnightMathColors.RoyalPlum,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new(margins[0], margins[1], margins[2], margins[3]),
                    RowCount = 2,
                    ColumnCount = 1
                };

                TableLayoutPanel exactTablePanel = new()
                {
                    Size = new(dimensions[0], dimensions[1]),
                    BackColor = MidnightMathColors.RoyalPlum,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new(margins[0], margins[1], margins[2], margins[3]),
                    RowCount = 2,
                    ColumnCount = 1
                };

                approxTablePanel.Controls.Add(approxLabel, 0, 0);
                approxTablePanel.Controls.Add(approxValueLabel, 0, 1);

                exactTablePanel.Controls.Add(exactLabel, 0, 0);
                exactTablePanel.Controls.Add(exactValueLabel, 0, 1);

                _tableLayoutPanel.Controls.Add(approxTablePanel, 0, 6);
                _tableLayoutPanel.Controls.Add(exactTablePanel, 1, 6);
            }
        }
    }
}
