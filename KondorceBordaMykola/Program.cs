using System;
using System.IO;
using System.Linq;

namespace KondorceBordaMykola
{
    class Program
    {
        static int[] masNums;
        static char[,] masABC;
        static string[] masabc;
        static void Main(string[] args)
        {
            GetDataNums();
            GetDataAbs();
            GetDataABC();

            Console.WriteLine("Метод Борда");

            int A = Borda('A', "A_kilkist");
            int B = Borda('B', "B_kilkist");
            int C = Borda('C', "C_kilkist");

            if (A > B && A > C)
                Console.WriteLine($"Перемiг кандидат А. Голоcи = {A}");
            if (B > A && B > C)
                Console.WriteLine($"Перемiг кандидат В. Голоси = {B}");
            if (C > A && C > B)
                Console.WriteLine($"Перемiг кандидат С. Голоси = {C}");

            Console.WriteLine("\n Метод Кондорсе");
            int kondorseAB = Kondorse('A', 'B', "kandidatA");
            int kondorseAC = Kondorse('A', 'C', "kandidatA");
            int kondorseBA = Kondorse('B', 'A', "kandidatB");
            int kondorseBC = Kondorse('B', 'C', "kandidatB");
            int kondorseCA = Kondorse('C', 'A', "kandidatC");            
            int kondorseCB = Kondorse('C', 'B', "kandidatC");

            int[] kondor = { kondorseAB, kondorseAC, kondorseBA, kondorseBC, kondorseCA, kondorseCB };
            int maximumKondorse = kondor.Max();

            if (kondorseAB == maximumKondorse)
            {
                Console.WriteLine($"Найбiльше голосiв набрав кандидат А -  { maximumKondorse}");
            }
            else if (kondorseAC == maximumKondorse)
            {
                Console.WriteLine($"Найбiльше голосiв набрав кандидат А - { maximumKondorse}");

            }
            else if (kondorseBA == maximumKondorse)
            {
                Console.WriteLine($"Найбiльше голосiв набрав кандидат B - { maximumKondorse}");

            }
            else if (kondorseBC == maximumKondorse)
            {
                Console.WriteLine($"Найбiльше голосiв набрав кандидат B - { maximumKondorse}");

            }
            else if (kondorseCA == maximumKondorse)
            {
                Console.WriteLine($"Найбiльше голосiв набрав кандидат C - { maximumKondorse}");

            }           
            else if (kondorseCB == maximumKondorse)
            {
                Console.WriteLine($"Найбільше голосів набрав кандидат C -{ maximumKondorse}");


            }
        }

            public static int[] GetDataNums() // метод для зчитування і запису чисел в масив 
        {
            string filePath = Path.GetFullPath("Nums.txt");

            using var fileReader = new StreamReader(filePath);
            string file = fileReader.ReadToEnd();
            string[] lines = file.Split('\n');

            masNums = new int[lines.Length];

            for (int i = 0; i < masNums.Length; i++)
            {
                masNums[i] = Convert.ToInt32(lines[i]);
            }
            return masNums;
        }
        public static char[,] GetDataABC() // метод для зчитування і запису БУКВ в ДВОРІВНЕВИЙ МАСИВ 
        {
            string filePath = Path.GetFullPath("ABC.txt");

            using var fileReader = new StreamReader(filePath);
            string file = fileReader.ReadToEnd();
            string[] a = file.Split(' ');
            
            masABC = new char[5,3];
            
            
            for (int i=0; i<a.Length; i++)
            {
                for (int j=0; j<3; j++)
                {

                    masABC[i, j]= a[i].ToCharArray()[j];
                   
                }
            }    
         return masABC;

        }

        public static string[] GetDataAbs() { 
            string filePath = Path.GetFullPath("ABC.txt");
            using var fileReader = new StreamReader(filePath);
            string file = fileReader.ReadToEnd();
            string[] b = file.Split(' ');
            masabc = new string[5];
            for(int i = 0; i < b.Length; i++)
            {
                masabc[i] = b[i];
                //Console.WriteLine(masabc[i]);
               
            }
            //Console.WriteLine("Lеngth {0}", b.Length);
            return masabc;
        }



