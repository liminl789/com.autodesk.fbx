// ***********************************************************************
// Copyright (c) 2017 Unity Technologies. All rights reserved.
//
// Licensed under the ##LICENSENAME##.
// See LICENSE.md file in the project root for full license information.
// ***********************************************************************
using NUnit.Framework;
using FbxSdk;

namespace UnitTests
{
    /// <summary>
    /// Run some tests that any vector type should be able to pass.
    /// If you add tests here, you probably want to add them to the other
    /// FbxDouble* test classes.
    /// </summary>
    public class FbxDouble4Test
    {

#if ENABLE_COVERAGE_TEST
        [Test]
        public void TestCoverage() { CoverageTester.TestCoverage(typeof(FbxDouble4), this.GetType()); }
#endif

        /// <summary>
        /// Test the basics. Subclasses should override and add some calls
        /// e.g. to excercise all the constructors.
        /// </summary>
        [Test]
        public void TestBasics()
        {
            // make sure the no-arg constructor doesn't crash
            new FbxDouble4();

            // make sure we can dispose
            using (new FbxDouble4()) { }
            new FbxDouble4().Dispose();

            // make sure equality works.
            Assert.IsTrue(new FbxDouble4().Equals(new FbxDouble4()));

            Assert.IsTrue(new FbxDouble4() == new FbxDouble4());
            Assert.IsFalse(new FbxDouble4() != new FbxDouble4());

            Assert.IsFalse(new FbxDouble4() == (FbxDouble4)null);
            Assert.IsTrue(new FbxDouble4() != (FbxDouble4)null);

            Assert.IsFalse((FbxDouble4)null == new FbxDouble4());
            Assert.IsTrue((FbxDouble4)null != new FbxDouble4());

            Assert.IsTrue((FbxDouble4)null == (FbxDouble4)null);
            Assert.IsFalse((FbxDouble4)null != (FbxDouble4)null);

            Assert.IsTrue(new FbxDouble4(1,2,3,4) == new FbxDouble4(1,2,3,4));
            Assert.IsFalse(new FbxDouble4(1,2,3,4) != new FbxDouble4(1,2,3,4));

            Assert.IsFalse(new FbxDouble4(1,2,3,0) == new FbxDouble4(1,2,3,4));
            Assert.IsTrue(new FbxDouble4(1,2,3,0) != new FbxDouble4(1,2,3,4));

            var v = new FbxDouble4(1,2,3,4);
            Assert.AreEqual(v, v);

            // Test operator[]
            v = new FbxDouble4();
            v[0] = 1;
            Assert.AreEqual(1, v[0]);
            v[1] = 2;
            Assert.AreEqual(2, v[1]);
            v[2] = 3;
            Assert.AreEqual(3, v[2]);
            v[3] = 4;
            Assert.AreEqual(4, v[3]);
            Assert.That(() => v[-1], Throws.Exception.TypeOf<System.IndexOutOfRangeException>());
            Assert.That(() => v[ 4], Throws.Exception.TypeOf<System.IndexOutOfRangeException>());
            Assert.That(() => v[-1] = 5, Throws.Exception.TypeOf<System.IndexOutOfRangeException>());
            Assert.That(() => v[ 4] = 5, Throws.Exception.TypeOf<System.IndexOutOfRangeException>());

            // Test 4-argument constructor and members X/Y/Z/W
            v = new FbxDouble4(1, 2, 3, 4);
            Assert.AreEqual(1, v.X);
            Assert.AreEqual(2, v.Y);
            Assert.AreEqual(3, v.Z);
            Assert.AreEqual(4, v.W);
            v.X = 3;
            v.Y = 4;
            v.Z = 5;
            v.W = 6;
            Assert.AreEqual(3, v.X);
            Assert.AreEqual(4, v.Y);
            Assert.AreEqual(5, v.Z);
            Assert.AreEqual(6, v.W);
        }
    }
}
