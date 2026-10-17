using System;
using System.Collections.Generic;
using System.Text;

using org.mariuszgromada.math.mxparser;
using org.mariuszgromada.math.mxparser.syntaxchecker;

namespace RiemannSumVisualizer.backend
{
    public class Riemann(
        string expression, double start, double end, int numOfRects, 
        Riemann.RiemannType riemannType
        )
    {
        public enum RiemannType : int
        {
            Left,
            Right,
            Mid,
            Trapezoidal
        }

        private readonly Argument _argument = new("x = 0");
        private Expression? _expression;

        private readonly double _start = start;
        private readonly double _end = end;

        private readonly double _deltaX = (end - start) / numOfRects;

        private readonly int _numOfRects = numOfRects;

        private RiemannType riemannType = riemannType;

        private double _left, _mid, _right, _trap, _exact;

        public double CalculateLeftSum()
        {
            double x_i;

            _expression = new(expression, _argument);

            CheckEquationSyntax();
            CheckBounds();

            for (int i = 0; i < _numOfRects; i++)
            {
                x_i = _start + i * _deltaX;

                _argument.setArgumentValue(x_i);

                _left += _expression.calculate() * _deltaX;
            }

            return _left;
        }

        public double CalculateRightSum()
        {
            double x_iPlus1;

            _expression = new(expression, _argument);

            CheckEquationSyntax();
            CheckBounds();

            for (int i = 0; i < _numOfRects; i++)
            {
                x_iPlus1 = _start + (i + 1) * _deltaX;

                _argument.setArgumentValue(x_iPlus1);

                _right += _expression.calculate() * _deltaX;
            }

            return _right;
        }

        public double CalculateMidSum()
        {
            double x_i, x_iPlus1;

            _expression = new(expression, _argument);

            CheckEquationSyntax();
            CheckBounds();

            for (int i = 0; i < _numOfRects; i++)
            {
                x_i = _start + i * _deltaX;
                x_iPlus1 = _start + (i + 1) * _deltaX;

                _argument.setArgumentValue(
                    (x_i + x_iPlus1) / 2
                );

                _mid += _expression.calculate() * _deltaX;
            }

            return _mid;
        }

        public double CalculateTrapezoidalSum()
        {
            double x_i, x_iPlus1;

            _expression = new(expression, _argument);

            CheckEquationSyntax();
            CheckBounds();

            for (int i = 0; i < _numOfRects; i++)
            {
                x_i = _start + i * _deltaX;

                _argument.setArgumentValue(x_i);

                _trap += (_expression.calculate() / 2) * _deltaX;

                x_iPlus1 = x_i + _deltaX;

                _argument.setArgumentValue(x_iPlus1);

                _trap += (_expression.calculate() / 2) * _deltaX;
            }

            return _trap;
        }

        public double CalculateExactIntegral()
        {
            _expression = new("int(" + expression + ",x," + _start + "," + _end + ")");

            CheckEquationSyntax();
            CheckBounds();

            _exact = _expression.calculate();

            return _exact;
        }

        public double CalculateApproximationError()
        {
            return riemannType switch
            {
                RiemannType.Left => (_left / _exact) * 100,
                RiemannType.Right => (_right / _exact) * 100,
                RiemannType.Mid => (_mid / _exact) * 100,
                RiemannType.Trapezoidal => (_trap / _exact) * 100,
                _ => throw new NotImplementedException()
            };
        }
        private void CheckEquationSyntax()
        {
            if (_expression is null)
            {
                throw new NullReferenceException("Error! Please enter an expression.");
            }

            if (_expression.checkSyntax() == false)
            {
                throw new ParseException("Error! Please enter a valid expression");
            }
        }

        private void CheckBounds()
        {
            if (_start >= _end)
            {
                throw new ArgumentException(
                    "Error! The starting point cannot be greater than or equal " +
                    "to the ending point."
                    );
            }
            
            if (_end <= _start)
            {
                throw new ArgumentException(
                    "Error! The ending point cannot be less than or equal " +
                    "to the starting point."
                    );
            }
        }
    }
}