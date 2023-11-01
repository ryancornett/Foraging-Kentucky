﻿using System.Text.RegularExpressions;

namespace Foraging_Kentucky.Domain;
public class User : IEntity
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Item> Items { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public DateTime Updated { get; set; } = DateTime.Now;

    public User(string Name, string Email)
    {
        if (ValidateEmail(Email))
        {
            this.Email = Email;
        }
        else
        {
            this.Email = "genericeuser@genericuser.com";
        }
        this.Name = Name;
        Items = new List<Item>();
    }

    public bool ValidateEmail(string email)
    {
        bool isEmailValid = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        return isEmailValid;
    }

    public void UpdateTimeUpdated()
    {
        Updated = DateTime.Now;
    }
}
