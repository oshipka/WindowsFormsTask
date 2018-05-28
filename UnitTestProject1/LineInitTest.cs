using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using WinForm.Shape;

namespace UnitTestProject1
{
    [TestClass]
    public class LineTest
    {
        private TestContext _contextInstance;

        public TestContext TestContext { get => _contextInstance; set => _contextInstance = value; }

        private const string DataDir = "LineInitData\\";

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "|DataDirectory|\\" + DataDir + "LineData.csv",
            "LineData#csv",
            DataAccessMethod.Sequential),
            DeploymentItem(DataDir + "LineData.csv")]
        [TestMethod]
        public void TestConstructor()
        {
            var x1 = int.Parse(TestContext.DataRow["x1"].ToString());
            var y1 = int.Parse(TestContext.DataRow["y1"].ToString());
            var x2 = int.Parse(TestContext.DataRow["x2"].ToString());
            var y2 = int.Parse(TestContext.DataRow["y2"].ToString());
            var name = TestContext.DataRow["name"].ToString();
            var r = int.Parse(TestContext.DataRow["r"].ToString());
            var g = int.Parse(TestContext.DataRow["g"].ToString());
            var b = int.Parse(TestContext.DataRow["b"].ToString());
            var expSX = int.Parse(TestContext.DataRow["exp_sx"].ToString());
            var expSY = int.Parse(TestContext.DataRow["exp_sy"].ToString());
            var expEX = int.Parse(TestContext.DataRow["exp_ex"].ToString());
            var expEY = int.Parse(TestContext.DataRow["exp_ey"].ToString());
            var expName = TestContext.DataRow["exp_name"].ToString();
            var expR = int.Parse(TestContext.DataRow["exp_r"].ToString());
            var expG = int.Parse(TestContext.DataRow["exp_g"].ToString());
            var expB = int.Parse(TestContext.DataRow["exp_b"].ToString());
            var line = new Line(name, new Point(x1, y1), new Point(x2, y2), Color.FromArgb(r, g, b));
            Assert.AreEqual(line.Name, expName);
            Assert.AreEqual(line.StartX, expSX);
            Assert.AreEqual(line.StartY, expSY);
            Assert.AreEqual(line.EndX, expEX);
            Assert.AreEqual(line.EndY, expEY);
            Assert.AreEqual(line.R, expR);
            Assert.AreEqual(line.G, expG);
            Assert.AreEqual(line.B, expB);
        }
    }
}
