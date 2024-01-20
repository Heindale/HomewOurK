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

		public bool AddSubject(int teacherId, int groupId, int subjectId)
		{
			var teacher = _teacherRepository.GetById(teacherId, groupId);
			var subject = _subjectsRepository.GetById(subjectId, groupId);

			if (teacher != null && subject != null)
			{
				teacher.Subjects.Add(subject);
				return _teacherRepository.Update(teacher);
			}
			return false;
		}

		public bool AddSubject(Teacher teacher, Subject subject)
		{
			if (teacher != null && subject != null)
			{
				teacher.Subjects.Add(subject);
				return _teacherRepository.Update(teacher);
			}	
			return false;
		}

		public bool AddTeacher(Teacher teacher)
		{
			return _teacherRepository.Add(teacher);
		}

		public bool DeleteSubject(int teacherId, int groupId, int subjectId)
		{
			var teacher = _teacherRepository.GetById(teacherId, groupId);
			var subject = _subjectsRepository.GetById(subjectId, groupId);

			if (teacher != null && subject != null)
			{
				teacher.Subjects.Remove(subject);
				return _teacherRepository.Update(teacher);
			}
			return false;
		}

		public bool DeleteSubject(Teacher teacher, Subject subject)
		{
			if (teacher != null && subject != null)
			{
				teacher.Subjects.Remove(subject);
				return _teacherRepository.Update(teacher);
			}
			return false;
		}

		public bool DeleteTeacher(Teacher teacher)
		{
			return _teacherRepository.Delete(teacher);
		}

		public IEnumerable<Subject>? GetSubjectsFromTeacher(Teacher teacher)
		{
			return _teacherRepository.Entities
				.Where(x => x.Id == teacher.Id && x.GroupId == teacher.GroupId)
				.Select(x => x.Subjects)
				.FirstOrDefault();
		}

		public IEnumerable<Subject>? GetSubjectsByTeacherId(int teacherId, int groupId)
		{
			return _teacherRepository.Entities
				.Where(x => x.Id == teacherId && x.GroupId == groupId)
				.Select(x => x.Subjects)
				.FirstOrDefault();
		}

		public Teacher? GetTeacherById(int teacherId, int groupId)
		{
			return _teacherRepository.GetById(teacherId, groupId);
		}

		public IEnumerable<Teacher> GetTeachersByGroupId(int groupId)
		{
			return _teacherRepository.Entities.Where(x => x.GroupId == groupId).ToList();
		}

		public bool UpdateTeacher(Teacher teacher)
		{
			return _teacherRepository.Update(teacher);
		}
	}
}