using Microsoft.VisualStudio.TestTools.UnitTesting;
using WinForm.Misc;
using System.Drawing;

namespace UnitTestProject1
{
    [TestClass]
    public class MiscFunctionsTest
    {
        private TestContext _contextInstance;
        public TestContext TestContext { get => _contextInstance; set => _contextInstance = value; }
        private const string TestDataDir = "MiscTestData\\";

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\" + TestDataDir + "DifPointsData.csv",
            "DifPointsData#csv",
            DataAccessMethod.Sequential),
            DeploymentItem(TestDataDir + "DifPointsData.csv")]
        [TestMethod]
        public void TestPointsAreDifferent()
        {
            var x1 = int.Parse(TestContext.DataRow["x1"].ToString());
            var y1 = int.Parse(TestContext.DataRow["y1"].ToString());
            var x2 = int.Parse(TestContext.DataRow["x2"].ToString());
            var y2 = int.Parse(TestContext.DataRow["y2"].ToString());
            var expected = bool.Parse(TestContext.DataRow["expected"].ToString());
            Assert.AreEqual(MiscFunctions.PointsAreDifferent(new Point(x1, y1), new Point(x2, y2)), expected);
        }

        [DataSource(
    "Microsoft.VisualStudio.TestTools.DataSource.CSV",
    "|DataDirectory|\\" + TestDataDir + "SwapPointsData.csv",
    "SwapPointsData#csv",
    DataAccessMethod.Sequential),
    DeploymentItem(TestDataDir + "SwapPointsData.csv")]

        [TestMethod]
        public void TestSwapPoints()
        {
            var x1 = int.Parse(TestContext.DataRow["x1"].ToString());
            var y1 = int.Parse(TestContext.DataRow["y1"].ToString());
            var x2 = int.Parse(TestContext.DataRow["x2"].ToString());
            var y2 = int.Parse(TestContext.DataRow["y2"].ToString());
            var point1 = new Point(x1, y1);
            var point2 = new Point(x2, y2);
            Assert.AreEqual(point1.X, x1);
            Assert.AreEqual(point1.Y, y1);
            Assert.AreEqual(point2.X, x2);
            Assert.AreEqual(point2.Y, y2);
            MiscFunctions.SwapPoints(ref point1, ref point2);
            Assert.AreEqual(point2.X, x1);
            Assert.AreEqual(point2.Y, y1);
            Assert.AreEqual(point1.X, x2);
            Assert.AreEqual(point1.Y, y2);
        }

        [DataSource(
    "Microsoft.VisualStudio.TestTools.DataSource.CSV",
    "|DataDirectory|\\" + TestDataDir + "PointIsBtwData.csv",
    "PointIsBtwData#csv",
    DataAccessMethod.Sequential),
    DeploymentItem(TestDataDir + "PointIsBtwData.csv")]

        [TestMethod]
        public void TestPointIsBetween()
        {
            var x1 = int.Parse(TestContext.DataRow["x1"].ToString());
            var y1 = int.Parse(TestContext.DataRow["y1"].ToString());
            var x2 = int.Parse(TestContext.DataRow["x2"].ToString());
            var y2 = int.Parse(TestContext.DataRow["y2"].ToString());
            var ax = int.Parse(TestContext.DataRow["ax"].ToString());
            var ay = int.Parse(TestContext.DataRow["ay"].ToString());
            var expected = bool.Parse(TestContext.DataRow["expected"].ToString());

            var point1 = new Point(x1, y1);
            var point2 = new Point(x2, y2);
            var pointa = new Point(ax, ay);
            Assert.AreEqual(MiscFunctions.PointIsBetween(pointa, new WinForm.Shape.Line("name", point1, point2, Color.Black)), expected);
        }
    }
}
