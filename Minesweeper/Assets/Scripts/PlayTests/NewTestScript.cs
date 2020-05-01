using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

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
 
        [UnityTest]
        public IEnumerator MovementControllerWithRigidBody2d()
        {
            yield return new WaitForSeconds(0.1f);
            Assert.NotNull(movementController.GetComponent<Rigidbody2D>());
        }

        [UnityTest]
        public IEnumerator PlayerSpawnedInSpawnPoint()
        {
            SceneManager.LoadScene(1);
            yield return new WaitForSeconds(0.1f);
            var player = GameObject.Find("Player");
            Vector3 position = player.GetComponent<MovementController>().transform.position;
            Vector3 spawn = new Vector3(-8, -8.6f, 0);
            Assert.AreEqual(spawn, position);
        }

         [UnityTest]
         public IEnumerator PlayerDoNotMoveWithoutInput()
         {
            SceneManager.LoadScene(1);
            yield return new WaitForSeconds(0.1f);
            var player = GameObject.Find("Player");
            Vector3 position = player.GetComponent<MovementController>().transform.position;

            yield return new WaitForSeconds(0.1f);

            Vector3 newPosition = player.GetComponent<MovementController>().transform.position;

            Assert.AreEqual(position, newPosition);
        }

        [UnityTest]
        public IEnumerator PlayerMovesOnCommand()
        {
            SceneManager.LoadScene(1);
            yield return new WaitForSeconds(0.1f);
            var player = GameObject.Find("Player");
            Vector3 position = player.GetComponent<MovementController>().transform.position;
            player.GetComponent<MovementController>().transform.position = new Vector3Int(-5, -16, 0);           
            yield return new WaitForSeconds(1f);
            Vector3 newPosition = player.GetComponent<MovementController>().transform.position;

            Assert.AreNotEqual(position, newPosition);
        }

        [UnityTest]
        public IEnumerator PlayerMovesOnCommandToExactPosition()
        {
            SceneManager.LoadScene(1);
            yield return new WaitForSeconds(0.1f);
            var player = GameObject.Find("Player");
            Vector3 position = player.GetComponent<MovementController>().transform.position;
            Vector3 spawn = new Vector3(-5, -16, 0);
            player.GetComponent<MovementController>().transform.position = spawn;
            yield return new WaitForSeconds(1f);
            Vector3 newPosition = player.GetComponent<MovementController>().transform.position;

            Assert.AreEqual(spawn, newPosition);
        }
        //SITA GALI LIESTI
        [UnityTest]
        public IEnumerator GameOverWhenSteppedOnBomb()
        {
            SceneManager.LoadScene(1);
            yield return new WaitForSeconds(0.1f);
            var player = GameObject.Find("Player");
            Vector3 bombPos = new Vector3(-6.5f, -8.1f, 0);

            player.GetComponent<MovementController>().transform.position = bombPos;
            yield return new WaitForSeconds(1f);
            bool isDead = player.GetComponent<MovementController>().isDead;

            Assert.AreEqual(true, isDead);
        }
        //NELIESTI!!!
        /*[UnityTest]
         public IEnumerator GameOverWhenSteppedOnBomb()
         {
             SceneManager.LoadScene(1);
             yield return new WaitForSeconds(0.1f);
             var player = GameObject.Find("Player");
             Vector3 bombPos = new Vector3(-6.5f, -8.1f, 0);

             player.GetComponent<MovementController>().transform.position = bombPos;
             yield return new WaitForSeconds(1f);
             bool isDead = player.GetComponent<MovementController>().isDead;

             Assert.AreEqual(true, isDead);
         }*/

        /*[UnityTest]
        public IEnumerator GameWinWhenSteppedOnTower()
        {
            SceneManager.LoadScene(1);
            yield return new WaitForSeconds(0.1f);
            var player = GameObject.Find("Player");
            Vector3 bombPos = new Vector3(14, 3.1f, 0);

            player.GetComponent<MovementController>().transform.position = bombPos;
            yield return new WaitForSeconds(1f);
            bool hasWon = player.GetComponent<MovementController>().isWon;

            Assert.AreEqual(true, hasWon);
        }*/
        //(-7,-8.6,0) item
        //(-6.5,-8.1,0) bomb
        //(14,3.1,0) win
        [TearDown]
        public void TearDown()
        {
            GameObject.Destroy(testObject);
        }
    }
}
