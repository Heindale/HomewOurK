//using HomewOurK.Domain.Common;
//using HomewOurK.Domain.Entities;
//using HomewOurK.Persistence.Contexts;
//using HomewOurK.Persistence.Repositories;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using Moq;
//using System.ComponentModel.DataAnnotations;

//namespace HomewOurK.Tests.Repositories
//{
//	[TestFixture]
//	public class BaseEntityRepositoryTests
//	{
//		 �������� ������ ��� ������� ��������
//		public class TestEntity : BaseEntity
//		{
//			 �������� ��������, ����������� ��� ����� ��������
//		}

//		public class TestGroup : TestEntity
//		{
//			[Required]
//			[StringLength(25)]
//			public string Name { get; set; } = "";

//			[System.ComponentModel.DataAnnotations.Range(0, 99)]
//			public int? Grade { get; set; }

//			[StringLength(25)]
//			public string? GroupType { get; set; }

//			public List<User> Users { get; set; } = new List<User>();
//			public List<GroupsUsers> GroupsUsers { get; set; } = new List<GroupsUsers>();
//		}

//		private BaseEntityRepository<TestEntity> _repository;
//		private Mock<ApplicationContext> _contextMock;
//		private Mock<ILogger> _loggerMock;

//		[SetUp]
//		public void Setup()
//		{
//			 ������� Mock ��� ApplicationContext � ILogger
//			_contextMock = new Mock<ApplicationContext>();
//			_contextMock.Setup(x => x.Set<TestEntity>()).Returns(Mock.Of<DbSet<TestEntity>>());

//			_loggerMock = new Mock<ILogger>();

//			 ������� ����������� � �������������� Mock-��������
//			_repository = new BaseEntityRepository<TestEntity>(_contextMock.Object, (ILogger<BaseEntityRepository<TestEntity>>)_loggerMock.Object);
//		}

//		[Test]
//		public void Add_EntityAdded_ReturnsTrue()
//		{
//			 Arrange
//			var entity = new TestEntity();

//			 Act
//			var result = _repository.Add(entity);

//			 Assert
//			Assert.IsTrue(result); // ���������, ��� ����� ���������� true
//			_contextMock.Verify(x => x.SaveChanges(), Times.Once); // ���������, ��� SaveChanges ��� ������ ���� ���
//		}

//		[Test]
//		public void Add_EntityNotAdded_ReturnsFalse()
//		{
//			 Arrange
//			_contextMock.Setup(x => x.SaveChanges()).Throws(new Exception()); // ��������� ���������� �� ����� SaveChanges

//			var entity = new TestEntity();

//			 Act
//			var result = _repository.Add(entity);

//			 Assert
//			Assert.IsFalse(result); // ���������, ��� ����� ���������� false
//			_loggerMock.Verify(x => x.Log(
//				LogLevel.Information, // ���������, ��� ��������� ���� ������������� � ������� Information
//				It.IsAny<EventId>(), // ������������� �������
//				It.IsAny<object>(), // ������-�������� (� ������ ������, ����������)
//				It.IsAny<Exception>(), // ����������
//				(Func<object, Exception, string>)It.IsAny<object>())); // ������� �������������� ���������
//		}

//		 �������� ����� ��� Delete, Update, GetAll, GetById, � �.�.

//		[Test]
//		public void GetById_EntityExists_ReturnsEntity()
//		{
//			 Arrange
//			var entityId = 1;
//			var entity = new TestEntity { Id = entityId };
//			_contextMock.Setup(x => x.Set<TestEntity>().Find(entityId)).Returns(entity);

//			 Act
//			var result = _repository.GetById(entityId);

//			 Assert
//			Assert.AreEqual(entity, result); // ���������, ��� ������������ �������� ������������� ���������
//		}

//		[Test]
//		public void GetById_EntityDoesNotExist_ReturnsNull()
//		{
//			 Arrange
//			var entityId = 1;
//			_contextMock.Setup(x => x.Set<TestEntity>().Find(entityId)).Returns((TestEntity)null);

//			 Act
//			var result = _repository.GetById(entityId);

//			 Assert
//			Assert.IsNull(result); // ���������, ��� ����� ���������� null ��� �������������� ��������
//		}

//		[Test]
//		public void Delete_GroupDeleted_ReturnsTrue()
//		{
//			var group = new TestGroup
//			{
//				Id = 1,
//				Name = "test",
//				Grade = 2,
//				GroupType = "Class"
//			};

//			_contextMock.Setup(x => x.Set<TestGroup>().Add(group));

//			var result = _repository.Delete(group);

//			Assert.IsTrue(result);
//			_contextMock.Verify(x => x.SaveChanges(), Times.Once);
//		}
//	}
//}