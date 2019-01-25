using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace exceptionperf
{
    [ClrJob, CoreJob]
    public class Test
    {
        [Benchmark]
        public string ExceptionTryCatch()
        {
            try
            {
                throw new ArgumentOutOfRangeException("Test for Try/Catch with when");
            }
            catch (Exception ex) when (ex is ArgumentNullException || ex is ArgumentOutOfRangeException)
            {
                return ex.Message;
            }
        }
        [Benchmark]
        public string ExceptionWithWith()
        {
            try
            {
                throw new ArgumentOutOfRangeException("Test for Try/Catch with when");
            }
            catch (ArgumentNullException ex) 
            {
                return ex.Message;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return ex.Message;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Test>();
        }
    }
}
