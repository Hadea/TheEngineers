using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeLogic;

namespace TicTacToeTests
{
    [TestClass]
    public class LogicTests
    {
        [TestMethod]
        public void Creation()
        {
            Logic l = new();
            Assert.IsNotNull(l.GameBoard);
            Assert.IsTrue(checkIfEmpty(l.GameBoard));
        }

        [TestMethod]
        public void PlayerChangeAfterValidTurn()
        {
            Logic l = new();
            bool player = l.GetCurrentPlayer();
            Assert.AreEqual(TurnResult.Valid, l.Turn(0, 0));
            Assert.AreNotEqual(player, l.GetCurrentPlayer());
        }

        [TestMethod]
        public void NoPlayerChangeAfterInValidTurn()
        {
            Logic l = new();
            bool player = l.GetCurrentPlayer();
            Assert.AreEqual(TurnResult.Invalid, l.Turn(0, 3)); // ausserhalb des spielfeldes
            Assert.AreEqual(TurnResult.Invalid, l.Turn(-1, 2)); // ausserhalb des spielfeldes
            Assert.AreEqual(TurnResult.Invalid, l.Turn(3, 3)); // ausserhalb des spielfeldes
            Assert.AreEqual(player, l.GetCurrentPlayer());
        }

        [TestMethod]
        public void ValidTurnOnField()
        {
            Logic l = new();
            Assert.AreEqual(TurnResult.Valid, l.Turn(0, 0));
        }

        [TestMethod]
        public void MoveOnTakenFieldInvalid()
        {
            Logic l = new();
            // zug auf die linke obere ecke
            Assert.AreEqual(TurnResult.Valid, l.Turn(0, 0));

            // zug auf die linke obere ecke, die aber schon belegt ist, daher ungültig
            Assert.AreEqual(TurnResult.Invalid, l.Turn(0, 0));
        }

        [TestMethod]
        public void ResetEmptiesBoard()
        {
            Logic l = new();
            Assert.AreEqual(TurnResult.Valid, l.Turn(0, 0));
            Assert.AreNotEqual(Field.Empty, l.GameBoard[0, 0]);
            l.ResetGame();
            Assert.IsTrue(checkIfEmpty(l.GameBoard));
        }



        /// <summary>
        /// Tests winning the game in the top column
        /// XXX
        /// 00_
        /// ___
        /// </summary>
        [TestMethod]
        public void WinColumnTop()
        {
            Logic l = new();
            Assert.AreEqual(TurnResult.Valid, l.Turn(0, 0));
            Assert.AreEqual(TurnResult.Valid, l.Turn(0, 1));
            Assert.AreEqual(TurnResult.Valid, l.Turn(1, 0));
            Assert.AreEqual(TurnResult.Valid, l.Turn(1, 1));
            Assert.AreEqual(TurnResult.Win, l.Turn(2, 0));
        }

        /// <summary>
        /// Tests winning the game in the middle column
        /// 00_
        /// XXX
        /// ___
        /// </summary>
        [TestMethod]
        public void WinColumnMiddle()
        {
            Logic l = new();
            Assert.AreEqual(TurnResult.Valid, l.Turn(0, 1));
            Assert.AreEqual(TurnResult.Valid, l.Turn(0, 0));
            Assert.AreEqual(TurnResult.Valid, l.Turn(1, 1));
            Assert.AreEqual(TurnResult.Valid, l.Turn(1, 0));
            Assert.AreEqual(TurnResult.Win, l.Turn(2, 1));
        }

        /// <summary>
        /// Tests winning the game in the bottom column
        /// 00_
        /// ___
        /// XXX
        /// </summary>
        [TestMethod]
        public void WinColumnBottom()
        {
            Logic l = new();
            Assert.AreEqual(TurnResult.Valid, l.Turn(0, 2));
            Assert.AreEqual(TurnResult.Valid, l.Turn(0, 0));
            Assert.AreEqual(TurnResult.Valid, l.Turn(1, 2));
            Assert.AreEqual(TurnResult.Valid, l.Turn(1, 0));
            Assert.AreEqual(TurnResult.Win, l.Turn(2, 2));
        }

        /// <summary>
        /// Tests winning the game in the left row
        /// X00
        /// X__
        /// X__
        /// </summary>
        [TestMethod]
        public void WinRowLeft()
        {
            Logic l = new();
            Assert.AreEqual(TurnResult.Valid, l.Turn(0, 0));
            Assert.AreEqual(TurnResult.Valid, l.Turn(1, 0));
            Assert.AreEqual(TurnResult.Valid, l.Turn(0, 1));
            Assert.AreEqual(TurnResult.Valid, l.Turn(2, 0));
            Assert.AreEqual(TurnResult.Win, l.Turn(0, 2));
        }

