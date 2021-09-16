using System;
using System.Collections.Generic;

namespace Expect_Kasir
{
    class Root
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{equalBarrier()} Dapatkan diskon 10%, setiap min belanja Rp 150000 {equalBarrier()}");
            showMenu();
        }

        private static void showMenu()
        {
            Food nasiGoreng = new Food("Nasi Goreng", 15000, true);
            Food bakmi = new Food("Bakmi", 18000, false);
            Root mainClass = new Root();

            Food[] menus = { nasiGoreng, bakmi };
            double totalPrice = 0;

            int num = 3;
            Console.WriteLine($"{equalBarrier()} Toko Fernando F {equalBarrier()}");
            Console.WriteLine("1. Keluar / Exit\n2. Selesaikan pembelian\n");
            foreach (var menu in menus)
            {
                if (menu.getFried() == false)
                {
                    Console.WriteLine($"{num}. Nama makanan: {menu.getName()}\nharga: {menu.getPrice()}\nDigoreng? Iya\n");
                    num++;
                }
                else
                {
                    Console.WriteLine($"{num}. Nama makanan: {menu.getName()}\nharga: {menu.getPrice()}\nDigoreng? Tidak\n");
                    num++;
                }
            }

            mainClass.questions(menus, totalPrice);
        }

        private void questions(Food[] menus, double totalPrice)
        {
            string answer;
            Root mainClass = new Root();

            Console.Write("Apakah anda ingin memulai pembelanjaan? ya / tidak: ");
            answer = Convert.ToString(Console.ReadLine());

            if (answer == "ya")
            {
                mainClass.purchasing(menus, totalPrice);
            }
            else if (answer == "tidak")
            {
                Console.WriteLine("Terima kasih sudah melihat-lihat...");
                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine("Maaf saya tidak mengerti yang anda maksud...\n");
                mainClass.questions(menus, totalPrice);
            }
        }

        private void purchasing(Food[] menus, double totalPrice)
        {
            int menuPil, countKey = 0;
            var foodPil = new Dictionary<int, Food>();

            Console.Write("Masukkan menu pilihan: ");
            menuPil = Convert.ToInt32(Console.ReadLine());

            switch (menuPil)
            {
                case 1:
                    {
                        Console.WriteLine("Terima kasih sudah memesan...");
                        Environment.Exit(0);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine($"\n{equalBarrier()} Menghitung total pembelian {equalBarrier()} \n");
                        foreach (var food in foodPil)
                        {
                            totalPrice += food.Value.getTotalPrice();
                        }

                        if (totalPrice >= 150000)
                        {
                            totalPrice *= 0.1;

                            Console.WriteLine("\nSelamat anda mendapatkan diskon");
                            Console.WriteLine($"\nTotal harga pembelian: Rp.{totalPrice}");
                            Console.WriteLine($"\n{equalBarrier()}{equalBarrier()}{equalBarrier()}\n");
                            Console.ReadKey(true);
                            break;
                        } else
                        {
                            Console.WriteLine($"\nTotal harga pembelian: Rp.{totalPrice}");
                            Console.WriteLine($"\n{equalBarrier()}{equalBarrier()}{equalBarrier()}\n");
                            Console.ReadKey(true);
                            break;
                        }
                    }
                case 3:
                    {
                        countKey++;
                        Food ng = menus[0];
                        int count;

                        Console.Write("Masukkan jumlah yang ingin dibeli: ");
                        count = Convert.ToInt32(Console.ReadLine());
                        ng.setOrderCount(count);
                        Console.WriteLine($"Total harga menu yang dipilih: {ng.getTotalPrice()}");

                        foodPil.Add(countKey, ng);
                        break;
                    }
                case 4:
                    {
                        Food bm = menus[1];
                        int count;

                        Console.Write("Masukkan jumlah yang ingin dibeli: ");
                        count = Convert.ToInt32(Console.ReadLine());
                        bm.setOrderCount(count);
                        Console.WriteLine($"Total harga menu yang dipilih: {bm.getTotalPrice()}");

                        foodPil.Add(countKey, bm);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Maaf menu yang anda masukkan tidak ada...");
                        questions(menus, totalPrice);
                        break;
                    }
            }

            if (foodPil.Count > 0)
            {
                foreach (var food in foodPil)
                {
                    totalPrice += food.Value.getTotalPrice();
                }

                questions(menus, totalPrice);
            }
        }

        private static string equalBarrier()
        {
            return "===================";
        }
    }
}
