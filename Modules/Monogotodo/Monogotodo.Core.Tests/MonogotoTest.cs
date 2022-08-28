using System.Linq;
using Moq;
using Xunit;

namespace Monogotodo.Core.Tests
{
    public class MonogotoTest
    {
        [Fact]
        public void AssignedObserver_IntoCrumb_Broadcast_Call_Receive()
        {
            var observerMock = new Mock<IMonogoto>();
            observerMock.Setup(o => o.Receive());

            var broadcaster = new Monogoto();
            broadcaster.RegisterObserver(observerMock.Object);
            //act
            broadcaster.Broadcast();

            observerMock.Verify(o => o.Receive(), Times.Once);
        }

        [Fact]
        public void Assign_Observer()
        {
            var observerMonogoto = new Monogoto();
            var broadcaster = new Monogoto();

            //act
            Assert.Empty(broadcaster.Observers);
            broadcaster.RegisterObserver(observerMonogoto);

            Assert.Single(broadcaster.Observers);
        }

        [Fact]
        public void Unassign_Observer()
        {
            var observerMonogoto = new Monogoto();
            var broadcaster = new Monogoto();
            broadcaster.RegisterObserver(observerMonogoto);

            //act
            Assert.Single(broadcaster.Observers);
            broadcaster.UnregisterObserver(observerMonogoto);

            Assert.Empty(broadcaster.Observers);
        }

        [Fact]
        public void GetBranch_OK_WithNoRoot_OnlyFirstLineInheriting()
        {
            var MonogotoRoot = new Monogoto();
            //A
            var MonogotoA = new Monogoto();
            var MonogotoA_A = new Monogoto();
            var MonogotoA_B = new Monogoto();
            //C
            var MonogotoC = new Monogoto();

            MonogotoRoot.RegisterObserver(MonogotoA);
            MonogotoRoot.RegisterObserver(MonogotoC);

            MonogotoA.RegisterObserver(MonogotoA_A);
            MonogotoA.RegisterObserver(MonogotoA_B);

            //act
            var MonogotoABranch = MonogotoA.GetBranch().ToArray();
            var MonogotoCBranch = MonogotoC.GetBranch().ToArray();

            Assert.Equal(3, MonogotoABranch.Length);
            Assert.Contains(MonogotoA, MonogotoABranch);
            Assert.Contains(MonogotoA_A, MonogotoABranch);
            Assert.Contains(MonogotoA_B, MonogotoABranch);

            Assert.Single(MonogotoCBranch);
            Assert.Contains(MonogotoC, MonogotoCBranch);
        }

        [Fact]
        public void GetBranch_OK_WithNoRoot_AlsoSecondLineInheriting()
        {
            var MonogotoRoot = new Monogoto();
            //B
            var MonogotoB = new Monogoto();
            var MonogotoB_A = new Monogoto();
            var MonogotoB_B = new Monogoto();
            var MonogotoB_C = new Monogoto();
            var MonogotoB_C_A = new Monogoto();
            //C
            var MonogotoC = new Monogoto();

            MonogotoRoot.RegisterObserver(MonogotoB);
            MonogotoRoot.RegisterObserver(MonogotoC);

            MonogotoB.RegisterObserver(MonogotoB_A);
            MonogotoB.RegisterObserver(MonogotoB_B);

            MonogotoB_C.RegisterObserver(MonogotoB_C_A);
            MonogotoB.RegisterObserver(MonogotoB_C);

            //act
            var MonogotoBBranch = MonogotoB.GetBranch().ToArray();
            var MonogotoCBranch = MonogotoC.GetBranch().ToArray();

            Assert.Equal(5, MonogotoBBranch.Length);
            Assert.Contains(MonogotoB, MonogotoBBranch);
            Assert.Contains(MonogotoB_A, MonogotoBBranch);
            Assert.Contains(MonogotoB_B, MonogotoBBranch);
            Assert.Contains(MonogotoB_C, MonogotoBBranch);
            Assert.Contains(MonogotoB_C_A, MonogotoBBranch);

            Assert.Single(MonogotoCBranch);
            Assert.Contains(MonogotoC, MonogotoCBranch);
        }

        [Fact]
        public void GetWholeChain_ReturnAllMonogotos_RelatedTo_Selected_One()
        {
            var MonogotoRoot = new Monogoto();
            //B
            var MonogotoB = new Monogoto();
            var MonogotoB_A = new Monogoto();
            var MonogotoB_B = new Monogoto();
            var MonogotoB_C = new Monogoto();
            var MonogotoB_C_A = new Monogoto();
            //C
            var MonogotoC = new Monogoto();

            MonogotoRoot.RegisterObserver(MonogotoB);
            MonogotoRoot.RegisterObserver(MonogotoC);

            MonogotoB.RegisterObserver(MonogotoB_A);
            MonogotoB.RegisterObserver(MonogotoB_B);

            MonogotoB_C.RegisterObserver(MonogotoB_C_A);
            MonogotoB.RegisterObserver(MonogotoB_C);

            //act
            var MonogotoChain = MonogotoB.GetWholeChain().ToArray();

            Assert.Equal(6, MonogotoChain.Length);
            Assert.Contains(MonogotoRoot, MonogotoChain);
            Assert.Contains(MonogotoB, MonogotoChain);
            Assert.Contains(MonogotoB_A, MonogotoChain);
            Assert.Contains(MonogotoB_B, MonogotoChain);
            Assert.Contains(MonogotoB_C, MonogotoChain);
            Assert.Contains(MonogotoB_C_A, MonogotoChain);
        }

        [Fact]
        public void GetWholeChain_ReturnMonogotosRelatedTo_Selected_WithNoSideOnes()
        {
            var MonogotoRoot = new Monogoto() {Name = "root"};
            //B
            var MonogotoB = new Monogoto() {Name = "B"};
            var MonogotoB_A = new Monogoto() {Name = "B_A"};
            var MonogotoB_B = new Monogoto();
            var MonogotoB_C = new Monogoto();
            var MonogotoB_C_A = new Monogoto();
            //C
            var MonogotoC = new Monogoto();

            MonogotoRoot.RegisterObserver(MonogotoB);
            MonogotoRoot.RegisterObserver(MonogotoC);

            MonogotoB.RegisterObserver(MonogotoB_A);
            MonogotoB.RegisterObserver(MonogotoB_B);

            MonogotoB_C.RegisterObserver(MonogotoB_C_A);
            MonogotoB.RegisterObserver(MonogotoB_C);

            //act
            var MonogotoChain = MonogotoB_A.GetWholeChain().ToArray();

            Assert.Equal(3, MonogotoChain.Length);
            Assert.Contains(MonogotoRoot, MonogotoChain);
            Assert.Contains(MonogotoB, MonogotoChain);
            Assert.Contains(MonogotoB_A, MonogotoChain);
        }
    }
}