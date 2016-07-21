using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileTableOperations;
using System.IO;

namespace Tests
{
    [TestClass]
    public class UploadTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string filepath = @"C:\Users\Mark\Downloads\trailmap.pdf";
            Guid guid =  FileTableOperation.UploadFile("trailmap.pdf", File.ReadAllBytes(filepath));

            File.WriteAllBytes(@"C:\Users\Mark\Downloads\test.pdf", FileTableOperation.RetrieveFile(guid));
        }
    }
}
