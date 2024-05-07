using Siemens.Runtime.HmiUnified;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siemens.Runtime.HmiIL.TestClient
{
     class Program
     {
          static void Main(string[] args)
          {
               Console.WriteLine("Connecting to Runtime...");
               Start start = new Start();
               start.Connect();

               IRuntime runtime = Start.runtime;

               Console.WriteLine("Getting version info...");
               start.GetVersionInfo(runtime);

               Console.WriteLine($"Project: {runtime.ProjectName}");
               Console.WriteLine($"User: {runtime.UserName}");

             

               TagSample tagSample = new TagSample();

               
               while (true)
               {
                    tagSample.ReadSingleTagSync();
               }
               

               //tagSample.WriteSingleTagSync();
               //tagSample.WriteTagSetSync();
               //tagSample.ReadTagSetSync();
               
               Console.ReadKey();
          }
     }
}
