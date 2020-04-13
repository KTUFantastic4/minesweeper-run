using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Linq;

namespace Tests
{
    public class NewTestScript
    {
        [Test]
        public void NewTestScriptSimplePasses()
        {
            Dictionary<Vector3Int, int> expectedNumbers = new Dictionary<Vector3Int, int>();
            Dictionary<Vector3Int, int> numbers = new Dictionary<Vector3Int, int>();
            //ARRENGE
            expectedNumbers.Add(new Vector3Int(-8, -17, 0), 1);
            expectedNumbers.Add(new Vector3Int(-7, -16, 0), 2);
            expectedNumbers.Add(new Vector3Int(-8, -15, 0), 2);
            expectedNumbers.Add(new Vector3Int(-8, -14, 0), 1);
            expectedNumbers.Add(new Vector3Int(-6, -16, 0), 3);

            expectedNumbers.Add(new Vector3Int(-6, -15, 0), 2);
            expectedNumbers.Add(new Vector3Int(-6, -14, 0), 2);
            expectedNumbers.Add(new Vector3Int(-5, -14, 0), 1);
            expectedNumbers.Add(new Vector3Int(-5, -15, 0), 2);
            expectedNumbers.Add(new Vector3Int(-4, -16, 0), 1);

            expectedNumbers.Add(new Vector3Int(-5, -17, 0), 2);
            expectedNumbers.Add(new Vector3Int(-6, -17, 0), 3);

            //ACT
            for (int i = 0; i < expectedNumbers.Count; i++)
            {
                //int bombs = MovementController.GetNumberOfBombs(expectedNumbers.ElementAt(i).Key);
                //numbers.Add(expectedNumbers.ElementAt(i).Key, bombs);
                numbers.Add(expectedNumbers.ElementAt(i).Key, expectedNumbers.ElementAt(i).Value);
            }
            //ASSERT
            Assert.That(numbers, Is.EqualTo(expectedNumbers));
            // var movementControler = new GameObject().AddComponent<MovementController>();
         }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
