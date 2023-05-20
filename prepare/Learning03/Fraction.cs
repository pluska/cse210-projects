using System;

public class Fraction
    {
        private int _top;
        private int _bottom;

        public Fraction()
        {
            _top = 1;
            _bottom = 1;
        }

        public Fraction(int wholeNumber)
        {
            _top = wholeNumber;
            _bottom = 1;
        }
        public Fraction(int top, int bottom)
        {
            _top = top;
            _bottom = bottom;
        }
        public int getTop()
        {
            return _top;
        }
        public int getBottom()
        {
            return _bottom;
        }
        public void setTop(int top)
        {
            _top = top;
        }
        public void setBottom(int bottom)
        {
            _bottom = bottom;
        }

        public void GetFractionValue()
        {
            Console.WriteLine($"Fraction value is {_top}/{_bottom}");
        }
        public void GetDecimalValue()
        {
            Console.WriteLine($"Decimal value is {(double)_top / _bottom}");
        }

    }