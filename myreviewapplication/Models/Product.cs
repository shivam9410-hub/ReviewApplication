namespace myreviewapplication.Models
{
    public class Product
    {
          public   Guid Id { get; set; }   
        public string Name { get; set; }    
        public string Description { get; set; }

        public string ImageUrl { get; set; }    
         public  int Price { get; set; }
        public  double Rating { get;set; }

        public int Score { get; set; } = 0;
        public string review { get; set; } = " ";

        
       


    }
}
