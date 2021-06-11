using System;
using System.Linq;
using System.Text;
using TechOneAssessment.Models;

namespace TechOneAssessment.Controllers
{
    public class NumbersToWords
    {
        public static String ConvertToWords(double numbers)
        {
            var words = new StringBuilder();
            NumbersToWordsModel model = new NumbersToWordsModel();

            //Validation on Backend for numbers
            if (ValidateNumbers(numbers, words))
            {
                return ValidationFailed(words);
            }

            //Creates another variable to store non-decimal numbers.
            long wholeNumber = (long)numbers;

            //Passes in non-decimal wholenumber to WordBuilder method.
            WordBuilder(model, wholeNumber, words);
            words.Append(" dollars ");
            //Passes in whole number including decimals to DecimalBuilder method.
            DecimalBuilder(model, numbers, words);

            return words.ToString();
        }

        private static string ValidationFailed(StringBuilder words)
        {
            words.Append("Invalid Number");
            return words.ToString();
        }

        private static Boolean ValidateNumbers(double numbers, StringBuilder words)
        {
            if (numbers < 0 || numbers > 1000000000000000)
            {
                return true;
            }
            else { return false; }
        }

        private static string DecimalBuilder(NumbersToWordsModel model, double numbers, StringBuilder words)
        {
            long decNumber = 0;

            //Checks if number contains decimal numbers, then sets decNumber .
            if ((numbers % 1) > 0)
            {
                decimal i = (decimal)numbers;
                i = (i - Math.Truncate(i)) * 100;
                decNumber = (long)i;
            }
            //If number did contain decimals, decNumber will be greater than 0.
            if (decNumber > 0)
            {
                words.Append("and");
                //Call WordBuilder method with decNumber.
                WordBuilder(model, decNumber, words);
                words.Append(" cents");
            }

            return words.ToString();
        }
 
        private static string WordBuilder(NumbersToWordsModel model, long dividend, StringBuilder words)
        {
            //Checks to see if number passed in (dividend) is contained in the Mapping.
            if (model._NumberMap.ContainsKey(dividend))
            {
                AppendTo(words, model, dividend);
            }
            else
            {
                //Finds the first key in mapping that is less than or equal to dividend.
                var divisor = model._NumberMap.First(m => m.Key <= dividend).Key;
                var quotient = dividend / divisor;
                var remainder = dividend % divisor;

                //Checks to see if divisor and quotient are too large, uses recursion 
                //to find the place value of dividend number, largest first.
                if (quotient > 0 && divisor >= 100)
                {
                    WordBuilder(model, (long)quotient, words);
                }

                //if a place value has been narrowed down, append to String Builder words.
                AppendTo(words, model, (long)divisor);

                //If the remainder is too great use recursion to narrow down 
                //further into dividend.
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