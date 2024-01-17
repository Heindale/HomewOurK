using HomewOurK.Domain.Entities;

namespace HomewOurK.Application.Interfaces
{
	public interface IExperienceService
	{
		void RaiseLevel(int userId, int groupId);
		void IncrementCompletedHomeworksCount(int userId, int groupId);
		void IncrementCreatedHomeworksCount(int userId, int groupId);
		void AddExperience(int userId, int groupId, int experienceValue);
		GroupsUsers GetInfoAboutExperience(int userId, int groupId);
		List<GroupsUsers> GetInfoAboutExperienceByGroupId(int groupId);
		List<GroupsUsers> GetInfoAboutExperienceByUserId(int userId);
	}
}
