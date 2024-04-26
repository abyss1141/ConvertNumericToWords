using ConvertNumericToWords.Models;
using System;

namespace ConvertNumericToWords.Service
{
    public class ConverterService : IConverterService
    {
        private static readonly string[] singleNumber =
        {
            "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE",
        };

        private static readonly string[] teensNumber =
        {
            "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN",
        };

        private static readonly string[] tensNumber =
        {
            "", "", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY",
        };

        private static readonly string[] largeNumbers =
        {
            "", "THOUSAND", "MILLION", "BILLION", "TRILLION", "QUADRILLION", "QUINTILLION",
        };


        public ServiceResponse<string> ConvertNumericToWord(double numericValue)
        {
            try
            {
                string wholeNumberWords = "";
                string decimalNumberWords = "";

                long wholeNumber = (long)Math.Truncate(numericValue);
                int decimalNumber = (int)((numericValue - wholeNumber) * 100);

                if (wholeNumber == 0 && decimalNumber == 0)
                {
                    return new ServiceResponse<string>
                    {
                        Data = "ZERO DOLLARS",
                        IsSuccess = true,
                        Message = "Numeric Value Converted",
                        Time = DateTime.Now,
                    };
                }

                if (wholeNumber > 0)
                {
                    wholeNumberWords = ConvertWholeNumberToWords(wholeNumber);
                }

                if (decimalNumber > 0)
                {
                    decimalNumberWords = ConvertDecimalToWords(decimalNumber);
                }

                string result = wholeNumberWords.Trim();
                if (!string.IsNullOrEmpty(result))
                {
                    result += " DOLLARS";
                    if (!string.IsNullOrEmpty(decimalNumberWords))
                    {
                        result += " AND " + decimalNumberWords + " CENTS";
                    }
                }

                return new ServiceResponse<string>
                {
                    Data = result,
                    IsSuccess = true,
                    Message = "Numeric Value Converted",
                    Time = DateTime.Now,
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<string>
                {
                    Data = null,
                    Message = ex.Message,
                    IsSuccess = false,
                    Time = DateTime.Now,
                };
            }
        }

        private static string ConvertWholeNumberToWords(long number)
        {
            if (number == 0)
            {
                return "";
            }

            string words = ""; 
            int index = 0;


            do
            {
                long chunk = number % 1000;
                if (chunk != 0)
                {
                    string chunkWords = ConvertChunkToWords(chunk);
                    if (index > 0)
                    {
                        if (!string.IsNullOrEmpty(words))
                        {
                            chunkWords += " " + largeNumbers[index] + " " + words;
                        }
                        else
                        {
                            chunkWords += " " + largeNumbers[index];
                        }
                    }
                    words = chunkWords;
                }
                number /= 1000;
                index++;
            } while (number > 0);

            return words.Trim();
        }


        private static string ConvertChunkToWords(long number)
        {
            if (number == 0)
            {
                return ""; 
            }

            string chunkWords = ""; 

            if (number >= 100)
            {
                chunkWords += singleNumber[number / 100] + " HUNDRED";
                number %= 100;
                if (number > 0)
                {
                    chunkWords += " ";
                }
            }

            if (number >= 20)
            {
                chunkWords += tensNumber[number / 10];
                number %= 10;
                if (number > 0)
                {
                    chunkWords += "-";
                }
            }
            else if (number >= 10 && number <= 19) 
            {
                chunkWords += teensNumber[number - 10];
                number = 0; 
            }

            if (number > 0)
            {
                if (chunkWords != "")
                {
                    chunkWords += " ";
                }
                chunkWords += singleNumber[number];
            }

            return chunkWords;
        }

        private static string ConvertDecimalToWords(int number)
        {
            if (number == 0)
            {
                return "";
            }

            string decimalWords = ConvertChunkToWords(number);

            if (number < 10)
            {
                decimalWords = singleNumber[0] + " " + decimalWords;
            }

            return decimalWords;
        }
    }
}
