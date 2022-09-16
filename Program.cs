/*
Задайте одномерный массив, заполненный случайными числами. Найдите сумму элементов, стоящих на нечётных позициях.
[3, 7, 23, 12] -> 19
[-4, -6, 89, 6] -> 0
*/
int size = 0, sumOddElements = 0;

if (!InputControl())
    return;

int[] array = InitArray(size);

DoWorkArray(array, ref sumOddElements);

PrintArray(array);

# region methods

bool InputControl()
{
    int tryCount = 3;
    string inputStr = string.Empty;
    bool resInputCheck = false;

    while (!resInputCheck)
    {
        Console.WriteLine($"\r\nЗадайте размерность массива (количество попыток: {tryCount}):");
        inputStr = Console.ReadLine() ?? string.Empty;

        resInputCheck = int.TryParse(inputStr, out size) && size > 0;

        if (!resInputCheck)
        {
            tryCount--;

            if (tryCount == 0)
            {
                Console.WriteLine("\r\nВы исчерпали все попытки.\r\nВыполнение программы будет остановлено.");
                return false;
            }
        }
    }

    return true;
}

int[] InitArray(int sizeArray)
{
    int[] array = new int[sizeArray];

    for (int i = 0; i < sizeArray; i++)
    {
        array[i] = new Random().Next(-99, 100);
    }

    return array;
}

void DoWorkArray(int[] array, ref int sum)
{
    for (int i = 0; i < size; i++)
    {
        if (i % 2 != 0)
            sum += array[i];
    }
}

void PrintArray(int[] array)
{    
    foreach (int elem in array)
    {
        if (elem == array.First() && elem == array.Last())
            Console.WriteLine($"[{elem}] -> {sumOddElements}");
        else
            Console.Write($"{(elem == array.First() ? "[" + elem : (elem == array.Last() ? "," + elem + "] -> " + sumOddElements : "," + elem))}");
    }
}

#endregion
