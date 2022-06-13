using System;
using TMPro;

namespace Asteroids
{
    internal sealed class InterpreterPoints
    {
        private TMP_Text _text;
        
        public InterpreterPoints(TMP_Text text)
        {
            _text = text;
        }

        public void ViewPoints(long count)
        {
            _text.text = ToFormat(count);
        }
        
        private string ToFormat(long number)
        {
            if (number < 1) return string.Empty;
            if (number >= 1000000) return $"{number / 1000000}M";
            if (number >= 1000) return $"{number / 1000}K";
            if (number >= 1) return $"{number}";
            throw new ArgumentOutOfRangeException(nameof(number));
        }
    }
}