using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class SomeGreenTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void SomeGreenTestPassing()
        {
            Assert.Pass();
        }
    }
}
