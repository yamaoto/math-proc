using System;
using System.Linq;
using Mathproc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class TestProccessВыражение
    {
        public const string Math1 = "1+2";//+ 1 2
        public const string Math2 = "3*2+5";//* 3 + 2 5
        public const string Math3 = "1+2*(6+5)-8";



        [TestMethod]
        public void TestGetMathExprs1()
        {
            var processor = new Mathproc.Processors.ProccessВыражение();
            var result = processor.GetMathExprs(Math1);
            System.Diagnostics.Debug.Write(result.Aggregate("", (current, expr) => current + expr.Polska() + " "));
        }

        [TestMethod]
        public void TestGetMathExprs2()
        {
            var processor = new Mathproc.Processors.ProccessВыражение();
            var result = processor.GetMathExprs(Math2);
            System.Diagnostics.Debug.Write(result.Aggregate("", (current, expr) => current + expr.Polska() + " "));
        }

        [TestMethod]
        public void TestGetMathExprs3()
        {
            var processor = new Mathproc.Processors.ProccessВыражение();
            var result = processor.GetMathExprs(Math3);
            System.Diagnostics.Debug.Write(result.Aggregate("", (current, expr) => current + expr.Polska() + " "));
        }


        [TestMethod]
        public void TestGetPolskaFormat1()
        {
            var processor = new Mathproc.Processors.ProccessВыражение();
            Mathproc.Processors.MathExpr[] exprs = null;
            System.Diagnostics.Debug.Write(processor.GetPolskaFormat(Math1, out exprs));
        }
        

        [TestMethod]
        public void TestGetPolskaFormat2()
        {
            var processor = new Mathproc.Processors.ProccessВыражение();
            Mathproc.Processors.MathExpr[] exprs = null;
            System.Diagnostics.Debug.Write(processor.GetPolskaFormat(Math2, out exprs));
        }

        [TestMethod]
        public void TestProccess1()
        {
            var processor = new Mathproc.Processors.ProccessВыражение();
            Mathproc.Processors.MathExpr[] exprs = null;
            AbstractTreeItem item = null;
            Assert.IsTrue(processor.Proccess(Math1, null, out item));
        }

        [TestMethod]
        public void TestProccess2()
        {
            var processor = new Mathproc.Processors.ProccessВыражение();
            Mathproc.Processors.MathExpr[] exprs = null;
            AbstractTreeItem item = null;
            Assert.IsTrue(processor.Proccess(Math2, null, out item));
        }
    }
}
