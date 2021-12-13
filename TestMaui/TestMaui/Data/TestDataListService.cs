using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMaui.Data
{
    public class TestDataListService
    {
        public List<TestData> GetTestDataList()
        {
            return TestDataListSingleton.Instance;
        }

        public Task<List<TestData>> GetTestDataListAsync()
        {
            return Task.FromResult(TestDataListSingleton.Instance);
        }

        public Task AddDataItemAsync(TestData item)
        {
            AddDataItem(item);
            return Task.CompletedTask;
        }

        public void AddDataItem(TestData item)
        {
            TestDataListSingleton.Instance.Add(item);
        }
    }

    public sealed class TestDataListSingleton
    {
        private static readonly Lazy<List<TestData>> testDataSingleton = new Lazy<List<TestData>>(() => GenerateTestData());
        public static List<TestData> Instance { get { return testDataSingleton.Value; } }
        private TestDataListSingleton() { }
        private static List<TestData> GenerateTestData()
        {
            var returnList = new List<TestData>();
            for (int i = 0; i < 10; i++)
            {
                returnList.Add(new TestData()
                {
                    Id = Guid.NewGuid(),
                    Item1 = $"Item1_{i}",
                    Item2 = $"Item2_{i}"
                });
            }
            return returnList;
        }
    }
}
