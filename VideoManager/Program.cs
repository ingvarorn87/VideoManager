using System;
using System.Collections.Generic;
using VideoManagerEntity;

namespace VideoManager
{
    class Program
    {
        #region Fake DB
        static int id = 1;
        static List<Video> videos = new List<Video>();
        #endregion

        static void Main(string[] args)
        {

            Video vid1 = new Video
            {
                VideoName = "Gremlins",
                Year = 1997,
                Genre = "Horror",
                Id = id++
            };
            Video vid2 = new Video
            {
                VideoName = "How High",
                Year = 2007,
                Genre = "Terrible",
                Id = id++
            };
            videos.Add(vid1);
            videos.Add(vid2);


            string[] menuItems =
            {
                "Show videos",
                "Add a Video",
                "Delete a Video",
                "Edit a Video",
                "Exit"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        ListVideos();
                        break;
                    case 2:
                        AddVideos();
                        break;
                    case 3:
                        DeleteVideo();
                        break;
                    case 4:
                        EditVideo();
                        break;

                    default:
                        Console.WriteLine("Exit..........");
                        break;
                }
                selection = ShowMenu(menuItems);
            }

            Console.ReadLine();
        }

        private static void EditVideo()
        {
            var video = FindVideoById();
            Console.WriteLine("Name of Video?");
            video.VideoName = Console.ReadLine();

            Console.WriteLine("Genre of Video?");
            video.Genre = Console.ReadLine();

            Console.WriteLine("Year of Release?");
            video.Year = Convert.ToInt32(Console.ReadLine());

        }

        private static Video FindVideoById()
        {
            Console.WriteLine("Insert Id of video to Delete:  ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Insert a Number.");
            }
         

            foreach (var video in videos)
            {
                if (video.Id == id)
                {
                    return video;
                }
            }
            return null;
        }


        private static void DeleteVideo()
        {

            var videoFound = FindVideoById();
            if (videoFound != null)
            {
                videos.Remove(videoFound);
            }
        }

        private static void AddVideos()
        {
            Console.WriteLine("Name of Video?");
            var vName = Console.ReadLine();

            Console.WriteLine("Genre of Video?");
            var vGenre = Console.ReadLine();

            Console.WriteLine("Year of Release?");
            int vYear = Convert.ToInt32(Console.ReadLine());

         

            videos.Add(new Video()
            {
                VideoName = vName,
                Genre = vGenre,
                Year = vYear,
                Id = id++

            });
        }

        private static void ListVideos()
        {
            Console.WriteLine("List of Videos;");
            foreach (var video in videos)
            {
                Console.WriteLine($"Name:{video.VideoName} Year:{video.Year} Genre:{video.Genre} Id:{video.Id}");
            }
        }

        private static int ShowMenu(string[] menuItems)
        {
            
            Console.WriteLine("Select what you want to do\n ");
            Console.WriteLine("");
            Console.WriteLine("--------------------------------------");
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + menuItems[i]);
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 5
                )
            {
                Console.WriteLine("Select a number between 1-5");
            }
           
            return selection;


                

        }
    }
}
