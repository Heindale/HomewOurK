using System.Security.Cryptography;
using System.Text;

namespace HomewOurK.Infrastructure.Extensions
{
	public static class PasswordHasher
	{
		public static string HashPassword(string password)
		{
			using (SHA256 sha256 = SHA256.Create())
			{
				// Преобразуем пароль в массив байтов
				byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

				// Хэшируем пароль
				byte[] hashBytes = sha256.ComputeHash(passwordBytes);

				// Преобразуем массив байтов в строку шестнадцатеричного представления
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < hashBytes.Length; i++)
				{
					stringBuilder.Append(hashBytes[i].ToString("x2"));
				}
				return stringBuilder.ToString();
			}
		}

		public static bool VerifyPassword(string password, string hashedPassword)
		{
			// Получаем хэш для введенного пароля
			string hashedInputPassword = HashPassword(password);

			// Сравниваем полученный хэш с хэшем, хранящимся в базе данных
			return string.Equals(hashedInputPassword, hashedPassword, StringComparison.OrdinalIgnoreCase);
		}
	}
}