        public static int Borda(char Bukva, string Perekluchatel)
        {
            /*  для методу борда створено масив другого виміру де в кожному елементі першого виміру є масив з трьо елементів
            де перший рівень елемент це є буквосполучення а елемент другого рівня - символ словосполучення
            для вирішення задачі методом борда я створив я створив загальний метод який  приймає параметри необхідбні для підрахунку голосів кожного кандидата
            метод  приймає два значення букву кандидата і сам переключатель для кожного кандидата щоб змогти рахувати кількість голосів для нього і повертати її
            далі за допомогою методів ІФ реалізований обрахунок кількості голосів для кожного кандидата де ми беремо коефіцієнт довіри помножений число з заданої 
            умови і доданий до змінної кількості голосів
            Всі шість кількостей голосів для можливих варіантів я записую в масив , вибирає з нього максимальне значення, та виводжу її на екран.
            */
             int kilkist = 0, A_kilkist = 0, B_kilkist = 0, C_kilkist = 0;

            if (Perekluchatel == "A_kilkist") { kilkist = A_kilkist; }                               
            else if (Perekluchatel == "B_kilkist") { kilkist = B_kilkist;  }
            else if (Perekluchatel == "C_kilkist") { kilkist = C_kilkist; }
           
           

            if (masABC[0, 0] == Bukva) { kilkist += masNums[0] * 3;  }
            else if (masABC[0,1]==Bukva) { kilkist += masNums[0] * 2; }
            else if (masABC[0, 2] == Bukva) { kilkist += masNums[0] * 1; }

            if (masABC[1, 0] == Bukva) { kilkist += masNums[1] * 3;  }
            else if (masABC[1, 1] == Bukva) { kilkist += masNums[1] * 2;}
            else if (masABC[1, 2] == Bukva) { kilkist += masNums[1] * 1;}

            if (masABC[2, 0] == Bukva) { kilkist += masNums[2] * 3; }
            else if (masABC[2, 1] == Bukva) { kilkist += masNums[2] * 2; }
            else if (masABC[2, 2] == Bukva) { kilkist += masNums[2] * 1; }

            if (masABC[3, 0] == Bukva) { kilkist += masNums[3] * 3; }
            else if (masABC[3, 1] == Bukva) { kilkist += masNums[3] * 2; }
            else if (masABC[3, 2] == Bukva) { kilkist += masNums[3] * 1; }


            if (masABC[4, 0] == Bukva) { kilkist += masNums[4] * 3; }
            else if (masABC[4, 1] == Bukva) { kilkist += masNums[4] * 2; }
            else if (masABC[4, 2] == Bukva) { kilkist += masNums[4] * 1; }

                Console.WriteLine($"Кандитат {Bukva} набирає {kilkist} голосiв");

                return kilkist;
            }


                public static int Kondorse(char First, char Second, string Kandidat)
                {
                    /*для методу Кондорсе створений метод який також приймає вже три параметри, це перша буква, друга буква - для виокремлення буквосполучення яка тотожна
                     * з пріоритетом довіри (АВ=A>B .
                     Після чого в масиві елементів (де елемент це буквосполучення трьох букв ( кандидатів_  з умови таблиці, я обирає індекс першого параметра та порівнбюю індекс
                    другого парметру, якщо він менший то в змінну WIN присвоюю число з відповідним індексом з масиву чисел заданих в умові. Таку дію я проробляю для кожного 
                     масиву буквосполучень ( пріоритетів кандидатів ) та формую три значеення змінної WIN . */

                    int A = 0;
                    int B = 0;
                    int C = 0;
                    int win = 0;

                    if (Kandidat == "kandidatA") { win = A; }
                    else if (Kandidat == "kandidatB") { win = B; }
                    else if (Kandidat == "kandidatC") { win = C; }

                    if (masabc[0].IndexOf(First) < masabc[0].IndexOf(Second))
                    { win += masNums[0]; }

                    if (masabc[1].IndexOf(First) < masabc[1].IndexOf(Second))
                    { win += masNums[1]; }


                    if (masabc[2].IndexOf(First) < masabc[2].IndexOf(Second))
                    { win += masNums[2]; }


                    if (masabc[3].IndexOf(First) < masabc[3].IndexOf(Second))
                    { win += masNums[3]; }


                    if (masabc[4].IndexOf(First) < masabc[4].IndexOf(Second))
                    { win += masNums[4]; }


                    return win;


                }



            }

                }
