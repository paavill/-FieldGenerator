using System;
using System.Drawing;

namespace gener
{
    class Program
    {
        static int SizeField = 50;//размер поля
        static int[,] tempMap = new int[SizeField, SizeField];
        static void GenerateMap3()
        {
            int StartPositionOffset = 26;//размер загона при данном размере поля
            var rnd = new Random();

            int Offset = rnd.Next(1);//смщение по x и y
            int countt = 0;
            int Flag;
            int g;
            int j;
            int i;
            int Fence = 3; //!!!!!!!!!!!
            int StepRnd = 3;//длина ответвлений
            int[] AddCord = new int[3];
            int rndDirOld = 0;
            int rndDirNew = 0;
            int tempRnd = 0;
            int StartPnt = (SizeField - StartPositionOffset) / 2;
            int PartSize = SizeField / 2;

            AddCord[0] = StartPnt - Offset;
            if (AddCord[0] < 0)
                AddCord[0] = 0;
            AddCord[1] = SizeField - StartPnt - Offset;
            if (AddCord[1] > SizeField - 1)
                AddCord[1] = 15;
            for (i = AddCord[0]; i < AddCord[1]; i++)
            {
                tempRnd++;
                tempMap[AddCord[0] + rndDirOld, i] = Fence;

                if (tempRnd == 2 && i != AddCord[1] - 1) //tempRnd - отвечает за кол-во смены направлений генерации
                {
                    tempRnd = 0;
                    rndDirNew = rnd.Next(-2, StepRnd);
                    if (AddCord[0] + rndDirNew > SizeField - 1)
                        rndDirNew = 0;
                    if (rndDirNew > rndDirOld)
                        for (int k = rndDirOld; k <= rndDirNew; k++)
                            tempMap[AddCord[0] + k, i + 1] = Fence;
                    else
                        if (rndDirNew != rndDirOld)
                        for (int k = rndDirOld; k > rndDirNew; k--)
                        {
                            tempMap[AddCord[0] + k, i + 1] = Fence;
                        }
                }
                rndDirOld = rndDirNew;
            }
            AddCord[0] = StartPnt + rndDirOld - Offset;
            if (AddCord[0] < 0)
                AddCord[0] = 0;
            AddCord[1] = SizeField - StartPnt - Offset;
            if (AddCord[1] > SizeField - 1)
                AddCord[1] = 15;
            rndDirOld = 0;
            rndDirNew = 0;
            tempRnd = 0;

            for (i = AddCord[0]; i < AddCord[1]; i++)
            {
                tempRnd++;
                tempMap[i, AddCord[1] + rndDirOld] = Fence;
                if (tempRnd == 2 && (i != SizeField - StartPnt - Offset - 3) && (i != SizeField - StartPnt - Offset - 2) && (i != SizeField - StartPnt - Offset - 1)) //tempRnd - отвечает за кол-во смены направлений генерации
                {
                    tempRnd = 0;
                    rndDirNew = rnd.Next(StepRnd);
                    if (SizeField + rndDirNew - StartPnt - Offset > SizeField - 1)
                        rndDirNew = 0;
                    if (rndDirNew > rndDirOld)
                        for (int k = rndDirOld; k <= rndDirNew; k++)
                            tempMap[i + 1, SizeField + k - StartPnt - Offset] = Fence;
                    else
                        if (rndDirNew != rndDirOld)
                    {
                        for (int k = rndDirOld; k > rndDirNew; k--)
                        {
                            tempMap[i + 1, SizeField + k - StartPnt - Offset] = Fence;
                        }
                    }
                }
                else if ((i == SizeField - StartPnt - Offset - 3) && (i == SizeField - StartPnt - Offset - 2) && (i == SizeField - StartPnt - Offset - 1))
                    tempRnd = 0;
                rndDirOld = rndDirNew;
            }
            AddCord[0] = AddCord[1];
            AddCord[1] = SizeField + rndDirOld - StartPnt - Offset;
            if (AddCord[1] > SizeField - 1)
                AddCord[1] = 15;
            AddCord[2] = StartPnt - Offset;
            if (AddCord[2] < 0)
                AddCord[2] = 0;

            for (i = AddCord[1]; i > AddCord[2]; i--)
            {
                if (i == PartSize)
                    tempMap[AddCord[0] - 1, i] = Fence - 1;
                tempMap[AddCord[0], i] = Fence;
            }

            rndDirOld = 0;
            rndDirNew = 0;
            tempRnd = 0;

            for (i = AddCord[0]; i > AddCord[2]; i--)
            {
                tempRnd++;
                if (i <= AddCord[2] + 2)
                {
                    if (i == AddCord[2] + 2)
                        for (int k = rndDirOld; k >= 0; k--)
                        {
                            tempMap[i, AddCord[2] - k] = Fence;
                        }
                    else
                        tempMap[i, AddCord[2]] = Fence;
                }
                else
                {
                    if (AddCord[2] - rndDirOld < 0)
                        rndDirOld = 0;
                    tempMap[i, AddCord[2] - rndDirOld] = Fence;

                    if (tempRnd == 2 && (i != AddCord[2] + 3) && (i != AddCord[2] + 4))
                    {
                        tempRnd = 0;
                        rndDirNew = rnd.Next(StepRnd);
                        if (AddCord[2] - rndDirNew < 0)
                            rndDirNew = 0;
                        if (rndDirNew > rndDirOld)
                        {
                            for (int k = rndDirOld; k < rndDirNew; k++)
                            {
                                tempMap[i - 1, AddCord[2] - k] = Fence;
                            }
                        }
                        else if (rndDirNew != rndDirOld)
                        {
                            for (int k = rndDirOld; k >= rndDirNew; k--)
                            {
                                tempMap[i - 1, -k + StartPnt - Offset] = Fence;
                            }
                        }
                    }
                    else if ((i == SizeField - StartPnt - Offset + 3) && (i == SizeField - StartPnt - Offset + 2))
                        tempRnd = 0;
                    rndDirOld = rndDirNew;
                }
            }
            //подсчет площади
            for (i = 0; i < SizeField; i++)
                for (g = 0; g < SizeField; g++)
                    if (tempMap[i, g] == 0 || tempMap[i, g] == 2)
                    {
                        Flag = 0;
                        j = i;
                        while (j >= 0)
                            if (tempMap[j, g] == 3)
                            {
                                Flag++;
                                j = -1;
                            }
                            else
                                j--;
                        j = i;
                        while (j < SizeField)
                            if (tempMap[j, g] == 3)
                            {
                                Flag++;
                                j = SizeField;
                            }
                            else
                                j++;
                        j = g;
                        while (j >= 0)
                            if (tempMap[i, j] == 3)
                            {
                                Flag++;
                                j = -1;
                            }
                            else
                                j--;
                        j = g;
                        while (j < SizeField)
                            if (tempMap[i, j] == 3)
                            {
                                Flag++;
                                j = SizeField;
                            }
                            else
                                j++;
                        if (Flag == 4)
                        {
                            countt++;
                            tempMap[i, g] = Flag;
                        }
                    }
            Console.Write(Offset + "\n");
            Console.Write("Новый метод площади: " + countt + "\n");
        }

        static void Main(string[] args)
        {
            GenerateMap3();
            for (int i = 0; i < SizeField; i++)
            {
                Console.Write("\n");
                for (int k = 0; k < SizeField; k++)
                {
                    if (tempMap[i, k] == 0)
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    else
                        if (tempMap[i, k] == 3)
                        Console.ForegroundColor = ConsoleColor.White;
                    else
                        Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(tempMap[i, k] + " ");
                }
            }
        }
    }
}
