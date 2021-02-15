using Space3DWorld.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static Space3DWorld.Globals;  //C# V6

namespace Space3DWorld.Tests
{
    [TestClass]
    public class Space3DWorldTest
    {

        public CreateSpace3DWorld TestSpace3DWorld = new CreateSpace3DWorld();
               

        [TestMethod]
        public void Volume_Test_Cube()
        {
            Assert.IsTrue(CreateSpace3DWorld.Cube05.CalculateVolume().ToString() == "125000 px^3");
        }
        [TestMethod]
        public void Volume_Test_SphereElement()
        {
            Assert.IsTrue(TestSpace3DWorld.ElementS10One.ElementShape.CalculateVolume().Quantity == 523599m);
        }

        [TestMethod]
        public void Intersect_With_Itself_Test()
        {
            Assert.IsTrue(TestSpace3DWorld.ElementC05Zero.IntersectedVolume(TestSpace3DWorld.ElementC05Zero).ToString() == TestSpace3DWorld.ElementC05Zero.ElementShape.CalculateVolume().ToString());
        }

        [TestMethod]
        public void No_Intersect_CubeElements()
        {
            Assert.IsTrue(TestSpace3DWorld.ElementC05Zero.IntersectedVolume(TestSpace3DWorld.ElementC05FarAway).Quantity == CreateSpace3DWorld.Zero.Quantity);
        }
        [TestMethod]
        public void Intersect_CubeElements()
        {
            Assert.IsTrue(TestSpace3DWorld.ElementC05Zero.IntersectedVolume(TestSpace3DWorld.ElementC05HalfRight).Equals(CreateSpace3DWorld.Cube05.CalculateVolume()/2));
        }

    }

}

