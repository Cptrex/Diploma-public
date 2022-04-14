using System;
using System.Collections.Generic;
using System.Text;

namespace Diploma.DataContext
{
    public class Case
    {
        public int ID { get; set; }
        public string? Photo { get; set; }
        public bool? IsWanted { get; set; }
        public int? CaseNumber { get; set; }
        public string? Fullname { get; set; }
        public string? Firstname { get; set; }
        public string? Surname { get; set; }
        public string? Secondname { get; set; }
        public string? Nickname { get; set; }
        public string? DateBirth { get; set; }
        public string? PlaceBirth { get; set; }
        public string? Citizenship { get; set; }
        public string? Height { get; set; }
        public string? Conviction { get; set; }
        public string? OCGMember { get; set; } //Organized Crime Group Member
        public string? LivingPlace { get; set; }
        public string? FamilyComposition { get; set; }
        public string? HumanForm { get; set; }
        public string? Description { get; set; }
        public string? Contacts { get; set; }
        public string? SocialNetwork { get; set; }
        public string? Note { get; set; }
        public string? PublishedDate { get; set; }

        public int ProfileID { get; set; }
        public Profile Profile { get; set; }
        public int ExtremistOrgID { get; set; }
        public ExtremistOrg ExtremistOrg { get; set; }
        public int GenderID { get; set; }
        public Gender Gender { get; set; }
        public int NationalityID { get; set; }
        public Nationality Nationality { get; set; }
        public int AccessLevel { get; set; }
        public AccessModel AccessModel { get; set; }
    }
}