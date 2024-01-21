using HomewOurK.Domain.Common;
using HomewOurK.Persistence.Contexts;
using HomewOurK.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace HomewOurK.Tests.Repositories
{
	[TestFixture]
	public class BaseEntityRepositoryTests
	{
		// Тестовый объект для базовой сущности
		public class TestEntity : BaseEntity
		{
			// Добавьте свойства, специфичные для вашей сущности
		}

		private BaseEntityRepository<TestEntity> _repository;
		private Mock<ApplicationContext> _contextMock;
		private Mock<ILogger<BaseEntityRepository<TestEntity>>> _loggerMock;

		[SetUp]
		public void Setup()
		{
			// Создаем Mock для ApplicationContext и ILogger
			_contextMock = new Mock<ApplicationContext>();
			_contextMock.Setup(x => x.Set<TestEntity>()).Returns(Mock.Of<DbSet<TestEntity>>());

			_loggerMock = new Mock<ILogger<BaseEntityRepository<TestEntity>>>();

			// Создаем репозиторий с использованием Mock-объектов
			_repository = new BaseEntityRepository<TestEntity>(_contextMock.Object, _loggerMock.Object);
		}

		[Test]
		public void Add_EntityAdded_ReturnsTrue()
		{
			// Arrange
			var entity = new TestEntity();

			// Act
			var result = _repository.Add(entity);

			// Assert
			Assert.IsTrue(result); // Проверяем, что метод возвращает true
			_contextMock.Verify(x => x.SaveChanges(), Times.Once); // Проверяем, что SaveChanges был вызван один раз
		}

		[Test]
		public void Add_EntityNotAdded_ReturnsFalse()
		{
			// Arrange
			_contextMock.Setup(x => x.SaveChanges()).Throws(new Exception()); // Имитируем исключение во время SaveChanges

			var entity = new TestEntity();

			// Act
			var result = _repository.Add(entity);

			// Assert
			Assert.IsFalse(result); // Проверяем, что метод возвращает false
			_loggerMock.Verify(x => x.Log(
				LogLevel.Information, // Проверяем, что сообщение было залоггировано с уровнем Information
				It.IsAny<EventId>(), // Идентификатор события
				It.IsAny<object>(), // Объект-параметр (в данном случае, исключение)
				It.IsAny<Exception>(), // Исключение
				(Func<object, Exception, string>)It.IsAny<object>())); // Функция форматирования сообщения
		}

		// Подобные тесты для Delete, Update, GetAll, GetById, и т.д.

		[Test]
		public void GetById_EntityExists_ReturnsEntity()
		{
			// Arrange
			var entityId = 1;
			var entity = new TestEntity { Id = entityId };
			_contextMock.Setup(x => x.Set<TestEntity>().Find(entityId)).Returns(entity);

			// Act
			var result = _repository.GetById(entityId);

			// Assert
			Assert.AreEqual(entity, result); // Проверяем, что возвращенная сущность соответствует ожидаемой
		}

		[Test]
		public void GetById_EntityDoesNotExist_ReturnsNull()
		{
			// Arrange
			var entityId = 1;
			_contextMock.Setup(x => x.Set<TestEntity>().Find(entityId)).Returns((TestEntity)null);

			// Act
			var result = _repository.GetById(entityId);

			// Assert
			Assert.IsNull(result); // Проверяем, что метод возвращает null для несуществующей сущности
		}
	}
}
