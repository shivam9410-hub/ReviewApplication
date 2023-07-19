using myreviewapplication.Models;
using System.Security.Cryptography;

namespace myreviewapplication.ProductData
{
    public static class  ReviewDataRating
    {


     public static Dictionary<string, int> rating = new Dictionary<string, int>();


       static ReviewDataRating()
        {
           rating["bad"] = 1;
            rating["fine"] = 2;
            rating["good"] = 3;
            rating["very good"] = 4;
            rating["excellent"] = 5;
            
        }
            





    }
}
