using System.Linq;
using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Common;
using HomewOurK.Domain.Entities;
using HomewOurK.Persistence.Contexts;
using HomewOurK.Persistence.Repositories;
using NUnit.Framework;

[TestFixture]
public class BaseEntityRepositoryTests
{
	private ApplicationContext _context;
	private IBaseEntityRepository<Groups> _repository;

	[SetUp]
	public void Setup()
	{
		_context = new ApplicationContext(); // Вам нужно убедиться, что используется тестовый контекст БД
		_repository = new BaseEntityRepository<Groups>(_context);
	}

	[Test]
	public void Add_EntitySuccessfullyAdded()
	{
		// Arrange
		var entity = new Groups { Id = 1, Name = "Test" };

		// Act
		_repository.Add(entity);

		// Assert
		Assert.AreEqual(1, _context.Set<Groups>().Count());
	}

	[Test]
	public void Delete_EntitySuccessfullyDeleted()
	{
		// Arrange
		var entity = new Groups { Id = 2, Name = "Test2" };
		_repository.Add(entity);

		// Act
		_repository.Delete(entity.Id);

		// Assert
		Assert.AreEqual(0, _context.Set<Groups>().Count());
	}

	[Test]
	public void Update_EntitySuccessfullyUpdated()
	{
		// Arrange
		var entity = new Groups { Id = 3, Name = "Test3" };
		_repository.Add(entity);

		// Act
		entity.Name = "UpdatedTest";
		_repository.Update(entity);

		// Assert
		var updatedEntity = _context.Set<Groups>().FirstOrDefault(e => e.Id == entity.Id);
		Assert.IsNotNull(updatedEntity);
		Assert.AreEqual("UpdatedTest", updatedEntity.Name);
	}

	[Test]
	public void GetAll_ReturnsAllEntities()
	{
		// Arrange
		_repository.Add(new Groups { Id = 4, Name = "Test4" });
		_repository.Add(new Groups { Id = 5, Name = "Test5" });

		// Act
		var entities = _repository.GetAll();

		// Assert
		Assert.AreEqual(2, entities.Count());
	}

	[Test]
	public void GetById_ReturnsEntityWithMatchingId()
	{
		// Arrange
		_repository.Add(new Groups { Id = 6, Name = "Test6" });

		// Act
		var entity = _repository.GetById(6);

		// Assert
		Assert.IsNotNull(entity);
		Assert.AreEqual("Test6", entity.Name);
	}

	[Test]
	public void GetById_ReturnsNullForNonexistentId()
	{
		// Arrange
		_repository.Add(new Groups { Id = 7, Name = "Test7" });

		// Act
		var nonExistentEntity = _repository.GetById(8);

		// Assert
		Assert.IsNull(nonExistentEntity);
	}
}
