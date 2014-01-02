using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sjerrul.Utilities.Accessibility
{
    public class NumberReader
    {
        public string Read(decimal number)
        {
            if (number == 0)
                return "Zero";
            bool isNegative = false;
            if (number < 0)
            {
                isNegative = true;
                number = Math.Abs(number);
            }
            decimal integerPart = decimal.Floor(number);
            List<int> thousandsList = new List<int>();
            for (int i = 1; i <= Convert.ToInt32(Math.Ceiling(Convert.ToDouble(integerPart.ToString().Length) / 3)); i++)
                thousandsList.Add(GetThousands(integerPart, i));

            StringBuilder output = new StringBuilder();

            for (int i = thousandsList.Count - 1; i >= 0; i--)
            {
                string currentThreeDigits = ReadThreeDigits(thousandsList[i]);
                if (!string.IsNullOrEmpty(currentThreeDigits))
                {
                    output.Append(currentThreeDigits);
                    #region Big Numbers
                    switch (i)
                    {
                        case 0:
                            break;
                        case 1:
                            output.Append(" Thousand");
                            break;
                        case 2:
                            output.Append(" Million");
                            break;
                        case 3:
                            output.Append(" Billion");
                            break;
                        case 4:
                            output.Append(" Trillion");
                            break;
                        case 5:
                            output.Append(" Quadrillion");
                            break;
                        case 6:
                            output.Append(" Quintillion");
                            break;
                        case 7:
                            output.Append(" Sextillion");
                            break;
                        case 8:
                            output.Append(" Septillion");
                            break;
                        case 9:
                            output.Append(" Octillion");
                            break;
                        case 10:
                            output.Append(" Nonillion");
                            break;
                        case 11:
                            output.Append(" Decillion");
                            break;
                        case 12:
                            output.Append(" Undecillion");
                            break;
                        case 13:
                            output.Append(" Duodecillion");
                            break;
                        case 14:
                            output.Append(" Tredecillion");
                            break;
                        case 15:
                            output.Append(" Quattuordecillion");
                            break;
                        case 16:
                            output.Append(" Quindecillion");
                            break;
                        case 17:
                            output.Append(" Sexdecillion");
                            break;
                        case 18:
                            output.Append(" Septendecillion");
                            break;
                        case 19:
                            output.Append(" Octodecillion");
                            break;
                        case 20:
                            output.Append(" Novemdecillion");
                            break;
                        case 21:
                            output.Append(" Vigintillion");
                            break;
                        default:
                            break;
                    }
                    #endregion
                    output.Append(", ");
                }
            }
            string allOutput = (isNegative ? "Negative " : "") + output.ToString().Trim();
            if (allOutput.EndsWith(","))
                allOutput = allOutput.Substring(0, allOutput.Length - 1);
            return allOutput;
        }

        protected string ReadThreeDigits(int number)
        {
            StringBuilder output = new StringBuilder();

            int hundreds = GetDigit(number, 3);
            int tenth = GetDigit(number, 2);
            int units = GetDigit(number, 1);

            if (hundreds != 0)
            {
                output.Append(ReadOneDigit(hundreds) + " Hundred");
                if (tenth != 0 || units != 0)
                    output.Append(" ");
            }

            switch (tenth)
            {
                case 0:
                    if (units != 0)
                        output.Append(ReadOneDigit(units));
                    break;
                case 1:
                    switch (units)
                    {
                        case 0:
                            output.Append("Ten");
                            break;
                        case 1:
                            output.Append("Eleven");
                            break;
                        case 2:
                            output.Append("Twelve");
                            break;
                        case 3:
                            output.Append("Thirteen");
                            break;
                        case 4:
                            output.Append("Fourteen");
                            break;
                        case 5:
                            output.Append("Fifteen");
                            break;
                        case 6:
                            output.Append("Sixteen");
                            break;
                        case 7:
                            output.Append("Seventeen");
                            break;
                        case 8:
                            output.Append("Eighteen");
                            break;
                        case 9:
                            output.Append("Nineteen");
                            break;
                        default:
                            throw new Exception("error 8929526406!");
                    }
                    break;
                case 2:
                    output.Append("Twenty");
                    break;
                case 3:
                    output.Append("Thirty");
                    break;
                case 4:
                    output.Append("Fourty");
                    break;
                case 5:
                    output.Append("Fifty");
                    break;
                case 6:
                    output.Append("Sixty");
                    break;
                case 7:
                    output.Append("Seventy");
                    break;
                case 8:
                    output.Append("Eighty");
                    break;
                case 9:
                    output.Append("Ninety");
                    break;
                default:
                    break;
            }
            switch (tenth)
            {
                //case 0:
                //case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    if (units > 0)
                    {
                        output.Append(" " + ReadOneDigit(units));
                    }
                    break;
            }

            return output.ToString().Trim();
        }

        protected int GetDigit(decimal number, int index)
        {
            number = Math.Abs(number);
            var output = decimal.Floor(
                    decimal.Divide(number,
                    Convert.ToInt32(Math.Floor(Math.Pow(10, index - 1)))
                    )
                    % 10
                );
            if (output < 0)
                return 0;
            return Convert.ToInt32(output);
        }

        protected int GetThousands(decimal number, int index)
        {
            number = Math.Abs(number);
            int output = Convert.ToInt32(
                decimal.Floor(
                    decimal.Divide(number,
                        Convert.ToDecimal(
                            Math.Pow(1000, index - 1)
                        )
                    )
                    % 1000
                ));
            if (output < 0)
                return 0;
            return output;
        }

        protected string ReadOneDigit(int digit)
        {
            switch (digit)
            {
                case 1:
                    return "One";
                case 2:
                    return "Two";
                case 3:
                    return "Three";
                case 4:
                    return "Four";
                case 5:
                    return "Five";
                case 6:
                    return "Six";
                case 7:
                    return "Seven";
                case 8:
                    return "Eight";
                case 9:
                    return "Nine";
                case 0:
                    return "Zero";
                default:
                    throw new Exception("Digit '" + digit + "' not defined!");
            }

        }

    }
}
