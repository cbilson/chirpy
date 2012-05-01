using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should.Fluent;
using Zippy.Chirp.JavaScript;

namespace Zippy.Chirp.Tests.JavaScript
{
    [TestClass]
    public class UglifyTest :BaseTest
    {

        [TestMethod]
        public void CanRunMultipleTimes()
        {

            for (var j = 0; j < 10; j++)
            {
                var times = new List<long>();
                var stopwatch = new System.Diagnostics.Stopwatch();

                for (var i = 0; i < 10; i++)
                {
                    stopwatch.Start();

                    string code = "if(test==0){alert(1);}";
                    string minid = Uglify.squeeze_it(code);

                    minid.Length.Should().Be.InRange(1, code.Length);
                    stopwatch.Stop();
                    times.Add(stopwatch.ElapsedMilliseconds);
                    stopwatch.Reset();
                }

                Console.WriteLine(string.Join(", ", times));
            }
        }
    }
}
