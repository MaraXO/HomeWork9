using System;
using System.Runtime.ExceptionServices;

class Program
{
    public static void Main()
    {
        //const int myArrSize = 5;
        //var myarray = new int[myArrSize] { 5, 3, 8, 4, 2 };
        const int mysizearr = 30;
        var myarray = GenerateRandom(mysizearr);
        ShowArray(myarray);
        //BubleSortSimple(myarray);
        //BubleSortOptimazed(myarray);
        //InsertionSortSimple(myarray);
        SelectionSort(myarray);
        ShowArray(myarray);
       
        
    }

    public static int[] GenerateRandom(int size)
    {
        const int start = 1, end = 100;
        var array = new int[size];
        var random = new Random();
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(start, end);
        }
        return array;
    }

    public static void ShowArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write($"{item}\t");
        }
        Console.WriteLine();
    }

    public static void BubleSortSimple(int[] array)
    {
        for (int i = 0; i < array.Length; i++)  
        {
            for (int j = 0; j < array.Length - i - 1; j++) 
            {
                if (array[j] > array[j + 1])
                {
                    var temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
        // зовн. і = 0, внутр. j = 0;
        //BubleSortSimple [5, 3, 8, 4, 2] -> BubleSortSimple [3, 5, 8, 4, 2] (5>3, обмін) 
        // зовн. і = 0, внутр.j = 1; 
        //BubleSortSimple [3, 5, 8, 4, 2] -> BubleSortSimple [3, 5, 8, 4, 2] (5 <8, без обміну)
        // зовн. і = 0, внутр.j = 2; 
        //BubleSortSimple [3, 5, 8, 4, 2] -> BubleSortSimple [3, 5, 4, 8, 2] (8> 4, обмін)
        // зовн. і = 0, внутр.j = 3; 
        //BubleSortSimple [3, 5, 4, 8, 2] -> BubleSortSimple [3, 5, 4, 2, 8] (8 > 2, обмін)
        // зовн. і = 1, внутр.j = 0; 
        //BubleSortSimple [3, 5, 4, 2, 8] -> BubleSortSimple [3, 5, 4, 2, 8] ( 3< 5, без обміну)
        // зовн. і = 1, внутр.j = 1; 
        //BubleSortSimple [3, 5, 4, 2, 8] -> BubleSortSimple [3, 4, 5, 2, 8] (5<4 обмін)
        // зовн. і = 1, внутр.j = 2; 
        //BubleSortSimple [3, 4, 5, 2, 8] -> BubleSortSimple [3, 4, 2, 5, 8] ( 5>2 обмін)
        // зовн. і = 2, внутр.j = 0; 
        //BubleSortSimple[3, 4, 2, 5, 8] -> BubleSortSimple[3, 4, 2, 5, 8]  (3 < 4, без обміну)
        // зовн. і = 2, внутр.j = 1; 
        // BubleSortSimple[3, 4, 2, 5, 8] -> BubleSortSimple[3, 2, 4, 5, 8] (4 > 2, обмін)
        // зовн. і = 3, внутр.j = 0; 
        //BubleSortSimple[3, 2, 4, 5, 8] ->  BubleSortSimple[2, 3, 4, 5, 8] (3 > 2, обмін)


    }

    public static void BubleSortOptimazed(int[] array) 
    {
        for (int i = 0;i < array.Length; i++) 
        {
            bool swaped = false;
            for (int j = 0;j < array.Length - i -1;j++) 
            {
                if (array[j] > array[j + 1]) 
                {
                    var temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                    swaped = true;

                }
            }
            if (!swaped) 
            {
                break;
            }

        }
        // зовн. і = 0, внутр. j = 0;
        //BubleSortSimple [5, 3, 8, 4, 2] -> BubleSortSimple [3, 5, 8, 4, 2] (5>3, обмін swaped ) 
        // зовн. і = 0, внутр.j = 1; 
        //BubleSortSimple [3, 5, 8, 4, 2] -> BubleSortSimple [3, 5, 8, 4, 2] (5 <8, без обміну  break )
        // зовн. і = 0, внутр.j = 2; 
        //BubleSortSimple [3, 5, 8, 4, 2] -> BubleSortSimple [3, 5, 4, 8, 2] (8> 4, обмін swaped )
        // зовн. і = 0, внутр.j = 3; 
        //BubleSortSimple [3, 5, 4, 8, 2] -> BubleSortSimple [3, 5, 4, 2, 8] (8 > 2, обмін swaped )
        // зовн. і = 1, внутр.j = 0; 
        //BubleSortSimple [3, 5, 4, 2, 8] -> BubleSortSimple [3, 5, 4, 2, 8] ( 3< 5, без обміну break)
        // зовн. і = 1, внутр.j = 1; 
        //BubleSortSimple [3, 5, 4, 2, 8] -> BubleSortSimple [3, 4, 5, 2, 8] (5<4 обмін swaped )
        // зовн. і = 1, внутр.j = 2; 
        //BubleSortSimple [3, 4, 5, 2, 8] -> BubleSortSimple [3, 4, 2, 5, 8] ( 5>2 обмін swaped )
        // зовн. і = 2, внутр.j = 0; 
        //BubleSortSimple[3, 4, 2, 5, 8] -> BubleSortSimple[3, 4, 2, 5, 8]  (3 < 4, без обміну break)
        // зовн. і = 2, внутр.j = 1; 
        // BubleSortSimple[3, 4, 2, 5, 8] -> BubleSortSimple[3, 2, 4, 5, 8] (4 > 2, обмін swaped )
        // зовн. і = 3, внутр.j = 0; 
        //BubleSortSimple[3, 2, 4, 5, 8] ->  BubleSortSimple[2, 3, 4, 5, 8] (3 > 2, обмін )
    }

    public static void InsertionSortSimple(int[] array) 
    {
        for (int i = 1; i < array.Length; i++) 
        {
            var key = array[i];
            var flag = false;

            for (int j = i - 1; j >= 0 && flag != true;) 
            {
                if (key < array[j]) 
                {
                    array[j + 1] = array[j];
                    j--;
                    array[j + 1] = key;
 
                }
                else 
                {
                    flag = true;
                
                }
            
            }

        }
        // зовн. і = 1, key = 3  flag = false 
        //InsertionSortSimple [5, 3, 8, 4, 2] -> InsertionSortSimple [3, 5, 8, 4, 2] (3 < 5, Вставка вліво) 
        // зовн. і = 2, key = 8  flag = true  
        //InsertionSortSimple [[3, 5, 8, 4, 2] -> InsertionSortSimple [3, 5, 8, 4, 2] (8 > 5 вставка не відбувається)
        // зовн. і = 3, key = 4 flag = false 
        //InsertionSortSimple [[3, 5, 8, 4, 2] -> InsertionSortSimple [3, 4, 5, 8, 2]  (4 < 8  Вставка вліво на 2)
        // зовн. і = 4, key = 2 flag = false 
        //InsertionSortSimple [3, 4, 5, 8, 2] -> InsertionSortSimple [2, 3, 4, 5, 8] ( 2 < 8 Вставка вліво на 3)
    }

    public static void SelectionSort(int[] array) 
    {
        for (int i = 0; i < array.Length - 1; i++) 
        {
            var smallest = i;

            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[smallest]) 
                {
                    smallest = j;
                }
            }

            var temp = array[smallest];
            array[smallest] = array[i];
            array[i] = temp;

        }
        // Пошук
        // smallest = 0  - > smallest -> 1
        // j = 2 (8) -> smalles - > 1
        // j = 3 (4) -> smalles - > 1
        // j = 4 (2) -> smallest -> 4 
        // Свайп 
        // SelectionSort [5 3 8 4 2] -> SelectionSort [2 3 8 4 5] 
        // Пошук
        // smallest = 1 -> - > smallest -> 1
        // Свайп 
        //SelectionSort[2 3 8 4 5]-> SelectionSort [2 3 8 4 5] 
        // Пошук
        // smallest = 2 -> smallest = 3
        // Свайп 
        //SelectionSort[2 3 8 4 5]-> SelectionSort [2 3 4 8 5]
        //// Пошук
        // smallest = 3 -> smallest = 4
        //SelectionSort [2 3 4 8 5] -> SelectionSort [2 3 4 5 8]




    }

}