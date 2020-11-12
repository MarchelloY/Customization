using NUnit.Framework;
using UnityEngine;
using Unity.PerformanceTesting;

namespace Tests
{
    public class Test
    {
        [Test, Performance]
        public void TestDistance()
        {
            Measure.Method(() => Distance())
                .WarmupCount(10)
                .MeasurementCount(1000)
                .Run();
        }
        
        [Test, Performance]
        public void TestSqrMagnitude()
        {
            Measure.Method(() => SqrMag())
                .WarmupCount(10)
                .MeasurementCount(1000)
                .Run();
        }

        private static float SqrMag()
        {
            return Vector3.SqrMagnitude(v2 - v1);
        }
        
        private static float Distance()
        {
            return Vector3.Distance(v1, v2);
        }
        
        private static Vector3 v1 => new Vector3(Random.value,Random.value,Random.value);
        private static Vector3 v2 => new Vector3(Random.value,Random.value,Random.value);
    }
}