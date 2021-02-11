using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreReceptionist
{
    class Program
    {
        static void Main(string[] args)
        {
            //Program to act as store receptionist
             
            
            //ask customer to enter his/her name
            Console.WriteLine("Please Enter Your Name:");
            //store input inside customerName variable
            string customerName = Console.ReadLine();


            //ask customer to enter his/her phone number
            Console.WriteLine("Please Enter Your Phone Number:");
            //store input inside customerPhoneNumber variable
            string customerPhoneNumber = Console.ReadLine();

            //we will create a list of all items available in the store
            //we will create a class for this called StoreItem
            List<StoreItem> storeItems = new List<StoreItem>();
            

            //I will now proceed to create 5 items for the store
            //item 1 FIFA World Cup 2018 Match Ball
            StoreItem soccerBall = new StoreItem();
            //set properties for soccer ball
            soccerBall.ItemCode = "SOC001";
            soccerBall.ItemName = "FIFA World Cup 2018 Match Ball";
            soccerBall.UnitPrice = 652.27M;

            storeItems.Add(soccerBall);

            //Item 2 Beverage
            StoreItem beverage = new StoreItem();
            //set properties for beverage
            beverage.ItemCode = "BEV002";
            beverage.ItemName = "MILO";
            beverage.UnitPrice = 450.00M;

            storeItems.Add(beverage);

            //Item 3 tv
            StoreItem tv= new StoreItem();
            //set properties for tv
            tv.ItemCode = "TV003";
            tv.ItemName = "LG XV 16 Inch TV";
            tv.UnitPrice = 45000.00M;

            storeItems.Add(tv);

            //Item 4 Meat Pie
            StoreItem meatPie = new StoreItem();
            //set properties for meatPie
            meatPie.ItemCode = "MEAT004";
            meatPie.ItemName = "MacDonalds Meat Pie";
            meatPie.UnitPrice = 300.00M;

            storeItems.Add(meatPie);

            //Item 4 Men's Office Shirt
            StoreItem officeShirt = new StoreItem();
            //set properties for office Shirt
            officeShirt.ItemCode = "SHIRT005";
            officeShirt.ItemName = "TOMMY HILFIGER Men's Office Shirt";
            officeShirt.UnitPrice = 987.22M;

            storeItems.Add(officeShirt);

            //display items available in the store to the customer
            Console.WriteLine("We have the following items avalaible in the store");
            for(int i=0;i<storeItems.Count;i++)
            {
                Console.WriteLine("Item {0}", i + 1);
                Console.WriteLine("Item Code:{0}", storeItems[i].ItemCode);
                Console.WriteLine("Item Name:{0}", storeItems[i].ItemName);
                Console.WriteLine("UnitPrice:{0}", storeItems[i].UnitPrice);
                Console.WriteLine("................................");
            }

            List<CustomerBasketItem> customerBasket = new List<CustomerBasketItem>();

            Console.WriteLine("Out Of The {0} Items We Have In The Store, Please Enter The Number Of Items You Want To Purchase", storeItems.Count);

            int numberOfItemsToBePurchased = Convert.ToInt32(Console.ReadLine());

        

            for(int j=0;j<numberOfItemsToBePurchased;j++)
            {

                //create a new item
                CustomerBasketItem basketItem = new CustomerBasketItem();
                Console.WriteLine("Please Enter The Item Code For The Item You Want To Purchase");
                string basketItemCode = Console.ReadLine();

                StoreItem storeItem = storeItems.FirstOrDefault(p => p.ItemCode == basketItemCode);

                if(storeItem!=null)
                {
                    basketItem.CustomerSelection = storeItem;
                    Console.WriteLine("Please Enter Quantity Of Item {0} That You Want To Purchase!",storeItem.ItemName);
                    basketItem.QuantityPurchased = Convert.ToInt32(Console.ReadLine());
                    customerBasket.Add(basketItem);

                }
                else
                {
                    Console.WriteLine("You Have Entered Invalid Item Code!");
                }

                
            }



            //display invoice to user
            Console.WriteLine("You Have Decided To Purchase The Following Items");
            decimal totalBasketAmount=0, totalItemAmount;

            Console.WriteLine("Customer Name:{0}", customerName);

            Console.WriteLine("Customer Phone:{0}", customerPhoneNumber);

            for (int k=0;k<customerBasket.Count;k++)
            {
                Console.WriteLine("Purchase {0}", k + 1);
                Console.WriteLine("Purchased Item Code:{0}", customerBasket[k].CustomerSelection.ItemCode);
                Console.WriteLine("Purchased Item Name:{0}", customerBasket[k].CustomerSelection.ItemName);
                Console.WriteLine("Purchased Item Unit Price:{0}", customerBasket[k].CustomerSelection.UnitPrice);
                Console.WriteLine("Quantity Purchased:{0}", customerBasket[k].QuantityPurchased);
                Console.WriteLine("Item Total:{0}", customerBasket[k].CustomerSelection.UnitPrice * customerBasket[k].QuantityPurchased);
                totalItemAmount = customerBasket[k].CustomerSelection.UnitPrice * customerBasket[k].QuantityPurchased;
                totalBasketAmount = totalBasketAmount + totalItemAmount;
                Console.WriteLine("..............................");
            }

            Console.WriteLine("Total Value Of Your Invoice Is {0}", totalBasketAmount);



        }
    }

    public class StoreItem
    {
        //class properties
        public string ItemCode { get; set; }

        public string ItemName { get; set; }

        public decimal UnitPrice { get; set; }
    }


    public class CustomerBasketItem
    {
        //class properties
        public StoreItem CustomerSelection { get; set; }

        public int QuantityPurchased { get; set; }

    }
}
