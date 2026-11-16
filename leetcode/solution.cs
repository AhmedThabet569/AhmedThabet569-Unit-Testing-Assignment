public class Solution {
     public  int MinEatingSpeed(int[] piles, int h)
        {
            // start
            int low = 1;
            int high = GetMax(piles);
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                long hours = 0;
                foreach (int i in piles)
                {
                    hours  += (i+mid -1) / mid;
                    
                }
                if (hours <= h) high = mid - 1;
                else low = mid + 1;

            }
            return low;
        }
        public static int GetMax(int[] piles)
        {
            int max = 0;
            foreach (var item in piles)
            {
                if (item > max)
                    max = item;
            }
            return max;
        }
       
}