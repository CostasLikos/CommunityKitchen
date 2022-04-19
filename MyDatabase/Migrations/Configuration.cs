namespace MyDatabase.Migrations
{
    using Entities;
    using Entities.IdentityModel;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyDataBase.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyDataBase.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            Random random = new Random();

            var causes = CauseSeed();
            var events = EventSeed();
            var items = ItemSeed();
            if (!context.Causes.Any())
            {
                context.Causes.AddRange(causes);
            }
            if (!context.Events.Any())
            {
                context.Events.AddRange(events);
            }
            if (!context.Items.Any())
            {
                context.Items.AddRange(items);
            }

            if (!context.Roles.Any())
            {
                var userRoles = UserRoles();
                foreach (var role in userRoles)
                {
                    context.Roles.Add(role);
                }
            }


            if (!context.Users.Any(u => u.UserName == "DateChangedInfo@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(store);

                var passwordHash = new PasswordHasher();
                var user = new ApplicationUser()
                {
                    UserName = "DateChangedInfo@gmail.com",
                    Email = "DateChangedInfo@gmail.com",
                    PasswordHash = passwordHash.HashPassword("321SAdmin!")
                };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "SuperAdmin");
            }
            if (!context.Users.Any(u => u.UserName == "IreceiveNotice@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(store);

                var passwordHash = new PasswordHasher();
                var user = new ApplicationUser()
                {
                    UserName = "IreceiveNotice@gmail.com",
                    Email = "IreceiveNotice@gmail.com",
                    PasswordHash = passwordHash.HashPassword("321Member!")
                };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Member");
            }
            if (!context.Users.Any(u => u.UserName == "organizer2@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(store);

                var passwordHash = new PasswordHasher();
                var user = new ApplicationUser()
                {
                    UserName = "organizer2@gmail.com",
                    Email = "organizer2@gmail.com",
                    PasswordHash = passwordHash.HashPassword("Organizer21234!")
                };
                userManager.Create(user);

                context.SaveChanges();

                userManager.AddToRole(user.Id, "Admin");
                context.SaveChanges();
            }
            if (!context.Users.Any(u => u.UserName == "organizer@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(store);

                var passwordHash = new PasswordHasher();
                var user = new ApplicationUser() { UserName = "organizer@gmail.com", Email = "organizer@gmail.com", PasswordHash = passwordHash.HashPassword("Organizer1234!") };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Admin");
            }

            List<ApplicationUser> myUsers = new List<ApplicationUser>();
            myUsers.AddRange(context.Users.Where(x => x.Email == "organizer@gmail.com").ToList());
            myUsers.AddRange(context.Users.Where(x => x.Email == "organizer2@gmail.com").ToList());


            if (context.Events.All(x => x.Moderator == null))
            {
                foreach (var eve in events)
                {
                    var index = random.Next(0, 2);
                    eve.Moderator = myUsers[index];
                }
            }
            if (context.Causes.All(x => x.Moderator == null))
            {
                foreach (var cau in causes)
                {
                    var index = random.Next(0, 2);
                    cau.Moderator = myUsers[index];
                }
            }

            if (context.Items.All(x => x.Moderator == null))
            {
                foreach (var item in items)
                {
                    var index = random.Next(0, 2);
                    item.Moderator = myUsers[index];
                }
            }
            context.SaveChanges();
        }
        public List<Cause> CauseSeed()
        {
            List<Cause> causes = new List<Cause>()
            {
              new Cause() {Title = "Help The Poor",Description="Raising money for our poor friends",FullDescription="In every corner of some streets in Athens, Larisa and other big cities of Greece you will find people who need your help. " +
              "You can help now reduce the pain of those people in need of the basic things to be able to live and function normally, so that they can get back on their feet, be able to get employed and see their life turn for good. Any help towards that target is more than welcome.",TargetGoal=150,CurrentAmmount=25 , Photo = "106052.jpg"},
              new Cause() {Title = "Those Who Have Can Share",Description="Help your fellow people by offering them something, you are going to feel better!",FullDescription="We are raising funds for the people in our neighboorhoods who are struggling with their own personal situations weather it is " +
              "health issues, better housing, or just enough money to go to the grocery store. Do you think you can tip and help on our purpose?",TargetGoal=210,CurrentAmmount=75, Photo = "6646987.jpg" },
              new Cause() {Title = "Food For The Homeless",Description="Help us offer them a warm meal",FullDescription="Over 33% of people visit food-sharing programs annually. When one considers the subcategory of homeless individuals and other at-risk populations, hunger is too prevalent to quantify. " +
              "Inadequate nourishment directly results in innumerable physical, mental, and emotional health consequences that lead to heavy cost burdens, further health concerns, and even&nbsp;death. Addressing hunger is a moral imperative, which draws in thousands of volunteers who feel compelled to help their " +
              "neighbors in need. Will you be one of them and help us offer them a warm meal?",TargetGoal=110,CurrentAmmount=32 , Photo = "food-donation.jpg" },
              new Cause() {Title = "Clothing For The Poor",Description="Raise money to buy clothes for the poor",FullDescription="Firstly, we are doing this for people that feel excluded from society because they are poor. The lack of clothes is among the reasons that prevent children from poor communities from going to school and thus increases the" +
              " school drop-out rate.Through our effort more clothes will be purchased even from thrift-stores and will be donated to people in need and thus you will be able to contribute to reducing the school drop-out rate in greek society and to making people of all ages be warm through the winter. We are doing this for the donors, who will be able to actively contribute to make our community a " +
              "better place, from the comfort of their home.They will feel that they are not alone, but part of a bigger community with the same goals – reduce poverty and see more people smiling :).",TargetGoal=350,CurrentAmmount=110, Photo = "clothing.jpg" },
              new Cause() {Title = "Build A Shelter For Stray Animals",Description="Help us build a warm house for dozens of stray animals that need your help now",FullDescription="At Nauplio, in a beautiful location, a model animal shelter will be created with love and care that will " +
              "be housing our stray companions. The shelter will offer each animal its own individual accommodation, will have a fully equipped clinic for first aid, neutering, vaccination and temporary hospitalization. The animals will be taken care of within our premises until they are adopted or alternatively, " +
              "they will be set free into their natural environment, neutered and in good health. We aspire for 'Love Shelter' to evolve into a center which will teach how to treat animals with respect and moreover become a hub of communication for all animal lovers. Donate now and help us fulfill that beautiful dream!",TargetGoal=23000,CurrentAmmount=5200, Photo = "doggo.jpg" },
              new Cause() {Title = "Help Victims Of Wildfires",Description="The Greek arm of the Red Cross is providing financial support and food for those affected by the fires",FullDescription="Three wildfires have displaced hundreds of " +
              " of people and destroyed many homes. So far, dozens of people have been confirmed dead and hundreds more are missing. Vast expanses of land have been scorched in Northern Greece by the Camp Fire — " +
              "the deadliest and most destructive wildfire in the country’s history — and in Southern Peloponhssos, as well. They need your help!",TargetGoal=10000,CurrentAmmount=50, Photo = "fire.jpg"  },
              new Cause() {Title = "Support The Ukrainian War Immigrants",Description="Everyday more and more war immigrants need your help, help us gather money and help them stand in their feet",FullDescription="We are heartbroken by the horrible suffering the Ukrainian people are enduring, and support legal protections for those already in the country, as well as increased resettlement of Ukrainian refugees in Greece. " +
              "We target on providing protection and humanitarian assistance, including emergency shelter, relief items such as blankets, and protection such as psychological support. Donations are urgently needed to help refugees from Ukraine and other displaced people. Do you think you can help on our cause?",TargetGoal=20000,CurrentAmmount=9850, Photo = "war.jpg"  },
              new Cause() {Title = "Help Victims Of Floods",Description="Help us provide for the victims of floods",FullDescription="The catastrophic results of the recent flooding in the areas of Northern Greece need to be addressed. We know from previous floods that as soon as the water recedes, flood-affected areas will be inundated with well-meaning volunteers wanting to help with the clean-up. \nBut although this volunteer effort is " +
              "welcome in some ways, it can also be challenging for flood impacted people to manage and absorb. A great way to help will always be the financial support tho the afflicted people. They need any help they can get. Can you help us on our cause to support them?",TargetGoal=350,CurrentAmmount=50, Photo = "flood.jpg"  },
              new Cause() {Title = "Support The Organization: Save The Children",Description="We strongly support the non-profitable organization 'Save The Children'",FullDescription="When you give to Save the Children, your money goes straight to our mission to provide lifesaving relief to children; With your money; \nWe can provide enough food to keep children from going hungry for a month. " +
              "\nWe can wrap warm, cozy blankets around children affected by conflict. \nWe can provide face masks to refugee health workers on the front lines. \nWith your support, we help the 'Save The Children' organization to continue their work to keep children in the Greece healthy, educated and safe.",TargetGoal=500,CurrentAmmount=100, Photo = "children.jpg"  },
              new Cause() {Title = "Support The Organization: To Hamogelo Tou Paidiou",Description="We strongly support the non-profitable organization 'To Hamogelo Tou Paidiou'",FullDescription="'To Hamogelo Tou Paidiou' (translated as 'The Smile of a Child') was created in 1995 by 10-year-old Andreas Yannopoulos, who, shortly before departing from life, expressed in his diary his " +
              "wish to found an organization that will make sure that all children will have what he had so generously enjoyed: love, affection, care and respect. \nThe dream of 10-year-old Andreas became reality and today the Organization 'To Hamogelo Tou Paidiou', recognized internationally, with a Vision: the Smile of every child, implements nationwide, 365 days a year and 24 hours a day, " +
              "effective and direct actions for preventing and addressing particular phenomena that threaten children. \nIn the course of 23 years of action 'The Smile of the Child' has supported more than 1.480.000 children and their families. Children victims of any form of violence, missing children, children with health problems, children living in poverty or threatened by poverty, have found a solution." +
              " \nDonate now and let's support this pursue of children's smile together.",TargetGoal=600,CurrentAmmount=250, Photo = "kostas.jpg"  },
              new Cause() {Title = "Help Elena To Beat Cancer",Description="Support Elena a true fighter, to overcome her illness, we gather money for her surgery.",FullDescription="Our dear friend Elena was recently diagnosed with bone cancer. We are fundraising to help cover ct/pet scans, chemo, extensive surgery, prosthetics and physical therapy. Insurance will only cover a small part of the medical bills and we want to alleviate the " +
              "financial burden so that her family Emily can just focus on Elena. Your prayers and financial support are greatly appreciated! ",TargetGoal=870,CurrentAmmount=850, Photo = "elena.jpg"  },
              new Cause() {Title = "Help us get clothing At Melenikou St, Thessaloniki",Description="Help us efficiently provide clothing to those in need and get warm smiles in return!",FullDescription="We are asking for your finanial support to provide money for the homeless and needy people of Thessaloniki. The clothing purchased with this money will help" +
              "make sure that the poor people of Thessaloniki will have what they need to pass the winter and not suffer from the cold. We are happy for every contribution. Each dollar matters!",TargetGoal=1250,CurrentAmmount=500, Photo = "6994869.jpg"  },
              new Cause() {Title = "Support Ukraine",Description="In co-operation with the Greek embassy in Ukraine we provide help to the non-profitable org. Support Ukraine",FullDescription="According to the UN human rights office, 136 civilians have died in the war on Ukraine so far. But it acknowledges that the figure is probably much higher. \nThese deaths may have occurred directly – collateral damage to the fighting – " +
              "but war affects people’s health beyond bullets and bombs. Some deaths are not combat-related but the result of the wider effects of conflict on public health – effects that linger long after the war has ended. The Russian invasion of Ukraine could bring with it catastrophic suffering and health consequences for the civilian population. \n\nWars are complex health emergencies. They lead to the breakdown of society, " +
              "cause considerable damage and destruction to infrastructure, create insecurity and have a significant economic impact. We are here to help reduce those consequences by providing emoptional and financial support. Help us help them!",TargetGoal=800,CurrentAmmount=500, Photo = "ukraine.jpg"  },
              new Cause() {Title = "Help The Homeless",Description="Help those with nothing start fresh",FullDescription="Nobody wants to become homeless. It is a state that no one chooses. But some people have experienced it already, some made it through to a better life, some have not been there yet. \nHelping an individual that lost the comfort " +
              "of their house feel appreciated, supported and encouraged is always a great way of helping your society become a better place. It gives you a sense of purpose and sets a good example. \nDo you want to be one of those who help" +
              "turn people's destiny? We are here to recieve and give back to them any help they can get. You can help our brothers on the street now by joining us on our cause.",TargetGoal=750,CurrentAmmount=500, Photo = "homeless.jpg"  },
              new Cause() {Title = "Support The Victims Of Tornado Martha",Description="We support the victims of tornado to recover from this hardship",FullDescription="The devastating results of tornado Martha at the areas of middle Greece has given us a new goal and perspective. To help the afflicted by it and encourage them any way we can." +
              "After seeing destroyed homes and people who have lost everything, while we may be tempted to donate clothing, food, bottled water or other supplies, truth is that a financial donation can be spent on what is needed most at that particular moment. We appreciate your help!",TargetGoal=950,CurrentAmmount=500, Photo = "tornado.jpg"  }
            };
            return causes;
        }
        public List<Event> EventSeed()
        {
            List<Event> events = new List<Event>()
            {
              new Event() {Title = "Agiou Meletiou Charity Meal",Description="Offering meals at Agiou Meletiou Street",FullDescription="We are happy to announce that a new event is organized for the help of the hungry people of any age and ethnicity, on Thursday, 12th of May, at Agiou Meletiou Street in Pagrati, Athens. " +

              "Warm food will be served with the money we gathered through our Causes and every available volunteer from our team. Any help, even in the form of your simple presence in there, will be welcome and greatly appreciated. The food needs to be " +

              "distributed to the needy ones with love and a healthy attitude of encouragement. As we always say, the more the merrier!",Address="Agiou Meletiou 32, Athens, Pagrati 12443",
                  EventDate=new DateTime(2022,05,12), Photo = "food1.jpg"},
              new Event() {Title = "St.Nicolas Church Food Festival",Description="Offering meals at St.Nicolas Church",FullDescription="St. Nicolas Church is opening its doors on May, Saturday the 7th! We would like to invite all of you to this amazing" +
              " and selfless action, a community gathering with one goal. Feed as many people as we can! We will happily accept any sort of help, while your participation will keep our team encouraged and support the will of the event openers to organize more" +
              " heart-warming and thoughtful festivals such as this! Make sure you're there!",Address="Stratarxou Karaiskaki 22, Athens, Haidari 12461",
                  EventDate=new DateTime(2022,05,07), Photo = "food2.jpg" },
              new Event() {Title = "Bazaar Of Poor Souls",Description="Open Market to support the poor",FullDescription="The Bazaar of Poor Souls, organized this time in the center of Egaleo, is an action of concern and an effort of support the people who cannot afford the basics, to have a chance to find good things for free or at the lowest price possible." +
              "If you have items of good condition that will be proved useful to the poor community you can always bring them with you when you come. And always remember, when you have nothing else to give, a warm hug will always be helpful! See you there :)",Address="Dwdwkanisou 62, Athens, Egaleo 12364",
                  EventDate=new DateTime(2022,04,05), Photo = "bazaar.jpg" },
              new Event() {Title = "Lending A Hand At Dervenakion St",Description="Free grooming for poor people",FullDescription="Are you a hairdresser? Do you think you can find some spare time on Sunday, the 5th of June? We have news for you! Our team has organized a very 'delicate' event where your skills will be needed!" +
              " \n We are grooming poor people that cannot afford a new haircut and a fresh shave. Many people struggle in getting employeed because of the way they look - unfortunately, not many people offer work to homeless-looking men or women. So we are all called to help! We are inviting any good doer who can support our effort with his " +
              "or her skills, or just as an encouraging figure, to our event. Even if you do not possess any hairdressing skills, we are calling you to hang out with us and watch our friends' lives be transformed by small actions of good, such as a single haircut. Will you join us?",Address="Dervenakiwn 87, Athens, Peristeri 12452",
                  EventDate=new DateTime(2022,05,30), Photo = "grooming2.jpg" },
              new Event() {Title = "Lending A Hand At Iroon Politehniou St ",Description="Free grooming for poor people",FullDescription="If you are a hairdresser and you think you can find some spare time this weekend, on Saturday the 22nd of April, we have some news for you! We are inviting you to another 'delicate' event where your skills will be helpful and vastly appreciated." +
              " \n We are grooming poor people that cannot afford a new haircut and a fresh shave. Many people struggle in getting employeed because of the way they look - unfortunately, not many people offer work to homeless-looking men or women. We are called to help. You and any other good doer, is invited on this appealing event, along with anyone else who can support our effort with his " +
              "or her skills or just as an encouraging presence on your own. Even if you do not possess any hairdressing skills, we are calling you to hang out with us as we see our friends' lives get transformed by small actions of good, such as a fresh haircut! Will you be there?",Address="Iroon Politehniou 27, Athens, Hilioupolis 12452",
                  EventDate=new DateTime(2022,08,23), Photo = "grooming.jpg" },
              new Event() {Title = "Soup Kitchen At Iroon Square",Description="Offering free meals at Plateia Iroon in Chaidari from 12:00 to 18:00.",FullDescription="Another Soup Kitchen event is opening in our city, at Chaidari this time, as a fresh start for the week on Monday the 6th of June. People who can help with the distribution of the meals will be" +
              "gratefully welcomed, along with those who have food to offer or any kind of help as well, including emotional! We are expecting to see happy faces unite and serve our poor brothers in understanding and in love, knowing that we could've been in their own shoes. We wholeheartedly ask for your participation and we will be glad to see you there! You coming?",
                  Address="Pl. Ir. 1940 41, Chaidari 124 61",EventDate=new DateTime(2022,06,06), Photo = "7551595.jpg" },
              new Event() {Title = "Share meal-boxes at Amerikis Square",Description="Offering free meal-boxes at Plateia Amerikis in Athens from 14:00 to 18:00",FullDescription="We are happy to invite you on Monday the 5th of September, at Plateia Amerikis in Athens, to our loving meal-sharing event! " +
              "It's a simple giveaway of meal-boxes filled with love, compassion and nutritional snacks that we can provide with the money we've raised, to the people that need it. The distribution will be according to people's need and we would like you to participate and help us feed the hungry. \nIf you, yourself, are in need or you know people who are," +
              " you can always come and get served by us since helping every single person means a lot to us. We will be happy to see you there!",
                  Address="Amerikis Square, Athens 112 52",EventDate=new DateTime(2022,09,05), Photo = "foodbox.jpg" },
              new Event() {Title = "Soup Kitchen at Kanigos Square",Description="Offering free meals at Plateia Kaniggos in Athens from 13:00 to 17:00",FullDescription="One more Soup Kitchen is opening its arms at Kanigos Square on Sturday, 5th of August, and we are excited for this!" +
              " \nPeople from all over the city who require nutritional and emotional support are invited, and our team will do its best to make sure all meals will be equally and peacefully distributed to the ones in need." +
              " \n If you have a heart for those who are needy and want to help, you are gladly called to join our event and show your support by helping our team feed the people or even by supporting our cause and showing support towards our common goal. \nLet's help each other!",
                  Address="Akadimias 92, Athens 106 77",EventDate=new DateTime(2022,08,05), Photo = "soup1.jpg" },
              new Event() {Title = "Open Kitchen at Omonia Square",Description="Offering free meals at Plateia Omonoias in Athens from 12:00 to 17:00",FullDescription="An Open Kitchen event is being organized by our charity on the 12th of October and we would like to see you there." +
              " \nPeople in need from the neighboorhoods of Monastiraki, Omonia and other parts of Athens that are closeby will be invited to enjoy a free meal and see a warm smile. We will be there, always on the frontline, sharing freshly cooked meals with our " +
              " less fortunate friends and we would like to see you there as well! If you are not in need of such treatment, but you have it in your heart to help the poor, we are inviting you to join our team to share free meals with the participants. Are you coming?",
                  Address="Square, District of Freedom 8573311, Athens 104 31",EventDate=new DateTime(2022,10,12) , Photo = "openkitchen.jpg"},
              new Event() {Title = "Soup Kitchen at Exarcheia Square",Description="Offering free meals at Plateia Exarcheion in Athens from 15:00 to 19:00",FullDescription="Free meals on Friday,2nd of September, will be distributed at the infamous Plateia Exarcheion in the center of Athens and we " +
              "will be glad to see you there. We are encouraging anyone that finds themselves on a tough spot, to come and enjoy a warm meal that our kitchen will be offering on that date for free. You are more than welcome to invite people that need that kind of help" +
              "and we will do our best to serve them as well, until the pots are squicky clean! \n If by any chance you have nothing better to do on that date, consider passing by to say hi, or even better, to help us and support eevn with your presence there on our purpose; To share love anyway we can!",
                  Address="Stournari 5, Athens 106 83",EventDate=new DateTime(2022,09,02), Photo = "soup2.jpg"  },
              new Event() {Title = "Soup Kitchen at Karaiskaki Square",Description="Offering free meals at Plateia Karaiskaki in Athens from 12:00 to 18:00",FullDescription="As Soup Kitchen events become more and more successful, we decided to organize another one in such a small amount of time form the previous one " +
              "which was a great success! This time, at Plateia Karaiskaki on the 4th of June, the menu will include freshly reaped vegetables that we will add in our meals, to serve an even more nutritious and tasty meal to our poor friends. " +
              "\n People in need - of any race, age and identity - are more than welcome to be served and enjoy our food, and in the meantime we will be happy to see people who come to simply help us on our cause; To spread the love in a form of a well-prepared meal and see happy smiles on people's faces." +
              " \nWill you join us?",
                  Address="Pl. Karaiskaki, Athens 104 37",EventDate=new DateTime(2022,06,04), Photo = "soup3.jpg"  },
              new Event() {Title = "Soup Kitchen at Kolonaki Square",Description="Offering free meals at Plateia Kolonakiou in Athens from 13:00 to 15:00",FullDescription="We are happy to announce one more upcoming 'Soup Kitchen' event, this time at Plateia Kolonakiou on the 6th of August!" +
              " \nAs always, our team will be there to help, support and serve the poorrer community of Athens with freshly-cooked meals and a loving attitude. Anyone who finds themselves free of time on that date can join us and help us" +
              "share our love in the form of meals faster, more efficient and happier. Remember the more, the merrier! We are expecting you!",
                  Address="Pl. Filikis Eterias 11, Athens 106 74",EventDate=new DateTime(2022,08,06), Photo = "soup4.png"  },
              new Event() {Title = "Soup Kitchen at Syntagma Square",Description="Offering free meals at Plateia Syntagmatos in Athens from 12:00 to 15:00",FullDescription="As Soup Kitchen events tend to gather a lot of needy people, we happily announce the upcoming one which will be at Plateia Syntagmatos, on June the 6th, by our Team." +
              "\nFree meals will be once more distributed to the people who need them, while new friendships will bloom up as we meet new people every time. We will be glad to see you join us, weather in need of a meal or just to show your emotional or physical support!" +
              " After all, seeing  that our purpose is being served, we will more cheerfully organize the next upcoming Soup Kitchen events and find relief in the fact that our efforts keep reaching their target; To help as many as we can." +
              "\n Are you coming?",
                  Address="Pl. Sintagmatos, Athens 105 63",EventDate=new DateTime(2022,06,06), Photo = "soup5.jpg"  },
              new Event() {Title = "Soup Kitchen at Davaki Square",Description="Offering free meals at Plateia Davaki in Kallithea from 13:00 to 17:00",FullDescription="Upcoming Soup Kitchen event on the 5th of May, at Kallithea." +
              "\n Our Team once more organized a people-feeding event, so that our less fortunate friends will be able to enjoy a warm meal in the midst of this cold spring. Any good doers and cooks that find themselves available on that date would be welcome to join us and " +
              "anyone that find themselves in need of a meal is gladly welcomed. Meet people, serve people, love people. That's our moto once more!",
                  Address="Mantzagriotaki 68, Kallithea 176 72",EventDate=new DateTime(2022,05,05), Photo = "soup6.jpg"  },
              new Event() {Title = "Lending A Hand At Cross Square",Description="Free grooming for poor people at Plateia Estavromenoy in Egaleo from 12:00 to 18:00",FullDescription="If you are a hairdresser and you think you can find some spare time this weekend, on Saturday the 22nd of April, we have some news for you! We are inviting you to another 'delicate' event where your skills will be helpful and vastly appreciated." +
              " \n We are grooming poor people that cannot afford a new haircut and a fresh shave. Many people struggle in getting employeed because of the way they look - unfortunately, not many people offer work to homeless-looking men or women. We are called to help. You and any other good doer, is invited on this appealing event, along with anyone else who can support our effort with his " +
              "or her skills or just as an encouraging presence on your own. Even if you do not possess any hairdressing skills, we are calling you to hang out with us as we see our friends' lives get transformed by small actions of good, such as a fresh haircut! Will you be there?",
                  Address="Dimarchiou 1, Egaleo 122 42",EventDate=new DateTime(2022,11,06), Photo = "grooming3.jpg"  }
            };
            return events;
        }

        //public List<Cause> CauseSeed()
        //{
        //    List<Cause> causes = new List<Cause>()
        //    {
        //      new Cause() {Title = "Help The Poor",Description="Raising money for our poor friends",TargetGoal=150,CurrentAmmount=25 , Photo = "106052.jpg"},
        //      new Cause() {Title = "Those Who Have Can Share",Description="Help your fellow people by offering them something, you are going to feel better!",TargetGoal=210,CurrentAmmount=75, Photo = "6646987.jpg" },
        //      new Cause() {Title = "Food For The Homeless",Description="Help us offer them a warm meal",TargetGoal=110,CurrentAmmount=32 , Photo = "food-donation.jpg" },
        //      new Cause() {Title = "Clothing For The Poor",Description="Raise money to buy clothes for the poor",TargetGoal=350,CurrentAmmount=110, Photo = "clothing.jpg" },
        //      new Cause() {Title = "Build A Shelter For Stray Animals",Description="Help us build a warm house for dozens of stray animals that need your help now",TargetGoal=23000,CurrentAmmount=5200, Photo = "doggo.jpg" },
        //      new Cause() {Title = "Help Victims Of Wildfires",Description="The Greek arm of the Red Cross is providing financial support and food for those affected by the fires",TargetGoal=10000,CurrentAmmount=50, Photo = "fire.jpg"  },
        //      new Cause() {Title = "Support The Ukrainian War Immigrants",Description="Everyday more and more war immigrants need your help, help us gather money and help them stand in their feet",TargetGoal=20000,CurrentAmmount=9850, Photo = "war.jpg"  },
        //      new Cause() {Title = "Help Victims Of Floods",Description="Help us provide for the victims of floods",TargetGoal=350,CurrentAmmount=50, Photo = "flood.jpg"  },
        //      new Cause() {Title = "Support The Organization: Save The Children",Description="We strongly support the non-profitable organization save the children",TargetGoal=500,CurrentAmmount=100, Photo = "children.jpg"  },
        //      new Cause() {Title = "Support The Organization: Hamogelo Tou Ppaidiou",Description="We strongly support the non-profitable organization hamogelo tou paidiou",TargetGoal=600,CurrentAmmount=250, Photo = "kostas.jpg"  },
        //      new Cause() {Title = "Provide For Those In Need",Description="After the resent events more and more come in need, help them to stand on their feet",TargetGoal=500,CurrentAmmount=250, Photo = "helpgreeks2.jpg"  },
        //      new Cause() {Title = "Help Elena To Beat Cancer",Description="Support Elena a true fighter, to overcome her illness, we gather money for her surgery",TargetGoal=870,CurrentAmmount=850, Photo = "elena.jpg"  },
        //      new Cause() {Title = "Volunteer in sharing clothing At Melenikou St, Thessaloniki",Description="Help us efficiently distribute clothing to those in need and get warm smiles in return!",TargetGoal=1250,CurrentAmmount=500, Photo = "6994869.jpg"  },
        //      new Cause() {Title = "Support Ukraine",Description="In co-operation with the Greek embassy in Ukraine we provide help to the non-profitable org. Support Ukraine",TargetGoal=800,CurrentAmmount=500, Photo = "ukraine_get_help_red_cross.jpg"  },
        //      new Cause() {Title = "Help The Homeless",Description="Help those with nothing start fresh",TargetGoal=550,CurrentAmmount=500, Photo = "homeless.jpg"  },
        //      new Cause() {Title = "Support The Victims Of Tornado Martha",Description="We support the victims of tornado to recover from this hardship",TargetGoal=950,CurrentAmmount=500, Photo = "tornado.jpg"  }
        //    };
        //    return causes;
        //}
        //public List<Event> EventSeed()
        //{
        //    List<Event> events = new List<Event>()
        //    {
        //      new Event() {Title = "Agiou Meletiou Charity Meal",Description="Offering meal at Agiou Meletiou street",Address="Agiou Meletiou 32, Athens, Pagrati 12443",
        //          EventDate=new DateTime(2022,04,05), Photo = "food1.jpg"},
        //      new Event() {Title = "St.Nicolas Church Food Festival",Description="Offering meal St.Nicolas Church",Address="Stratarxou Karaiskaki 22, Athens, Haidari 12461",
        //          EventDate=new DateTime(2022,05,07), Photo = "food2.jpg" },
        //      new Event() {Title = "Bazaar Of Poor Souls",Description="Open Market to support the poor",Address="Dwdwkanisou 62, Athens, Egaleo 12364",
        //          EventDate=new DateTime(2022,04,05), Photo = "bazaar.jpg" },
        //      new Event() {Title = "Lending A Hand At Dervenakion St",Description="Free grooming for poor people",Address="Dervenakiwn 87, Athens, Peristeri 12452",
        //          EventDate=new DateTime(2022,06,05), Photo = "grooming2.jpg" },
        //      new Event() {Title = "Lending A Hand At Iroon Politehniou St ",Description="Free grooming for poor people",Address="Iroon Politehniou 27, Athens, Hilioupolis 12452",
        //          EventDate=new DateTime(2022,02,05), Photo = "grooming.jpg" },
        //      new Event() {Title = "Soup Kitchen At Iroon Square",Description="Offering free meals at Plateia Iroon in Chaidari from 12:00 to 18:00.",
        //          Address="Pl. Ir. 1940 41, Chaidari 124 61",EventDate=new DateTime(2022,06,06), Photo = "7551595.jpg" },

        //      new Event() {Title = "Share meal-boxes at Amerikis Square",Description="Offering free meal-boxes at Plateia Amerikis in Athens from 14:00 to 18:00",
        //          Address="Amerikis Square, Athens 112 52",EventDate=new DateTime(2022,09,05), Photo = "foodbox.jpg" },

        //      new Event() {Title = "Soup Kitchen at Kanigos Square",Description="Offering free meals at Plateia Kaniggos in Athens from 13:00 to 17:00",
        //          Address="Akadimias 92, Athens 106 77",EventDate=new DateTime(2022,08,05), Photo = "soup1.jpg" },

        //      new Event() {Title = "Open Kitchen at Omonia Square",Description="Offering free meals at Plateia Omonoias in Athens from 12:00 to 17:00",
        //          Address="Square, District of Freedom 8573311, Athens 104 31",EventDate=new DateTime(2022,10,12) , Photo = "openkitchen.jpg"},

        //      new Event() {Title = "Soup Kitchen at Exarcheia Square",Description="Offering free meals at Plateia Exarcheion in Athens from 15:00 to 19:00",
        //          Address="Stournari 5, Athens 106 83",EventDate=new DateTime(2022,09,02), Photo = "soup2.jpg"  },

        //      new Event() {Title = "Soup Kitchen at Karaiskaki Square",Description="Offering free meals at Plateia Karaiskaki in Athens from 12:00 to 18:00",
        //          Address="Pl. Karaiskaki, Athens 104 37",EventDate=new DateTime(2022,06,04), Photo = "soup3.jpg"  },

        //      new Event() {Title = "Soup Kitchen at Kolonaki Square",Description="Offering free meals at Plateia Kolonakiou in Athens from 13:00 to 15:00",
        //          Address="Pl. Filikis Eterias 11, Athens 106 74",EventDate=new DateTime(2022,08,06), Photo = "soup4.png"  },

        //      new Event() {Title = "Soup Kitchen at Syntagma Square",Description="Offering free meals at Plateia Syntagmatos in Athens from 12:00 to 15:00",
        //          Address="Pl. Sintagmatos, Athens 105 63",EventDate=new DateTime(2022,06,06), Photo = "soup5.jpg"  },

        //      new Event() {Title = "Soup Kitchen at Davaki Square",Description="Offering free meals at Plateia Davaki in Kallithea from 13:00 to 17:00",
        //          Address="Mantzagriotaki 68, Kallithea 176 72",EventDate=new DateTime(2022,05,05), Photo = "soup6.jpg"  },

        //      new Event() {Title = "Lending A Hand At Cross Square",Description="Free grooming for poor people at Plateia Estavromenoy in Egaleo from 12:00 to 18:00",
        //          Address="Dimarchiou 1, Egaleo 122 42",EventDate=new DateTime(2022,06,06), Photo = "grooming3.jpg"  }
        //    };
        //    return events;
        //}

        public List<Item> ItemSeed()
        {
            List<Item> items = new List<Item>()
            {
                new Item() {Id = Guid.NewGuid(), ItemName = "Makaronia",Quantity = 3,Price=1.95m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Aggouria",Quantity = 1,Price=1.7m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Ntomates",Quantity = 4,Price=1.5m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Feta",Quantity = 1,Price=3.95m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Orange Juice",Quantity = 1,Price=1.85m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Water",Quantity = 2,Price=1.75m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Chicken",Quantity = 3,Price=1.95m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Beef",Quantity = 1,Price=2.95m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Salt",Quantity = 5,Price=0.75m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Flour",Quantity = 1,Price=1.15m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Canned Tomatoes",Quantity = 4,Price=4.10m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Tost Bread",Quantity = 6,Price=2.10m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Canned Beans",Quantity = 3,Price=2.40m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Canned Tuna",Quantity = 7,Price=1.80m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Canned Vegetables",Quantity = 6,Price=1.30m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Milk",Quantity = 4,Price=3.10m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Beer",Quantity = 8,Price=1.70m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Bottled Water",Quantity = 8,Price=0.90m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Sprinkling Water",Quantity = 9,Price=1.20m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Potatoes",Quantity = 15,Price=1.30m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Bread",Quantity = 10,Price=1.10m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Chicken Noodles",Quantity = 15,Price=0.60m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Beef Noodles",Quantity = 15,Price=0.60m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Oatmeal",Quantity = 3,Price=0.95m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Peanut Butter Jar",Quantity = 3,Price=0.95m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Powdered milk",Quantity = 3,Price=1.95m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Rice",Quantity = 1,Price=0.95m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Pink Salt",Quantity = 1,Price=0.55m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Oregano",Quantity = 1,Price=0.55m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Pepper",Quantity = 1,Price=0.55m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Coriander",Quantity = 1,Price=0.55m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Garlic powder",Quantity = 1,Price=0.55m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Bay leaves",Quantity = 1,Price=0.55m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Paprika",Quantity = 1,Price=0.55m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Cumin",Quantity = 1,Price=0.55m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Chili powder",Quantity = 1,Price=0.55m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Red Wine",Quantity = 4,Price=5.30m},
                new Item() {Id = Guid.NewGuid(), ItemName = "White Wine",Quantity = 2,Price=4.30m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Baby Potatoes",Quantity = 15,Price=1.50m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Spinach",Quantity = 7,Price=0.80m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Lettuce",Quantity = 9,Price=0.90m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Water Mellon",Quantity = 6,Price=2.30m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Mellon",Quantity = 6,Price=1.60m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Coca-Cola",Quantity = 12,Price=0.70m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Pepsi-Cola",Quantity = 12,Price=0.70m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Vikos-Cola",Quantity = 12,Price=0.70m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Chocolate",Quantity = 8,Price=1.70m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Tea",Quantity = 9,Price=0.60m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Orange Juice",Quantity = 3,Price=1.20m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Lemon Juice",Quantity = 2,Price=1.20m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Mash Tomato",Quantity = 4,Price=1.20m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Olive Oil",Quantity = 2,Price=4.20m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Sunflower Oil",Quantity = 2,Price=1.20m},
                new Item() {Id = Guid.NewGuid(), ItemName = "Onion",Quantity = 7,Price=1.60m},
                new Item() {Id = Guid.NewGuid(), ItemName= "Red Sugar",Quantity=1,Price=0.60m}

            };
            return items;
        }
        public void CreateRoles(MyDataBase.ApplicationDbContext context)
        {
            // ***** New Role ***** \\
            if (!context.Roles.Any(r => r.Name == "Guest"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole() { Name = "guest" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "SuperAdmin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole() { Name = "SuperAdmin" };
                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole() { Name = "Admin" };

                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Member"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole() { Name = "Member" };

                manager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "Donor"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole() { Name = "Donor" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(store);

                var passwordHash = new PasswordHasher();
                var user = new ApplicationUser() { UserName = "admin@gmail.com", Email = "admin@gmail.com", PasswordHash = passwordHash.HashPassword("Admin1234!") };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "SuperAdmin");
            }
            if (!context.Users.Any(u => u.UserName == "member@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(store);

                var passwordHash = new PasswordHasher();
                var user = new ApplicationUser() { UserName = "member@gmail.com", Email = "member@gmail.com", PasswordHash = passwordHash.HashPassword("Member1234!") };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Member");
            }
            if (!context.Users.Any(u => u.UserName == "organizer@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(store);

                var passwordHash = new PasswordHasher();
                var user = new ApplicationUser() { UserName = "organizer@gmail.com", Email = "organizer@gmail.com", PasswordHash = passwordHash.HashPassword("Organizer1234!") };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Admin");
            }
        }

        public List<ApplicationUser> RegisteredUsersSeed()
        {
            List<ApplicationUser> users = new List<ApplicationUser>()
        {
            new ApplicationUser() {FirstName="Takis",LastName="Mpompos",Address ="Kratira 12,Athens",UserName="Helper"},
            new ApplicationUser() {FirstName="Balya",LastName="Papaki",Address ="Xomateri 20,Traxanoplagia",UserName="Polar"},
            new ApplicationUser() {FirstName="John",LastName="Doe",Address ="3rd Avenue 112,Manhattan",UserName="Foreigner"}
        };
            return users;
        }
        public List<IdentityRole> UserRoles()
        {
            return new List<IdentityRole>()
            {
                new IdentityRole(){ Name = "Guest" },
                new IdentityRole(){ Name = "SuperAdmin"},
                new IdentityRole(){ Name = "Admin"},
                new IdentityRole(){ Name = "Donor"},
                new IdentityRole(){ Name = "Member"}
            };

        }
    }
}
