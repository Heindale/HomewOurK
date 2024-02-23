using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Entities;
using HomewOurK.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HomewOurK.Persistence.Repositories
{
	public class TeacherRepository : GroupElementRepository<Teacher>, ITeacherRepository
	{
		private readonly ILogger _logger;
		private readonly ApplicationContext _context;

		public TeacherRepository(ApplicationContext context, ILogger<GroupElementRepository<Teacher>> logger) : base(context, logger)
		{
			_context = context;
			_logger = logger;
		}

		public bool DeleteSubjectFromTeacher(int teacherId, int groupId, int subjectId)
		{
			try
			{
				var teacher = _context.Teachers
					.Include(t => t.Subjects)
					.FirstOrDefault(t => t.Id == teacherId && t.GroupId == groupId);
				var subject = _context.Subjects
					.FirstOrDefault(s => s.Id == subjectId && s.GroupId == groupId);

				if (teacher != null && subject != null)
				{
					teacher.Subjects.Remove(subject);
					_context.SaveChanges();
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				_logger.LogInformation(ex, "The element could not be deleted!");
				return false;
			}
		}
	}
}