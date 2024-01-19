using HomewOurK.Application.Interfaces;
using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Entities;

namespace HomewOurK.Infrastructure.Services
{
    public class TeacherService : ITeacherService
	{
		private readonly IGroupElementRepository<Teacher> _teacherRepository;

		private readonly IGroupElementRepository<Subject> _subjectsRepository;

        public TeacherService(IGroupElementRepository<Teacher> teacherRepository, 
			IGroupElementRepository<Subject> subjectRepository)
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

		public void AddTeacher(Teacher teacher)
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

		public void Delete(int teacherId, int groupId)
		{
			_teacherRepository.DeleteById(teacherId, groupId);
		}

		public List<Subject> GetSubjectsByTeacherId(int teacherId, int groupId)
		{
			return _subjectsRepository.Entities.Where(x => x.GroupId == groupId).ToList();
		}

		public Teacher GetTeacherById(int teacherId, int groupId)
		{
			return _teacherRepository.GetById(teacherId, groupId);
		}

		public List<Teacher> GetTeachersByGroupId(int groupId)
		{
			return _teacherRepository.Entities.Where(x => x.GroupId == groupId).ToList();
		}

		public void UpdateTeacher(Teacher teacher)
		{
			_teacherRepository.Update(teacher);
		}
	}
}