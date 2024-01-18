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

		public void AddSubject(int teacherId, int subjectId)
		{
			throw new NotImplementedException();
		}

		public void AddTeacher(Teachers teacher)
		{
			_teacherRepository.Add(teacher);
		}

		public void DeleteSubjectById(int teacherId, int subjectId)
		{
			throw new NotImplementedException();
		}

		public void DeleteTeacherById(int teacherId, int groupId)
		{
			_teacherRepository.DeleteById(teacherId, groupId);
		}

		public List<Subjects> GetSubjectsByTeacherId(int teacherId, int groupId)
		{
			throw new NotImplementedException();
		}

		public Teachers GetTeacherById(int teacherId, int groupId)
		{
			return _teacherRepository.GetById(teacherId, groupId);
		}

		public List<Teachers> GetTeachersByGroupId(int groupId)
		{
			return _teacherRepository.Entities.Where(x => x.GroupId == groupId).ToList();
		}

		public void UpdateTeacher(Teachers teacher)
		{
			_teacherRepository.Update(teacher);
		}
	}
}