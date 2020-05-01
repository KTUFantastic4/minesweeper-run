using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;
using UnityEngine.Tilemaps;

namespace Tests
{
    public class NewTestScript
    {
        private GameObject testObject;
        private MovementController movementController;

        [SetUp]
        public void Setup()
        {
            testObject = GameObject.Instantiate(new GameObject());
            movementController = testObject.AddComponent<MovementController>();
        }

        /*[UnityTest]
        public IEnumerator MovementControllerWithRigidBody2d()
        {
            yield return new WaitForSeconds(0.1f);
            Assert.NotNull(movementController.GetComponent<Rigidbody2D>());
        }*/

        [UnityTest]
        public IEnumerator PlayerDoNotMoveWithoutInput()
        {
            yield return new WaitForSeconds(0.1f);
            Vector3 position = movementController.transform.position;
            //For testing only
            //movementController.transform.position = new Vector3Int(-5, -16, 0);
            yield return new  WaitForSeconds(1f);//yield return null;//

            Vector3 newPosition = movementController.transform.position;

            Assert.AreEqual(position, newPosition);
        }

       /* [UnityTest]
        public IEnumerator PlayerMovesOnCommand()
        {
            Vector3 position = movementController.transform.position;
            movementController.transform.position = new Vector3Int(-5, -16, 0);
            yield return new WaitForSeconds(1f);

            Vector3 newPosition = movementController.transform.position;

            Assert.AreNotEqual(position, newPosition);
        }

        [UnityTest]
        public IEnumerator PlayerSpawnedInSpawnPoint()
        {
            Vector3 position = movementController.transform.position;
            Vector3 spawn = new Vector3(-8,-8.6f,0);
            yield return null;
            Assert.AreEqual(spawn, position);
        }

        /*[UnityTest]
        public IEnumerator GameOverWhenSteppedOnBomb()
        {
            //Sukurti objektus cia
            BombDetection bombDetection = new BombDetection();
            IMovementController mc = Substitute.For<IMovementController>();
            Tilemap bombs = mc.GetBombsTilemap();
            Vector3Int pos = mc.GetCurrentPosition();
            bool result = false;

            //if(bombs != null)
            result = bombDetection.HandlePlayerInteractionWithBombs(bombs, pos);

            Assert.AreEqual(true, result);
            yield return null;
        }*/

        [TearDown]
        public void TearDown()
        {
            GameObject.Destroy(testObject);
        }
    }
}