        /// <summary>
        /// Tests winning the game in the left row
        /// 0X0
        /// _X_
        /// _X_
        /// </summary>
        [TestMethod]
        public void WinRowMiddle()
        {
            Logic l = new();
            Assert.AreEqual(TurnResult.Valid, l.Turn(1, 0));
            Assert.AreEqual(TurnResult.Valid, l.Turn(0, 0));
            Assert.AreEqual(TurnResult.Valid, l.Turn(1, 1));
            Assert.AreEqual(TurnResult.Valid, l.Turn(2, 0));
            Assert.AreEqual(TurnResult.Win, l.Turn(1, 2));
        }

        /// <summary>
        /// Tests winning the game in the left row
        /// 00X
        /// __X
        /// __X
        /// </summary>
        [TestMethod]
        public void WinRowRight()
        {
            Logic l = new();
            Assert.AreEqual(TurnResult.Valid, l.Turn(2, 0));
            Assert.AreEqual(TurnResult.Valid, l.Turn(0, 0));
            Assert.AreEqual(TurnResult.Valid, l.Turn(2, 1));
            Assert.AreEqual(TurnResult.Valid, l.Turn(1, 0));
            Assert.AreEqual(TurnResult.Win, l.Turn(2, 2));
        }

        /// <summary>
        /// Tests winning the game in the left row
        /// X00
        /// _X_
        /// __X
        /// </summary>
        [TestMethod]
        public void WinDiagonalA()
        {
            Logic l = new();
            Assert.AreEqual(TurnResult.Valid, l.Turn(0, 0));
            Assert.AreEqual(TurnResult.Valid, l.Turn(1, 0));
            Assert.AreEqual(TurnResult.Valid, l.Turn(1, 1));
            Assert.AreEqual(TurnResult.Valid, l.Turn(2, 0));
            Assert.AreEqual(TurnResult.Win, l.Turn(2, 2));
        }

        /// <summary>
        /// Tests winning the game in the left row
        /// 00X
        /// _X_
        /// X__
        /// </summary>
        [TestMethod]
        public void WinDiagonalB()
        {
            Logic l = new();
            Assert.AreEqual(TurnResult.Valid, l.Turn(2, 0));
            Assert.AreEqual(TurnResult.Valid, l.Turn(0, 0));
            Assert.AreEqual(TurnResult.Valid, l.Turn(1, 1));
            Assert.AreEqual(TurnResult.Valid, l.Turn(1, 0));
            Assert.AreEqual(TurnResult.Win, l.Turn(0, 2));
        }

        /// <summary>
        /// Tests a draw
        /// XX0
        /// 0XX
        /// X00
        /// </summary>
        [TestMethod]
        public void Draw()
        {
            Logic l = new();
            Assert.AreEqual(TurnResult.Valid, l.Turn(0, 0)); //X
            Assert.AreEqual(TurnResult.Valid, l.Turn(2, 0)); //O
            Assert.AreEqual(TurnResult.Valid, l.Turn(1, 0)); //X

            Assert.AreEqual(TurnResult.Valid, l.Turn(0, 1)); //O
            Assert.AreEqual(TurnResult.Valid, l.Turn(1, 1)); //X
            Assert.AreEqual(TurnResult.Valid, l.Turn(1, 2)); //O

            Assert.AreEqual(TurnResult.Valid, l.Turn(2, 1)); //X
            Assert.AreEqual(TurnResult.Valid, l.Turn(2, 2)); //O
            Assert.AreEqual(TurnResult.Draw, l.Turn(0, 2)); //X
        }

        [TestMethod]
        public void NoTurnsAfterEnd()
        {
            Logic l = new();
            Assert.AreEqual(TurnResult.Valid, l.Turn(2, 0));
            Assert.AreEqual(TurnResult.Valid, l.Turn(0, 0));
            Assert.AreEqual(TurnResult.Valid, l.Turn(1, 1));
            Assert.AreEqual(TurnResult.Valid, l.Turn(1, 0));
            Assert.AreEqual(TurnResult.Win, l.Turn(0, 2));
            Assert.AreEqual(TurnResult.Invalid, l.Turn(2, 2)); // turn after win is always invalid
        }

        private static bool checkIfEmpty(Field[,] GameBoard)
        {
            for (int Y = 0; Y < 3; Y++)
            {
                for (int X = 0; X < 3; X++)
                {
                    if (GameBoard[Y,X] != Field.Empty)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
