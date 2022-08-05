using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.AnonymousCache
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, DataSet> dataSets = new Dictionary<string, DataSet>();
            Dictionary<string, DataSet> cache = new Dictionary<string, DataSet>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(new string[]{" -> ", " | "}, StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "thetinggoesskrra")
                {
                    break;
                }

                if (input.Length == 1)
                {
                    string dataSetName = input[0];

                    dataSets[dataSetName] = new DataSet();

                    if (cache.ContainsKey(dataSetName))
                    {
                        dataSets[dataSetName].Size = cache[dataSetName].Size;
                        dataSets[dataSetName].DataKeys = cache[dataSetName].DataKeys;
                    }
                }
                else
                {
                    string dataKey = input[0];
                    long dataSize = long.Parse(input[1]);
                    string dataSetName = input[2];

                    if (!dataSets.ContainsKey(dataSetName))
                    {
                        if (!cache.ContainsKey(dataSetName))
                        {
                            cache[dataSetName] = new DataSet();
                        }

                        cache[dataSetName].Size += dataSize;
                        cache[dataSetName].DataKeys.Add(dataKey);
                    }
                    else
                    {
                        dataSets[dataSetName].Size += dataSize;
                        dataSets[dataSetName].DataKeys.Add(dataKey);
                    }
                }
            }

            if (dataSets.Count > 0)
            {
                KeyValuePair<string, DataSet> bestDataSet = dataSets.OrderByDescending(d => d.Value.Size).First();

                Console.WriteLine($"Data Set: {bestDataSet.Key}, Total Size: {bestDataSet.Value.Size}");

                foreach (var dataKey in bestDataSet.Value.DataKeys)
                {
                    Console.WriteLine($"$.{dataKey}");
                }
            }
        }
    }

    class DataSet
    {
        public List<string> DataKeys { get; set; }
        public long Size { get; set; }

        public DataSet()
        {
            DataKeys = new List<string>();
        }
    }
}
