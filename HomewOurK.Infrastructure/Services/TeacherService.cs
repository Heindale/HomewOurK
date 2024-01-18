using HomewOurK.Application.Interfaces;
using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Entities;

namespace HomewOurK.Infrastructure.Services
{
    public class TeacherService : ITeacherService
	{
		private readonly IGroupElementRepository<Teachers> _teacherRepository;

		private readonly IGroupElementRepository<Subjects> _subjectsRepository;

        public TeacherService(IGroupElementRepository<Teachers> teacherRepository, 
			IGroupElementRepository<Subjects> subjectRepository)
        {
            _teacherRepository = teacherRepository;
			_subjectsRepository = subjectRepository;
        }

		public void AddSubject(int teacherId, int groupId, int subjectId)
		{
			var teacher = _teacherRepository.GetById(teacherId, groupId);
			if (teacher == null)
				return;
			teacher.Subjects.Add(_subjectsRepository.GetById(subjectId, groupId));
			_teacherRepository.Update(teacher);
		}

		public void AddTeacher(Teachers teacher)
		{
			_teacherRepository.Add(teacher);
		}

		public void DeleteSubjectById(int teacherId, int groupId, int subjectId)
		{
			var teacher = _teacherRepository.GetById(teacherId, groupId);
			if (teacher == null)
				return;
			teacher.Subjects.Remove(_subjectsRepository.GetById(subjectId, groupId));
			_teacherRepository.Update(teacher);
		}

		public void DeleteTeacherById(int teacherId, int groupId)
		{
			_teacherRepository.DeleteById(teacherId, groupId);
		}

		public List<Subjects> GetSubjectsByTeacherId(int teacherId, int groupId)
		{
			return _subjectsRepository.Entities.Where(x => x.GroupId == groupId).ToList();
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