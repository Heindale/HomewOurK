using HomewOurK.Application.Interfaces;
using HomewOurK.Application.Interfaces.Repositories;
using HomewOurK.Domain.Entities;

namespace HomewOurK.Infrastructure.Services
{
	public class SubjectService(IGroupElementRepository<Teacher> teacherRepository,
			IGroupElementRepository<Subject> subjectRepository) : ISubjectService
	{
		private readonly IGroupElementRepository<Teacher> _teacherRepository = teacherRepository;
		private readonly IGroupElementRepository<Subject> _subjectsRepository = subjectRepository;

		public bool AddSubject(Subject subject)
		{
			return _subjectsRepository.Add(subject);
		}

		public bool AddTeacher(Subject subject, Teacher teacher)
		{
			if (teacher != null && subject != null)
			{
				subject.Teachers.Add(teacher);
				return _subjectsRepository.Update(subject);
			}
			return false;
		}

		public bool AddTeacher(int subjectId, int groupId, int teacherId)
		{
			var teacher = _teacherRepository.GetById(teacherId, groupId);
			var subject = _subjectsRepository.GetById(subjectId, groupId);

			if (teacher != null && subject != null)
			{
				subject.Teachers.Add(teacher);
				return _subjectsRepository.Update(subject);
			}
			return false;
		}

		public bool UpdateSubject(Subject subject)
		{
			return _subjectsRepository.Update(subject);
		}

		public bool DeleteSubject(Subject subject)
		{
			return _subjectsRepository.Delete(subject);
		}

		public Subject? GetSubjectById(int subjectId, int groupId)
		{
			return _subjectsRepository.GetById(subjectId, groupId);
		}

		public IEnumerable<Subject> GetSubjectsByGroupId(int groupId)
		{
			return _subjectsRepository.Entities.Where(x => x.GroupId == groupId);
		}

		public IEnumerable<Teacher>? GetTeachersBySubjectId(int subjectId, int groupId)
		{
			return _subjectsRepository.Entities
				.Where(x => x.Id == subjectId && x.GroupId == groupId)
				.Select(x => x.Teachers)
				.FirstOrDefault();
		}

		public IEnumerable<Teacher>? GetTeachersFromSubject(Subject subject)
		{
			return _subjectsRepository.Entities
				.Where(x => x.Id == subject.Id && x.GroupId == subject.GroupId)
				.Select(x => x.Teachers)
				.FirstOrDefault();
		}

		public bool DeleteTeacher(Subject subject, Teacher teacher)
		{
			if (teacher != null && subject != null)
			{
				subject.Teachers.Remove(teacher);
				return _subjectsRepository.Update(subject);
			}
			return false;
		}

		public bool DeleteTeacher(int subjectId, int groupId, int teacherId)
		{
			var teacher = _teacherRepository.GetById(teacherId, groupId);
			var subject = _subjectsRepository.GetById(subjectId, groupId);

			if (teacher != null && subject != null)
			{
				subject.Teachers.Remove(teacher);
				return _subjectsRepository.Update(subject);
			}
			return false;
		}
	}
}