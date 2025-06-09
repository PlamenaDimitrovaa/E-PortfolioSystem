using System.ComponentModel.DataAnnotations;

namespace E_PortfolioSystem.Common
{
    public static class EntityValidationConstants
    {
        public static class Profile
        {
            public const int FullNameMinLength = 1;
            public const int FullNameMaxLength = 200;

            public const int PhoneMinLength = 7;
            public const int PhoneMaxLength = 15;

            public const int BioMinLength = 1;
            public const int BioMaxLength = 500;

            public const int LocationMinLength = 1;
            public const int LocationMaxLength = 200;

            public const int ImageUrlMinLength = 1;
            public const int ImageUrlMaxLength = 2048;
        }

        public static class Skill
        {
            public const int SkillNameMinLength = 1;
            public const int SkillNameMaxLength = 100;

            public const int LevelMinLength = 1;
            public const int LevelMaxLength = 50;
        }

        public static class Project
        {
            public const int TitleMinLength = 1;
            public const int TitleMaxLength = 200;

            public const int LinkMinLength = 1;
            public const int LinkMaxLength = 2048;

            public const int DescriptionMinLength = 1;
            public const int DescriptionMaxLength = 500;

            public const int FilePathMinLength = 1;
            public const int FilePathMaxLength = 2048;

            public const int ImageUrlMinLength = 1;
            public const int ImageUrlMaxLength = 2048;
        }

        public static class Evaluation
        {
            public const int FeedbackMinLength = 1;
            public const int FeedbackMaxLength = 200;

            public const int EvaluationTypeMinLength = 1;
            public const int EvaluationTypeMaxLength = 20;
        }

        public static class Education
        {
            public const int InstitutionMinLength = 1;
            public const int InstitutionMaxLength = 150;

            public const int DegreeMinLength = 1;
            public const int DegreeMaxLength = 50;

            public const int SpecialtyMinLength = 1;
            public const int SpecialtyMaxLength = 150;

            public const int FacultyMinLength = 1;
            public const int FacultyMaxLength = 150;
        }

        public static class Certificate
        {
            public const int TitleMinLength = 1;
            public const int TitleMaxLength = 50;

            public const int IssuerMinLength = 1;
            public const int IssuerMaxLength = 150;

            public const int FilePathMinLength = 1;
            public const int FilePathMaxLength = 150;

            public const int DescriptionMinLength = 1;
            public const int DescriptionMaxLength = 400;
        }

        public static class Subject
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 80;
        }

        public static class Notification
        {
            public const int TitleMinLength = 1;
            public const int TitleMaxLength = 100;

            public const int ContentMinLength = 1;
            public const int ContentMaxLength = 500;
        }

        public static class Email
        {
            public const int SubjectMinLength = 1;
            public const int SubjectMaxLength = 200;

            public const int BodyMinLength = 1;
            public const int BodyMaxLength = 500;
        }

        public static class HRContact
        {
            public const int MessageMinLength = 1;
            public const int MessageMaxLength = 500;

            public const int NameMinLength = 1;
            public const int NameMaxLength = 500;

            public const int EmailMinLength = 4;
            public const int EmailMaxLength = 254;

            public const int PhoneNumberMinLength = 1;
            public const int PhoneNumberMaxLength = 15;
        }

        public static class Chat
        {
            public const int MessageMinLength = 1;
            public const int MessageMaxLength = 500;
        }

        public static class Recommendation
        {
            public const int TextMinLength = 1;
            public const int TextMaxLength = 500;
        }

        public static class AttachedDocument
        {
            public const int DocumentTypeMinLength = 1;
            public const int DocumentTypeMaxLength = 50;

            public const int FileNameMinLength = 1;
            public const int FileNameMaxLength = 500;

            public const int DescriptionMinLength = 1;
            public const int DescriptionMaxLength = 250;

            public const int FileContentMinLength = 1;
            public const int FileContentMaxLength = 2048;

            public const int FileLocationMinLength = 1;
            public const int FileLocationMaxLength = 150;
        }

        public static class Student
        {
            public const int FacultyNumberMinLength = 8;
            public const int FacultyNumberMaxLength = 10;
        }

        public static class Experience
        {
            public const int ProfessionMinLength = 3;
            public const int ProfessionMaxLength = 500;

            public const int DescriptionMinLength = 3;
            public const int DescriptionMaxLength = 500;

            public const int CompanyMinLength = 3;
            public const int CompanyMaxLength = 500;

            public const int SectorMinLength = 3;
            public const int SectorMaxLength = 500;
        }

        public static class User
        {
            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 15;

            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 15;

            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 100;
        }
    }
}
