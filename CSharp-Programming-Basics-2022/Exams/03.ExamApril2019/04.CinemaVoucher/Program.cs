using System;

namespace _04.CinemaVoucher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int voucher = int.Parse(Console.ReadLine());
            string purchase = Console.ReadLine();
            int ticketsBought = 0;
            int otherPurchases = 0;

            while (purchase != "End")
            {
                if (purchase.Length > 8)
                {

                    if (purchase[0] + purchase[1] > voucher)
                    {
                        break;
                    }
                    else
                    {
                        ticketsBought++;
                        voucher -= purchase[0] + purchase[1];
                    }
                }
                else
                {

                    if (purchase[0] > voucher)
                    {
                        break;
                    }
                    else
                    {
                        otherPurchases++;
                        voucher -= purchase[0];
                    }
                }

                purchase = Console.ReadLine();
            }

            Console.WriteLine(ticketsBought);
            Console.WriteLine(otherPurchases);
        }
    }
}
