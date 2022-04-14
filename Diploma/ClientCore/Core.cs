using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Diploma.DataContext;
using System.Threading.Tasks;

namespace Diploma.ClientCore
{
    public class Core
    {
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
        public int ProfileID { get; set; } = 0;
        public int CaseID { get; set; } = 0;
        public bool IsProfileEditModeEnabled { get; set; } = false;
        public bool IsCaseEditModeEnabled { get; set; } = false;

        public static Core Main = new Core();

        public static List<DataContext.Case> CaseList = new List<DataContext.Case>();
        public static List<DataContext.ExtremistOrg> ExtremistOrgs = new List<DataContext.ExtremistOrg>();
        public static List<DataContext.Profile> ProfileList = new List<DataContext.Profile>();
        public static List<DataContext.Nationality> NationalityList = new List<DataContext.Nationality>();
        public static List<DataContext.Gender> GenderList = new List<DataContext.Gender>();
        public static List<DataContext.Rank> RankList = new List<DataContext.Rank>();
        public static List<DataContext.Position> PositionList = new List<DataContext.Position>();


        public static async Task <List<DataContext.ExtremistOrg>> LoadExtremistOrgs()
        {
            if (ExtremistOrgs.Count > 0) return ExtremistOrgs;

            using DiplomaDataContext db = new DiplomaDataContext();
            await foreach (var org in db.ExtremistOrgs) ExtremistOrgs.Add(org);

            return ExtremistOrgs;
        }

        public static async Task <List<DataContext.Nationality>> LoadNationalityList()
        {
            if (NationalityList.Count > 0) return NationalityList;

            using DiplomaDataContext db = new DiplomaDataContext();
            await foreach (var org in db.Nationalities) NationalityList.Add(org);

            return NationalityList;
        }

        public static async Task<List<DataContext.Gender>> LoadGenderList()
        {
            if (GenderList.Count > 0) return GenderList;

            using DiplomaDataContext db = new DiplomaDataContext();
            await foreach (var org in db.Genders) GenderList.Add(org);

            return GenderList;
        }

        public static async Task<List<DataContext.Rank>> LoadRankList()
        {
            if (RankList.Count > 0) return RankList;

            using DiplomaDataContext db = new DiplomaDataContext();
            await foreach (var org in db.Ranks) RankList.Add(org);

            return RankList;
        }

        public static async Task<List<DataContext.Position>> LoadPositionList()
        {
            if (PositionList.Count > 0) return PositionList;

            using DiplomaDataContext db = new DiplomaDataContext();
            await foreach (var org in db.Positions) PositionList.Add(org);

            return PositionList;
        }
    }
}