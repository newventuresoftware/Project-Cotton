namespace Cotton.Engine
{
    using System;

    public class Distance
    {
        public static double Levenshtein(string source, string target)
        {
            if (source.Length == 0)
                return target.Length;

            if (target.Length == 0)
                return source.Length;

            if (source == target)
                return 0;
            
            var memo = new int[target.Length];

            for (int k = 0; k < target.Length; k++)
                memo[k] = k;

            for (int i = 1; i < source.Length; i++)
            {
                var currentRowMemo = new int[target.Length];
                currentRowMemo[0] = i;

                for (int k = 1; k < target.Length; k++)
                {
                    currentRowMemo[k] = Math.Min(
                        Math.Min(currentRowMemo[k - 1] + 1, memo[k] + 1),
                        memo[k - 1] + (source[i - 1] != target[k - 1] ? 1 : 0));
                }

                memo = currentRowMemo;
            }

            return memo[target.Length - 1];
        }
    }
}
