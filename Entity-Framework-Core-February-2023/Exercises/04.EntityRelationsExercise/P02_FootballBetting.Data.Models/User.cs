﻿namespace P02_FootballBetting.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Common;

public class User
{
    public User()
    {
        this.Bets = new HashSet<Bet>();
    }

    [Key]
    public int UserId { get; set; }

    [MaxLength(ValidationConstants.UserUsernameMaxLength)]
    public string Username { get; set; } = null!;

    [MaxLength(ValidationConstants.UserPasswordMaxLength)]
    public string Password { get; set; } = null!;

    [MaxLength(ValidationConstants.UserEmailMaxLength)]
    public string Email { get; set; } = null!;

    [MaxLength(ValidationConstants.UserNameMaxLength)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Balance { get; set; }

    public virtual ICollection<Bet> Bets { get; set; }
}