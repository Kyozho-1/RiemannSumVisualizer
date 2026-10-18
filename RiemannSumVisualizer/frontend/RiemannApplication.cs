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

        private readonly Color _neonSkyBlue = Color.FromArgb(152, 255, 255);
        private readonly Color _cloudyLavendar = Color.FromArgb(203, 204, 255);

        public RiemannApplication(Form form)
        {
            this._form = form;

            _splitContainer = new()
            {
                Orientation = Orientation.Vertical,
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = _cloudyLavendar
            };

            _tableLayoutPanel = new()
            {
                RowCount = 8,
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                Padding = new(10),
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };

            _form.Controls.Add(_splitContainer);

            _splitContainer.Panel1.Controls.Add(_tableLayoutPanel);

            AddFunctionInput();
            AddBoundInputs();
        }

        private void AddFunctionInput()
        {
            Label functionLabel = new()
            {
                Text = "f(x) =",
                Font = _defaultFont,
                AutoSize = true
            };

            TextBox functionTextBox = new()
            {
                BackColor = _neonSkyBlue,
                Size = new(_splitContainer.SplitterDistance, 80),
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Left
            };

            _tableLayoutPanel.Controls.AddRange([functionLabel, functionTextBox]);
        }

        private void AddBoundInputs()
        {
            Label lowerBoundLabel = new()
            {
                Text = "Lower Bound (a) =",
                Font = _defaultFont,
                AutoSize = true
            };

            TextBox lowerBoundTextBox = new()
            {
                BackColor = _neonSkyBlue,
                Size = new(_splitContainer.SplitterDistance, 80),
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Left
            };

            Label upperBoundLabel = new()
            {
                Text = "Upper Bound (b) =",
                Font = _defaultFont,
                AutoSize = true
            };

            TextBox upperBoundTextBox = new()
            {
                BackColor = _neonSkyBlue,
                Size = new(_splitContainer.SplitterDistance, 80),
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Left
            };

            _tableLayoutPanel.Controls.AddRange([lowerBoundLabel, lowerBoundTextBox]);
            _tableLayoutPanel.Controls.AddRange([upperBoundLabel, upperBoundTextBox]);
        }
    }
}
