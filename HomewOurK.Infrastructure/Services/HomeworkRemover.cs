﻿using HomewOurK.Application.Interfaces;
using HomewOurK.Domain.Entities;
using HomewOurK.Persistence.Repositories;

namespace HomewOurK.Infrastructure.Services
{
	public class HomeworkRemover(SubjectElementRepository<Homework> homeworkRepository) : IHomeworkRemover
	{
		private readonly SubjectElementRepository<Homework> _homeworkRepository = homeworkRepository;

		public void RemoveHomework()
		{
			TimeSpan timeOfDeletion = TimeSpan.FromDays(60);
			DateTime today = DateTime.Now;

			List<Homework> homeworks = _homeworkRepository
				.GetAll()
				.Where(x => x.Done == true)
				.ToList();

			foreach (Homework homework in homeworks)
			{
				if (today.CompareTo(homework.CompletedDate + timeOfDeletion) < 0)
				{
					_homeworkRepository.Delete(homework);
				}
			}
		}
	}
}