using JsonExampleCode.Shared.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonExampleCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateJsonFileExample();
        }


        /// <summary>
        /// Function to create a JSON File after read the HTML
        /// </summary>
        public static void CreateJsonFileExample()
        {
            //Here goes the code to pick up the file after creation by Tester, then read it and get the needed values.






            //Create object UnitUnderTestDTO ( DTO Means Data Transfer Object)
            var modelDTO = new UnitUnderTestDTO()
            {
                Id = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMinutes(5),
                SerialNumber = "123456789",
                Model = "ABCModel",
                ComputerName = "MXCHIM0FVT01",
       
                TestedExecuted = new List<Test>()
                {
                   //Adding dummie data.
                   new Test()
                   {
                       TestName = "Prueba1",
                       Status = TestStatus.Success
                   },

                    //Adding dummie data.
                   new Test()
                   {
                       TestName = "Prueba2",
                       Status = TestStatus.Failure
                   },

                    //Adding dummie data.
                   new Test()
                   {
                       TestName = "Prueba3",
                       Status = TestStatus.Success
                   }
                },                
            };

            //Evaluate if any of the test fail mark the modelDTO status as a failure
            var result = modelDTO.TestedExecuted.Any(x=>x.Status == TestStatus.Failure);


            //This is the common evaluation used IF syntaxis
            if (result)
            {
                modelDTO.Status = TestStatus.Failure;
            }
            else
            {
                modelDTO.Status = TestStatus.Success;
            }


            //This is an example using extension Methods just FYI
            var TestStatusExample = TestStatus.Failure.ToBoolean();

       
            //Create the JSON File using Newtownsoft dependency
            var json = JsonConvert.SerializeObject(modelDTO);

            //Here just create the file and send it to the next computer, Monitor App to be readed by it.
            string root = @"C:\";
            using(var sw = new StreamWriter($"{root}\\ExampleFolder\\"))
            {
                sw.WriteLine(json);
            }
        }

        public static void ReadJsonFileExample()
        {
            string root = @"C:\";

            //Read JsonFile.
            var jsonStr = File.ReadAllText($"{root}\\The rest of the path");


            //Here the json file read it will deserialized into the specific object UnitUnderTestDTO
            var responseDTO = JsonConvert.DeserializeObject<UnitUnderTestDTO>(jsonStr);



            //then you will can use the propierties exaclty what you want.

            int Id = (int)responseDTO.Id; // Here it is needed apply a casting explicit because the propertie has a safe null using ? this question mark into the propertie
            string SerialNumber = responseDTO.SerialNumber;
            string model = responseDTO.Model;
        }
    }
}
