public static class CountingSort
{
    public static List<int> CountSort(List<int> inputArray)
    {
        int N = inputArray.Count;

        int M = 0;
        for (int i = 0; i < N; i++)
            M = Math.Max(M, inputArray[i]);

        List<int> countArray = new List<int>(new int[M + 1]);

        for (int i = 0; i < N; i++)
            countArray[inputArray[i]]++;

        for (int i = 1; i <= M; i++)
            countArray[i] += countArray[i - 1];
        
        List<int> outputArray = new List<int>(new int[N]);
        for (int i = N - 1; i >= 0; i--)
        {
            outputArray[countArray[inputArray[i]] - 1] = inputArray[i];
            countArray[inputArray[i]]--;
        }
        return outputArray;
    }
}