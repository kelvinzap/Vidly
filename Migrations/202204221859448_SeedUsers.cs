namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0d5d81c8-20aa-4c2c-8225-a406cb33ad7a', N'chisom859@gmail.com', 0, N'AP4o/uO4kP8bDnBBbhuWLrmkDVVNNYcyacuP9PQF6DbEi49XdTHuvr4meMH15fAZzg==', N'f8cd2393-70af-45d3-8816-d42918ba2c86', NULL, 0, 0, NULL, 1, 0, N'chisom859@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1d87c5b4-7d0f-47c5-80d3-b132cc75644c', N'admin@gmail.com', 0, N'AMgLfrSQVvgBJ9Ov+Tpr5ISUZi0wqDEYJuzOgy3uS7hNIQ3tgNLhdV+t3/9O7Vny4w==', N'cb6c4ef5-393f-4ed1-ad0f-edb1b8154a17', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a88dc38a-0a63-41a5-8743-a05b4e6b58d4', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1d87c5b4-7d0f-47c5-80d3-b132cc75644c', N'a88dc38a-0a63-41a5-8743-a05b4e6b58d4')

");
        }

        public override void Down()
        {
        }
    }
}
