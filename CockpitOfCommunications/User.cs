using System;
using System.io;


public class User
{

	private int id { get; set; }
	private string name { get; set; }
	private string email { get; set; }
	private string password { get; set; }
	private DateTime birthDate { get; set; }
	private int taxId { get; set; }
	private string imageURL { get; set; }
    private List<UserCaracteristics> caracteristics { get; set; }

    public User(int id, string name, string email, string password, DateTime birthDate, int taxId, string imageURL, List<UserCaracteristics> caracteristics)
    {
        this.id = id;
        this.name = name;
        this.email = email;
        this.password = password;
        this.birthDate = birthDate;
        this.taxId = taxId;
        this.imageURL = imageURL;
        this.caracteristics = caracteristics.Add(UserCaracteristics.isActive);
    }






}


