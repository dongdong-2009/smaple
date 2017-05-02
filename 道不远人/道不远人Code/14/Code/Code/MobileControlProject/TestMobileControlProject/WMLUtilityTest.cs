// 以下代码由 Microsoft Visual Studio 2005 生成。
// 测试所有者应该检查每个测试的有效性。
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;

namespace TestMobileControlProject
{
    /// <summary>
    ///这是 MobileControlLibrary.UI.WMLUtility 的测试类，旨在
    ///包含所有 MobileControlLibrary.UI.WMLUtility 单元测试
    ///</summary>
    [TestClass()]
    public class WMLUtilityTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        #region 附加测试属性
        // 
        //编写测试时，可使用以下附加属性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///WMLAttributeEncode (string) 的测试
        ///</summary>
        [TestMethod()]
        public void WMLAttributeEncodeTest()
        {
            string value = "中国>日本"; 

            string expected = "中国>日本";
            string actual;

            actual = MobileControlLibrary.UI.WMLUtility.WMLAttributeEncode(value);
            actual = MobileControlLibrary.UI.WMLUtility.WMLDecode(actual);

            Assert.AreEqual(expected, actual, "MobileControlLibrary.UI.WMLUtility.WMLAttributeEncode 未返回所需的值。");


            value = "中国>美国";

            expected = "中国>美国";
            actual = MobileControlLibrary.UI.WMLUtility.WMLAttributeEncode(value);
            actual = MobileControlLibrary.UI.WMLUtility.WMLDecode(actual);

            Assert.AreEqual(expected, actual, "MobileControlLibrary.UI.WMLUtility.WMLAttributeEncode 未返回所需的值。");
        }

    }


}
