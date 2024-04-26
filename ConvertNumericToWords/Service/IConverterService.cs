using ConvertNumericToWords.Models;

namespace ConvertNumericToWords.Service
{
    public interface IConverterService
    {
        ServiceResponse<string> ConvertNumericToWord(double numericValue);
    }
}
