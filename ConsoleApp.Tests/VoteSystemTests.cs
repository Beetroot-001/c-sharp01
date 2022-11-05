using ConsoleApp1;
using Moq;

namespace ConsoleApp.Tests
{
	[TestClass]
	public class VoteSystemTests
	{
		[TestMethod]
		public void CreateVote_VoteWithSameTitle_Exception()
		{
			// arrange
			var votePromptServiceMock = new Mock<IVotePromptService>();
			var voteRepositoryMock = new Mock<IVoteRepository>();

			votePromptServiceMock.Setup(x => x.PromptVoteTitle()).Returns("123");
			voteRepositoryMock.Setup(x => x.GetVoteByTitle(It.IsAny<string>())).Returns(new Vote(""));

			var duplicatedVoteTitle = "asd";
			var initialVotes = new List<Vote>
			{
				new Vote(duplicatedVoteTitle)
			};

			// act
			var voteSystem = new VoteSystem(null, voteRepositoryMock.Object);

			Assert.ThrowsException<VoteDuplicatedException>(() => voteSystem.CreateVoteV2(duplicatedVoteTitle));
		}
	}
}