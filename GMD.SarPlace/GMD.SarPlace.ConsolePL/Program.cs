using System;
using System.Collections.Generic;
using GMD.SarPlace.Etities;
using GMD.SarPlace.Dependencies;
using GMD.SarPlace.StandartBLL;
using GMD.SarPlace.BLL.Interfaces;

namespace GMD.SarPlace.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            var userBLL = DependencyResolver.Instance.usersLogic;
            var placeBLL = DependencyResolver.Instance.placesLogic;
            var commentBLL = DependencyResolver.Instance.commentsLogic;

            Console.WriteLine("Welcome");
            Console.WriteLine("1 - user");
            Console.WriteLine("2 - place");
            Console.WriteLine("3 - comment");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("1 - Add user");
                    Console.WriteLine("2 - find user");
                    Console.WriteLine("3 - find all users");
                    Console.WriteLine("4 - delete user");
                    Console.WriteLine("5 - edit user");

                    string choice1 = Console.ReadLine();

                    switch (choice1)
                    {
                        case "1":
                            Console.WriteLine("Имя");
                            var crName = Console.ReadLine();
                            Console.WriteLine("Пароль");
                            var crPassword = Console.ReadLine();
                            var check = userBLL.Add(new User(crName, crPassword));

                            Console.WriteLine(check.ToString());

                            Main(args);
                            break;
                        case "2":
                            Console.WriteLine("GUID:");
                            var findId = Console.ReadLine();
                            while (!Guid.TryParse(findId, out var findGuid))
                            {
                                Console.WriteLine("Invalid Guid, please retry");
                                findId = Console.ReadLine();
                            }
                            WriteUser(userBLL.GetById(Guid.Parse(findId)));
                            Main(args);
                            break;
                        case "3":
                            foreach (var user in userBLL.GetAll())
                            {
                                WriteUser(user);
                            }
                            Main(args);
                            break;
                        case "4":
                            Console.WriteLine("GUID:");
                            var removeId = Console.ReadLine();
                            while (!Guid.TryParse(removeId, out var findGuid))
                            {
                                Console.WriteLine("Invalid Guid, please retry");
                                removeId = Console.ReadLine();
                            }
                            userBLL.Remove(Guid.Parse(removeId));
                            Main(args);
                            break;
                        case "5":
                            Console.WriteLine("GUID:");
                            var myId = Console.ReadLine();
                            while (!Guid.TryParse(myId, out var findGuid))
                            {
                                Console.WriteLine("Invalid Guid, please retry");
                                myId = Console.ReadLine();
                            }
                            var toEdit = userBLL.GetById(Guid.Parse(myId));
                            Console.WriteLine("Object to edit");
                            Console.WriteLine(toEdit.ToString());
                            var newEdit = new User(toEdit.ID, toEdit.RegistrationDate, "newtest", "newPass");
                            Console.WriteLine("Object edit to..");
                            Console.WriteLine(newEdit.ToString());
                            userBLL.Edit(newEdit);
                            Console.WriteLine("Result");
                            var edited = userBLL.GetById(Guid.Parse(myId));
                            Main(args);
                            break;
                        default:
                            Main(args);
                            break;
                    }
                    Main(args);
                    break;

                case "2":
                    Console.WriteLine("1 - Add place");
                    Console.WriteLine("2 - find place");
                    Console.WriteLine("3 - find all places");
                    Console.WriteLine("4 - delete place");
                    Console.WriteLine("5 - edit place");

                    string choice2 = Console.ReadLine();

                    switch (choice2)
                    {
                        case "1":
                            Console.WriteLine("Title:");
                            var crTitle = Console.ReadLine();
                            Console.WriteLine("Text:");
                            var crText = Console.ReadLine();
                            Console.WriteLine("User Guid:");
                            var guidUser = Console.ReadLine();
                            while (!Guid.TryParse(guidUser, out var findGuid))
                            {
                                Console.WriteLine("Invalid Guid, please retry");
                                guidUser = Console.ReadLine();
                            }

                            var check = placeBLL.Add(new Place(crTitle, crText, Guid.Parse(guidUser)));

                            Console.WriteLine(check.ToString());

                            Main(args);
                            break;
                        case "2":
                            Console.WriteLine("GUID:");
                            var findId = Console.ReadLine();
                            while (!Guid.TryParse(findId, out var findGuid))
                            {
                                Console.WriteLine("Invalid Guid, please retry");
                                findId = Console.ReadLine();
                            }
                            WritePlace(placeBLL.GetById(Guid.Parse(findId)));
                            Main(args);
                            break;
                        case "3":
                            foreach (var place in placeBLL.GetAll())
                            {
                                WritePlace(place);
                            }
                            Main(args);
                            break;
                        case "4":
                            Console.WriteLine("GUID:");
                            var removeId = Console.ReadLine();
                            while (!Guid.TryParse(removeId, out var findGuid))
                            {
                                Console.WriteLine("Invalid Guid, please retry");
                                removeId = Console.ReadLine();
                            }
                            placeBLL.Remove(Guid.Parse(removeId));
                            Main(args);
                            break;
                        case "5":
                            Console.WriteLine("GUID:");
                            var myId = Console.ReadLine();
                            while (!Guid.TryParse(myId, out var findGuid))
                            {
                                Console.WriteLine("Invalid Guid, please retry");
                                myId = Console.ReadLine();
                            }
                            var toEdit = userBLL.GetById(Guid.Parse(myId));
                            Console.WriteLine("Object to edit");
                            Console.WriteLine(toEdit.ToString());
                            var newEdit = new User(toEdit.ID, toEdit.RegistrationDate, "newtest", "newPass");
                            Console.WriteLine("Object edit to..");
                            Console.WriteLine(newEdit.ToString());
                            userBLL.Edit(newEdit);
                            Console.WriteLine("Result");
                            var edited = userBLL.GetById(Guid.Parse(myId));
                            Main(args);
                            break;
                        default:
                            Main(args);
                            break;
                    }
                    break;

                case "3":
                    Console.WriteLine("1 - Add comment");
                    Console.WriteLine("2 - find comment");
                    Console.WriteLine("3 - find all comments");
                    Console.WriteLine("4 - delete comment");
                    Console.WriteLine("5 - edit comment");

                    string choice3 = Console.ReadLine();

                    switch (choice3)
                    {
                        case "1":
                            Console.WriteLine("Text:");
                            var crText = Console.ReadLine();
                            Console.WriteLine("User Guid:");
                            var guidUser = Console.ReadLine();
                            while (!Guid.TryParse(guidUser, out var findGuid))
                            {
                                Console.WriteLine("Invalid Guid, please retry");
                                guidUser = Console.ReadLine();
                            }
                            Console.WriteLine("Place Guid:");
                            var guidPlace = Console.ReadLine();
                            while (!Guid.TryParse(guidPlace, out var findGuid))
                            {
                                Console.WriteLine("Invalid Guid, please retry");
                                guidUser = Console.ReadLine();
                            }

                            var check = commentBLL.Add(new Comment(Guid.Parse(guidUser), Guid.Parse(guidPlace), crText));

                            Console.WriteLine(check.ToString());

                            Main(args);
                            break;
                        case "2":
                            Console.WriteLine("GUID:");
                            var findId = Console.ReadLine();
                            while (!Guid.TryParse(findId, out var findGuid))
                            {
                                Console.WriteLine("Invalid Guid, please retry");
                                findId = Console.ReadLine();
                            }
                            WriteComment(commentBLL.GetById(Guid.Parse(findId)));
                            Main(args);
                            break;
                        case "3":
                            foreach (var comment in commentBLL.GetAll())
                            {
                                WriteComment(comment);
                            }
                            Main(args);
                            break;
                        case "4":
                            Console.WriteLine("GUID:");
                            var removeId = Console.ReadLine();
                            while (!Guid.TryParse(removeId, out var findGuid))
                            {
                                Console.WriteLine("Invalid Guid, please retry");
                                removeId = Console.ReadLine();
                            }
                            commentBLL.Remove(Guid.Parse(removeId));
                            Main(args);
                            break;
                        case "5":
                            Console.WriteLine("GUID:");
                            var myId = Console.ReadLine();
                            while (!Guid.TryParse(myId, out var findGuid))
                            {
                                Console.WriteLine("Invalid Guid, please retry");
                                myId = Console.ReadLine();
                            }
                            var toEdit = userBLL.GetById(Guid.Parse(myId));
                            Console.WriteLine("Object to edit");
                            Console.WriteLine(toEdit.ToString());
                            var newEdit = new User(toEdit.ID, toEdit.RegistrationDate, "newtest", "newPass");
                            Console.WriteLine("Object edit to..");
                            Console.WriteLine(newEdit.ToString());
                            userBLL.Edit(newEdit);
                            Console.WriteLine("Result");
                            var edited = userBLL.GetById(Guid.Parse(myId));
                            Main(args);
                            break;
                        default:
                            Main(args);
                            break;
                    }
                    break;

                default:
                    Main(args);
                    break;
            }

            
        }
        private static void WriteUser(User user)
        {
            Console.WriteLine($"User id: {user.ID}");
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Password: {user.Password}");
            Console.WriteLine($"Registration date: {user.RegistrationDate}");
            Console.WriteLine("-------------------------");
        }
        private static void WritePlace(Place place)
        {
            Console.WriteLine($"Place id: {place.ID}");
            Console.WriteLine($"Title: {place.Title}");
            Console.WriteLine($"Text: {place.Text}");
            Console.WriteLine($"Publication date: {place.PublicationDate}");
            Console.WriteLine($"User id: {place.User_id}");
            Console.WriteLine("-------------------------");
        }
        private static void WriteComment(Comment comment)
        {
            Console.WriteLine($"Comment id: {comment.ID}");
            Console.WriteLine($"Text: {comment.Text}");
            Console.WriteLine($"Publication date: {comment.PublicationDate}");
            Console.WriteLine($"User id: {comment.User_id}");
            Console.WriteLine($"Place id: {comment.Place_id}");
            Console.WriteLine("-------------------------");
        }
    }
}
