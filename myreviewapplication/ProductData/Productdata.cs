using myreviewapplication.Models;
using System.Security.Cryptography;

namespace myreviewapplication.ProductData
{
    public static class Productdata
    {
      static  public  List<Product> myproducts = new List<Product>();
    static public Dictionary<Guid, Product>myproddict= new Dictionary<Guid, Product>();

        
        static Productdata()
        {
            Product p1 = new Product();
            
            p1.Name = "Acer Aspire 5 Gaming";
            p1.Price = 53900;
            p1.Id= Guid.NewGuid();  
            p1.ImageUrl = "https://m.media-amazon.com/images/I/41dgHDQs4RL._SX300_SY300_QL70_FMwebp_.jpg";
            p1.Description = "Acer Aspire 5 Gaming laptop is powered by the latest 12th Gen Intel Core i7 processor consisting of 12 cores for multitasking and productivity.;RTX It's On : NVIDIA GeForce RTX 2050 - 4G-GDDR6 laptops deliver ray tracing and cutting-edge AI features. The RTX 2050 also works seamlessly with NVIDIA Optimus technology to give you the perfect balance between long battery life and optimum performance. Over 150 top games and applications use RTX to deliver realistic graphics or cutting-edge new AI features like NVIDIA DLSS and NVIDIA Broadcast. RTX is the new standard.";
            myproddict[p1.Id] = p1;
    
            myproducts.Add(p1);

            Product p2 = new Product();
            p2.Name = "JUAREZ Octavé JRK661 61-Key Electronic Keyboard Piano";
            p2.Price = 3571;
            p2.Id = Guid.NewGuid();
            p2.ImageUrl = "https://m.media-amazon.com/images/I/41i16gx438L._SY300_SX300_QL70_FMwebp_.jpg";
            p2.Description = "FLAWLESS, AUTHENTIC RANGE OF SOUND - Built-in speakers offer tremendous sound, complete with 255 Timbres, 255 rhythms, 8 keyboard percussions, and 24 demonstration songs.\r\nINTEGRATED LEARNING SYSTEM - Designed for beginner to intermediate-level use, this multi-function keyboard piano features 61 keys, providing a traditional piano or organ feel for versatile learning and an exciting acoustic experience.";
            myproducts.Add(p2);
            myproddict[p2.Id] = p2; 
            Product p3 = new Product();
            p3.Name = "Red Tape Sports Walking Shoes for Men | Comfortable Lace-Up";
            p3.Price = 1699;
            p3.Id = Guid.NewGuid();
            p3.ImageUrl = "https://m.media-amazon.com/images/I/61jBY529rkL._UY695_.jpg";
            p3.Description = "RedTape shoes was conceptualised as a lifestyle brand for the aspiring and ambitious Generation Next. A brand synonymous with unparalleled comfort, international style and exceptional finesse owing to its unrelenting focus on quality, craftsmanship and in-vogue fashion.\r\n";
            myproducts.Add(p3);
            myproddict[p3.Id] = p3;

        }





    }
}
