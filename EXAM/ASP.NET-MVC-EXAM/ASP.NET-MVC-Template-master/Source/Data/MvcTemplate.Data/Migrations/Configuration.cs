namespace MvcTemplate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using MvcTemplate.Common;
    using MvcTemplate.Data.Models;
    
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = AdministratorUserName;

            if (!context.Roles.Any())
            {
                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                roleManager.Create(role);

                // Create admin user
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = AdministratorUserName, Email = AdministratorUserName };
                userManager.Create(user, AdministratorPassword);

                // Assign user to admin role
                userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);
            }

            if (!context.Users.Any())
            {
                var user = new ApplicationUser
                {
                    Email = "user1@site.com",
                    PasswordHash = "user1"
                };

                context.Users.AddOrUpdate(user);
            }

            if (!context.Ideas.Any())
            {
                var ideasList = new Idea[]
           {
                new Idea
                {
                    Title = "XNA 5",
                    Description = "Please continue to work on XNA. It's a great way for indie game developers like myself to make games and give them to the world. XNA gave us the ability to put our games, easily, on the most popular platforms, and to just dump XNA would be therefor heartbreaking... I implore you to keep working on XNA so we C# developers can still make amazing games!"
                },
                new Idea
                {
                    Title = "Allow .NET games on Xbox One",
                    Description = @"Yesterday was announced that Xbox One will allow indie developer to easily publish games on Xbox One.

Lots of indie developers and small game company are using .NET to develop games.Today, we are able to easily target several Windows platforms(Windows Desktop, Windows RT and Windows Phone 8) as well as other platforms thanks to Mono from Xamarin.

As we don't know yet the details about this indie developer program for Xbox One, we would love to use .NET on this platform - with everything accessible, from latest 4.5 with async, to unsafe code and native code access through DLLImport (and not only through WinRT components)

Please make .NET a compelling game development alternative on Xbox One!"
                },
                new Idea
                {
                    Title = "Support web.config style Transforms on any file in any project type",
                    Description = "Web.config Transforms offer a great way to handle environment-specific settings. XML and other files frequently warrant similar changes when building for development (Debug), SIT, UAT, and production (Release). It is easy to create additional build configurations to support multiple environments via transforms. Unfortunately, not everything can be handled in web.config files many settings need to be changed in xml or other \"config\" files. Also, this functionality is needed in other project types - most notably SharePoint 2010 projects."
                },
                new Idea
                {
                    Title = "Bring back Macros",
                    Description = "I am amazed you've decided to remove Macros from Visual Studio. Not only are they useful for general programming, but they're a great way to be introduced to the Visual Studio APIs. If you are unwilling to put in the development time towards them, please release the source code and let the community maintain it as an extension."
                },
                new Idea
                {
                    Title = "Open source Silverlight",
                    Description = @"For all intents and purposes Microsoft now views Silverlight as “Done”. While it is no longer in active development it is still being “supported” through to 2021 (source). 
                      However there is still a section of the .Net community that would like to see further development done on the Silverlight framework. "
                },
                new Idea
                {
                    Title = "Native DirectX 11 support for WPF",
                    Description = "in 2013 WPF still work on DX9, and this have a lot of inconvenience. First of all it is almost impossible to make interaction with native DX11 C++ and WPF. Axisting D3DImage class support only DX 9, but not higher and for now it is a lot of pain to attach DX 11 engine to WPF. Please, make nativa support for DX 11 in WOF by default and update D3DImage class to have possibility to work with nativa C++ DX 11 engine and make render directly to WPF control(controls) without pain with C++ dll."
                },
                new Idea
                {
                    Title = "Make WPF open-source and accept pull-requests from the community",
                    Description = "Please follow the footsteps of the ASP .NET team and make WPF open-source with the source code on GitHub, and accept pull-requests from the community."
                },
                new Idea
                {
                    Title="Fix 260 character file name length limitation",
                    Description = "Same description as here: http://visualstudio.uservoice.com/forums/121579-visual-studio/suggestions/2156195-fix-260-character-file-name-length-limitation"
                },
                new Idea
                {
                    Title = "Support for ES6 modules",
                    Description = "Add support for the new JavaScript ES6 module syntax, including module definition and imports."
                },
                new Idea
                {
                    Title = "Create a \"remove all remnants of Visual Studio from your system\" program.",
                    Description = "I'm writing this on behalf of the thousands of other Visual Studio users out there who have had nightmares trying to uninstall previous versions of VS. Thus cumulatively losing hundreds of thousands of productive work hours."
                }
           };

                var rnd = new Random();
                for (int i = 0; i < ideasList.Length; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        string commentContent = "Some comment " + (i + j).ToString();
                        string commentIp = "111.111." + (i + j).ToString();
                        var comment = new Comment
                        {
                            Content = commentContent,
                            AuthorIp = commentIp
                        };

                        ideasList[i].Comments.Add(comment);
                    }
                    for (int k = 0; k < 100; k++)
                    {
                        var voteValue = rnd.Next(1, 4);
                        var voteIp = rnd.Next(100000000, 999999999);
                        var voteIpString = voteIp.ToString().Insert(2, ".");
                        voteIpString = voteIpString.Insert(5, ".");

                        var vote = new Vote
                        {
                            Points = voteValue,
                            VoterIpAddress = voteIpString
                        };

                        ideasList[i].Votes.Add(vote);
                    }
                }

                context.Ideas.AddOrUpdate(ideasList);
            }
        }
    }
}
