using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Black Jack ");


            Shaffle();


        }


        static void Shaffle()
        {
            string[] mark = { "ハート", "スペード", "クラブ", "ダイヤ" };

            int[,] numbers = new[,]
            {
                {1,2,3,4,5,6,7,8,9,10,11,12,13},
                {1,2,3,4,5,6,7,8,9,10,11,12,13},
                 {1,2,3,4,5,6,7,8,9,10,11,12,13},
                  {1,2,3,4,5,6,7,8,9,10,11,12,13},
            };

            int number;
            int numberr;
            string egara;
            int kazu;
            int ddd = 1;
            string[] smark = { };
            int[] snumbers = { };

            Random cRandom = new Random();


            while (ddd < 53)
            {


                number = cRandom.Next(4);
                egara = mark[number];


                numberr = cRandom.Next(13);
                kazu = numbers[number, numberr];
                if (kazu == 0)
                {

                }
                else if (kazu != 0)
                {
                    ddd = ddd + 1;
                    numbers[number, numberr] = 0;


                    Console.WriteLine($"{A(kazu, egara)}");

                    Array.Resize(ref smark, smark.Length + 1);
                    smark[smark.Length - 1] = egara;

                    Array.Resize(ref snumbers, snumbers.Length + 1);
                    snumbers[snumbers.Length - 1] = kazu;


                }


            }
            //dealer turn
            int dealer = snumbers[0] + snumbers[1];
            Console.WriteLine("ディーラーの一枚目のカードは");
            Console.WriteLine(A(snumbers[0], smark[0]));


            //player turn
            Console.WriteLine("あなたの番です");
            Console.WriteLine(A(snumbers[2], smark[2]));


            string answer;
            int aaa = 1;

            int player = snumbers[2];
            int i = 3;
               

            while (aaa < 100)
            {
                Console.WriteLine("もう一度引きますか？　y or n");
                answer = Console.ReadLine();

                if (answer == "y")
                {


                    Console.WriteLine(A(snumbers[i], smark[i]));//山札の４枚目からひく

                    player = player + snumbers[i];//合計に加算

                    i = i + 1;// 今とった札の次からとる

                    Console.WriteLine($"あなたの合計は{player}です。");


                }
                else if (answer != "y")
                {
                    aaa = aaa + 100;//roop end
                }
                else if (answer != "n" || answer != "y")
                {
                    Console.WriteLine("不正な値が入力されています。");
                }
            }


            //dealer turn
            Console.WriteLine("ディーラーの二枚目のカードは");
            Console.WriteLine(A(snumbers[1], smark[1]));

            Console.WriteLine(B(snumbers[0], snumbers[1]));

            while (dealer < 17)
            {
                Console.WriteLine("ディーラーがカードを引きます");
                Console.WriteLine(A(snumbers[i], smark[i]));

                Console.WriteLine(B(dealer, snumbers[i]));
                dealer = dealer + snumbers[i];




            }

            //判定
            if (System.Math.Abs(21 - dealer) > System.Math.Abs(21 - player))
            {
                Console.WriteLine("あなたの勝ちです。");

            }
            else if (System.Math.Abs(21 - dealer) == System.Math.Abs(21 - player))
            {
                Console.WriteLine("引き分け！");
            }
            else if (System.Math.Abs(21 - dealer) < System.Math.Abs(21 - player))
            {
                Console.WriteLine("ディーラーの勝ちです。");
            }
        }





        public static string A(int a, string b)
        {
            string w = $"{b}の{a}です";
            return w;

        }

        public static string B(int a, int b)
        {
            int c;
            c = a + b;
            string d = $"ディーラーの合計は{c}です。";
            return d;
        }



    }
}
