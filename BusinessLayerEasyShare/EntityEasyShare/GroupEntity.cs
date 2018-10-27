using System.Collections.Generic;

namespace EntityEasyShare
{
   public class GroupEntity
    {
        public int GroupId { get; set; }
        public List<UserEntity> Users { get; set; }
    }
}
