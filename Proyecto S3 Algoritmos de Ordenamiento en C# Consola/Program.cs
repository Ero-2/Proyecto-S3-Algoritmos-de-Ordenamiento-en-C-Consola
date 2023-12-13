﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_S3_Algoritmos_de_Ordenamiento_en_C__Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 64, 34, 25, 12, 22, 11, 90 };

            Console.WriteLine("Original array: ");
            PrintArray(array);

            // Bubble Sort
            BubbleSort(array);
            Console.WriteLine("\nArray after Bubble Sort: ");
            PrintArray(array);

            // Bucket Sort
            int maxVal = array[0];
            foreach (var val in array)
            {
                if (val > maxVal)
                    maxVal = val;
            }
            BucketSort(array, maxVal);
            Console.WriteLine("\nArray after Bucket Sort: ");
            PrintArray(array);

            // Binary Tree Sort
            BinaryTreeSort(array);
            Console.WriteLine("\nArray after Binary Tree Sort: ");
            PrintArray(array);

            // Quick Sort
            QuickSort(array, 0, array.Length - 1);
            Console.WriteLine("\nArray after Quick Sort: ");
            PrintArray(array);

            // Cocktail Sort
            CocktailSort(array);
            Console.WriteLine("\nArray after Cocktail Sort: ");
            PrintArray(array);

            // Merge Direct Sort
            MergeDirectSort(array);
            Console.WriteLine("\nArray after Merge Direct Sort: ");
            PrintArray(array);

            // Natural Merge Sort
            NaturalMergeSort(array);
            Console.WriteLine("\nArray after Natural Merge Sort: ");
            PrintArray(array);

            // Merge Sort
            MergeSort(array);
            Console.WriteLine("\nArray after Merge Sort: ");
            PrintArray(array);

            // Radix Sort
            RadixSort(array);
            Console.WriteLine("\nArray after Radix Sort: ");
            PrintArray(array);

            // Shell Sort
            ShellSort(array);
            Console.WriteLine("\nArray after Shell Sort: ");
            PrintArray(array);

            // Pigeonhole Sort
            PigeonholeSort(array);
            Console.WriteLine("\nArray after Pigeonhole Sort: ");
            PrintArray(array);

            //gnomesort 
            GnomeSort(array);
            Console.WriteLine("\nArray after Gnome Sort: ");
            PrintArray(array);

            //Combsort 
            CombSort(array);
            Console.WriteLine("\nArray after Combsort Sort: ");
            PrintArray(array);

            SelectionSort(array);
            Console.WriteLine("\nArray after Selection Sort: ");
            PrintArray(array);

            HeapSort(array);
            Console.WriteLine("\nArray after Heap Sort: ");
            PrintArray(array);

            CountingSort(array);
            Console.WriteLine("\nArray after Counting Sort: ");
            PrintArray(array);



            Console.ReadKey();
        }

        static void PrintArray(int[] arr)
        {
            foreach (var val in arr)
            {
                Console.Write(val + " ");
            }
            Console.WriteLine();
        }

        // Bubble Sort
        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        //BucketSort
        static void BucketSort(int[] arr, int maxVal)
        {
            int[] bucket = new int[maxVal + 1];
            int idx = 0;

            foreach (var val in arr)
            {
                bucket[val]++;
            }

            for (int i = 0; i < bucket.Length; i++)
            {
                for (int j = 0; j < bucket[i]; j++)
                {
                    arr[idx++] = i;
                }
            }
        }

        // Binary Tree Sort
        static void BinaryTreeSort(int[] arr)
        {
            Node root = null;

            // Construct the binary search tree
            foreach (var value in arr)
            {
                root = Insert(root, value);
            }

            // Perform in-order traversal to get sorted elements
            InOrderTraversal(root, arr, ref index);
        }

        static Node Insert(Node root, int value)
        {
            if (root == null)
            {
                return new Node(value);
            }

            if (value < root.Data)
            {
                root.Left = Insert(root.Left, value);
            }
            else if (value > root.Data)
            {
                root.Right = Insert(root.Right, value);
            }

            return root;
        }

        static int index = 0;

        static void InOrderTraversal(Node root, int[] arr, ref int index)
        {
            if (root != null)
            {
                InOrderTraversal(root.Left, arr, ref index);
                arr[index++] = root.Data;
                InOrderTraversal(root.Right, arr, ref index);
            }
        }


        // Quick Sort
        static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(arr, low, high);

                QuickSort(arr, low, partitionIndex - 1);
                QuickSort(arr, partitionIndex + 1, high);
            }
        }

        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(ref arr[i], ref arr[j]);
                }
            }

            Swap(ref arr[i + 1], ref arr[high]);
            return i + 1;
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        //Cocktail Sort
        static void CocktailSort(int[] arr)
        {
            bool swapped;
            do
            {
                swapped = false;

                for (int i = 0; i <= arr.Length - 2; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(ref arr[i], ref arr[i + 1]);
                        swapped = true;
                    }
                }

                if (!swapped)
                    break;

                swapped = false;

                for (int i = arr.Length - 2; i >= 0; i--)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(ref arr[i], ref arr[i + 1]);
                        swapped = true;
                    }
                }

            } while (swapped);
        }

        // Merge Direct Sort
        static void MergeDirectSort(int[] arr)
        {
            int[] temp = new int[arr.Length];
            MergeDirectSort(arr, temp, 0, arr.Length - 1);
        }

        static void MergeDirectSort(int[] arr, int[] temp, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeDirectSort(arr, temp, left, middle);
                MergeDirectSort(arr, temp, middle + 1, right);
                MergeDirect(arr, temp, left, middle, right);
            }
        }

        static void MergeDirect(int[] arr, int[] temp, int left, int middle, int right)
        {
            int i = left;
            int j = middle + 1;
            int k = left;

            while (i <= middle && j <= right)
            {
                if (arr[i] <= arr[j])
                    temp[k++] = arr[i++];
                else
                    temp[k++] = arr[j++];
            }

            while (i <= middle)
                temp[k++] = arr[i++];

            while (j <= right)
                temp[k++] = arr[j++];

            for (i = left; i <= right; i++)
                arr[i] = temp[i];
        }

        static void NaturalMergeSort(int[] arr)
        {
            int n = arr.Length;

            // Encontrar las corridas (runs)
            List<int[]> runs = new List<int[]>();
            int start = 0;
            while (start < n)
            {
                int end = start + 1;
                while (end < n && arr[end - 1] <= arr[end])
                {
                    end++;
                }

                int[] run = new int[end - start];
                Array.Copy(arr, start, run, 0, end - start);
                runs.Add(run);

                start = end;
            }

            // Fusionar las corridas hasta que solo quede una corrida
            while (runs.Count > 1)
            {
                List<int[]> newRuns = new List<int[]>();
                for (int i = 0; i < runs.Count; i += 2)
                {
                    if (i + 1 < runs.Count)
                    {
                        int[] mergedRun = MergeRuns(runs[i], runs[i + 1]);
                        newRuns.Add(mergedRun);
                    }
                    else
                    {
                        newRuns.Add(runs[i]);
                    }
                }
                runs = newRuns;
            }

            // Copiar la corrida ordenada al array original
            Array.Copy(runs[0], arr, n);
        }

        //NaturalMerge
        static int[] MergeRuns(int[] run1, int[] run2)
        {
            int n1 = run1.Length;
            int n2 = run2.Length;
            int[] mergedRun = new int[n1 + n2];

            int i = 0, j = 0, k = 0;
            while (i < n1 && j < n2)
            {
                if (run1[i] <= run2[j])
                {
                    mergedRun[k++] = run1[i++];
                }
                else
                {
                    mergedRun[k++] = run2[j++];
                }
            }

            while (i < n1)
            {
                mergedRun[k++] = run1[i++];
            }

            while (j < n2)
            {
                mergedRun[k++] = run2[j++];
            }

            return mergedRun;
        }

        // Merge Sort
        static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }

        static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSort(arr, left, middle);
                MergeSort(arr, middle + 1, right);

                Merge(arr, left, middle, right);
            }
        }

        static void Merge(int[] arr, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] L = new int[n1];
            int[] R = new int[n2];

            for (int ii = 0; ii < n1; ++ii)
                L[ii] = arr[left + ii];

            for (int jj = 0; jj < n2; ++jj)
                R[jj] = arr[middle + 1 + jj];

            int i = 0, j = 0;
            int k = left;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        // Radix Sort
        static void RadixSort(int[] arr)
        {
            int max = GetMax(arr);
            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                CountSort(arr, exp);
            }
        }

        static int GetMax(int[] arr)
        {
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }

        static void CountSort(int[] arr, int exp)
        {
            int n = arr.Length;
            int[] output = new int[n];
            int[] count = new int[10];

            for (int i = 0; i < n; i++)
            {
                count[(arr[i] / exp) % 10]++;
            }

            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = n - 1; i >= 0; i--)
            {
                output[count[(arr[i] / exp) % 10] - 1] = arr[i];
                count[(arr[i] / exp) % 10]--;
            }

            for (int i = 0; i < n; i++)
            {
                arr[i] = output[i];
            }
        }

        //shellsort
        static void ShellSort(int[] arr)
        {
            int n = arr.Length;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = arr[i];
                    int j;
                    for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                    {
                        arr[j] = arr[j - gap];
                    }
                    arr[j] = temp;
                }
            }

        }

        //pigenogolesort
        static void PigeonholeSort(int[] arr)
        {
            int n = arr.Length;
            int min = arr[0];
            int max = arr[0];
            for (int i = 1; i < n; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
                if (arr[i] > max)
                    max = arr[i];
            }

            int range = max - min + 1;
            List<int>[] holes = new List<int>[range];
            for (int i = 0; i < range; i++)
            {
                holes[i] = new List<int>();
            }

            for (int i = 0; i < n; i++)
            {
                holes[arr[i] - min].Add(arr[i]);
            }

            int index = 0;
            for (int i = 0; i < range; i++)
            {
                foreach (var value in holes[i])
                {
                    arr[index++] = value;
                }
            }
        }

        static void GnomeSort(int[] arr)
        {
            int n = arr.Length;
            int index = 0;

            while (index < n)
            {
                if (index == 0)
                    index++;
                if (arr[index] >= arr[index - 1])
                    index++;
                else
                {
                    Swapp(ref arr[index], ref arr[index - 1]);
                    index--;
                }
            }
        }

        static void Swapp(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void CombSort(int[] arr)
        {
            int n = arr.Length;
            int gap = n;
            bool swapped = true;

            while (gap > 1 || swapped)
            {
                gap = Math.Max(1, (int)(gap / 1.3));

                swapped = false;

                for (int i = 0; i + gap < n; i++)
                {
                    if (arr[i] > arr[i + gap])
                    {
                        Swap(ref arr[i], ref arr[i + gap]);
                        swapped = true;
                    }
                }
            }
        }

        static void SelectionSort(int[] arr)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                Swap(ref arr[i], ref arr[minIndex]);
            }
        }

        static void HeapSort(int[] arr)
        {
            int n = arr.Length;

            // Construir el heap (montículo)
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            // Extraer elementos del heap uno por uno
            for (int i = n - 1; i > 0; i--)
            {
                // Mover la raíz actual al final del array
                Swap(ref arr[0], ref arr[i]);

                // Llamar al procedimiento Heapify en la raíz reducida
                Heapify(arr, i, 0);
            }
        }

        static void Heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int leftChild = 2 * i + 1;
            int rightChild = 2 * i + 2;

            // Si el hijo izquierdo es más grande que la raíz
            if (leftChild < n && arr[leftChild] > arr[largest])
            {
                largest = leftChild;
            }

            // Si el hijo derecho es más grande que el más grande hasta ahora
            if (rightChild < n && arr[rightChild] > arr[largest])
            {
                largest = rightChild;
            }

            // Si el más grande no es la raíz
            if (largest != i)
            {
                Swap(ref arr[i], ref arr[largest]);

                // Llamar recursivamente al procedimiento Heapify en el subárbol afectado
                Heapify(arr, n, largest);
            }
        }

        static void CountingSort(int[] arr)
        {
            int n = arr.Length;

            // Encontrar el valor máximo en el array
            int max = arr[0];
            for (int i = 1; i < n; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            // Crear un array de conteo y inicializar todas las posiciones con 0
            int[] count = new int[max + 1];
            for (int i = 0; i <= max; i++)
            {
                count[i] = 0;
            }

            // Incrementar el conteo de cada elemento en el array original
            for (int i = 0; i < n; i++)
            {
                count[arr[i]]++;
            }

            // Actualizar el array original con los elementos ordenados
            int index = 0;
            for (int i = 0; i <= max; i++)
            {
                while (count[i] > 0)
                {
                    arr[index] = i;
                    index++;
                    count[i]--;
                }
            }
        }

    }
}
