//*****************************************************************************
//** 862. Shortest Subarray with Sum at Least K    leetcode                  **
//*****************************************************************************

int shortestSubarray(int* nums, int numsSize, int k) {
    long* prefix = (long*)malloc((numsSize + 1) * sizeof(long));
    prefix[0] = 0;
    for (int i = 0; i < numsSize; ++i) {
        prefix[i + 1] = prefix[i] + nums[i];
    }

    int* deque = (int*)malloc((numsSize + 1) * sizeof(int));
    int front = 0, back = 0;
    int minLength = INT_MAX;

    for (int i = 0; i <= numsSize; ++i) {
        while (front < back && prefix[i] - prefix[deque[front]] >= k) {
            int length = i - deque[front++];
            if (length < minLength) {
                minLength = length;
            }
        }

        while (front < back && prefix[i] <= prefix[deque[back - 1]]) {
            back--;
        }

        deque[back++] = i;
    }

    // Free memory
    free(deque);
    free(prefix);

    return minLength == INT_MAX ? -1 : minLength;
}