/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Siemens.Runtime.HmiIL;
using HmiILRt.MyOption.Interfaces;
using Siemens.Runtime.HmiUnified;

namespace Siemens.Runtime.HmiIL.TestClient
{
	class OptionSample
	{
		private IRuntime runtime = Start.runtime;
   
		public void GetOptionObject()
		{
			//load option component by name
			IMyOption rtOption = (IMyOption)runtime.GetOption("MyOptionName");
			//create a instance of the option object IMyOptionObject
			IMyOptionObject optionObject = rtOption.GetObject<IMyOptionObject>();
			try
			{
				string strMethod = optionObject.MyMethod();
				string strProperty = optionObject.MyProperty;
			}
			catch (OdkException ex)
			{
				//It is an option error?
				if (ex.ErrorSubCategory == MyOptionConstants.MYOPTION_ERRORCATEGORY)
				{
					//Handle option specific error
					if (ex.ErrorCode == (uint)MyErrorCodes.E_UNKNOWN_NAME)
					{
						//get error description
						string errorDescription = ex.Message;
					}
				}
			}
		}

		public void UsingOptionCpmWithoutExtension()
		{
			//load option component by name
			IMyOption rtOption = (IMyOption)runtime.GetOption("MyOptionName");

			IPlantModel myCpm = runtime.GetObject<IPlantModel>();
			IPlantObject cpmNode = myCpm.GetPlantObject(".hierarchy::PlantView/Unit1");

			//get extended interface for CpmNode
			IMyPlantObjectExt myCpmNodeExt = rtOption.GetPlantObjectExt(cpmNode);
			IMyPlantObjectFormula cpmNodeFormula = myCpmNodeExt.GetObject<IMyPlantObjectFormula>("Quality");
			cpmNodeFormula.Calc();
		}

		public void UsingOptionCpmExtensionMethod()
		{
            IPlantModel myCpm = runtime.GetObject<IPlantModel>();
            IPlantObject cpmNode = myCpm.GetPlantObject(".hierarchy::PlantView/Unit1");

            //using of option extension method "MyOption()"
            IMyPlantObjectFormula cpmNodeFormula = cpmNode.MyOption().GetObject<IMyPlantObjectFormula>("Quality");
			cpmNodeFormula.Calc();
		}
	}
}
*/