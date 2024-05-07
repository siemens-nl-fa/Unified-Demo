using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Runtime.HmiUnified;
using System.Reflection;
using Siemens.Runtime.HmiIL.TestClient;

namespace Siemens.Runtime.HmiIL.TestClient
{
     public class Start
     {
          public static IRuntime runtime = null;

          public void Connect()
          {
               try
               {
                    // Connect to running project
                    runtime = Siemens.Runtime.HmiUnified.Runtime.Connect();
               }
               catch (Exception ex)
               {
                    System.Console.WriteLine(string.Format("OdkException occured {0}", ex.Message));
               }
          }

          public void GetVersionInfo(IRuntime runtime)
          {
               try
               {
                    // Get product version
                    IProduct product = runtime.Product;
                    IVersionInfo version = product.Version;
                    System.Console.WriteLine(string.Format("Product version: {0}.{1}.{2}.{3}", version.Major, version.Minor, version.ServicePack, version.Update));

                    if (product.Options.Count > 0)
                    {
                         foreach (IOption op in product.Options)
                         {
                              IVersionInfo opVersion = op.Version;
                              // Iterate through options and get version
                              System.Console.WriteLine(string.Format("Option name: {0}", op.Name));
                              System.Console.WriteLine(string.Format("Option version: {0}.{1}.{2}.{3}", opVersion.Major, opVersion.Minor, opVersion.ServicePack, opVersion.Update));
                         }
                    }
               }
               catch (Exception ex)
               {
                    System.Console.WriteLine(string.Format("Exception occured {0}", ex.Message));
               }
          }
     }
}
