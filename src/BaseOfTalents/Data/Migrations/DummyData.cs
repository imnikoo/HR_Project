﻿using Domain.Entities;
using Domain.Entities.Enum;
using Domain.Entities.Enum.Setup;
using Domain.Entities.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Migrations
{
    public static class DummyData
    {

        static DummyData()
        {
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();

            Roles = GetRoles(42);
            Users = GetUsers(150);
            Vacancies = GetVacancies(1080);
            Candidates = GetCandidates(31337);
        }

        public static readonly List<Skill> Skills = new List<Skill>()
            {
                new Skill { Title="SQL" },
                new Skill { Title="WinForms" },
                new Skill { Title="DevExpress" },
                new Skill { Title=".Net" },
                new Skill { Title="C#" },
                new Skill { Title="Spring .Net" },
                new Skill { Title="JQuery" },
                new Skill { Title="JavaScript" },
                new Skill { Title="ASP .NET MVC" },
                new Skill { Title="HTML5+CSS3" },
                new Skill { Title="NHibernate" },
                new Skill { Title="Entity Framework" }
            };

        public static readonly List<Tag> Tags = new List<Tag>()
            {
                new Tag { Title="SQL" },
                new Tag { Title="WinForms" },
                new Tag { Title="DevExpress" },
                new Tag { Title=".Net" },
                new Tag { Title="C#" },
                new Tag { Title="Spring .Net" },
                new Tag { Title="JQuery" },
                new Tag { Title="JavaScript" },
                new Tag { Title="ASP .NET MVC" },
                new Tag { Title="HTML5+CSS3" },
                new Tag { Title="NHibernate" },
                new Tag { Title="Entity Framework" }
            };

        public static readonly List<Industry> Industries = new List<Industry>()
            {
                new Industry { Title="IT" },
                new Industry { Title="Accounting" },
                new Industry { Title="Administration" }
            };

        public static readonly List<Level> Levels = new List<Level>()
            {
                new Level { Title="Trainee" },
                new Level { Title="Junior" },
                new Level { Title="Middle" },
                new Level { Title="Senior" }
            };

        public static readonly List<DepartmentGroup> DepartmentGroups = new List<DepartmentGroup>()
            {
                new DepartmentGroup { Title="Contract" },
                new DepartmentGroup { Title="Nonprod" },
                new DepartmentGroup { Title="Prod" }
            };

        public static readonly List<Department> Departments = new List<Department>()
            {
                  new Department { Title = "Contract Programming",  DepartmentGroup = DepartmentGroups[0]},
                  new Department { Title = "Sites Design",          DepartmentGroup = DepartmentGroups[0]},
                  new Department { Title = "Web apps",              DepartmentGroup = DepartmentGroups[0]},
                  new Department { Title = "Accounting",            DepartmentGroup = DepartmentGroups[1]},
                  new Department { Title = "Administration",        DepartmentGroup = DepartmentGroups[1]},
                  new Department { Title = "Executives",            DepartmentGroup = DepartmentGroups[1]},
                  new Department { Title = "DevWorkshop",           DepartmentGroup = DepartmentGroups[1]},
                  new Department { Title = "HR",                    DepartmentGroup = DepartmentGroups[1]},
                  new Department { Title = "Managers",              DepartmentGroup = DepartmentGroups[1]},
                  new Department { Title = "Managers",              DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "QA",                    DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "UPM",                   DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "EPE",                   DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "Soft Web",              DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "AR",                    DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "Bank/Donor",            DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "iTMS",                  DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "Genetics 1",            DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "Genetics 2",            DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "Genetics 3",            DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "Genetics 5",            DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "Genetics Analysts",     DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "Genetics Autotesting",  DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "HLA",                   DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "Portal",                DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "Regr.Testing",          DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "Total QC",              DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "CM",                    DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "DBA",                   DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "MIS Tech Support",      DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "SA",                    DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "SE",                    DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "Architects",            DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "BI",                    DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "CSF",                   DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "Interfaces",            DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "Lab 5.0",               DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "LabMic",                DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "Mic 5.0",               DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "RNV",                   DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "Reports",               DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "Genetics Support",      DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "Support",               DepartmentGroup = DepartmentGroups[2]},
                  new Department { Title = "Update",                DepartmentGroup = DepartmentGroups[2]},
            };

        public static readonly List<Language> Languages = new List<Language>()
            {
                new Language { Title="English" },
                new Language { Title="Polish" }
            };

        public static readonly List<LanguageSkill> LanguageSkills = new List<LanguageSkill>
        {
            new LanguageSkill {Language = Languages[0], LanguageLevel = LanguageLevel.Beginner },
            new LanguageSkill {Language = Languages[0], LanguageLevel = LanguageLevel.Advanced },
            new LanguageSkill {Language = Languages[0], LanguageLevel = LanguageLevel.Fluent },
            new LanguageSkill {Language = Languages[0], LanguageLevel = LanguageLevel.Intermediate },
            new LanguageSkill {Language = Languages[0], LanguageLevel = LanguageLevel.PreIntermediate },
            new LanguageSkill {Language = Languages[0], LanguageLevel = LanguageLevel.UpperIntermediate }
        };

        public static readonly List<Country> Countries = new List<Country>()
            {
                new Country { Title="Ukraine" }
            };

        public static readonly List<Location> Locations = new List<Location>()
            {
                new Location { Country=Countries[0], Title="Kiev" },
                new Location { Country=Countries[0], Title="Kharkiv" },
                new Location { Country=Countries[0], Title="Odessa" },
                new Location { Country=Countries[0], Title="Dnipropetrovsk" },
                new Location { Country=Countries[0], Title="Zaporizhia" },
                new Location { Country=Countries[0], Title="Lviv" },
                new Location { Country=Countries[0], Title="Kryvyi Rih" },
                new Location { Country=Countries[0], Title="Mykolaiv" },
                new Location { Country=Countries[0], Title="Mariupol" },
                new Location { Country=Countries[0], Title="Luhansk" },
                new Location { Country=Countries[0], Title="Donetsk" },
                new Location { Country=Countries[0], Title="Sevastopol" },
                new Location { Country=Countries[0], Title="Vinnytsia" },
                new Location { Country=Countries[0], Title="Makiivka" },
                new Location { Country=Countries[0], Title="Simferopol" },
                new Location { Country=Countries[0], Title="Kherson" },
                new Location { Country=Countries[0], Title="Poltava" },
                new Location { Country=Countries[0], Title="Chernihiv" },
            };

        public static readonly List<Permission> Permissions = new List<Permission>()
            {
                new Permission { AccessRights=AccessRights.AddCandidate,                        Description = "Right to create a candidate",                                Group = "Candidates" },
                new Permission { AccessRights=AccessRights.AddCandidateToVacancy,               Description = "Right to attach exsisting candidate to a vacancy",           Group = "Vacancies" },
                new Permission { AccessRights=AccessRights.AddEvent,                            Description = "Right to create an event",                                   Group = "Calendar" },
                new Permission { AccessRights=AccessRights.AddRole,                             Description = "Right to create a role",                                     Group = "Roles" },
                new Permission { AccessRights=AccessRights.AddVacancy,                          Description = "Right to create a vacancy",                                  Group = "Vacancies" },
                new Permission { AccessRights=AccessRights.EditCandidate,                       Description = "Right to edit a candidate",                                  Group = "Candidates" },
                new Permission { AccessRights=AccessRights.EditEvent,                           Description = "Right to edit an event",                                     Group = "Calendar" },
                new Permission { AccessRights=AccessRights.EditRole,                            Description = "Right to edit a role",                                       Group = "Roles" },
                new Permission { AccessRights=AccessRights.EditUserProfile,                     Description = "Right to edit user profile",                                 Group = "Users" },
                new Permission { AccessRights=AccessRights.EditVacancy,                         Description = "Right to edit a vacancy",                                    Group = "Vacancies" },
                new Permission { AccessRights=AccessRights.GenerateReports,                     Description = "Right to generate reports",                                  Group = "Reports" },
                new Permission { AccessRights=AccessRights.InviteNewMember,                     Description = "Right to invite a new member to program",                    Group = "Users" },
                new Permission { AccessRights=AccessRights.RemoveCandidate,                     Description = "Right to remove candidate",                                  Group = "Candidates" },
                new Permission { AccessRights=AccessRights.RemoveCandidateFromVacancy,          Description = "Right to remove candidate from a vacancy",                   Group = "Vacancies" },
                new Permission { AccessRights=AccessRights.RemoveEvent,                         Description = "Right to remove event",                                      Group = "Calendar" },
                new Permission { AccessRights=AccessRights.RemoveRole,                          Description = "Right to remove role",                                       Group = "Roles" },
                new Permission { AccessRights=AccessRights.RemoveUserProfile,                   Description = "Right to remove user profile",                               Group = "Users" },
                new Permission { AccessRights=AccessRights.RemoveVacancy,                       Description = "Right to remove vacancy",                                    Group = "Vacancies" },
                new Permission { AccessRights=AccessRights.SearchCandidatesInExternalSource,    Description = "Right to search candidates on another work-searching sites", Group = "Candidates" },
                new Permission { AccessRights=AccessRights.SearchCandidatesInInternalSource,    Description = "Right to search candidates inside the base",                 Group = "Candidates" },
                new Permission { AccessRights=AccessRights.SystemSetup,                         Description = "Right to provide system setup",                              Group = "System" },
                new Permission { AccessRights=AccessRights.ViewCalendar,                        Description = "Right to view a calendar",                                   Group = "Calendar" },
                new Permission { AccessRights=AccessRights.ViewListOfCandidates,                Description = "Right to view list of candidates",                           Group = "Candidates" },
                new Permission { AccessRights=AccessRights.ViewListOfVacancies,                 Description = "Right to view list of vacancies",                            Group = "Vacancies" },
                new Permission { AccessRights=AccessRights.ViewRoles,                           Description = "Right to view roles",                                        Group = "Roles" },
                new Permission { AccessRights=AccessRights.ViewUserProfile,                     Description = "Right to view user profile",                                 Group = "Users" },
                new Permission { AccessRights=AccessRights.ViewUsers,                           Description = "Right to view users",                                        Group = "Users" }
            };

        public static readonly List<Stage> Stages = new List<Stage>()
            {
                new Stage { Title="Pool" },
                new Stage { Title="Selected" },
                new Stage { Title="HR Interview" },
                new Stage { Title="Test task" },
                new Stage { Title="Tech Interview" },
                new Stage { Title="Additional interview" },
                new Stage { Title="Final Interview",  },
                new Stage { Title="Job Offer Issued" },
                new Stage { Title="Job Offer Accepted", },
                new Stage { Title="Hired" },
                new Stage { Title="Rejected" },
            };

        public static readonly List<Photo> Photos = new List<Photo>
            {
                new Photo {Description="photo 1", ImagePath=@"~\images\ph11.jpg" },
                new Photo {Description="photo 2", ImagePath=@"~\images\ph12.jpg" },
                new Photo {Description="photo 3", ImagePath=@"~\images\ph13.jpg" },
                new Photo {Description="photo 4", ImagePath=@"~\images\ph14.jpg" },
                new Photo {Description="photo 5", ImagePath=@"~\images\ph15.jpg" },
                new Photo {Description="photo 6", ImagePath=@"~\images\ph16.jpg" },
                new Photo {Description="photo 7", ImagePath=@"~\images\ph17.jpg" },
                new Photo {Description="photo 8", ImagePath=@"~\images\ph18.jpg" },
                new Photo {Description="photo 9", ImagePath=@"~\images\ph19.jpg" }
            };

        public static readonly List<SocialNetwork> Socials = new List<SocialNetwork>
        {
            new SocialNetwork { ImagePath = GetRandomNumbers(12), Title="Facebook"},
            new SocialNetwork { ImagePath = GetRandomNumbers(12), Title="VK"},
            new SocialNetwork { ImagePath = GetRandomNumbers(12), Title="LinkedIn"},
            new SocialNetwork { ImagePath = GetRandomNumbers(12), Title="MySpace"}
        };

        public static List<User> Users;
        private static List<User> GetUsers(int count)
        {
            var users = new List<User>();

            for (int i = 0; i < count; i++)
            {
                users.Add(
                    new User
                    {
                        BirthDate = DateTime.Now.AddYears(-rnd.Next(20, 40)),
                        Email = string.Format("{0}@{1}.ua", GetRandomString(8), GetRandomString(6)),
                        FirstName = names.GetRandom(),
                        isMale = true,
                        LastName = lastNames.GetRandom(),
                        Location = Locations.GetRandom(),
                        Login = GetRandomString(4),
                        MiddleName = names.GetRandom(),
                        Password = GetRandomString(8),
                        PhoneNumbers = new List<PhoneNumber> { new PhoneNumber { Number = GetRandomNumbers(7) } },
                        Photo = Photos.GetRandom(),
                        Role = Roles.GetRandom(),
                        Skype = GetRandomString(8),
                    }
                    );
            }
            return users;
        }

        public static List<Role> Roles;
        private static List<Role> GetRoles(int count)
        {
            var roles = new List<Role>();

            for (int i = 0; i < count; i++)
            {
                roles.Add(new Role
                {
                    Title = "Role " + i,
                    Permissions = new List<Permission>
                    {
                        Permissions.GetRandom(),
                        Permissions.GetRandom(),
                        Permissions.GetRandom(),
                        Permissions.GetRandom()
                    }
                });
            }
            return roles;
        }
        public static List<Vacancy> Vacancies;
        private static List<Vacancy> GetVacancies(int count)
        {
            List<Vacancy> vacancies = new List<Vacancy>();
            for (int i = 0; i < count; i++)
            {
                vacancies.Add(
                    new Vacancy
                    {
                        DeadlineDate = DateTime.Now.AddDays(rnd.Next(-40, 40)),
                        Department = Departments.GetRandom(),
                        Description = GetRandomString(250),
                        Industry = Industries.GetRandom(),
                        LanguageSkill = LanguageSkills.GetRandom(),
                        Levels = Levels.Take(rnd.Next(Levels.Count)).ToList(),
                        Locations = Locations.Take(rnd.Next(Levels.Count)).ToList(),
                        RequiredSkills = Skills.Take(rnd.Next(Skills.Count)).ToList(),
                        Responsible = Users.GetRandom(),
                        SalaryMax = rnd.Next(1000, 2000),
                        SalaryMin = rnd.Next(0, 1000),
                        StartDate = DateTime.Now.AddDays(rnd.Next(-80, -40)),
                        Title = professons.GetRandom(),
                        TypeOfEmployment = TypeOfEmployment.FullTime,
                        EndDate = DateTime.Now.AddDays(rnd.Next(30)),
                    }
                    );
            }
            return vacancies;
        }

        public static readonly List<Candidate> Candidates;
        private static List<Candidate> GetCandidates(int count)
        {
            var candidates = new List<Candidate>();

            for (int i = 0; i < count; i++)
            {
                Candidate candidate = new Candidate()
                {
                    LocationId = rnd.Next(1, Locations.Count - 1),
                    BirthDate = DateTime.Now.AddYears(rnd.Next(-40, -20)),
                    Comments = new List<Comment> { },
                    Education = GetRandomString(15),
                    FirstName = names.GetRandom(),
                    IndustryId = rnd.Next(1, Industries.Count - 1),
                    Description = professons.GetRandom(),
                    Email = string.Format("{0}@{1}.me", GetRandomString(5), GetRandomString(6)),
                    Files = new List<File>() { },
                    IsMale = true,
                    LanguageSkills = new List<LanguageSkill>() { LanguageSkills.GetRandom() },
                    LastName = lastNames.GetRandom(),
                    MiddleName = names.GetRandom(),
                    PhoneNumbers = new List<PhoneNumber>() { },
                    Photo = new Photo() { Description = GetRandomString(25), ImagePath = GetRandomNumbers(25) },
                    PositionDesired = professons.GetRandom(),
                    Practice = GetRandomString(20),
                    RelocationAgreement = true,
                    SalaryDesired = rnd.Next(300, 3000),
                    Skills = new List<Skill>() { Skills.GetRandom() },
                    Skype = "skyper133",
                    //SocialNetworks = new List<CandidateSocial>() { new CandidateSocial() {SocialNetwork = Socials.GetRandom(), Path = GetRandomString(15) } },
                    Sources = new List<CandidateSource>() { new CandidateSource() { Source = Source.WorkUa, Path = "Path" } },
                    StartExperience = DateTime.Now.AddYears(-rnd.Next(10)),
                    Tags = new List<Tag>(),
                    TypeOfEmployment = TypeOfEmployment.FullTime,
                    VacanciesProgress = new List<VacancyStageInfo>() { }
                };
                candidates.Add(candidate);
            }
            return candidates;
        }

        static Random rnd = new Random();
        public static T GetRandom<T>(this List<T> list)
        {
            return list[rnd.Next(list.Count - 1)];
        }

        private static string GetRandomString(int count)
        {
            var random = new Random();
            var chars = "abcdefghijklmnopqrstuvwxyz";
            var stringChars = new char[count];
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            return new String(stringChars);
        }
        private static string GetRandomNumbers(int count)
        {
            var random = new Random();
            var nums = "1234567890";
            var stringChars = new char[count];
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = nums[random.Next(nums.Length)];
            }

            return new String(stringChars);
        }

        private readonly static List<string> names = new List<string> { "Велизар", "Велимир", "Венедикт", "Вениамин", "Венцеслав", "Веньямин", "Викентий",
            "Виктор", "Викторий", "Викул", "Викула", "Вилен", "Виленин", "Вильгельм", "Виссарион", "Вит", "Виталий", "Витовт", "Витольд",
            "Владилен", "Владимир", "Владислав", "Владлен", "Влас", "Власий", "Вонифат", "Вонифатий", "Всеволод", "Всеслав", "Вукол", "Вышеслав",
            "Вячеслав", "Гавриил", "Гаврил", "Гаврила", "Галактион", "Гедеон", "Гедимин", "Геласий", "Гелий", "Геннадий", "Генрих", "Георгий",
            "Герасим", "Гервасий", "Герман", "Гермоген", "Геронтий", "Гиацинт", "Глеб", "Гораций", "Горгоний", "Гордей", "Гостомысл", "Гремислав",
            "Григорий", "Гурий", "Гурьян", "Давид", "Давыд", "Далмат", "Даниил", "Данил", "Данила", "Дементий", "Демид", "Демьян", "Денис",
            "Денисий", "Димитрий", "Диомид", "Дионисий", "Дмитрий", "Добромысл", "Добрыня", "Довмонт", "Доминик", "Донат", "Доримедонт",
            "Дормедонт", "Дормидбнт", "Дорофей", "Досифей", "Евгений", "Евграф", "Евграфий", "Евдоким", "Евлампий", "Евлогий", "Евмен",
            "Евмений", "Евсей", "Евстафий", "Евстахий", "Евстигней", "Евстрат", "Евстратий" };
        private readonly static List<string> lastNames = new List<string>{"Иванов","Смирнов","Кузнецов","Попов","Васильев","Петров","Соколов","Михайлов",
            "Новиков","Фёдоров","Морозов","Волков","Алексеев","Лебедев","Семёнов","Егоров","Павлов","Козлов","Степанов","Николаев","Орлов",
            "Андреев","Макаров","Никитин","Захаров"};
        private static readonly List<string> professons = new List<string> { "Страховой аналитик", "Аудиолог", "Математик", "Статистик",
            "Специалист в области биомедицины", "Научный аналитик", "Стоматолог-гигиенист", "Инженер-программист", "Терапевт",
            "Специалист компьютерных систем", "Журналист", "Лесоруб", "Военнослужащий в нижних воинских званиях", "Шеф-повар",
            "Конферансье (тамада, шоумен и прочие смежные профессии)", "Фоторепортер", "Редактор", "Водитель такси", "Пожарный", "Почтовый курьер" };

    }
}