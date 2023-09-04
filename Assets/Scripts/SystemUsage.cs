using UnityEngine;
using UnityEngine.Profiling;
public class SystemUsage : MonoBehaviour
{
    void Update()
    {
        float totalAllocatedMemory = Profiler.GetTotalAllocatedMemoryLong() / (1024f * 1024f); // MB
        float totalReservedMemory = Profiler.GetTotalReservedMemoryLong() / (1024f * 1024f);  // MB
        float totalUnusedReservedMemory = Profiler.GetTotalUnusedReservedMemoryLong() / (1024f * 1024f);  // MB


        Debug.Log($"Allocated Memory: {totalAllocatedMemory} MB ");
    }
}