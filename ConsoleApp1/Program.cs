using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhereAmI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting GeoCoordinate Watcher...");

            // 2. Use the GeoCoordinate Watcher
            var watcher = new GeoCoordinateWatcher();

            watcher.StatusChanged += (s, e) =>
            {
                Console.WriteLine($"GeoCoordinateWatcher:StatusChanged:{e.Status}");
            };

            watcher.PositionChanged += (s, e) =>
            {
                watcher.Stop();

                Console.WriteLine($"GeoCoordinateWatcher:PositionChanged:{e.Position.Location}");

                // 3. Use the Map Image REST API
                MapImage.Show(e.Position.Location);
            };

            watcher.MovementThreshold = 100;

            watcher.Start();

            

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
