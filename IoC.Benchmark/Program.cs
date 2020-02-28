using IoC.Benchmark.Benchmarks;
using System;
using System.Collections;
using System.Linq;

namespace IoC.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get benchmarks
            var fBenchmarks = getBenchmarks("IoC.Benchmark.Benchmarks.Function");
            var oBenchmarks = getBenchmarks("IoC.Benchmark.Benchmarks.Object");
            var iBenchmarks = getBenchmarks("IoC.Benchmark.Benchmarks.Implementation");


            // Run benchmarks
            Console.WriteLine("--- Factory Function ---");
            foreach (BenchmarkBase benchmark in fBenchmarks)
                Console.WriteLine("{0}-{1}", benchmark.ToString(), benchmark.StartBenchmark());

            Console.WriteLine(Environment.NewLine + "--- Implementation ---");
            foreach (BenchmarkBase benchmark in iBenchmarks)
                Console.WriteLine("{0}-{1}", benchmark.ToString(), benchmark.StartBenchmark());

            Console.WriteLine(Environment.NewLine + "--- Object ---");
            foreach (BenchmarkBase benchmark in oBenchmarks)
                Console.WriteLine("{0}-{1}", benchmark.ToString(), benchmark.StartBenchmark());
        }

        private static IEnumerable getBenchmarks(string @namespace)
        {
            return typeof(BenchmarkBase)
                .Assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(BenchmarkBase)) && t.Namespace == @namespace)
                .Select(t => (BenchmarkBase)Activator.CreateInstance(t));
        }
    }
}
