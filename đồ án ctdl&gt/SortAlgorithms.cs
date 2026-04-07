using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace đồ_án_ctdl_gt
{
    internal class SortAlgorithms
    {
        //SelectionSort tăng dần
        public void SelectionSortAsc(List<Account> arr)
        {
            int n = arr.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j].Balance < arr[minIdx].Balance)
                        minIdx = j;
                }
                // Hoán đổi
                Account temp = arr[minIdx];
                arr[minIdx] = arr[i];
                arr[i] = temp;
            }
        }

        //SelectionSort giảm dần
        public void SelectionSortDesc(List<Account> arr)
        {
            int n = arr.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int maxIdx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j].Balance > arr[maxIdx].Balance)
                        maxIdx = j;
                }
                // Hoán đổi
                Account temp = arr[maxIdx];
                arr[maxIdx] = arr[i];
                arr[i] = temp;
            }
        }

        //InsertionSort tăng dần
        public void InsertionSortAsc(List<Account> arr)
        {
            int n = arr.Count;
            for (int i = 1; i < n; i++)
            {
                Account key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j].Balance > key.Balance)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }

        //InsertionSort giảm dần
        public void InsertionSortDesc(List<Account> arr)
        {
            int n = arr.Count;
            for (int i = 1; i < n; i++)
            {
                Account key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j].Balance < key.Balance)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }

        //BubbleSort tăng dần
        public void BubbleSortAsc(List<Account> arr)
        {
            int n = arr.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j].Balance > arr[j + 1].Balance)
                    {
                        // Hoán đổi
                        Account temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }

            }
        }

        //BubbleSort giảm dần
        public void BubbleSortDesc(List<Account> arr)
        {
            int n = arr.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j].Balance < arr[j + 1].Balance)
                    {
                        // Hoán đổi
                        Account temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        //QuickSort tăng dần
        public void QuickSortAsc(List<Account> arr, int low, int high)
        {
            if (low < high)
            {
                int pi = PartitionAsc(arr, low, high);
                QuickSortAsc(arr, low, pi - 1);
                QuickSortAsc(arr, pi + 1, high);
            }
        }

        private int PartitionAsc(List<Account> arr, int low, int high)
        {
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                if (arr[j].Balance < arr[high].Balance)
                {
                    i++;
                    Account temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            Account temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;
            return i + 1;
        }

        //QuickSort giảm dần
        public void QuickSortDesc(List<Account> arr, int low, int high)
        {
            if (low < high)
            {
                int pi = PartitionDesc(arr, low, high);
                QuickSortDesc(arr, low, pi - 1);
                QuickSortDesc(arr, pi + 1, high);
            }
        }

        private int PartitionDesc(List<Account> arr, int low, int high)
        {
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                if (arr[j].Balance > arr[high].Balance)
                {
                    i++;
                    Account temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            Account temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;
            return i + 1;
        }

        //MergeSort tăng dần
        public void MergeSortAsc(List<Account> arr, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                MergeSortAsc(arr, l, m);
                MergeSortAsc(arr, m + 1, r);
                MergeAsc(arr, l, m, r);
            }
        }
        private void MergeAsc(List<Account> arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;
            List<Account> L = new List<Account>();
            List<Account> R = new List<Account>();
            for (int i = 0; i < n1; ++i) L.Add(arr[l + i]);
            for (int j = 0; j < n2; ++j) R.Add(arr[m + 1 + j]);

            int i_idx = 0, j_idx = 0, k = l;
            while (i_idx < n1 && j_idx < n2)
            {
                if (L[i_idx].Balance <= R[j_idx].Balance)
                    arr[k++] = L[i_idx++];
                else
                    arr[k++] = R[j_idx++];
            }
            while (i_idx < n1) arr[k++] = L[i_idx++];
            while (j_idx < n2) arr[k++] = R[j_idx++];
        }


        //MergeSort giảm dần
        public void MergeSortDesc(List<Account> arr, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                MergeSortDesc(arr, l, m);
                MergeSortDesc(arr, m + 1, r);
                MergeDesc(arr, l, m, r);
            }
        }
        private void MergeDesc(List<Account> arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;
            List<Account> L = new List<Account>();
            List<Account> R = new List<Account>();
            for (int i = 0; i < n1; ++i) L.Add(arr[l + i]);
            for (int j = 0; j < n2; ++j) R.Add(arr[m + 1 + j]);

            int i_idx = 0, j_idx = 0, k = l;
            while (i_idx < n1 && j_idx < n2)
            {
                if (L[i_idx].Balance >= R[j_idx].Balance)
                    arr[k++] = L[i_idx++];
                else
                    arr[k++] = R[j_idx++];
            }
            while (i_idx < n1) arr[k++] = L[i_idx++];
            while (j_idx < n2) arr[k++] = R[j_idx++];
        }

        //HeapSort tăng dần
        public void HeapSortAsc(List<Account> arr)
        {
            int n = arr.Count;
            for (int i = n / 2 - 1; i >= 0; i--)
                HeapifyAsc(arr, n, i);

            for (int i = n - 1; i > 0; i--)
            {
                Account temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                HeapifyAsc(arr, i, 0);
            }
        }

        private void HeapifyAsc(List<Account> arr, int n, int i)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            if (l < n && arr[l].Balance > arr[largest].Balance) largest = l;
            if (r < n && arr[r].Balance > arr[largest].Balance) largest = r;
            if (largest != i)
            {
                Account swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;
                HeapifyAsc(arr, n, largest);
            }
        }

        //HeapSort giảm dần
        public void HeapSortDesc(List<Account> arr)
        {
            int n = arr.Count;
            for (int i = n / 2 - 1; i >= 0; i--)
                HeapifyDesc(arr, n, i);

            for (int i = n - 1; i > 0; i--)
            {
                Account temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;
                HeapifyDesc(arr, i, 0);
            }
        }
        private void HeapifyDesc(List<Account> arr, int n, int i)
        {
            int smallest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            if (l < n && arr[l].Balance < arr[smallest].Balance) smallest = l;
            if (r < n && arr[r].Balance < arr[smallest].Balance) smallest = r;
            if (smallest != i)
            {
                Account swap = arr[i];
                arr[i] = arr[smallest];
                arr[smallest] = swap;
                HeapifyDesc(arr, n, smallest);
            }
        }

    }
}
