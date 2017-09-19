using System;
using System.Collections.Generic;
using VideoManagerBLL;
using VideoManagerBLL.BusinessObjects;
using VideoManagerDAL.Entities;

namespace VideoManager
{
    class Program
    {
        static BLLFacade bllFacade = new BLLFacade();

        static void Main(string[] args)
        {

            var vid1 = new VideoBO
            {
                VideoName = "Gremlins",
                Year = 1997,
                Genre = "Horror",
              
            };
            var vid2 = new VideoBO
            {
                VideoName = "How High",
                Year = 2007,
                Genre = "Terrible",
           
            };
            bllFacade.VideoService.Create(vid1);
            bllFacade.VideoService.Create(vid2);



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
            if (video != null)
            {
                Console.WriteLine("Name of Video?");
                video.VideoName = Console.ReadLine();
                Console.WriteLine("Genre of Video?");
                video.Genre = Console.ReadLine();
                Console.WriteLine("Year of Release?");
                video.Year = Convert.ToInt32(Console.ReadLine());
                bllFacade.VideoService.Update(video);
            }
            else
            {
                Console.WriteLine("Video not found");
            }
            

        }

        private static VideoBO FindVideoById()
        {
            Console.WriteLine("Insert Id of video to Delete:  ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Insert a Number.");
            }

            return bllFacade.VideoService.Get(id);

        }


        private static void DeleteVideo()
        {

            var videoFound = FindVideoById();
            if (videoFound != null)
            {
                bllFacade.VideoService.Delete(videoFound.Id);
            }
           
            var response = videoFound == null ?
                "Video not found" : "Video deleted: " + videoFound.VideoName;
            Console.WriteLine(response);
            
        }

        private static void AddVideos()
        {
            Console.WriteLine("Name of Video?");
            var vName = Console.ReadLine();

            Console.WriteLine("Genre of Video?");
            var vGenre = Console.ReadLine();

            Console.WriteLine("Year of Release?");
            int vYear = Convert.ToInt32(Console.ReadLine());

         

           bllFacade.VideoService.Create(new VideoBO()
            {
                VideoName = vName,
                Genre = vGenre,
                Year = vYear,
            });
        }

        private static void ListVideos()
        {
            Console.WriteLine("List of Videos;");
            foreach (var video in bllFacade.VideoService.GetAll())
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
