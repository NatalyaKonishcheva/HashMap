using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hash;

namespace HashMapTest
{
    [TestClass]
    public class UnitTestHashMap
    {
        [TestMethod]
        public void CountOfElemInEmptyTable()
        {
            int expected = 0;
            HashMap<string, string> hashMap = new HashMap<string, string>(0);
            int actual = hashMap.Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetHashCodeFromTableWithRowCount1()
        {
            HashMap<string, string> hashMap = new HashMap<string, string>(0);
            Assert.ThrowsException<System.DivideByZeroException>(() => hashMap.GetMyHashCode("неважно, что тут написать"));
        }
        [TestMethod]

        public void PutToNull()
        {
            HashMap<string, string> hashMap = new HashMap<string, string>(0);
            Assert.ThrowsException<System.IndexOutOfRangeException>(() => hashMap.Put("r", "t"));
        }
        [TestMethod]
        public void GetValueByNonexistentKey()
        {
            string expected = null;
            HashMap<string, string> hashMap = new HashMap<string, string>();
            string actual = hashMap["dog"];
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UpdateOfKeys()
        {
            int expected = 1;

            HashMap<string, string> hashMap = new HashMap<string, string>();
            hashMap.Put("The same key", "The different value 1");
            hashMap.Put("The same key", "The different value 2");
            int actual = hashMap.Count;
            
            Assert.IsTrue(hashMap.ContainsValue("The different value 2"));
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetValueByNonexistentKeyInt()
        {
            int expected = default;
            HashMap<int, int> hashMap = new HashMap<int, int>();
            int actual = hashMap[3];
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void RemoveExistingKey()
        {
            HashMap<string, string> hashMap = new HashMap<string, string>();
            hashMap.Put("The same key", "The different value 1");
            hashMap.Remove("The same key");
            Assert.IsTrue(!hashMap.ContainsKey("The same key"));
        }
        [TestMethod]
        public void RemoveNonexistingKey()
        {
            HashMap<string, string> hashMap = new HashMap<string, string>();
            hashMap.Remove("The same key");
        }
        [TestMethod]
        public void VerifyToString()
        {
            HashMap<string, string> hashMap = new HashMap<string, string>();
            string expected = "“аблица пуста\r\n";
            string actual = hashMap.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
