/*Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.*/

void Task_54()
{
    int len_0 = 4;
    int len_1 = 4;
    int[][] array = new int[len_0][];
    Random rd = new Random();
    for (int i = 0; i < 4; i++)
    {
        array[i] = new int[len_1];
        for (int j = 0; j < 4; j++) array[i][j] = rd.Next(0, 50);
    }

    PrintArray(msg: "Unsort", matr: array);

    array = SortLines(matr: array);

    PrintArray(msg: "Sort", matr: array);

    static int[][] SortLines(int[][] matr)
    {
        int[][] ret = new int[matr.GetLength(0)][];

        for (int i = 0; i < matr.GetLength(0); i++)
        {
            Array.Sort(matr[i], (x, y) => y.CompareTo(x));
            ret[i] = new int[matr[i].Length];

            for (int j = 0; j < matr[i].Length; j++)
                ret[i][j] = matr[i][j];
        }

        return ret;
    }

    static void PrintArray(string msg, int[][] matr)
    {
        Console.WriteLine(msg);

        for (int j = 0; j < matr.GetLength(0); j++)
            Console.WriteLine(string.Join(", ", matr[j]));

        Console.WriteLine();
    }
}



/*Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.*/

void Task_56()
{
    int len_0 = 4;
    int len_1 = 4;
    int[][] array = new int[len_0][];
    Random rd = new Random();
    for (int i = 0; i < 4; i++)
    {
        array[i] = new int[len_1];
        for (int j = 0; j < 4; j++) array[i][j] = rd.Next(0, 50);
    }
    array = SortLines(matr: array);
    static int[][] SortLines(int[][] matr)
    {
        int[][] ret = new int[matr.GetLength(0)][];

        for (int i = 0; i < matr.GetLength(0); i++)
        {
            Array.Sort(matr[i], (x, y) => y.CompareTo(x));
            ret[i] = new int[matr[i].Length];

            for (int j = 0; j < matr[i].Length; j++)
                ret[i][j] = matr[i][j];
        }

        return ret;
    }

    var minpos = GetPosMinValue(matr: array);

    Console.WriteLine(string.Join(", ", SummLine(array)));

    Console.WriteLine($"Number lines (нумерация с 0) -> {minpos}");

    static int GetPosMinValue(int[][] matr)
    {
        int pos = 0;
        var vector = SummLine(matr);
        int min = vector[0];

        for (int i = 1; i < vector.Length; i++)
            if (min > vector[i])
                pos = i;

        return pos;
    }

    static int[] SummLine(int[][] matr)
    {
        int[] vector = new int[matr.GetLength(0)];

        for (int i = 0; i < vector.Length; i++)
        {
            int sum = 0;

            for (int j = 0; j < matr[i].Length; j++)
                sum += matr[i][j];

            vector[i] = sum;
        }

        return vector;
    }


}



/*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.*/

void Task_58()
{
    int[,] a = { { 2, 4 }, { 3, 2 } };
    int[,] b = { { 3, 4 }, { 3, 3 } };

    var mull = Mull(a: a, b: b);
    PrintArray(array: mull);

    static int[,] Mull(int[,] a, int[,] b)
    {
        if (a.GetLength(1) != b.GetLength(0))
            throw new Exception("Матрицы нельзя перемножить");

        int[,] mull = new int[a.GetLength(0), b.GetLength(1)];

        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < b.GetLength(1); j++)
            {
                for (int k = 0; k < b.GetLength(0); k++)
                    mull[i, j] += a[i, k] * b[k, j];
            }
        }

        return mull;
    }

    static void PrintArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
                Console.Write($"{array[i, j]}  ");

            Console.WriteLine();
        }
    }
}



Console.WriteLine("Введите номер задачи -> ");
string num_str = Console.ReadLine();
int num = int.Parse(num_str);
if(num == 54)
{
    Task_54();
    return;
} 
if(num == 56)
{
    Task_56();
    return;
}
if(num == 58)
{
    Task_58();
    return;
}  
else Console.WriteLine("Неверный номер задачи");

