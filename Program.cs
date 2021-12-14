using Octokit;

namespace GhRI {
    class GhRI {
        static async System.Threading.Tasks.Task<int> Main(string[] args) {
            string Repository = args[1];
            string User = args[0];

            GitHubClient Github = new GitHubClient(new ProductHeaderValue("GhRI-Finxx1"));

            Repository  Repo = await Github.Repository.Get(User, Repository);

            if (Repo.Description.ToLower().Contains("Library")) {
                System.Console.WriteLine("This is a library you dummy!");
                return -1;
            }

            Release CurrentRelease;

            try {
                CurrentRelease = await Github.Repository.Release.GetLatest(User, Repository);
            } catch (NotFoundException) {
                System.Console.WriteLine("This repository has no releases!");
                return -1;
            }

            if (CurrentRelease.Assets.Count == 0)  {
                System.Console.WriteLine("This repository has no releases with binaries!");
                return -1;
            }

            System.Net.WebClient Downloader = new System.Net.WebClient();
            int Chosen = 0;

            if (CurrentRelease.Assets.Count > 1) {
                System.Console.WriteLine("Choose one of the following:");
                for (int i = 0; i < CurrentRelease.Assets.Count; i++) {
                    System.Console.WriteLine(i.ToString() + ": " + CurrentRelease.Assets[i].Name);
                }

                Chosen = int.Parse(System.Console.ReadLine());
            }

            System.Console.Write("\nAre you sure you want to download? y/n : ");
            if (System.Console.ReadKey().KeyChar.Equals('y')) {
                if (new System.Random().Next(5) == 1) { // I was bored okay
                    System.Console.Write("\nWhat am I, a slave or something???? y/n : ");
                    if (System.Console.ReadKey().KeyChar.Equals('n')) {
                        System.Console.WriteLine("\n:D");
                        return 0;
                    } else {
                        System.Console.WriteLine("\nD:");
                    }
                }

                Downloader.DownloadFile(CurrentRelease.Assets[Chosen].BrowserDownloadUrl, CurrentRelease.Assets[Chosen].Name);
            }

            return 0;
        }
    }
}