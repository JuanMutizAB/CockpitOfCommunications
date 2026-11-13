using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;


public class User
{

	private int _id;
	private string _name;
	private string _email;
	private string _password;
	private DateTime _birthDate;
	private string _taxId;
    private List<UserCaracteristics> _caracteristics;

	private int id
	{
		get => _id;
		set => _id = value;
	}

	private string name
	{
		get => _name;
		set
		{
			if (string.IsNullOrWhiteSpace(value))
				throw new ArgumentNullException(nameof(name), "Name cannot be null or empty.");

			string[] nameParts = value.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
			if (nameParts.Length < 2)
				throw new FormatException("Name must contain at least a first and last name.");

			_name = value;
		}
	}

	private string email
	{
		get => _email;
		set
		{
			if (string.IsNullOrWhiteSpace(value))
				throw new ArgumentNullException(nameof(email), "Email cannot be null or empty.");

			if (!value.Contains("@"))
				throw new FormatException("Email must contain '@'.");

			_email = value;
		}
	}

	private string password
	{
		get => _password;
		set
		{
			if (string.IsNullOrWhiteSpace(value))
				throw new ArgumentNullException(nameof(password), "Password cannot be null or empty.");

			if (value.Length <= 8)
				throw new ArgumentOutOfRangeException(nameof(password), "Password must have more than 8 characters.");

			if (!value.Any(char.IsUpper))
				throw new FormatException("Password must contain at least one uppercase letter.");

			if (!value.Any(char.IsLower))
				throw new FormatException("Password must contain at least one lowercase letter.");

			if (!value.Any(char.IsDigit))
				throw new FormatException("Password must contain at least one digit.");

			if (!value.Any(c => !char.IsLetterOrDigit(c)))
				throw new FormatException("Password must contain at least one special character.");

			_password = HashPassword(value);
		}
	}

	private DateTime birthDate
	{
		get => _birthDate;
		set
		{
			if (value > DateTime.Now)
				throw new ArgumentOutOfRangeException(nameof(birthDate), "Birth date cannot be in the future.");

			_birthDate = value;
		}
	}

	private string taxId
	{
		get => _taxId;
		set
		{
			if (string.IsNullOrWhiteSpace(value))
				throw new ArgumentNullException(nameof(taxId), "Tax ID cannot be null or empty.");

			if (value.Length != 9 || !value.All(char.IsDigit))
				throw new FormatException("Tax ID must have exactly 9 digits.");

			_taxId = value;
		}
	}

    private List<UserCaracteristics> caracteristics
    {
        get => _caracteristics;
        set => _caracteristics = value;
    }

    public User(int id, string name, string email, string password, DateTime birthDate, string taxId, List<UserCaracteristics> caracteristics)
    {
        this.id = id;
        this.name = name;
        this.email = email;
        this.password = HashPassword(password);
        this.birthDate = birthDate;
        this.taxId = taxId;
        this.caracteristics = caracteristics;
		this.caracteristics.Add(UserCaracteristics.isActive);
    }

    private string HashPassword(string password)
    {
        byte[] bytes = SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(password));
        return Convert.ToHexString(bytes).ToLower();
    }


}
