using System;
using System.Linq;
using System.Text;
using TechOneAssessment.Models;

namespace TechOneAssessment.Controllers
{
    static internal class NumbersToWords
    {
        public static string ConvertToWords(double numbers)
        {
            var words = new StringBuilder();
            NumbersToWordsModel model = new NumbersToWordsModel();
 
            long wholeNumber = (long)numbers;

            WordBuilder(model, wholeNumber, words);
            words.Append(" dollars ");
            return DecimalBuilder(model, numbers, words);
        }

        private static string DecimalBuilder(NumbersToWordsModel model, double numbers, StringBuilder words)
        {
            int decNumber = 0;

            if ((numbers % 1) > 0)
            {
                double i = (numbers % 1) * 100;
                decNumber = (int)i;
            }
            if (decNumber > 0)
            {
                words.Append(" and ");
                WordBuilder(model, decNumber, words);
                words.Append(" cents");
            }

            return words.ToString();
        }

        private static string WordBuilder(NumbersToWordsModel model, long dividend, StringBuilder words)
        {

            if (model._NumberMap.ContainsKey(dividend))
            {
                AppendTo(words, model, dividend);
            }
            else
            {
                var divisor = model._NumberMap.First(m => m.Key <= dividend).Key;
                var quotient = dividend / divisor;
                var remainder = dividend % divisor;

                if (quotient > 0 && divisor >= 100)
                {
                    WordBuilder(model, (long)quotient, words);
                 }

                AppendTo(words, model, (long)divisor);

                if (remainder > 0)
                {
                    WordBuilder(model, (long)remainder, words);
                }
            }

            return words.ToString();
        }

        private static void AppendTo(StringBuilder words, NumbersToWordsModel model, long dividend)
        {
            words.Append(" ");
            words.Append(model._NumberMap[dividend]);
        }
    }
}