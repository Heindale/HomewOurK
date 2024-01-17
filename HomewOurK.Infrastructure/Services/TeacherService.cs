using HomewOurK.Application.Interfaces;
using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Entities;

namespace HomewOurK.Infrastructure.Services
{
    public class TeacherService : ITeacherService
	{
		private readonly IGroupElementRepository<Teachers> _teacherRepository;

        public TeacherService(IGroupElementRepository<Teachers> teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public void AddSubject(Teachers teacher, Subjects subject)
		{
			var dbTeacher = _teacherRepository.GetById(teacher.Id, teacher.GroupId);
			if (dbTeacher == null)
			{
				throw new Exception("The Entity was not found");
			}
			try
			{
				dbTeacher.Subjects.Add(subject);
				_teacherRepository.Update(dbTeacher);
			}
			catch ()
			{
                Console.WriteLine();
            }
		}

		public void AddTeacher(Teachers teacher)
		{
			_teacherRepository.Add(teacher);
		}

		public void DeleteTeacher(Teachers teacher)
		{
			_teacherRepository.Delete(teacher);
		}

		public List<Teachers> GetTeachersByGroupId(int groupId)
		{
			return _teacherRepository.Entities.Where(x => x.GroupId == groupId).ToList();
		}

		public Teachers GetTeacherById(int teacherId, int groupId)
		{
			return _teacherRepository.GetById(teacherId, groupId);
		}

		public void UpdateTeacher(Teachers teacher)
		{
			_teacherRepository.Update(teacher);
		}
	}
}