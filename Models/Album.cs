using System.Collections.Generic;

namespace Experian.Models
{
    public class Album
    {
        //Todo: Maybe it would be better to add Refit Method for photos here and hide the logic from the controller to Load data only when necessary
        public Album() {
            Photos = new List<Photo>();
        }
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<Photo> Photos { get; set; }
        
        
    }
}